using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.UserManagement;
using DCISDBManager.trnLib.Utility;
using System.IO;
using DCISDBManager.trnLib.CheckAuth;

namespace DSCMS.Views.User
{
    public partial class Signature : System.Web.UI.Page
    {
        UserSession userSession;
        CheckAuthManager authorized;
        string UserGroupID_SAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
        UserManager Um = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            authorized = new CheckAuthManager();

            if (!authorized.IsUserGroupAuthorised(userSession.User_Group, "USING"))
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            if (!IsPostBack)
            {
                getUsers();
            }
        }

        protected void getUsers()
        {
            UserGroupManager Userlist = new UserGroupManager();
            drpdwnUsers.DataSource = Userlist.getSignataryUsers(UserGroupID_SAdmin);
            drpdwnUsers.DataTextField = "Person_Name";
            drpdwnUsers.DataValueField = "User_ID";
            drpdwnUsers.DataBind();
        }

        protected void btnAddSignature_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;
                string DirectoryPath = "~/Signature/" + drpdwnUsers.SelectedValue;
                UserSignature USing = null;

                string pfx = Path.GetFileName(SinPFXupload.PostedFile.FileName.Replace(" ", "_"));
 
                string imgPath = Path.GetFileName(SinIMGupload.PostedFile.FileName.Replace(" ", "_"));

                if (!Directory.Exists(Server.MapPath(DirectoryPath)))
                {
                    Directory.CreateDirectory(Server.MapPath(DirectoryPath));
                }
                DCISDBManager.objLib.Usr.User usr = new DCISDBManager.objLib.Usr.User();
                if (SinIMGupload.HasFile)
                {
                    USing = Um.getUserSignatureDetails(drpdwnUsers.SelectedValue);
                    if (USing == null)
                    {

                        SinPFXupload.SaveAs(Server.MapPath(DirectoryPath) + "/" + pfx);
                        SinIMGupload.PostedFile.SaveAs(Server.MapPath(DirectoryPath) + "/" + imgPath);
                        //s               Response.Redirect(Request.Url.AbsoluteUri);

                        usr.PFX_path = DirectoryPath + "/" + pfx;
                        usr.SignatureIMG_path = DirectoryPath + "/" + imgPath;
                        usr.User_ID = drpdwnUsers.SelectedValue;
                        usr.Created_By = userSession.User_Id;

                        result = Um.setUserSignature(usr);
                    }
                    else
                    {
                        File.Delete(Server.MapPath(USing.PFX_path));
                        File.Delete(Server.MapPath(USing.SignatureIMG_Path));

                        SinPFXupload.SaveAs(Server.MapPath(DirectoryPath) + "/" + pfx);
                        SinIMGupload.PostedFile.SaveAs(Server.MapPath(DirectoryPath) + "/" + imgPath);
                        //s               Response.Redirect(Request.Url.AbsoluteUri);

                        usr.PFX_path = DirectoryPath + "/" + pfx;
                        usr.SignatureIMG_path = DirectoryPath + "/" + imgPath;
                        usr.User_ID = drpdwnUsers.SelectedValue;
                        usr.Created_By = userSession.User_Id;

                        result = Um.ModifyUserSignature(usr);
                    }
              }
                if (result)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " Signature Details Successfully Added....</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                }
                else
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " Unable to Complete the Data Transaction..</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error! </strong>Faild To add the Signature Details..</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }
        }
    }
}