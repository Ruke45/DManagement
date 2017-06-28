using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.UserManagement;
using System.Reflection;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.EmailManager;

namespace DSCMS
{
    public partial class User : System.Web.UI.Page


    {
        UserManager um = new UserManager();
        CertficateRequestDataManagement crm = new CertficateRequestDataManagement();
        UserGroupManager ugm = new UserGroupManager();
        UserSession session;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                databind();
            }
            session = new UserSession();
            if (session.User_Id=="")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "adu");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            if
            (ddUserGroup.SelectedValue=="sc"){
                cd.Visible = true;
            
            }

        }

        protected void databind()
        {
            DCISDBManager.objLib.Usr.UserGroup ddlistUser = new DCISDBManager.objLib.Usr.UserGroup();

          //  ddUserGroup.DataSource = ugm.getUserGroup("%", "y");
          ////  ddUserGroup.Items.Add ("<--please Select the Group--->");
          //  ddUserGroup.DataValueField = "GroupId1";
          //  //   ddUserGroup.DataTextField= "GroupName1";
          //  ddUserGroup.DataTextField = "GroupName1";

          //  ddUserGroup.DataBind();


            ddCustomer.DataSource = crm.getCustomerUser("%");
          //  ddUserGroup.Items.Add ("<--please Select the Group--->");
            ddCustomer.DataValueField = "Customer_ID";
            //   ddUserGroup.DataTextField= "GroupName1";
            ddCustomer.DataTextField = "Person_Name";

            ddCustomer.DataBind();




        }


       


        protected void Button1_Click1(object sender, EventArgs e)
        {
                
            try
            {
                string a = UserID.Text;
                if (um.CheckUserIDAvailability(a) == false)
                {

                    DCISDBManager.objLib.Usr.User adUser = new DCISDBManager.objLib.Usr.User();




                    adUser.User_ID = UserID.Text;
                    // adUser.UserGroup_ID = "1";
                    adUser.UserGroup_ID = ddUserGroup.SelectedValue;
                  //  adUser.PassowordExpiry_Date = DateTime.Today.AddDays(344).ToString("dd/MM/yyyy");
                    string expdate = System.Configuration.ConfigurationManager.AppSettings["ExpiryDate"];
                    adUser.PassowordExpiry_DateN = DateTime.Today.AddDays(Int32.Parse(expdate));

                    adUser.Designation_ = txtDesignation.Text;

                    adUser.Person_Name = PersonName.Text;
                    adUser.Created_By = session.User_Id;

                    //  adUser.Created_By = "1";
                    if (ddUserGroup.SelectedValue.Equals("CADMIN") || ddUserGroup.SelectedValue.Equals("CUSTOMER"))
                    {
                        adUser.Customer_ID = ddCustomer.SelectedValue;
                    }
                    else
                    {
                        adUser.Customer_ID = null;
                    }


                    adUser.Email_ = txteEmail.Text;
                    adUser.Password_ = Password.Text;
                    adUser.Is_Active = "Y";
                    um.CreateNewUserN(adUser);
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> User Creation Successful !!!</strong></div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;

                
                    UserID.Text = null;
                    PersonName.Text = null;
                    ddUserGroup.SelectedValue = "";
                   
                    
                 //  Response.Redirect("AddUser.aspx?show=1", false);
                   lblSuccess.Visible = true;
                }
                else {
                    lblSuccess.Visible = false;

                    lblErrorUser.Visible = true;
                    
                   // Response.Redirect("AddUser.aspx", false);
                }

            }
            catch (Exception es)
            {


                System.Console.Error.Write(es.Message);

            }

        }
    }
}