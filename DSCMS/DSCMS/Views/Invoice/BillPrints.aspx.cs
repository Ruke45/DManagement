using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Invoice;
using DCISDBManager.objLib.MasterMaintenance;
using DCISDBManager.objLib.Parameters;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.InvoiceManeger;
using DCISDBManager.trnLib.MasterMaintenance;
using DCISDBManager.trnLib.ParameterManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Invoice
{
    public partial class BillPrints : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();

            UserAutentication();
            GetInvoiceData();
            OwnerDetailManagement odm = new OwnerDetailManagement();

            OwnerDetailsobj para = new OwnerDetailsobj();
            lblHeadAddress1.Text = para.Address1_;
            lblHeadAddress2.Text = para.Address2_;
            lblHeadAddress3.Text = para.Address_3;
            lblTelephone.Text = para.Telephone_No;
            lblFax.Text = para.Fax_No;
            lblEmail.Text = para.Email_;
          //getOwnerDetail
        }

        private void GetInvoiceData()
        {
            try{
            string InvoiceNo =Request.QueryString["InvNo"];
            
            
            lblInvoiceNo.Text = InvoiceNo;


            CustomerApproveManager CM = new CustomerApproveManager();
            CustomerApproved data = CM.getInvoicePrintHeader(InvoiceNo);
            lblInvoiceDate.Text = data.CreatedDate1.ToShortDateString();
            lblCustomerName.Text = data.CustomerName1;
            lblCustomerId.Text = data.CustomerId1;
            lblAddress1.Text = data.Address11;
            lblAddress2.Text = data.Address21;
            lblAddress3.Text = data.Address31;
            lblFrom.Text = data.FromDate1;
            lblTo.Text = data.Todate1;
        
            InvoiceDetailSavingManager IM = new InvoiceDetailSavingManager();
            //gvInvoicedetails.DataSource = IM.getInvoiceBody(InvoiceNo);
           // gvInvoicedetails.DataBind();
            decimal CountRCost = 0;
            //request Grid filling
            gvRequest.DataSource = IM.getInvoiceBody(InvoiceNo);
            gvRequest.DataBind();
            foreach (var RCost in IM.getInvoiceBody(InvoiceNo))
            {
                CountRCost = CountRCost + System.Convert.ToDecimal(RCost.UnitCharge21);// RCost.UnitCharge21;
            }
            string certificateRow = null;
            foreach (var CertDetail in IM.getInvoiceCountDetails(InvoiceNo)) {
                certificateRow += "<tr><td>Certificates</td>";
                certificateRow += "<td>" + Math.Round(CertDetail.UnitCharge1,2) + "</td>";
                certificateRow += "<td>" + CertDetail.RowCount1+ "</td>";
                certificateRow += "<td><div style='float: right;'>" + Math.Round(CertDetail.RowCount1 * CertDetail.UnitCharge1, 2) + "</div></td></tr>";
            }
            CertificateDetail.InnerHtml = certificateRow;
            InvoiceDetailSaving tax = IM.getInvoiceTaxDetails(InvoiceNo);
            string TaxInvoice = tax.IsTaxInvoice1;
            decimal TotalTax = 0; 
            
            InvoiceTaxManager ITM = new InvoiceTaxManager();
          
            gvTax.DataSource = ITM.getTaxDetails(InvoiceNo);
            gvTax.DataBind();
            string taxRecode = null;
            foreach (var ItmData in ITM.getTaxDetails(InvoiceNo))
            {
              
               string taxname = ItmData.TaxName11;
               decimal presentage = ItmData.TaxPercentage1;
               decimal TaxCount = ItmData.Amount1;
               TotalTax = TotalTax + TaxCount;
               taxRecode += "<tr>";
               taxRecode += "<td style='width: 149px;' class='text-justify'>" + taxname + "(" + presentage + "%)</td>";
               taxRecode += "<td class='modal-sm' colspan='3'>";
               taxRecode += "<label Style='float: right;    font-weight: 100; ' >" + Math.Round(TaxCount, 2) + "<label>";
               taxRecode += "</td>";
               taxRecode += "</tr>";
            }
            head.InnerHtml = taxRecode;  
            CertificateManager CFM = new CertificateManager();
            gvRate.DataSource = CFM.getRateHistory(InvoiceNo);
            gvRate.DataBind();


            decimal TotalRateValue = 0;
            string RateRow = null;
            int InvoiceSupDocCount = 0;
            int otherSupDocCount = 0;
            decimal InvoiceRateValue = 0;
            decimal OthreRateValue = 0;
            foreach (var Rate in CFM.getRateHistory(InvoiceNo))
            {
                TotalRateValue = TotalRateValue + Rate.Rate1;
                string InvoiceRateId = System.Configuration.ConfigurationManager.AppSettings["InvoiceRateId"];
                if (InvoiceRateId == Rate.RateId1)
                {
                    InvoiceRateValue = Rate.Rate1;
                    InvoiceSupDocCount++;
                }

                else {
                    otherSupDocCount++;
                    OthreRateValue = Rate.Rate1;
                }
               
            }
            RateRow += "<tr><td>Supporting Documents</td>";
            RateRow += "<td>" + Math.Round(OthreRateValue, 2) + "</td>";
            RateRow += "<td>" + otherSupDocCount + "</td>";
            RateRow += "<td> <div style='float: right;'>" + Math.Round(otherSupDocCount * OthreRateValue, 2) + "</div></td></tr>";
            RateRow += "<tr><td>Invoices</td>";
            RateRow += "<td>" + Math.Round(InvoiceRateValue, 2) + "</td>";
            RateRow += "<td>" + InvoiceSupDocCount + "</td>";
            RateRow += "<td ><div style='float: right;'>" + Math.Round(InvoiceSupDocCount * InvoiceRateValue, 2) + "</div></td></tr>";
            RateDetails.InnerHtml = RateRow;

            lblRequestCost.Text = Math.Round(CountRCost,2).ToString();
           // lblTax.Text = Math.Round(TotalTax, 2).ToString();
            lblTotalTax.Text = Math.Round(TotalTax, 2).ToString();
           // lblSuportionDocRate.Text = Math.Round(TotalRateValue,2).ToString();
            lblTotalRate.Text = Math.Round(TotalRateValue, 2).ToString();
            lblGrossTotal.Text = tax.GrossTotal1.ToString();
            lblTotalGross.Text = tax.GrossTotal1.ToString();
            lblTotal.Text = Math.Round(tax.InvoiceTotal1, 2).ToString();
            lblTotalNet.Text = Math.Round(tax.InvoiceTotal1, 2).ToString();
            if (TaxInvoice == "Y")
            {
                lblInvoiceName.Text = "Tax Invoice";

            }
            else
            {
                lblInvoiceName.Text = "Invoice";
            }
            string StartDate = Request.QueryString["start"];
            string EndDate = Request.QueryString["End"];
            DateTime startdate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", null);
            DateTime enddate = DateTime.ParseExact(EndDate, "dd/MM/yyyy", null);
            string Start = startdate.ToString("yyyyMMdd");
            string End = enddate.ToString("yyyyMMdd");
            gvState.DataSource = IM.getStatementCountDiuringTimePeriod(Start, End, lblCustomerId.Text);
            gvState.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
        }
        private void UserAutentication()
        {
            try{
            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = userSession.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "InvPr");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
        }

        protected void Back(object sender, EventArgs e)
        {
            string MonthlyInvoice = Request.QueryString["Invoice"];
            if (MonthlyInvoice != "1")
            {
                string Start = Request.QueryString["start"];
                string End = Request.QueryString["End"];
                Response.Redirect("MonthlyInvoiceReport.aspx?Start=" + Start + "&End=" + End, false);
            }
            else {
                string Start = Request.QueryString["start"];
                string End = Request.QueryString["End"];
                Response.Redirect("MonthlyAllInvoice.aspx?Start=" + Start + "&End=" + End, false);
            }
        }

        protected void Printbtn(object sender, EventArgs e)
        {
            string InvoiceNo = lblInvoiceNo.Text;
            string Reson=null;
            string PrintBy = userSession.User_Id;
            InvoiceDetailSavingManager IM = new InvoiceDetailSavingManager();
            InvoiceDetailSaving printdata = IM.getInvoicePrintTime(InvoiceNo);
            if (printdata.InvoicePrintTime1 == 0)
            {
                lblPrintTime.Text = "Original Copy Of Invoice";
                
            }
            else
            {
                lblPrintTime.Text = "Invoice Copy No:-" + printdata.InvoicePrintTime1.ToString();
                Reson = txtPrintReason.Text;
                printdata.InvoiceNo1=InvoiceNo;
                printdata.InvoicePrintTime1=printdata.InvoicePrintTime1;
                printdata.Rason1=Reson;
                printdata.CreatedBy1 = PrintBy;
                IM.setInvoicePrintCount(printdata);
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "text", "PrintPage()", true);

            
        }


    }
}