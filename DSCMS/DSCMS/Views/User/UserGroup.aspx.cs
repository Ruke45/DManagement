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
    public partial class UserGroup : System.Web.UI.Page

    {
        UserSession session;
        UserGroupManager ugm = new UserGroupManager();
        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
        protected void Page_Load(object sender, EventArgs e)
        {
            
            session = new UserSession();
            if (session.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "userg");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }




            if (!Page.IsPostBack)
            {
                BindGrid();
                
            }
        }

        public void BindGrid()
        {
            try
            {
                GridView1.DataSource = ugm.getUserGroup("%", "y");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                System.Console.Error.Write(ex.Message);

            }

        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void btnSubmit2_Click(object sender, EventArgs e)
        {

            mp2.Show();

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {

               

                if (TxtGroupName.Text == "")
                {
                    lblError.Text = "Please Fill out the Group Name to continue.";
                    mp1.Show();
                    return;
                }
                

                DCISDBManager.objLib.Usr.UserGroup editGroup = new DCISDBManager.objLib.Usr.UserGroup();

               
               editGroup.GroupId1 = TxtUserGroupID.Text;
                editGroup.GroupName1 = TxtGroupName.Text;
                editGroup.ModifiedBy1 = session.User_Id;

                editGroup.IsActive1 = "y";

                ugm.ModifyUserGroup(editGroup);

                Response.Redirect("UserGroup.aspx",false);







            }
            catch (Exception es)
            {

                System.Console.Error.Write(es.Message);

            }






        }




        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mp1.Show();
        }
       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                TxtUserGroupID.Text = row.Cells[1].Text;
                TxtGroupName.Text = row.Cells[0].Text;
                
                mp1.Show();






            }

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {

                TxtUserGroupID.Text = row.Cells[1].Text;
                 
               

            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            DCISDBManager.objLib.Usr.UserGroup deleteGroup = new DCISDBManager.objLib.Usr.UserGroup();
            deleteGroup.GroupId1 = TxtUserGroupID.Text;
            deleteGroup.ModifiedBy1 = session.User_Id;
            deleteGroup.IsActive1 = "n";
            ugm.ChangeActiveStatusUserGroup(deleteGroup);
            Response.Redirect("UserGroup.aspx", false);
        
        
        
        }
        protected void btnSubmitA_Click(object sender, EventArgs e)
         {


             try
             {
                

                 if (txtaddGroupName.Text == "")
                 {
                     lblerroraddGrp.Text = "Please Fill out the Group Name to continue.";
                     mp2.Show();
                     return;
                 }



                 DCISDBManager.objLib.Usr.UserGroup adGroup = new DCISDBManager.objLib.Usr.UserGroup();
                 //adGroup.GroupId1 = txtaddGroupID.Text;
                 adGroup.GroupName1 = txtaddGroupName.Text;
                 adGroup.CreatedBy1 = session.User_Id;
                 adGroup.IsActive1 = "y";
                 adGroup.ModifiedBy1 = "none";
              
                 ugm.CreateNewUserGroup(adGroup);
                 Response.Redirect("UserGroup.aspx",false);


            }
            catch (Exception es)
             {

                 System.Console.Error.Write(es.Message);

             }





        }

       

      




       

       
    }
}