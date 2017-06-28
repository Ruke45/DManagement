using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Customer
{
    public partial class ViewUploadForm : System.Web.UI.Page
    {
        UserSession userSession;
        string regpath = null;
        string reqpath = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
           CheckAutentication();
            if (!IsPostBack) {
                GetAllCustomer();
            }
        }

        private void LoadPageData()
        {
            try
            {
                 ErrorMessage.InnerHtml = null;
                string CustomerId = drpCustomer.SelectedValue;
                CustomerRequestManager CRM = new CustomerRequestManager();
                CustomerRequest data = CRM.getCustomerLetterPath(CustomerId);

                string regdivdata1 = null;
                string reqdivdata2 = null;

                if (data.CustomerName1 != null)
                {
                    btnReqLetter.Visible = true;
                    btnViewRegLetter.Visible = true;

                    
                     regpath = "../../Letters/" + data.RegFilePath1;
                     Session["RegPath"] = regpath;
                     reqpath = "../../Letters/" + data.ReqFilePath1;
                     Session["ReqPath"] = reqpath;
                    regdivdata1 = "<a href='" +regpath + "' target='_blank' class='btn btn-primary' download>Download File</a>";
                    reqdivdata2 = "<a href='" + reqpath + "' target='_blank' class='btn btn-primary' download>Download File</a>";
                   
                   

                    if (data.RegFilePath1 == "No")
                    {
                        btnViewRegLetter.Visible = false;
                    }
                    else {
                        regLetter.InnerHtml = regdivdata1;
                    }
                    if (data.ReqFilePath1 == "No")
                    {
                        btnReqLetter.Visible = false;
                    }
                    else {
                        reqletter.InnerHtml = reqdivdata2;
                    }
                }
                else
                {
                    btnReqLetter.Visible = false;
                    btnViewRegLetter.Visible = false;
                    regLetter.InnerHtml = null;
                    reqletter.InnerHtml = null;
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong>Sorry...!</strong>This Customer Not Upload There Document";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                }
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }
        }

        protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPageData();
        }
        private void GetAllCustomer()
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

        private void CheckAutentication()
        {
            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            try
            {
                string groupId = userSession.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "Adminlet");
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

        protected void btnViewRegLetter_Click(object sender, EventArgs e)
        {
            try
            {
                Session["PDFUrl"] = Session["RegPath"].ToString();
                string pageurl = "../Certificate/PdfView.aspx";
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }
        }

        protected void btnReqLetter_Click(object sender, EventArgs e)
        {
            try{
                Session["PDFUrl"] = Session["ReqPath"].ToString();
                string pageurl = "../Certificate/PdfView.aspx";
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
             }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }
        }
    }
}