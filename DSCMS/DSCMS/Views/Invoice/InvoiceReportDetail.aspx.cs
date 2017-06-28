using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Invoice;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.InvoiceManeger;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DSCMS.Views.Invoice
{
    public partial class InvoiceReportDetail : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();

            UserAutentication();
            GetGridDeta();
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
            bool auth = Am.IsUserGroupAuthorised(groupId, "InvRe");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("~/Views/Home/Login.aspx");
            }
        }
        private void GetGridDeta()
        {
            try{
            string CustomerId = Request.QueryString["CustomerId"];
            string InvoiceNo = Request.QueryString["InvNo"];
            string GTotal = Request.QueryString["gtotal"];
            string NTotal = Request.QueryString["ntotal"];

           
            /*-----------------get hrader Information----------------------*/
            CustomerDetailManager HeaderDetails = new CustomerDetailManager();
            CustomerDetails deta = HeaderDetails.getRequestDetails(CustomerId);


            lblCustomerName.Text = deta.CustomerName1;
            lblCustomerId.Text = CustomerId;
            lblInvoiceNo.Text = InvoiceNo;
            

            /*-----------------get grid deta------------------------*/
            InvoiceDetailSavingManager rm = new InvoiceDetailSavingManager();
            gvInvoicedetails.DataSource = rm.getInvoiceDetails(InvoiceNo);
            gvInvoicedetails.DataBind();



            lblGrossTotal.Text =GTotal;
            lblTotal.Text = NTotal;
            /*----------------get footer Information---------------*/
            InvoiceTaxManager tax = new InvoiceTaxManager();
            string check = null;
            string divID = null;
            foreach (var money in tax.getTaxDetails(InvoiceNo))
            {
                
                divID += "<tr><td style='width: 149px; font-weight: bold;' class='text-justify'>" + money.TaxName11+"(" +money.TaxPercentage1+ "%)</td>";
                divID += "<td class='modal-sm' colspan='3'><div style='float:right'><Label ID=  >" + money.Amount1 + "<Label></div></td></tr>";

                check = money.TaxCode1;
                head.InnerHtml = divID;


            }
            
            if (check == "")
            {
                lblInvoiceName.Text = "Invoice";
            }
            if (check == null)
            {
                lblInvoiceName.Text = "Invoice";
            }
            else {
                lblInvoiceName.Text = "Tax Invoice";
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
               
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonthlyInvoiceReport.aspx", false);
        
        }
    
    
    }
}