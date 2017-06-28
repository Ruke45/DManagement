using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.ReportManagement;
using DCISDBManager.trnLib.Utility;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Report
{
    public partial class CustomerStatementReport : System.Web.UI.Page
    {

        ReportManager RManager = new ReportManager();
        UserSession userSession;
        CheckAuthManager authorized = new CheckAuthManager();

        string CertificateRateId = System.Configuration.ConfigurationManager.AppSettings["CertificateRateId"];
        string InvoiceRateId = System.Configuration.ConfigurationManager.AppSettings["InvoiceRateId"];
        string SupdocInvoiceRateId = System.Configuration.ConfigurationManager.AppSettings["SupdocInvoiceRateId"];
        string OtherRateId = System.Configuration.ConfigurationManager.AppSettings["OtherRateId"];

        string UserGroupID_Customer = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
        string UserGroupID_CustomerAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
        string CustomerID = string.Empty;
        string IsMember = string.Empty;
        string IsCash = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            if (userSession == null)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            if (!authorized.IsUserGroupAuthorised(userSession.User_Group, "CSTEMENT_R"))
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            if (userSession.User_Group.Equals(UserGroupID_Customer) || userSession.User_Group.Equals(UserGroupID_CustomerAdmin))
            {
                drpCustomer.Visible = false;
                drpNCEMember.Visible = false;
                lblCustomer.Visible = false;
                lblMember.Visible = false;
                drpPaytype.Visible = false;
                lblPaytype.Visible = false;


                
                CustomerID = userSession.Customer_ID;
                Member();
                CashCerdit();

            }
            if (!IsPostBack)
            {
                this.getCustomers();
            }
        }

        private void Member()
        {
            try
            {
                CustomerDetailManager Cmanager = new CustomerDetailManager();
                IsMember = Cmanager.getMemberDetails(userSession.Customer_ID);
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }
        private void CashCerdit()
        {
            try
            {
                CustomerDetailManager Cmanager = new CustomerDetailManager();
                IsCash = Cmanager.getIsCashOrCerdit(userSession.Customer_ID);
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        private void getCustomers()
        {
            try
            {
                CustomerDetailManager cm = new CustomerDetailManager();

                drpCustomer.DataSource = cm.getAllCustomer("Y");

                drpCustomer.DataValueField = "CustomerId1";
                drpCustomer.DataTextField = "CustomerName1";
                drpCustomer.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
        }

        private void GenarateReport()
        {
            DateTime F = Convert.ToDateTime(txtDate.Text);
            DateTime D = Convert.ToDateTime(txtToDate.Text);
            ReportViewer1.Reset();
            DataTable Ds = RManager.getCORegistryReport(F, D, CertificateRateId, SupdocInvoiceRateId, InvoiceRateId, OtherRateId, CustomerID, IsMember,IsCash);
            ReportDataSource Rds = new ReportDataSource("CustomerState", Ds);

            ReportViewer1.LocalReport.DataSources.Add(Rds);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CustomerStatmentRprt.rdlc");

            ReportParameter[] RptParameter = new ReportParameter[] { 
                 new ReportParameter("FDate", txtDate.Text),
                 new ReportParameter("TDate", txtToDate.Text)
                 //new ReportParameter("Customer", drpCustomer.SelectedItem.ToString()),
                 //new ReportParameter("NCEMember", drpNCEMember.SelectedItem.ToString())
                };

            ReportViewer1.LocalReport.SetParameters(RptParameter);

            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            if (userSession.User_Group.Equals(UserGroupID_Customer) || userSession.User_Group.Equals(UserGroupID_CustomerAdmin))
            {
                GenarateReport();
            }
            else
            {
                CustomerID = drpCustomer.SelectedValue;
                IsMember = drpNCEMember.SelectedValue;
                IsCash = drpPaytype.SelectedValue;
                GenarateReport();
            }
            
        }
    }
}