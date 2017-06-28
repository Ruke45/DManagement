using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Certificate
{
    public partial class CancelledCertificate : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            UserAutentication();
            dropdown();
            if (!IsPostBack)
            {
                DataBindingForGrid();
                txtTodate.Text = DateTime.Today.ToShortDateString();
                txtFromDate.Text = DateTime.Today.ToShortDateString();
            }
           
        }

        private void dropdown()
        {
            try
            {
                CustomerDetailManager cm = new CustomerDetailManager();
                if (!IsPostBack)
                {
                   
                    drpCustomer.DataSource = cm.getAllCustomer("Y");
                    drpCustomer.DataValueField = "CustomerId1";
                    drpCustomer.DataTextField = "CustomerName1";
                    drpCustomer.DataBind();
                    lblcusid.InnerText = "Customer Name";
                }
               
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        protected void Find_Click(object sender, EventArgs e)
        {
            DataBindingForGrid();
        }

        private void DataBindingForGrid()
        {
            try
            {
                string startdate = txtFromDate.Text;
                string enddate = txtTodate.Text;
                DateTime StartDate = Convert.ToDateTime(startdate);
                DateTime EndDate = Convert.ToDateTime(enddate);
                string Start = StartDate.ToString("yyyyMMdd");
                string End = EndDate.ToString("yyyyMMdd");
                string customerid = drpCustomer.SelectedValue;
                CertificateManager cManager = new CertificateManager();
                string refNo = txtrefNo.Text;
                if (refNo=="")
                {
                    refNo = "All";
                }
                gvCertificate.DataSource = cManager.getCancelCertificate(Start, End, customerid, refNo);
                gvCertificate.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        protected Boolean CertificateBtn(string CertificatePath)
        {
            if (CertificatePath != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected Boolean CertificateLbl(string CertificatePath)
        {
            if (CertificatePath == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvCertificate.PageIndex = e.NewPageIndex;
            DataBindingForGrid();

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
    }
}