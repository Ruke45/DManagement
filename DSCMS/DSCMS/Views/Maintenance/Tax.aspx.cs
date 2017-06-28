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

using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.MasterMaintenance;
using System.Reflection;
using System.Windows;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;


namespace DSCMS
{
    public partial class Tax : System.Web.UI.Page
    {
        TaxDataMaintenance tdm = new TaxDataMaintenance();
        UserSession session;
        String a;
        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];

      //  SupportingDocumentManagement sdm = new SupportingDocumentManagement();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            session = new UserSession();

            if (session.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "tx");
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
                GridView1.DataSource = tdm.getTaxData("%","y");
               
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
                ddTaxPriorityadd.DataSource = tdm.getTaxPriorityList("%");
                ddTaxPriorityadd.DataTextField = "Priority_No";
                ddTaxPriorityadd.DataValueField = "Priority_No";
                ddTaxPriorityadd.DataBind();


                ddeTaxPriority.DataSource = tdm.getTaxPriorityList("%");
                ddeTaxPriority.DataTextField = "Priority_No";
                ddeTaxPriority.DataValueField = "Priority_No";
                ddeTaxPriority.DataBind();


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
                TxteID.Text = row.Cells[0].Text;
                txtTaxName.Text = row.Cells[1].Text;
                txtTaxCode.Text = row.Cells[0].Text;
                 txtTaxPercentages.Text = row.Cells[2].Text;
                 ddeTaxPriority.SelectedValue = row.Cells[3].Text;
                // txtPersonName.Text = row.Cells[2].Text;
                mp1.Show();
            }

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
           

            txtTaxCode.Text = row.Cells[0].Text;
           
            }
            


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DCISDBManager.objLib.MasterMaintenance.Tax changeStatus = new DCISDBManager.objLib.MasterMaintenance.Tax();
            changeStatus.Is_Active = "n";
            changeStatus.Modified_By = session.User_Id;

            changeStatus.Tax_Code = txtTaxCode.Text;
            tdm.ModifyTaxDataStatus(changeStatus);
            Response.Redirect("Tax.aspx", false);
        
        
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            if (txtTaxCode.Text == "")
            {
                lblError.Text = "Please Fill out the Tax Code to continue.";
                mp1.Show();
                return;
            }

            if (txtTaxName.Text == "")
            {
                lblError.Text = "Please Fill out the Tax Name to continue.";
                mp1.Show();
                return;
            }

          
           /*
            if (txtTaxPercentages.Text == "" || Int32.Parse(txtTaxPercentages.Text)>100)
            {
                lblError.Text = "Please Fill out the Tax Percentages Correctly to continue.";
                mp1.Show();
                return;
            }
*/
            if (txtTaxPercentages.Text == "" )
            {
                lblError.Text = "Please Fill out the Tax Percentages Correctly to continue.";
                mp1.Show();
                return;
            }

            if (ddeTaxPriority.SelectedValue == "")
            {
                lblError.Text = "Please Select Tax Priority  to continue.";
                mp1.Show();
                return;
            }


            
            

                DCISDBManager.objLib.MasterMaintenance.Tax edittax = new DCISDBManager.objLib.MasterMaintenance.Tax();


             //   edittax.Tax_Id = TxteID.Text;

                edittax.Tax_Name = txtTaxName.Text;
                edittax.Tax_Code = txtTaxCode.Text;
                //edittax.Tax_Percentage = Int32.Parse(DDTaxPercentage.SelectedValue);
                edittax.Tax_Percentage = Convert.ToDecimal(txtTaxPercentages.Text);
                // edittax.Tax_Percentage = Int32.Parse(TextBox1.Text);
                edittax.Tax_Priority = int.Parse(ddeTaxPriority.SelectedValue.ToString());
                tdm.ModifyTaxData(edittax);
                Response.Redirect("Tax.aspx", false);
            

        }

        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaxCodeadd.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the Tax Code  to continue.";
                    mp2.Show();
                    return;
                }
                if (txtTaxNameadd.Text == "")
                {
                    lblerrorTaxNameadd.Text = "Please Fill out the Tax Code to continue.";
                    mp2.Show();
                    return;
                }


                //if (txtAddTaxPercentage.Text == "" || Int32.Parse(txtAddTaxPercentage.Text) > 100)
                if (txtAddTaxPercentage.Text == "" )
                  {
                   lblTaxPercentageAdd.Text = "Please Fill out the Tax Percentages Correctly to continue.";
                   mp2.Show();
                   return;
                }

                if (ddTaxPriorityadd.SelectedValue == "")
                  {
                      lblerrorTaxPriorityadd.Text = "Please Fill out Tax Priority to continue.";
                   mp2.Show();
                   return;
                }


                string a = txtTaxCodeadd.Text;
                if (tdm.CheckTaxCode(a) == false)
                {

                    DCISDBManager.objLib.MasterMaintenance.Tax addtax = new DCISDBManager.objLib.MasterMaintenance.Tax();
                    // addtax.Tax_Id = txtTaxIDAdd.Text;
                    addtax.Tax_Code = txtTaxCodeadd.Text;
                    addtax.Tax_Name = txtTaxNameadd.Text;
                    addtax.Is_Active = "y";
                    // addtax.Tax_Percentage = Int32.Parse(ddTaxPercentageadd.SelectedValue);
                    // txtAddTaxPercentage;
                    //addtax.Tax_Percentage = Int32.Parse(txtAddTaxPercentage.Text); Convert.ToDecimal();
                    addtax.Tax_Percentage = Convert.ToDecimal(txtAddTaxPercentage.Text);
                    // addtax.Tax_Priority = txtTaxPriorityadd.Text;
                    addtax.Tax_Priority = int.Parse(ddTaxPriorityadd.SelectedValue.ToString());

                    tdm.CreateTaxData(addtax);
                }
                else
                {
                    lblerroradddn.Text = " Tax Code Exists.";
                    mp2.Show();
                    return;
                    
                }
                Response.Redirect("Tax.aspx",false);


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

        protected void Addbutton_Click(object sender, EventArgs e)
        {

            txtTaxCodeadd.Text = null;
            txtTaxNameadd.Text = null;
            txtAddTaxPercentage.Text = null;

          

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mp1.Show();

        }





    }
}