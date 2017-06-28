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
    public partial class WeeklySummaryRprt : System.Web.UI.Page
    {
        ReportManager RManager = new ReportManager();

        string CertificateRateId = System.Configuration.ConfigurationManager.AppSettings["CertificateRateId"];
        string InvoiceRateId = System.Configuration.ConfigurationManager.AppSettings["InvoiceRateId"];
        string SupdocInvoiceRateId = System.Configuration.ConfigurationManager.AppSettings["SupdocInvoiceRateId"];
        string OtherRateId = System.Configuration.ConfigurationManager.AppSettings["OtherRateId"];

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GenarateReport()
        {
            DateTime F = Convert.ToDateTime(txtDate.Text);
            DateTime D = Convert.ToDateTime(txtToDate.Text);// need to changed to the same date
            ReportViewer1.Reset();
            DataTable Ds = RManager.getCORegistryReport(F, D, CertificateRateId, SupdocInvoiceRateId, InvoiceRateId, OtherRateId, "%", "%","%");
            ReportDataSource Rds = new ReportDataSource("WeekSummary", Ds);

            ReportViewer1.LocalReport.DataSources.Add(Rds);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/WeeklySummaryRprt.rdlc");

            ReportParameter[] RptParameter = new ReportParameter[] { 
                 new ReportParameter("FDate", txtDate.Text),
                 new ReportParameter("TDate", txtToDate.Text),
                 new ReportParameter("NCEMember", drpNCEMember.SelectedItem.ToString())
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