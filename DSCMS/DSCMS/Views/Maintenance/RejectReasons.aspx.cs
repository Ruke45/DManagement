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
using DCISDBManager.objLib.MasterMaintenance;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.MasterMaintenance;
using System.Reflection;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;

namespace DSCMS
{
    public partial class Reject_Reasons : System.Web.UI.Page
    {
        UserSession session;
        ReasonsManagement rm = new ReasonsManagement();
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
            bool auth = Am.IsUserGroupAuthorised(groupId, "rrsn");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }

            if (!Page.IsPostBack)
            {

                BindGrid();
                DropDown();
            }
         
        }

        public void BindGrid()
        {
            try
            {

               // GridView1.DataSource = rm.getReasons("%");
                GridView1.DataSource = rm.getReasonsn("%", "y");
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


        public void DropDown()
        {
           // ReasonsManagement rm2 = new ReasonsManagement();
            ddCategory.DataSource = rm.getReasonsCategory("%");
            ddCategory.DataTextField = "Category_";
            ddCategory.DataValueField = "Category_";
            ddCategory.DataBind();
            ddCategory.AppendDataBoundItems = false;
            ReasonsManagement rm2 = new ReasonsManagement();
            ddeCategory.DataSource = rm2.getReasonsCategory("%");
            ddeCategory.DataTextField = "Category_";
            ddeCategory.DataValueField = "Category_";
            ddeCategory.DataBind();
            ddeCategory.AppendDataBoundItems = false;

            


        }
   






        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                txtRejectCode.Text = row.Cells[0].Text;
                txtReasonName.Text = row.Cells[1].Text;
                ddeCategory.SelectedValue = row.Cells[2].Text;

              
                mp1.Show();
            }

        }
       

        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                txtRejectCode.Text = row.Cells[0].Text;
               



            }




        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            DCISDBManager.objLib.MasterMaintenance.ReasonsMaintenance changeStatus = new ReasonsMaintenance();
            changeStatus.Is_Active = "n";
            changeStatus.Modified_By = session.User_Id;
            changeStatus.Reject_Code = txtRejectCode.Text;
            rm.ModifyReasonsStatus(changeStatus);


            Response.Redirect("RejectReasons.aspx", false);

         


        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            if (txtReasonName.Text == "")
            {
                lblError.Text = "Please Fill out the Reject reasons to continue.";
                mp1.Show();
                return;
            }
            if (ddeCategory.SelectedValue=="" )
            {
                lblError.Text = "Please Select Category to continue.";
                mp1.Show();
                return;
            }

          


            DCISDBManager.objLib.MasterMaintenance.ReasonsMaintenance editrm = new ReasonsMaintenance();


            
            editrm.Reject_Code = txtRejectCode.Text;
            editrm.Reason_Name = txtReasonName.Text;
            editrm.Category_ = ddeCategory.SelectedValue;
            editrm.Modified_By = session.User_Id;
            editrm.Modified_By = "1";

          



            
            rm.ModifyReasons(editrm);

            Response.Redirect("RejectReasons.aspx",false);


        }

        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            try
            {

                //if (txtRejectCodeadd.Text == "")
                //{
                //    lblerroradddRejectCode.Text = "Please Fill out the reject Code to continue.";
                //    mp2.Show();
                //    return;
                //}
                if (txtReasonNameadd.Text == "")
                {
                    lblerroraddReasonName.Text = "Please Fill out the Reason Name to continue.";
                    mp2.Show();
                    return;
                }

                if (ddCategory.SelectedValue == "")
                {
                    lblerrorreasoncategory.Text = "Please Select Category to continue.";
                    mp2.Show();
                    return;
                }

               

                DCISDBManager.objLib.MasterMaintenance.ReasonsMaintenance addrm = new ReasonsMaintenance();
           //     addrm.Reject_Code = txtRejectCodeadd.Text;
                addrm.Reason_Name = txtReasonNameadd.Text;
                addrm.Category_ = ddCategory.SelectedValue;
                addrm.Created_By = session.User_Id;
                //addrm.Created_By = "1";
                addrm.Is_Active = "y";


                rm.CreateReasons(addrm);

                Response.Redirect("RejectReasons.aspx",false);


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