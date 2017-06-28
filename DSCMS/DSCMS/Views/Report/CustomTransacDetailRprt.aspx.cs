using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.ReportManagement;
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
    public partial class CustomTransacDetailRprt : System.Web.UI.Page
    {
        ReportManager RManager = new ReportManager();
        UserSession userSession;
        CheckAuthManager authorized = new CheckAuthManager();

        string CertificateRateId = System.Configuration.ConfigurationManager.AppSettings["CertificateRateId"];
        string InvoiceRateId = System.Configuration.ConfigurationManager.AppSettings["InvoiceRateId"];
        string SupdocInvoiceRateId = System.Configuration.ConfigurationManager.AppSettings["SupdocInvoiceRateId"];
        string OtherRateId = System.Configuration.ConfigurationManager.AppSettings["OtherRateId"];

        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            if (userSession == null)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            if (!authorized.IsUserGroupAuthorised(userSession.User_Group, "CTRANC_R"))
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
        }

        private void GenarateReport()
        {
            DateTime F = Convert.ToDateTime(txtDate.Text);
            DateTime D = Convert.ToDateTime(txtTodate.Text);// need to changed to the same date
            ReportViewer1.Reset();
            DataTable Ds = RManager.getCORegistryReport(F, D, CertificateRateId, SupdocInvoiceRateId, InvoiceRateId, OtherRateId, "%", "%","%");
            ReportDataSource Rds = new ReportDataSource("CustomTrans", Ds);

            ReportViewer1.LocalReport.DataSources.Add(Rds);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CustomTransactionRprt.rdlc");

            ReportParameter[] RptParameter = new ReportParameter[] { 
                 new ReportParameter("FDate", txtDate.Text),
                 new ReportParameter("TDate", txtTodate.Text)
                };

            ReportViewer1.LocalReport.SetParameters(RptParameter);

            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            GenarateReport();
        }
    }
}