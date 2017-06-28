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
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.trnLib.CustomerRequestManagement;


namespace DSCMS.Views.Maintenance
{
    public partial class UserEmail : System.Web.UI.Page
    {
        UserSession session;
        CustomerDetailManager cdm = new CustomerDetailManager();
        SupportingDocumentManagement sdm = new SupportingDocumentManagement();
        CertficateRequestDataManagement crm = new CertficateRequestDataManagement();
        TemplateForSupportingDocumentManagement rm = new TemplateForSupportingDocumentManagement();
        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
        // string StringTemp ="acv";
        string StringTemp { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            session = new UserSession();

            if (session.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "tsd");
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
                // GridView1.DataSource = rm.getReasons("%");
                //  GridView1.DataSource = rm.getTemplateSupportingDocument("%", "y");
                GridView1.DataSource = crm.getRequestDetail("%");

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

                ddCustomerName.DataSource = cdm.getAllCustomer("y");
                ddCustomerName.DataTextField = "CustomerName1";
                ddCustomerName.DataValueField = "CustomerId1";

                ddCustomerName.DataBind();
            

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
                TxtCustomerID.Text = row.Cells[0].Text;
                txtTemplateName.Text = row.Cells[1].Text;
                txtHeight.Text = row.Cells[4].Text;
                txtWidth.Text = row.Cells[5].Text; ;
                txtXCord.Text = row.Cells[2].Text; ;
                txtYcord.Text = row.Cells[3].Text; ;





                mp1.Show();
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument chageStatus = new DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument();
            //  String tempID=rm.getTemplateID(row.Cells[0].Text);
           // chageStatus.Template_Id = TxttempID.Text;
            chageStatus.Is_Active = "n";
            chageStatus.Modified_By = session.User_Id;
          //  chageStatus.SupportingDocument_Id = ddSDocName.SelectedValue;

            rm.ModifyTemplateSupportingDocumentStatus(chageStatus);
            Response.Redirect("TemplateSupportingDocument.aspx", false);



        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();
            
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
               
               




                    //DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument chageStatus = new DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument();
                    TxtCustomerID.Text = row.Cells[0].Text;
                    txtTemplateName.Text = row.Cells[1].Text;
                    txtHeight.Text = row.Cells[4].Text;
                    txtWidth.Text = row.Cells[5].Text; ;
                    txtXCord.Text = row.Cells[2].Text; ;
                    txtYcord.Text = row.Cells[3].Text; ;

                    //chageStatus.Template_Id = tempID;
                    //chageStatus.Is_Active = "n";
                    //chageStatus.Modified_By = session.User_Id;
                    //chageStatus.SupportingDocument_Id = lblSupDoc.Text;

                    //rm.ModifyTemplateSupportingDocumentStatus(chageStatus);
                
                // rm.ModifyReasonsStatus(changeStatus);


                //  Response.Redirect("TemplateSupportingDocument.aspx", false);



            }




        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtHeight.Text== "")
            {
               lblError.Text = "Please Enter a value for Height to continue.";
               mp1.Show();
               return;
            }
            if (txtWidth.Text == "")
            {
                lblError.Text = "Please Enter a value for Width to continue.";
                mp1.Show();
                return;
            }
            if (txtXCord.Text == "")
            {
                lblError.Text = "Please Enter a value for X-Cordinate to continue.";
                mp1.Show();
                return;
            }
            if (txtYcord.Text == "")
            {
                lblError.Text = "Please Enter a value for Y-Cordinate to continue.";
                mp1.Show();
                return;
            }




            DCISDBManager.objLib.Email.EmailCertificateConfig editcc = new DCISDBManager.objLib.Email.EmailCertificateConfig();
            editcc.Customer_ID = TxtCustomerID.Text;

            //editcc.Email_ = "erer";
            editcc.URX_cordinates = Convert.ToDouble(txtHeight.Text);
            editcc.URY_cordinates = Convert.ToDouble(txtWidth.Text);
            editcc.LLX_Cordinates = Convert.ToDouble(txtXCord.Text);
            editcc.LLY_Cordinates = Convert.ToDouble(txtYcord.Text);
            crm.ModifyCertificateConfig(editcc);


            //  editts.Template_Id = rm.getTemplateID(a);








            Response.Redirect("UserEmail.aspx", false);


        }
        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            
            if (ddCustomerName.SelectedValue == "")
            {
                lblerrorr.Text = "Please Select Customer Name to continue.";
                mp2.Show();
                return;
            }

            if (txtAHeight.Text == "")
            {
                lblerrorr.Text = "Please Select value for height to continue.";
                mp2.Show();
                return;
            }
            if (txtAWidth.Text == "")
            {
                lblerrorr.Text = "Please Select value for width to continue.";
                mp2.Show();
                return;
            }
            if (txtAXcord.Text == "")
            {
                lblerrorr.Text = "Please Select value for X-Coordinate to continue.";
                mp2.Show();
                return;
            }
            if (txtAYCord.Text == "")
            {
                lblerrorr.Text = "Please Select value for Y-Coordinate to continue.";
                mp2.Show();
                return;
            }
           
            
            //    if (txtTaxCode.Text == "")
            //    {
            //        lblError.Text = "Please Fill out the Tax Code to continue.";
            //        mp1.Show();
            //        return;
            //    }


            // lblerrorr
            try
            {


                DCISDBManager.objLib.Email.EmailCertificateConfig add = new DCISDBManager.objLib.Email.EmailCertificateConfig();
                // String tempID=rm.getTemplateID(ddTemplateName.SelectedValue);
                //  String supDoc = rm.getDocID(ddAddDocumentName.SelectedValue);

              //  addts.Template_Id = ddTemplateName.SelectedValue;
                add.Customer_ID = ddCustomerName.SelectedValue;
                add.URX_cordinates = Convert.ToDouble(txtAHeight.Text);
                add.URY_cordinates = Convert.ToDouble(txtAWidth.Text);
                add.LLX_Cordinates = Convert.ToDouble(txtAXcord.Text);
                add.LLY_Cordinates = Convert.ToDouble(txtAYCord.Text);
                if (crm.setCertificateConfig(add) == false) {

                    lblerrorr.Text = "Customer is already assigned with coordinates.";
                    mp2.Show();
                    return;
                }
                crm.setCertificateConfig(add);

                Response.Redirect("UserEmail.aspx", false);

                /*
                if (rm.CheckTaTempIDSupID(addts.Template_Id, addts.SupportingDocument_Id) == false)
                {
                    rm.CreateTemplateSupportingDocument(addts);
                }
                else
                {

                    lblerrorr.Text = " This Supporting Document is Already Assigned  to the Template.";
                    mp2.Show();
                    return;

                }*/





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