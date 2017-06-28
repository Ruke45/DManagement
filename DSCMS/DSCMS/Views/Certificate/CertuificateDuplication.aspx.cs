using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Certificate
{
    public partial class CertuificateDuplication : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            userSession = new UserSession();
            UserAutentication();
            CustomerDetailManager cm = new CustomerDetailManager();
            dataload(cm);
        }

        private void dataload(CustomerDetailManager cm)
        {
           
            if (!IsPostBack)
                txtFromDate.Text = (DateTime.Today.Month + "/" + 1 + "/" + DateTime.Today.Year).ToString();
            txtTodate.Text = DateTime.Today.ToShortDateString();
            {
                try
                {
                    drpCustomer.DataSource = cm.getAllCustomer("Y");
                    drpCustomer.DataValueField = "CustomerId1";
                    drpCustomer.DataTextField = "CustomerName1";
                    drpCustomer.DataBind();
                    DataBindingForGrid();
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError(ex);
                }

            }
            string StartDate = Request.QueryString["StartDate"];
            if (!IsPostBack)
            {
                if (StartDate != null)
                {
                    txtFromDate.Text = Request.QueryString["StartDate"];
                    txtTodate.Text = Request.QueryString["EndDate"];
                    drpCustomer.SelectedValue = Request.QueryString["CustomerId"];
                    DataBindingForGrid();
                }
            }
        }


        private void UserAutentication()
        {
            try
            {
                if (userSession.User_Id == "")
                {
                    Response.Redirect("~/Views/Home/Login.aspx");
                }
                string groupId = userSession.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "DoCanc");
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

        private void DataBindingForGrid()
        {
            try
            {
                int Check = 0;
                string firstDayOfMonth =(DateTime.Today.Month+"/"+ 1+"/"+ DateTime.Today.Year).ToString();
                DateTime firstDayOfMonth1 = Convert.ToDateTime(firstDayOfMonth);
                string CustomerId = drpCustomer.SelectedValue;
                string start = txtFromDate.Text;
                DateTime st = Convert.ToDateTime(start);
                int result1 = DateTime.Compare(firstDayOfMonth1, st);
                string refNo = txtRefNo.Text;
                if (refNo=="")
                {
                    refNo = "All";
               }
                if (result1 > 0) {
                    Check +=1 ;
                    lblDateError.Text = "Out Of Range";
                    lblDateError.Visible = true;
                }
                
                string end = txtTodate.Text;
                DateTime enddate = Convert.ToDateTime(end);
                int result2 = DateTime.Compare(DateTime.Today, enddate);
                if (result2 < 0) {
                    Check += 1;
                    lblDateError1.Text = "Out Of Range";
                    lblDateError1.Visible = true;
                }
                if (Check==0)
                {
                string StartDate1 = Request.QueryString["StartDate"];
                if (!IsPostBack)
                {

                    if (StartDate1 != null)
                    {
                        start = Request.QueryString["StartDate"];
                        end = Request.QueryString["EndDate"];
                        CustomerId = Request.QueryString["CustomerId"];
                        txtFromDate.Text = start;
                        txtTodate.Text = end;
                        drpCustomer.SelectedValue = CustomerId;

                    }
                    
                }
                string Maxdate = System.Configuration.ConfigurationManager.AppSettings["MaxDateForCertificateCancel"];
                int maxdate = Convert.ToInt16(Maxdate);

                DateTime start1 = Convert.ToDateTime(start);
                DateTime End = Convert.ToDateTime(end);
                var result = (DateTime.Today - start1).TotalDays;
              
                    lblDateError.Visible = false;
                    lblDateError1.Visible = false;
                    string StartDate = start1.ToString("yyyyMMdd");
                    string EndDate = End.ToString("yyyyMMdd");
                    string InvoiceSupDocId = System.Configuration.ConfigurationManager.AppSettings["SupdocInvoiceRateId"];
                    CertificateManager CM = new CertificateManager();
                    gvCertificate.DataSource = CM.getAllCertificateCanceldetails(CustomerId, "A", StartDate, EndDate, InvoiceSupDocId,refNo);
                    gvCertificate.DataBind();
               
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataBindingForGrid();
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvCertificate.PageIndex = e.NewPageIndex;
            DataBindingForGrid();

        }

       
        protected void btnDetails_Click(object sender, EventArgs e) {
            string CertificateNo = null;
            string DocType= null;
            string StartDate= null;
            string EndDate= null;
            string CustomerId = null;
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                CertificateNo = row.Cells[0].Text;
                DocType = row.Cells[3].Text;
                 StartDate = txtFromDate.Text;
                 EndDate = txtTodate.Text;
                 CustomerId = drpCustomer.SelectedValue;
            }
            Response.Redirect("IssueCertificasteDetails.aspx?StartDate=" + StartDate + "&EndDate=" + EndDate + "&CertificateNo=" + CertificateNo + "&CustomerId=" + CustomerId + "&DocType=" + DocType, false);
      
        }

        protected Boolean InvoicedCertificateBtn(string Status)
        {
            if (Status == "NOT") {
                return true;
            }
            else {
                return false;
            }
           
        }

        protected Boolean InvoicedCertificateLbl(string Status)
        {
            if (Status == "In")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}