using DCISDBManager.objLib.Usr;
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

namespace DSCMS.Views.Customer
{
    public partial class LetterUploadForm : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            CheckAutentication();
          
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
                bool auth = Am.IsUserGroupAuthorised(groupId, "RegLet");
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
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Label1.Visible = false;
                Label2.Visible = false;
                int count = 0;
                string subPath = "~/Letters/"; // your code goes here
               bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));
               string RegistrationFileName = null;
               string RequestLetterFileName = null;
               string CustomerId = userSession.Customer_ID;
                if (!exists)
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

                if (btnRegistration.HasFile)
                {
                    string fileName = Path.GetFileName(btnRegistration.PostedFile.FileName);
                    RegistrationFileName = userSession.Customer_ID + fileName;

                    string ext = System.IO.Path.GetExtension(this.btnRegistration.PostedFile.FileName);
                    if (ext == ".pdf")
                    {
                        btnRegistration.PostedFile.SaveAs(Server.MapPath("~/Letters/") + RegistrationFileName);
                        //Response.Redirect(Request.Url.AbsoluteUri);
                        count = count + 1;
                    }
                    else {
                        Label1.Visible = true;
                        Label1.Text = "Error Uploading the file. Make sure to select A correct file type";
                    }
                }
                
               
                if (btnRequestLetter.HasFile)
                {
                    string fileName = Path.GetFileName(btnRequestLetter.PostedFile.FileName);

                    string ext = System.IO.Path.GetExtension(this.btnRequestLetter.PostedFile.FileName);
                    if (ext == ".pdf")
                    {
                        RequestLetterFileName = userSession.Customer_ID + fileName;
                        btnRequestLetter.PostedFile.SaveAs(Server.MapPath("~/Letters/") + RequestLetterFileName);
                        count = count + 1;
                    }
                    else {
                        Label2.Visible = true;
                        Label2.Text = "Error Uploading the file. Make sure to select A correct file type";
                    }
                  //  Response.Redirect(Request.Url.AbsoluteUri);
                }
                
                if (count >= 1)
                {
                    CustomerRequestManager CRM = new CustomerRequestManager();
                    string ISIN = CRM.CheckLetterTable(CustomerId);
                    CRM.setCustomerletterPath(RequestLetterFileName, RegistrationFileName, CustomerId, null, ISIN);
                    string qu = null;
                    qu += "<div style='color:green' class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong>Attachment Uploaded Successfuly</strong> </div>";


                    ErrorMessage.InnerHtml = qu;
                    
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                

            }
        }
    }
}