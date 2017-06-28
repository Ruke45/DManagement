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
using DCISDBManager.objLib.Usr;

using DCISDBManager.trnLib;
using DCISDBManager.trnLib.Utility;

using DCISDBManager.trnLib.MasterMaintainance;
using System.Reflection;
using DCISDBManager.trnLib.CheckAuth;

namespace DSCMS
{
    public partial class SupportingDocuments : System.Web.UI.Page
    {
        UserSession session ;
        SupportingDocumentManagement sdm = new SupportingDocumentManagement();
        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
        protected void Page_Load(object sender, EventArgs e)
        {
           

         
            session = new UserSession();

            if (session.User_Id=="")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "supd");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
          

            BindGrid();
          //  datadropdown();
        }

        public void BindGrid()
        {
            try
            {
               // GridView1.DataSource = sdm.getSupportingDocument("%", "1");
                GridView1.DataSource = sdm.getSupportingDocumentn("%", "y");

                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }
        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }




        public void datadropdown()
        {
           try
            {
              //  ddPercentage.DataSource = Enumerable.Range(1, 100);
               
                //  ddPercentage.DataBind();


            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }


           

        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                txtedsupd.Text = row.Cells[0].Text;
                txtedsupname.Text = row.Cells[1].Text;             
                mp1.Show();
            }

        }
       
        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {

                txtedsupd.Text = row.Cells[0].Text;
                txtedsupname.Text = row.Cells[1].Text;  

                
            
            
            }
        //    Response.Redirect("SupportingDocuments.aspx",false);

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DCISDBManager.objLib.MasterMaintenance.SupportDocuments inactive = new SupportDocuments();
            inactive.Is_Active = "n";
            inactive.Modified_By = session.User_Id;
            inactive.SupportingDocument_Id = txtedsupd.Text; 
            sdm.ModifySupportingDocumentStatus(inactive);
            Response.Redirect("SupportingDocuments.aspx", false);
        
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            if (txtedsupname.Text == "")
            {
                lblError.Text = "Please Fill out the Supporting Document Name to continue.";
                mp1.Show();
                return;
            }


            DCISDBManager.objLib.MasterMaintenance.SupportDocuments editsd = new SupportDocuments();
            editsd.SupportingDocument_Id = txtedsupd.Text;
            editsd.SupportingDocument_Name = txtedsupname.Text;
            editsd.Modified_By = session.User_Id;


            sdm.ModifySupportingDocument(editsd);

            Response.Redirect("SupportingDocuments.aspx",false);


        }

        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            try
            {

               
                if (txtSDName.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the Supporting Document Name to continue.";
                    mp2.Show();
                    return;
                }
                String a= txtSDName.Text;
                if (sdm.SupportingDocumentName(a) == false)
                {

                    DCISDBManager.objLib.MasterMaintenance.SupportDocuments sd = new SupportDocuments();
                    //sd.SupportingDocument_Id = txtSDID.Text;
                    sd.SupportingDocument_Name = txtSDName.Text;
                    sd.Created_By = session.User_Id;
                    sd.Is_Active = "y";

                    sdm.CreateSupportingDocument(sd);
                    Response.Redirect("SupportingDocuments.aspx", false);
                }
                else {

                    lblerroradddn.Text = "Supporting Document Name already Exist.";
                    mp2.Show();
                    return;
                }


            }
            catch (Exception es)
            {

                ErrorLog.LogError(es);

            }




        }
        protected void btnSubmit2_Click(object sender, EventArgs e)
        {

            mp2.Show();

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mp1.Show();

        }

    }
}