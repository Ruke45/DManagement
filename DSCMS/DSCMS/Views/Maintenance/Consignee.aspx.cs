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
    public partial class Consignee : System.Web.UI.Page
    {
        UserSession session;
        PackageTypeManagement pt = new PackageTypeManagement();
        
        ConsigneeManagement cm = new ConsigneeManagement();
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
                GridView1.DataSource = cm.getConsignee("y");
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
                txtEConsignee.Text = row.Cells[0].Text;
                txtEDescription.Text = row.Cells[1].Text;
                // txtPersonName.Text = row.Cells[2].Text;
                mp1.Show();
            }


        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnShow.Visible = false;
            Response.Redirect("Consignee.aspx", false);


        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                txtEConsignee.Text = row.Cells[0].Text;
              
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DCISDBManager.objLib.MasterMaintenance.Consignee dc = new DCISDBManager.objLib.MasterMaintenance.Consignee();

            dc.Code_ = txtEConsignee.Text;
            dc.Is_Active = "n";
            cm.ModifyConsigneeStatus(dc);

            
            Response.Redirect("Consignee.aspx", false);




        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {



            if (txtEDescription.Text == "")
            {
                lblError.Text = "Please Fill out the Package Name to continue.";
                mp1.Show();
                return;
            }



            DCISDBManager.objLib.MasterMaintenance.Consignee cs = new DCISDBManager.objLib.MasterMaintenance.Consignee();
            cs.Code_ = txtEConsignee.Text;
            cs.Description_ = txtEDescription.Text;
            cm.ModifyConsignee(cs);


           



            // sdm.ModifySupportingDocument(editsd);
        
            btnShow.Visible = false;
            txtAddConsignee.Text = null;
            txtAddDescription.Text = null;

            Response.Redirect("Consignee.aspx", false);




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
                if (txtAddConsignee.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the Consignee to continue.";
                    mp2.Show();
                    return;
                }
                if (txtAddDescription.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the Consignee description to continue.";
                    mp2.Show();
                    return;
                }
                DCISDBManager.objLib.MasterMaintenance.Consignee cs = new DCISDBManager.objLib.MasterMaintenance.Consignee();

                cs.Code_ = txtAddConsignee.Text;
                cs.Description_ = txtAddDescription.Text;
                cs.Is_Active="y";
                cm.CreateConsignee(cs);


                txtAddConsignee.Text = null;
                txtAddDescription.Text = null;

                Response.Redirect("Consignee.aspx", false);
                
            

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