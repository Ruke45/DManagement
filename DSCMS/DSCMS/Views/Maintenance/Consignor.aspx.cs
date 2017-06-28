using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DCISDBManager.trnLib.Utility;

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

namespace DSCMS.Views.Maintenance
{
    public partial class Consignor : System.Web.UI.Page
    {
       
        ConsignorManagement cm = new ConsignorManagement();
        UserSession session;
        PackageTypeManagement pt = new PackageTypeManagement();
        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
        protected void Page_Load(object sender, EventArgs e)
        {
            session = new UserSession();

            //if (session.User_Id == "")
            //{
            //    Response.Redirect("~/Views/Home/Login.aspx");
            //}
            //string groupId = session.User_Group;
            //CheckAuthManager Am = new CheckAuthManager();
            //bool auth = Am.IsUserGroupAuthorised(groupId, "ptype");
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
                GridView1.DataSource = cm.getConsignor("y");
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
                txtConsigner.Text = row.Cells[0].Text;
                txtDescription.Text = row.Cells[1].Text;
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
                txtConsigner.Text = row.Cells[0].Text;
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
            DCISDBManager.objLib.MasterMaintenance.Consignor del= new DCISDBManager.objLib.MasterMaintenance.Consignor();
            del.Code_ = txtConsigner.Text;
            del.Is_Active = "n";
            cm.ModifyConsignorStatus(del);
            Response.Redirect("Consignor.aspx", false);




        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {



            if (txtDescription.Text == "")
            {
                lblError.Text = "Please Fill out the Package Name to continue.";
                mp1.Show();
                return;
            }



            DCISDBManager.objLib.MasterMaintenance.Consignor edit= new DCISDBManager.objLib.MasterMaintenance.Consignor();






            edit.Code_ = txtConsigner.Text;

            edit.Description_ = txtDescription.Text;
          //  edit.Is_Active = session.User_Id;



            // sdm.ModifySupportingDocument(editsd);
            cm.ModifyConsignor(edit);
            btnShow.Visible = false;
            txtConsigner.Text = null;
            txtDescription.Text = null;

            Response.Redirect("Consignor.aspx", false);




        }
        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtConsignorAdd.Text == "")
                {
                    lblerroradddid.Text = "Please Fill out the Consignor Name to continue.";
                    mp2.Show();
                    return;
                }
                if (txtConsignorDescriptionAdd.Text == "")
                    {
                        lblerroradddn.Text = "Please Fill out the Description to continue.";
                        mp2.Show();
                        return;
                    }
                    //if (txtPackageDescriptionAdd.Text == "")
                    //{
                    //    lblerroradddn.Text = "Please Fill out the Package description to continue.";
                    //    mp2.Show();
                    //    return;
                    //}


                    DCISDBManager.objLib.MasterMaintenance.Consignor add = new DCISDBManager.objLib.MasterMaintenance.Consignor();
                    add.Code_ = txtConsignorAdd.Text;
                    add.Description_ = txtConsignorDescriptionAdd.Text;
                    add.Is_Active = "y";
                    cm.CreateConsignor(add);



                    //txtPackageID.Text = null;
                    //  txtPackageDescription.Text = null;

                    Response.Redirect("Consignor.aspx", false);
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