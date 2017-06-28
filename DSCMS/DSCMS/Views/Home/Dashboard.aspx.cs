using DCISDBManager.objLib.Usr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Home
{
    public partial class Dashboard : System.Web.UI.Page
    {
        UserSession userSession;
        string UserGroupID_Customer = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
        string UserGroupID_Admin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
        string UserGroupID_FAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_FAdmin"];
        string UserGroupID_SAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
        string UserGroupID_PAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_PAdmin"];
        string UserGroupID_CustomerAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];

        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            PrintDashboard();
        }

        protected void PrintDashboard()
        {
            if (userSession.User_Id.Equals(""))
            {
                Response.Redirect("~/Views/Home/Login.aspx");

            }
            else if (userSession.User_Group.Equals(UserGroupID_Customer))
            {
                RowNCEAdmin.Visible = false;
                ROWNCESignatory.Visible = false;
                CAdminNuserR.Visible = false;
                ROWFINANCEADMIN.Visible = false;

            }
            else if (userSession.User_Group.Equals(UserGroupID_CustomerAdmin))
            {
                RowNCEAdmin.Visible = false;
                ROWNCESignatory.Visible = false;
                ROWFINANCEADMIN.Visible = false;
            }
            //else if (userSession.User_Group.Equals(UserGroupID_PAdmin))
            //{

            //}
            else if (userSession.User_Group.Equals(UserGroupID_FAdmin))
            {
                RowNCEAdmin.Visible = false;
                ROWNCESignatory.Visible = false;
                ROWCADMINNCUSTOMER.Visible = false;

            }
            else if (userSession.User_Group.Equals(UserGroupID_SAdmin))
            {
                RowNCEAdmin.Visible = false;
                ROWCADMINNCUSTOMER.Visible = false;
                ROWFINANCEADMIN.Visible = false;
            }
            else
            {
                ROWNCESignatory.Visible = false;
                ROWCADMINNCUSTOMER.Visible = false;
                ROWFINANCEADMIN.Visible = false;
            }
        }
    }
}