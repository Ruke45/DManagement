using DCISDBManager.objLib.MasterMaintenance;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.MasterMaintenance;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Maintenance
{
    public partial class EditNCEContactPersonName : System.Web.UI.Page
    {
           UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            CheckAutentication();
            if(!IsPostBack){
            getContactDetails();
        }
        }


        private void getContactDetails()
        {
            try
            {
                OwnerDetailManagement odm = new OwnerDetailManagement();

                OwnerDetailsobj a = new OwnerDetailsobj();



                var asd = odm.getNCEContactPerson();


                txtContactName.Text = asd.Name_;
                txtPhoneNumber.Text = asd.Telephone_No;
                txtContactEmail.Text = asd.Email_;
                txtfaxNo.Text = asd.Fax_No;
                txtWeb.Text = asd.Web_Address;



            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
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
                bool auth = Am.IsUserGroupAuthorised(groupId, "ConDetail");
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
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtContactName.Text;
                string email = txtContactEmail.Text;
                string web = txtWeb.Text;
                string telephone = txtPhoneNumber.Text;
                string fax = txtfaxNo.Text;
                OwnerDetailManagement odm = new OwnerDetailManagement();

                OwnerDetailsobj a = new OwnerDetailsobj();
                a.Name_ = name;
                a.Email_ = email;
                a.Web_Address = web;
                a.Telephone_No = telephone;
                a.Fax_No = fax;
                bool check=odm.ModifyNCEContactPerson(a);
                if (check)
                {
                    string  qu = null;
                    ErrorMessage.Visible = true;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += "Save Successful!</div>";

                 
                    ErrorMessage.InnerHtml = qu;
                }
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
                string qu = null;
                ErrorMessage.Visible = true;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += "Save Fail!</div>";


                ErrorMessage.InnerHtml = qu;
            }

        }
    }
}