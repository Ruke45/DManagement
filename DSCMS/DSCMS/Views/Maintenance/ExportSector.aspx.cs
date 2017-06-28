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
using DCISDBManager.objLib.MasterMaintenance;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.MasterMaintenance;
using System.Reflection;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.Utility;

namespace DSCMS.Views.Maintenance
{
    public partial class ExportSector : System.Web.UI.Page
    {

        ExportSectorManagement eS = new ExportSectorManagement();
        UserSession session;
        PackageTypeManagement pt = new PackageTypeManagement();
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
            bool auth = Am.IsUserGroupAuthorised(groupId, "ptype");
            //if (auth == false)
            //{
            //    Response.Redirect("~/Views/Home/Login.aspx");
            //}



            BindGrid();
         
        }

        public void BindGrid()
        {
            try
            {
               // GridView1.DataSource = pt.getPackageType("%");
                GridView1.DataSource = eS.getExportSection("y");
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
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            btnShow.Visible = true;
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                txtExportNameE.Text = row.Cells[0].Text;
                txtExportDescriptionE.Text = row.Cells[1].Text;
                // txtPersonName.Text = row.Cells[2].Text;
                mp1.Show();
            }
           

        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnShow.Visible = false;
            Response.Redirect("CertifcateDownload.aspx", false);


}
        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                txtExportNameE.Text = row.Cells[0].Text;
                //txtPackageID.Text = row.Cells[0].Text;
              //  DCISDBManager.objLib.MasterMaintenance.Packagetype inactive = new Packagetype();
              //  inactive.Modified_By = session.User_Id;
               // inactive.Package_Type = row.Cells[0].Text;
                //inactive.Is_Active = "n";
               // pt.ModifyPackageTypeStatus(inactive);
               

              //  Response.Redirect("PackageType.aspx",false);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ExportSec es = new ExportSec();
            es.Is_Active = "N";
            es.ExportSector_Name = txtExportNameE.Text;
            eS.ModifyExportSectionStatus(es);
            Response.Redirect("ExportSector.aspx", false);




        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            


            //if (txtPackageDescription.Text == "")
            //{
            //    lblError.Text = "Please Fill out the Export Description to continue.";
            //    mp1.Show();
            //    return;
            //}

            ExportSec es = new ExportSec();
            es.ExportSector_Name=txtExportNameE.Text;
            es.ExportSector_Description = txtExportDescriptionE.Text;
            es.Is_Active = "Y";
            
            eS.ModifyExportSection(es);



            

                Response.Redirect("ExportSector.aspx", false);
            
            


        }
        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            try
            {
/*
                if (txtPackageTypeAdd.Text == "")
                {
                    lblerroradddid.Text = "Please Fill out the Package type to continue.";
                    mp2.Show();
                    return;
                }  */
                if (txtDescriptionAdd.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the Export Sector Description to continue.";
                    mp2.Show();
                    return;
                }
                if (txtExportNameA.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out Name to continue.";
                    mp2.Show();
                    return;
                }
                ExportSec es = new ExportSec();

                es.ExportSector_Name = txtExportNameA.Text;
                es.ExportSector_Description = txtDescriptionAdd.Text;
                es.Is_Active = "Y";
                eS.CreateExportSection(es);
               

                    Response.Redirect("ExportSector.aspx", false);
                }
               

            
            catch (Exception es)
            {

                System.Console.Error.Write(es.Message);

            }




        }
        protected void btnSubmit2_Click(object sender, EventArgs e)
        {

            mp2.Show();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   this.mp1.Show();

        }



        }
    }
