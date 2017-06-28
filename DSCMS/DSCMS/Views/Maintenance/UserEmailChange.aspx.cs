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
using DCISDBManager.objLib.Email;
using DCISDBManager.trnLib.UserManagement;
using DCISDBManager.trnLib.CertificateManagement;

namespace DSCMS.Views.Maintenance
{
    public partial class UserEmailChange : System.Web.UI.Page
    {
        UserSession session;
        
        CertficateRequestDataManagement crm = new CertficateRequestDataManagement();
        DownloadCertificate dc = new DownloadCertificate();
        UserManager UM=new UserManager();
        EmailRequest er = new EmailRequest();
        protected void Page_Load(object sender, EventArgs e)
        {
            session=new UserSession(); 
            if (!Page.IsPostBack)
            {


                BindGrid();
                BindDropDown();

            }


        }


        private void UserAuthentication()
        {
            try
            {

                if (session.User_Id == "")
                {
                    Response.Redirect("~/Views/Home/Login.aspx");
                }
                string groupId = session.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "UsrEmailc");
                if (auth == false)
                {
                    Response.Redirect("~/Views/Home/Forbidden.aspx");
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("~/Views/Home/Login.aspx");
            }
        }


        public void BindGrid()
        {
            try
            {
                // GridView1.DataSource = rm.getReasons("%");
                //  GridView1.DataSource = rm.getTemplateSupportingDocument("%", "y");
                GridView1.DataSource = crm.getUserEmail("%");

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



                ddUserID.DataSource = crm.getCustomerUser("%");
                ddUserID.DataTextField = "Person_Name";
                ddUserID.DataValueField = "User_ID";
               ddUserID.DataBind();
                





                //ddSDocName.DataSource = rm.getSupportDocNameforTemplate("%");
                //   ddSDocName.DataSource = sdm2.getSupportingDocumentn("%", "y");


                //  ddSDocName.DataTextField = "SupportingDocument_Name";
                // ddSDocName.DataValueField = "SupportingDocument_Id";
                // ddSDocName.DataBind();




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

                txteUserID.Text = row.Cells[1].Text;
                txteUserName.Text = row.Cells[0].Text;
                txteCusID.Text = row.Cells[2].Text;
                txteEmail.Text = row.Cells[3].Text;





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

         
            Response.Redirect("TemplateSupportingDocument.aspx", false);



        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {






                //DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument chageStatus = new DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument();
           ;

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
           
            if (txteEmail.Text == "")
            {
                lblError.Text = "Please Fill Email Address to continue.";
                mp1.Show();
                return;
            }



            DCISDBManager.objLib.Email.EmailCertificateConfig editcc = new DCISDBManager.objLib.Email.EmailCertificateConfig();


            editcc.User_ID = txteUserID.Text;
            editcc.Email_ = txteEmail.Text;

            crm.ModifyUserEmail(editcc);

            Response.Redirect("UserEmailChange.aspx", false);


        }
        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            
            if (ddUserID.SelectedValue == "")
            {
               lblerrorn.Text = "Please Select User Name to continue.";
                mp2.Show();
                return;
            }

            if (txtAEmail.Text== "")
            {
                lblerrorn.Text = "Please Fill Email Address to continue.";
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

                add.User_ID = ddUserID.SelectedValue;
                add.Customer_ID = dc.getCustIDfrmUserID(add.User_ID);
                add.Email_ = txtAEmail.Text;
           
                // String tempID=rm.getTemplateID(ddTemplateName.SelectedValue);
                //  String supDoc = rm.getDocID(ddAddDocumentName.SelectedValue);

                //  addts.Template_Id = ddTemplateName.SelectedValue;
                if ( true)
                {
                    crm.setUserEmail(add);
                }
                else {
                    mp2.Show();
                    return;
                
                }

                Response.Redirect("UserEmailChange.aspx", false);

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