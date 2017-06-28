using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Drawing;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.UserManagement;
using System.Reflection;
using DCISDBManager.trnLib.CheckAuth;

namespace DSCMS
{
    public partial class UserRequest : System.Web.UI.Page


    {
        UserRequestManager adduserreq = new UserRequestManager();
        UserSession session;
        UserManager um = new UserManager();
        UserGroupManager ugm = new UserGroupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            session = new UserSession();
            if (session.User_Id=="")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "userq");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }

            if (!Page.IsPostBack)
            {

                databind();
            }
           
        }
        protected void databind()
        {
            DCISDBManager.objLib.Usr.UserGroup ddlistUser = new DCISDBManager.objLib.Usr.UserGroup();

          // // ddUserGroup.DataSource = ugm.getUserGroup("%", "y");
          //  ddUserGroup.DataSource = ugm.getSelectedUserGroup("%", "y");

          //  ddUserGroup.DataValueField = "GroupId1";
          //ddUserGroup.DataTextField= "GroupName1";
          // // ddUserGroup.DataTextField = "GroupId1";
          
          // ddUserGroup.DataBind();


        
        
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try{
            
                 string a = UserID.Text;
                 if (um.CheckUserIDAvailability(a) == false && adduserreq.CheckUserReqUserIDAvailability(a)==false)
                 {
                     //DCISDBManager.objLib.Usr.User adUser = new DCISDBManager.objLib.Usr.User();

                     //DCISDBManager.objLib.Usr.UserRequest ur = new DCISDBManager.objLib.Usr.UserRequest();
                     //ur.User_Id= UserID.Text;
                    
                     //ur.UserGroup_ID = ddUserGroup.SelectedValue;

                    
                     //ur.Person_Name = PersonName.Text;
                     //ur.Created_By = session.User_Id;
                     //ur.Password_ = Password.Text;
                     //ur.Status_ = "A";
                     //ur.Approved_By = session.User_Id;
                     //ur.Modified_By = session.User_Id;
                     //ur.Customer_ID = session.Customer_ID;
                   
                     //adduserreq.NewUserRequest(ur);

                     DCISDBManager.objLib.Usr.User adUsers = new DCISDBManager.objLib.Usr.User();




                     adUsers.User_ID = UserID.Text;
                     // adUser.UserGroup_ID = "1";
                     adUsers.UserGroup_ID = ddUserGroup.SelectedValue;
                     //  adUser.PassowordExpiry_Date = DateTime.Today.AddDays(344).ToString("dd/MM/yyyy");
                     string expdate = System.Configuration.ConfigurationManager.AppSettings["ExpiryDate"];
                     adUsers.PassowordExpiry_DateN = DateTime.Today.AddDays(Int32.Parse(expdate));

                     adUsers.Person_Name = PersonName.Text;
                     adUsers.Created_By = session.User_Id;

                     //  adUser.Created_By = "1";
                     
                         adUsers.Customer_ID = session.Customer_ID;
                         adUsers.Designation_ = txtDesignation.Text;

                         adUsers.Email_ = txteEmail.Text;


                     adUsers.Password_ = Password.Text;
                     adUsers.Is_Active = "Y";
                     um.CreateNewUserN(adUsers);




                     lblSuccess.Visible = true;
                     lblErrorUser.Visible = false;
                     PersonName.Text = null;
                     Password.Text = null;
                     ddUserGroup.SelectedValue = null;
                     string qu = null;
                     qu += "<div style='color:green' class=\"alert alert-dismissable alert-success\">";
                     qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                     qu += " <strong>User Created Successfully...!</strong> </div>";


                     ErrorMessage.InnerHtml = qu;

                    
                 }
                 else {

                     lblErrorUser.Visible = true;
                     lblSuccess.Visible = false;
                     Password.Text = null;
                     PersonName.Text = null;
                     ddUserGroup.SelectedValue = null;
                    
                 }

            }
            catch(Exception es) {


                System.Console.Error.Write(es.Message);
            
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PersonName.Text = "a";
            UserID.Text = "b";
            ddUserGroup.SelectedValue = "a";

            Response.Redirect("UserGroup.aspx", false);

        }
    }
}