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
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.MasterMaintenance;
using System.Reflection;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;

namespace DSCMS
{
    public partial class UnitChargeMaintenance : System.Web.UI.Page

    {
        UserSession session ;
        DCISDBManager.trnLib.MasterMaintenance.UnitChargeMaintenance CUC = new DCISDBManager.trnLib.MasterMaintenance.UnitChargeMaintenance();
        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["ExpiryDate"];

        
        protected void Page_Load(object sender, EventArgs e)
        {
            session = new UserSession();

            
                        if (session.User_Id=="")
                        {
                            Response.Redirect("~/Views/Home/Login.aspx");
                        }
                        string groupId = session.User_Group;
                        CheckAuthManager Am = new CheckAuthManager();
                        bool auth = Am.IsUserGroupAuthorised(groupId, "ucm");
                        if (auth == false)
                        {
                            Response.Redirect("~/Views/Home/Login.aspx");
                        }


            if (!Page.IsPostBack)
            {


                BindGrid();
                BindDropDown();
                

            }
         
        }

        public void BindGrid()
        {
            try
            {
              //  GridView1.DataSource = CUC.getUnitCharge("%");
                GridView1.DataSource = CUC.getUnitChargen("%");
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

        public void BindDropDown()
        {
            try
            {
                ddTemplateID.DataSource = CUC.getTemplateID("%");
                ddTemplateID.DataTextField = "Template_Name";
                ddTemplateID.DataValueField = "Template_Id";
                ddTemplateID.DataBind();



            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }
 



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Label lblTemp = null;
            lblError.Text = null;
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                

                lblTemp = (Label)row.FindControl("lblTemplateID");
                txtTemplateID.Text = lblTemp.Text;
                
                txtUnitChargeValue.Text = row.Cells[2].Text;
             
                mp1.Show();
            }

        }
       
        protected void Delete_Click(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            decimal d;
            if (decimal.TryParse(txtUnitChargeValue.Text, out d))
            {

            }
            else
            {
                lblError.Text = "Please Fill out the UnitCharge Value Correctly to continue.";
                mp1.Show();
                return;
            }


            if (txtUnitChargeValue.Text == "")
            {
                lblError.Text = "Please Fill out the Supporting Document Name to continue.";
                mp1.Show();
                return;
            }


            
            CertificateUnitCharge editcuc = new CertificateUnitCharge();
            editcuc.Template_Id = txtTemplateID.Text;
            editcuc.Created_By = session.User_Id;
            editcuc.Modified_By = session.User_Id;
            editcuc.UnitCharge_Value = Decimal.Parse(txtUnitChargeValue.Text);
         
            CUC.ModifyUnitCharge(editcuc);

          

            Response.Redirect("UnitChargeMaintenance.aspx",false);


        }

        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            try
            {
                //decimal d;
                //if (decimal.TryParse(txtUnitChargeAdd.Text, out d))
                //{
                   
                //}
                //else
                //{
                //    lblerroradddn.Text = "Please Fill out the UnitCharge Value Correctly to continue.";
                //    mp2.Show();
                //    return;
                //}


                if (txtUnitChargeAdd.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the UnitCharge Vlaue  to continue.";
                    mp2.Show();
                    return;
                }

               
                CertificateUnitCharge createuc = new CertificateUnitCharge();
               
                createuc.Template_Id = ddTemplateID.SelectedValue;
                createuc.Is_Active = "y";

               // createuc.UnitCharge_Value = Decimal.Parse(txtUnitChargeAdd.Text);Convert.ToDecimal(txtUnitChargeAdd.Text)
                    createuc.UnitCharge_Value =Convert.ToDecimal(txtUnitChargeAdd.Text);
                    createuc.Modified_By = session.User_Id;
                    createuc.Created_By = session.User_Id;
                    if (CUC.CheckTempID(createuc.Template_Id) == false)
                    {
                        CUC.CreateUnitCharge(createuc);
                    }
                    else
                    {
                        lblerroradddn.Text = " UnitCharge Value is Already asigned to the Template.";
                        mp2.Show();
                        return;
                    }


              //  sdm.CreateSupportingDocument(sd);
                Response.Redirect("UnitChargeMaintenance.aspx",false);


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
  
    
