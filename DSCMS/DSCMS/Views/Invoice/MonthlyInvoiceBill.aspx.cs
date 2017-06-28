using DCISDBManager.objLib.Certificate;
using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Invoice;
using DCISDBManager.objLib.TaxDetails;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.InvoiceManeger;
using DCISDBManager.trnLib.RateManagement;
using DCISDBManager.trnLib.TaxManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS
{

    public partial class MonthlyInvoiceBill : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            UserAutentication();
            GetInvoiceDeta();
        }

        private void UserAutentication()
        {
            try{
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
        private void GetInvoiceDeta()
        {

            try{
            string UserID = userSession.User_Id;

            //string RequestId = Request.QueryString["req"];
            string StartDate = Request.QueryString["StartDate"];
            string EndDate = Request.QueryString["EndDate"];
            DateTime startdate=DateTime.ParseExact(StartDate, "dd/MM/yyyy", null);
            DateTime enddate=DateTime.ParseExact(EndDate, "dd/MM/yyyy", null);
            //DateTime startdate=Convert.ToDateTime(StartDate);
           // DateTime enddate = Convert.ToDateTime(EndDate);
            string CustomerId = Request.QueryString["cus"];
            string Start = startdate.ToString("yyyyMMdd");
            string End = enddate.ToString("yyyyMMdd");
            string Status = "A";
            
            decimal Cost = 0;
            string RequestID=null;
            bool check1 = false;
            string TaxCode=null;
            string CertificateRateId = System.Configuration.ConfigurationManager.AppSettings["CertificateRateId"];
            
            InvoiceManager rm = new InvoiceManager();
            gvInvoicedetails.DataSource = rm.getInvoiceDetail(Status, Start, End, CustomerId,CertificateRateId);
            gvInvoicedetails.DataBind();

            InvoiceDetailSavingManager setmanager = new InvoiceDetailSavingManager();
            InvoiceDetailSaving invoice = new InvoiceDetailSaving();
            foreach (var requst in rm.getInvoiceDetail(Status, Start, End, CustomerId, CertificateRateId))
            {
                RequestID=requst.RequestId1;
 //               Cost = Cost + requst.UnitCharge1;
                CustomerId = requst.CustomerId1;

                
            }

            /*------------get tax details and calculation------------*/
            CustometTaxDetailManager tax = new CustometTaxDetailManager();

            decimal TaxCount = 0;
            decimal TotalTax = 0;

            
           
            CertificateManager CM=new CertificateManager();
            decimal InvoiceRateValue = 0;
            decimal CoRateValue = 0;
            decimal OtherRateValue = 0;
           
            decimal TaxCAl1 = 0;
           
            decimal Gross = 0;
            string InvoiceRateId = System.Configuration.ConfigurationManager.AppSettings["InvoiceRateId"]; 
             
            string OtherRateId = System.Configuration.ConfigurationManager.AppSettings["OtherRateId"];
            string RateIdSupdoc = System.Configuration.ConfigurationManager.AppSettings["RateIdSupdoc"];
            //foreach (var supporting in CM.getSuuportingDocumentApproval(CustomerId, SupportingDocStatus, Start, End, InvoiceRateId, RateIdSupdoc))
            //{
            //    RateId = supporting.RateId1;
            //    SuportingId = supporting.SuportingDocId1;
               
            //        Rate = supporting.Rate1;
            //        InvoiceRateValue = InvoiceRateValue + Rate;
                
            //}


            

            TaxCAl1 = Cost + InvoiceRateValue;
            Gross = TaxCAl1;
            string divID = null;
            foreach (var money in tax.getTaxDetail(CustomerId,"Y"))
            {
                 TaxCode = money.TaxCode1;
                decimal presentage = money.TaxPersentage1;
                string taxname = money.TaxName1;
                TaxCount = presentage * TaxCAl1 / 100;
                TaxCAl1 = TaxCAl1 + TaxCount;
                TotalTax = TotalTax + TaxCount;
                string TaxCount1 = Math.Round(TaxCount, 2).ToString();
                divID += "<tr><td style='width: 149px; font-weight: bold;' class='text-justify'>" + taxname + "(" + presentage + "%)</td>";
                divID += "<td class='modal-sm' colspan='3'><Label style='float:right;'  >" + TaxCount1 + "<Label></td></tr>";
                

               
               

            }
            head.InnerHtml = divID;
            decimal Total = TotalTax + Cost +InvoiceRateValue+CoRateValue+OtherRateValue;
            
              
           
            /*-------------------get header information for invoice header----------------*/
            CustomerDetailManager HeaderDetails = new CustomerDetailManager();
            CustomerDetails deta = HeaderDetails.getRequestDetails(CustomerId);

            /*------------------Insert value to header table------------------------*/
           

                invoice.CustomerId1 = CustomerId;
                invoice.FromDate1 = DateTime.ParseExact(StartDate, "dd/MM/yyyy", null); //Convert.ToDateTime(StartDate);
                invoice.ToDate1 = DateTime.ParseExact(EndDate, "dd/MM/yyyy", null); //Convert.ToDateTime(EndDate);
                invoice.GrossTotal1 = Gross;
                invoice.InvoiceTotal1 = Total;
                if (TotalTax != 0)
                {
                    invoice.IsTaxInvoice1 = "Y";
                }
                else {
                    invoice.IsTaxInvoice1 = "N";
                }
                invoice.CreatedBy1 = UserID;
                invoice.InvoicePrintTime1 = 0;
               string invoiceNo=setmanager.setInvoiceHeader(invoice);


               foreach (var requst in rm.getInvoiceDetail(Status, Start, End, CustomerId, CertificateRateId))
                {
                    /*---------------insert value to detail table------------------*/
                    invoice.RequestNo1 = requst.RequestId1;
//                    invoice.UnitCharge1 = requst.UnitCharge1;
                    invoice.InvoiceNo1 = invoiceNo;
                    invoice.CreatedBy1 = UserID;
                    check1 = setmanager.setInvoiceDetails(invoice);
                 
                }
                InvoiceTaxManager taxmanager = new InvoiceTaxManager();
                InvoiceTax taxdeta = new InvoiceTax();
                decimal TaxCAl = Gross;
                foreach (var money in tax.getTaxDetail(CustomerId,"Y"))
                {
                    /*---------------------insert value to invoice tax------------------*/
                    TaxCode = money.TaxCode1;
                    decimal presentage = money.TaxPersentage1;
                    TaxCount = presentage * TaxCAl / 100;
                    TaxCAl = TaxCAl + TaxCount;
                    
                    taxdeta.InvoiceNo1 = invoiceNo;
                    taxdeta.TaxCode1=money.TaxCode1;
                    taxdeta.Amount1 = TaxCount;
                    taxdeta.CreatedBy1 = UserID;
                    taxdeta.TaxPercentage1 = presentage;
                    taxmanager.setInvoiceTaxDetails(taxdeta);
                }


            //    foreach (var supporting in CM.getSuuportingDocumentApproval(CustomerId, SupportingDocStatus, Start, End, InvoiceRateId, RateIdSupdoc))
            //{
            //    RateId = supporting.RateId1;
            //    SuportingId = supporting.SuportingDocId1;
            //    if (SuportingId == InvoiceRateId)//check Invoice Rate
            //    {
            //        Rate = supporting.Rate1;
            //        InvoiceRateValue = InvoiceRateValue + Rate;
            //    }
            //    //if (SuportingId == CoRateId)//check Co Rate
            //    //{
            //    //    Rate = supporting.Rate1;
            //    //    CoRateValue = CoRateValue + Rate;
            //    //}
            //    else //(SuportingId == OtherRateId)//check Other Rate
            //    {
            //        Rate = supporting.Rate1;
            //        OtherRateValue = OtherRateValue + Rate;
            //    }
            //    CertificateRequestHeader CRH = new CertificateRequestHeader();
            //    CRH.CustomerId1 = CustomerId;
            //    CRH.InvoiceNo1=invoiceNo;
            //    CRH.SuportingDocName1 = supporting.SuportingDocName1;
            //    CRH.RateId1 = RateId;
            //    CRH.Rate1 = Rate;
            //    CRH.CreatedBy1 = userSession.User_Id;
            //    CM.setInvoiceRate(CRH);
            //}

               
                    /*---------------Asign Value to Lable--------------*/
                 lblInvoiceCharges.Text = Math.Round(InvoiceRateValue, 2).ToString();
                 lblCoCharges.Text = Math.Round(CoRateValue, 2).ToString();
                 lblOtherCharges.Text = Math.Round(OtherRateValue, 2).ToString();
                
                 lblGrossTotal.Text = Math.Round(Gross, 2).ToString();
                 lblTotal.Text = Math.Round(Total, 2).ToString();
                 //string StartDate = Request.QueryString["StartDate"];
                // string EndDate = Request.QueryString["EndDate"];
                 Response.Redirect("BillPrints.aspx?InvNo=" + invoiceNo + "&Invoice=1&Start=" + StartDate + "&End=" + EndDate, false);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
              
            }
               
        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("MonthlyAllInvoice.aspx", false);
        }
       

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            { Response.Write(ex.Message); }  
        }

        




        
    }
    
}