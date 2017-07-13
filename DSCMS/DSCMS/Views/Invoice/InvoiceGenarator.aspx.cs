using DCISDBManager.objLib.Certificate;
using DCISDBManager.objLib.Invoice;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.InvoiceManeger;
using DCISDBManager.trnLib.TaxManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Invoice
{
    public partial class InvoiceGenarator : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            UserAutentication();
            string StartDate;
            string EndDate;
            string CustomerId;
            string Start;
            string End;
            string Status;
            
            string SupportingDocStatus;
            string CertificateRateId;
            string SupDocCertificateRateId;
            InvoiceManager rm;
            string InvoiceRateId;
            string OtherRateId;
            string SupDocOtherRateId;
            string SupsDocInvoiceRateId;
            string AttachSheetId = "SDID5";
            CertificateManager CM;
            decimal Rate;
            decimal GrossTotal;
            CustometTaxDetailManager tax;
            InvoiceDetailSavingManager InvoicesaveManager;
            InvoiceDetailSaving invoice;
            string invoiceNo;
            try
            {
                SetValueToHeadeTable(out StartDate, out EndDate, out CustomerId, out Start, out End, out Status, out SupportingDocStatus, out CertificateRateId, out SupDocCertificateRateId, out rm, out InvoiceRateId, out OtherRateId, out SupDocOtherRateId, out SupsDocInvoiceRateId, out CM, out Rate, out GrossTotal, out tax, out InvoicesaveManager, out invoice, out invoiceNo);

                SetValueToInvoiceTable(CustomerId, Start, End, Status, CertificateRateId, rm, InvoicesaveManager, invoice, invoiceNo);


                Rate = SetValuetoInvoiceTateTable(CustomerId, Start, End, SupportingDocStatus, SupDocCertificateRateId, InvoiceRateId, OtherRateId, SupDocOtherRateId, SupsDocInvoiceRateId, CM, Rate, invoiceNo, AttachSheetId);
                GrossTotal = SetValuetoInvoiceTaxtable(CustomerId, GrossTotal, tax, invoiceNo);
                Response.Redirect("BillPrints.aspx?InvNo=" + invoiceNo + "&Invoice=1&Start=" + StartDate + "&End=" + EndDate, false);
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
                Response.Redirect("MonthlyAllInvoice.aspx");
            }
            
        }

        private void UserAutentication()
        {
            try
            {
                string Access = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
                if (userSession.User_Id == "")
                {
                    Response.Redirect("~/Views/Home/Login.aspx");
                }
                string groupId = userSession.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "InvBl");
                if (auth == false)
                {
                    Response.Redirect("~/Views/Home/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("~/Views/Home/Login.aspx");
            }
        }

        private decimal SetValuetoInvoiceTaxtable(string CustomerId, decimal GrossTotal, CustometTaxDetailManager tax, string invoiceNo)
        {
            /*start set value for Tax table*/

            decimal TaxCounts = 0;

            foreach (var money in tax.getTaxDetail(CustomerId, "Y"))
            {
                /*---------------------insert value to invoice tax------------------*/

                decimal presentage = money.TaxPersentage1;

                TaxCounts = presentage * GrossTotal / 100;
                GrossTotal = GrossTotal + TaxCounts;
                InvoiceTaxManager taxmanager = new InvoiceTaxManager();
                InvoiceTax taxdeta = new InvoiceTax();
                taxdeta.InvoiceNo1 = invoiceNo;
                taxdeta.TaxCode1 = money.TaxCode1;
                taxdeta.Amount1 = TaxCounts;
                taxdeta.CreatedBy1 = userSession.User_Id;
                taxdeta.TaxPercentage1 = presentage;
                taxmanager.setInvoiceTaxDetails(taxdeta);
            }
            /*start set value for Tax table*/
            return GrossTotal;
        }

        private decimal SetValuetoInvoiceTateTable(string CustomerId, string Start, string End, string SupportingDocStatus, string SupDocCertificateRateId, string InvoiceRateId, string OtherRateId, string SupDocOtherRateId, string SupsDocInvoiceRateId, CertificateManager CM, decimal Rate, string invoiceNo, string AttachSheetId )
        {
            /*start to set Invoice rate Table*/
            foreach (var supporting in CM.getSuuportingDocumentApproval(CustomerId, SupportingDocStatus, Start, End, InvoiceRateId, OtherRateId, SupsDocInvoiceRateId, SupDocOtherRateId, AttachSheetId))
            {
                string RateId = supporting.RateId1;
                string SuportingId = supporting.SuportingDocId1;
               
              //  if (SuportingId == SupsDocInvoiceRateId)//check Invoice Rate
              //  {
              //      Rate = supporting.Rate1;
                    //InvoiceRateValue = InvoiceRateValue + Rate;
              //  }
                //if (SuportingId == SupDocCertificateRateId)//check Co Rate
                //{
                //    Rate = supporting.Rate1;
                //    // CertificateRateValue = CertificateRateValue + Rate;
                //}
              //  else //(SuportingId == OtherRateId)//check Other Rate
               // {
               //     Rate = supporting.Rate1;
                    // OtherRateValue = OtherRateValue + Rate;
               // }
                CertificateRequestHeader CRH = new CertificateRequestHeader();
                CRH.CustomerId1 = CustomerId;
                CRH.InvoiceNo1 = invoiceNo;
                CRH.SuportingDocName1 = supporting.RequestId1;
                CRH.RateId1 = RateId;
                CRH.Rate1 = supporting.Rate1;
                CRH.CreatedBy1 = userSession.User_Id;
                CM.setInvoiceRate(CRH);
                /*end to set Invoice rate Table*/



            }
            return Rate;
        }

        private void SetValueToInvoiceTable(string CustomerId, string Start, string End, string Status, string CertificateRateId, InvoiceManager rm, InvoiceDetailSavingManager InvoicesaveManager, InvoiceDetailSaving invoice, string invoiceNo)
        {
            /*start set Value for Invoice detail Table*/
            foreach (var requst in rm.getInvoiceDetail(Status, Start, End, CustomerId, CertificateRateId))
            {
                /*---------------insert value to detail table------------------*/
                invoice.RequestNo1 = requst.RequestId1;
                invoice.InvoiceNo1 = invoiceNo;
                invoice.UnitCharge1 = requst.Rate1;
                invoice.CreatedBy1 = userSession.User_Id;
                InvoicesaveManager.setInvoiceDetails(invoice);

            }
            /*end set Value for Invoice detail Table*/
        }

        private void SetValueToHeadeTable(out string StartDate, out string EndDate, out string CustomerId, out string Start, out string End, out string Status, out string SupportingDocStatus, out string CertificateRateId, out string SupDocCertificateRateId, out InvoiceManager rm, out string InvoiceRateId, out string OtherRateId, out string SupDocOtherRateId, out string SupsDocInvoiceRateId, out CertificateManager CM, out decimal Rate, out decimal GrossTotal, out CustometTaxDetailManager tax, out InvoiceDetailSavingManager InvoicesaveManager, out InvoiceDetailSaving invoice, out string invoiceNo)
        {
            /*Start get data for Calculate And Insert to invoice Header for get Invoice No*/

            StartDate = Request.QueryString["StartDate"];//Start Date from URL
            EndDate = Request.QueryString["EndDate"];//End Date from URL
            CustomerId = Request.QueryString["cus"];//CusId form URL

            /*start make date for corrct format*/
            DateTime startdate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", null);
            DateTime enddate = DateTime.ParseExact(EndDate, "dd/MM/yyyy", null);
            Start = startdate.ToString("yyyyMMdd");
            End = enddate.ToString("yyyyMMdd");
            /*end make date for corrct format*/

            Status = "A";//Certificate Status
            SupportingDocStatus = "A";
            CertificateRateId = System.Configuration.ConfigurationManager.AppSettings["CertificateRateId"];//get Certificate Rate Id from Web Config
            SupDocCertificateRateId = System.Configuration.ConfigurationManager.AppSettings["SupDocCertificateRateId"];//get Certificate Rate Id from Web Config

            decimal Cost = 0;

            /*start get Certificate Data*/
            rm = new InvoiceManager();
            foreach (var requst in rm.getInvoiceDetail(Status, Start, End, CustomerId, CertificateRateId))
            {
                Cost = Cost + requst.Rate1;
                CustomerId = requst.CustomerId1;
            }
            /*End get Certificate Data*/

            /*start get Suporting Document Data*/
            InvoiceRateId = System.Configuration.ConfigurationManager.AppSettings["InvoiceRateId"];//get Invoice Rate Id
            OtherRateId = System.Configuration.ConfigurationManager.AppSettings["OtherRateId"];//get Other Rate Id
            SupDocOtherRateId = System.Configuration.ConfigurationManager.AppSettings["SupdocOtherRateId"];//get Supprting Document Id for Other Rate
            SupsDocInvoiceRateId = System.Configuration.ConfigurationManager.AppSettings["SupdocInvoiceRateId"];//get Supporting Document id For Invoice Rate
            string AttachSheetId = "SDID5";
            CM = new CertificateManager();
            Rate = 0;
            decimal RateValue = 0;
            foreach (var supporting in CM.getSuuportingDocumentApproval(CustomerId, SupportingDocStatus, Start, End, InvoiceRateId, OtherRateId, SupsDocInvoiceRateId, SupDocOtherRateId, AttachSheetId))
            {
                Rate = supporting.Rate1;
                RateValue = RateValue + Rate;
            }

            /*end get Suporting Document Data*/

            GrossTotal = RateValue + Cost;//get gross total=Total Certificate value+total Supproting Document Value
            decimal GrossTotalCal = GrossTotal;//asign grocess value in to grosstotal cal for take total
            /*Start Get Tax details And calculation*/

            /*end Get Tax details And calculation*/
            tax = new CustometTaxDetailManager();
            decimal TaxCount = 0;
            int checkTaxInvoice = 0;
            foreach (var money in tax.getTaxDetail(CustomerId, "Y"))
            {

                decimal presentage = money.TaxPersentage1;
                TaxCount = presentage * GrossTotalCal / 100;
                GrossTotalCal = GrossTotalCal + TaxCount;
                checkTaxInvoice = 1;

            }

            /* start insert Data to header Table*/
            InvoicesaveManager = new InvoiceDetailSavingManager();
            invoice = new InvoiceDetailSaving();
            invoice.CustomerId1 = CustomerId;
            invoice.FromDate1 = DateTime.ParseExact(StartDate, "dd/MM/yyyy", null); //Convert.ToDateTime(StartDate);
            invoice.ToDate1 = DateTime.ParseExact(EndDate, "dd/MM/yyyy", null); //Convert.ToDateTime(EndDate);
            invoice.GrossTotal1 = GrossTotal;
            invoice.InvoiceTotal1 = GrossTotalCal;
            if (checkTaxInvoice != 0)
            {
                invoice.IsTaxInvoice1 = "Y";
            }
            else
            {
                invoice.IsTaxInvoice1 = "N";
            }
            invoice.CreatedBy1 = userSession.User_Id;
            invoice.InvoicePrintTime1 = 0;
            invoiceNo = InvoicesaveManager.setInvoiceHeader(invoice);
            /* end insert Data to header Table*/

            /*End get data for Calculate And Insert to invoice Header for get Invoice No*/
        }
    }
}