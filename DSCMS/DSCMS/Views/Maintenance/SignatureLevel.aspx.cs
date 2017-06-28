using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Drawing;
using DCISDBManager.objLib.MasterMaintenance;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.MasterMaintenance;
using System.Reflection;
using DCISDBManager.trnLib.UserManagement;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;

namespace DSCMS
{
    public partial class SignatureLevel : System.Web.UI.Page
    {
        UserSession session ;
       SignatureLevelManagement sgl = new SignatureLevelManagement();
       UserGroupManager ugm = new UserGroupManager();
       TemplateForSupportingDocumentManagement rm = new TemplateForSupportingDocumentManagement();
       string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
       string Sadmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];

        protected void Page_Load(object sender, EventArgs e)
       {
           
           session = new UserSession();

           if (session.User_Id == "")
           {
               Response.Redirect("~/Views/Home/Login.aspx");
           }
           string groupId = session.User_Group;
           CheckAuthManager Am = new CheckAuthManager();
           bool auth = Am.IsUserGroupAuthorised(groupId, "sigl");
           if (auth == false)
           {
               Response.Redirect("~/Views/Home/Login.aspx");
           }
           if (!Page.IsPostBack)
           {
               
               BindGrid();
               datadropdown();
               //Please check if you are binding checkbox controls here. 
               //If not bring them in here
           }
            
         
        }

        public void BindGrid()
        {
            try
            {
                GridView1.DataSource = sgl.getSignatureLevels("%", "%","y");
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


        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();
            
             using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
               
                txtTemplateID.Text = row.Cells[0].Text;
                txtAddUser.Text = row.Cells[1].Text;
                ddeSugnatureLevels.SelectedValue = row.Cells[2].Text;

            }

            



        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SignatureLevels chgest = new SignatureLevels();

            chgest.User_Id = txtAddUser.Text;
            chgest.Template_Id = txtTemplateID.Text;

            chgest.Is_Active = "n";
            sgl.ActivateDeactivetSignatureLevel(chgest.User_Id, chgest.Is_Active, chgest.Template_Id);
            Response.Redirect("SignatureLevel.aspx", false); 
        
        }
        
        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            if (ddAddUser.SelectedValue == "")
            {
                lblerrorn.Text = "Please Select User to continue.";
                mp2.Show();
                return;
            }
            if (ddTemplateIDadd.SelectedValue == "")
            {
                lblerrorn.Text = "Please Select Template to continue.";
                mp2.Show();
                return;
            }
            if (ddAddSigLevel.SelectedValue == "")
            {
                lblerrorn.Text = "Please Select Signature Level to continue.";
                mp2.Show();
                return;
            }

            String a = ddAddUser.SelectedValue;
            String b = ddTemplateIDadd.SelectedValue;
            if (sgl.CheckTemplateIDandUserID(a, b,"y") == false)
            {
                DCISDBManager.objLib.MasterMaintenance.SignatureLevels AddLevels = new DCISDBManager.objLib.MasterMaintenance.SignatureLevels();
                AddLevels.User_Id = ddAddUser.SelectedValue;
                AddLevels.Template_Id = ddTemplateIDadd.SelectedValue;
                AddLevels.Level_Id = ddAddSigLevel.SelectedValue;
                AddLevels.Is_Active = "y";
                AddLevels.Created_By = session.User_Id;
                sgl.CreateSignatureLevels(AddLevels);
                Response.Redirect("SignatureLevel.aspx", false);
            }
            else {

                lblerrorn.Text = " Signature Level of this User is Already Assigned to the Selected Template";
                mp2.Show();
                return;
            
            }



        }

        public void datadropdown()
        {
            try
            {
                ddAddUser.DataSource = sgl.getLeveledUser("%", Sadmin);
                ddAddUser.DataValueField = "User_ID";
                ddAddUser.DataTextField = "User_ID";
                ddAddUser.DataBind();

                ddTemplateIDadd.DataSource = rm.getTemplateIDforSupportDoc("%","%");
                ddTemplateIDadd.DataValueField = "Template_Id";
                ddTemplateIDadd.DataTextField = "Template_Name";
                //ddSignatureLevel.DataSource = Enumerable.Range(1, 10);

                  ddTemplateIDadd.DataBind();

                  ddAddSigLevel.DataSource = sgl.getSignatureLevelID("%");
                  ddAddSigLevel.DataValueField = "Level_Id";
                  ddAddSigLevel.DataTextField = "Level_Id";
                  ddAddSigLevel.DataBind();

               

                ddeSugnatureLevels.DataSource = sgl.getSignatureLevelID("%");
                ddeSugnatureLevels.DataValueField = "Level_Id";
                ddeSugnatureLevels.DataTextField = "Level_Id";
                ddeSugnatureLevels.DataBind();


                    


            }
            catch (Exception ex)
            {
                System.Console.Error.Write(ex.Message);

            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                txtTemplateID.Text = row.Cells[0].Text;
                txtAddUser.Text = row.Cells[1].Text;
                ddeSugnatureLevels.SelectedValue = row.Cells[2].Text;

                
               // txtUserID.Text = row.Cells[0].Text;
                // txtGroupID.Text = row.Cells[1].Text;
                // txtPersonName.Text = row.Cells[2].Text;
                mp1.Show();
                
            }

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.mp1.Show();
            

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddeSugnatureLevels.SelectedValue == "")
            {
                lblError.Text = "Please Select Level to continue.";
                mp1.Show();
                return;
            }


            
            DCISDBManager.objLib.MasterMaintenance.SignatureLevels editLevels = new DCISDBManager.objLib.MasterMaintenance.SignatureLevels();

            editLevels.Template_Id = txtTemplateID.Text;
            editLevels.Level_Id = ddeSugnatureLevels.SelectedValue;
            editLevels.User_Id = txtAddUser.Text;
            editLevels.Is_Active = "y";
            editLevels.Modified_By = session.User_Id;
           // editLevels.Level_Id = ddSignatureLevel.SelectedValue.ToString();
           /// editLevels.Level_Id = "8";
           // editLevels.Template_Id = "1";
            sgl.ModifySignatureLevel(editLevels);
            ddeSugnatureLevels.SelectedValue = null;
           
            Response.Redirect("SignatureLevel.aspx",false); 



        }
    }
}