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

namespace DSCMS.Views.maintenance
{
    public partial class TemplateSupportingDocument : System.Web.UI.Page
    {
        UserSession session ;
        SupportingDocumentManagement sdm = new SupportingDocumentManagement();
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
            //string groupId = session.User_Group;
            //CheckAuthManager Am = new CheckAuthManager();
            //bool auth = Am.IsUserGroupAuthorised(groupId, "tsd");
            //if (auth == false)
            //{
            //    Response.Redirect("~/Views/Home/Login.aspx");
            //}
            
           
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
                GridView1.DataSource = rm.getTemplateSupportingDocumentn("y");
                
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

                ddTemplateName.DataSource = rm.getTemplateNameforSupportDoc("%");
                ddTemplateName.DataTextField = "Template_Name";
                ddTemplateName.DataValueField = "Template_Id";

                ddTemplateName.DataBind();
                /*
                ddAddDocumentName.DataSource = rm.getSupportDocNameforTemplate("%");
                ddAddDocumentName.DataTextField = "SupportingDocument_Name";
                ddAddDocumentName.DataValueField = "SupportingDocument_Id";
                ddAddDocumentName.DataBind();
                */
                ddAddDocumentName.DataSource = sdm.getSupportingDocumentn("%", "y");
                ddAddDocumentName.DataTextField = "SupportingDocument_Name";
                ddAddDocumentName.DataValueField = "SupportingDocument_Id";
                ddAddDocumentName.DataBind();
                SupportingDocumentManagement sdm2 = new SupportingDocumentManagement();



              ddSDocName.DataSource = rm.getSupportDocNameforTemplate("%");
            //   ddSDocName.DataSource = sdm2.getSupportingDocumentn("%", "y");


                ddSDocName.DataTextField = "SupportingDocument_Name";
                ddSDocName.DataValueField = "SupportingDocument_Id";
                ddSDocName.DataBind();




            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Label lblTemp = null;
            Label lblSupDoc = null;
            Label lblTempSup = null;
           
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {

                lblTempSup = (Label)row.FindControl("lblTemplateSupDoc"); 
                lblTemp = (Label)row.FindControl("lblTemplateID");
                lblSupDoc = (Label)row.FindControl("lblSupDocID");
              //  StringTemp = lblTemp.Text;
                StringTemp = "a";
                TxttempID.Text = lblTemp.Text;
                TxtSupDOcid.Text = lblSupDoc.Text;
                TxtTemSup.Text = lblTempSup.Text;
                ddSDocName.SelectedValue = lblSupDoc.Text;


                txtTemplateName.Text = row.Cells[3].Text;
               
                if (row.Cells[5].Text == "y")
                {
                    RbtnIsMandetory.SelectedValue = "Yes";

                }

                else {

                    RbtnIsMandetory.SelectedValue = "No";
                
                }




                lblTemp = (Label)row.FindControl("lblTemplateID");
                if (lblTemp != null) {
                  string tempID = lblTemp.Text;
                
                }

             


                mp1.Show();
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
             DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument chageStatus = new DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument();
                    //  String tempID=rm.getTemplateID(row.Cells[0].Text);
             chageStatus.Template_Id = TxttempID.Text;
                    chageStatus.Is_Active = "n";
                    chageStatus.Modified_By = session.User_Id;
                    chageStatus.SupportingDocument_Id = ddSDocName.SelectedValue;

                    rm.ModifyTemplateSupportingDocumentStatus(chageStatus);
                    Response.Redirect("TemplateSupportingDocument.aspx", false);
                


        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();
            Label lblTemp = null;
            Label lblSupDoc = null;
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                lblTemp = (Label)row.FindControl("lblTemplateID");
                lblSupDoc = (Label)row.FindControl("lblSupDocID");
                TxttempID.Text = lblTemp.Text;
                ddSDocName.SelectedValue = lblSupDoc.Text;
                if (lblTemp != null)
                {
                    string tempID = lblTemp.Text;




                    //DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument chageStatus = new DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument();
                    ////  String tempID=rm.getTemplateID(row.Cells[0].Text);
                    //chageStatus.Template_Id = tempID;
                    //chageStatus.Is_Active = "n";
                    //chageStatus.Modified_By = session.User_Id;
                    //chageStatus.SupportingDocument_Id = lblSupDoc.Text;

                    //rm.ModifyTemplateSupportingDocumentStatus(chageStatus);
                }
               // rm.ModifyReasonsStatus(changeStatus);


              //  Response.Redirect("TemplateSupportingDocument.aspx", false);



            }




        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddSDocName.SelectedValue == "")
            {
                lblError.Text = "Please Select Document Name to continue.";
                mp1.Show();
                return;
            }

          

                
            DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument editts = new DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument();

            if (RbtnIsMandetory.SelectedValue == "Yes")
            {
                editts.Is_Mandatory = "y";

            }
            else {
                editts.Is_Mandatory = "n";
            
            }
          //  editts.Template_Id = rm.getTemplateID(a);
            editts.Template_Id = TxttempID.Text;

            editts.TemplateSupporting_Document = TxtTemSup.Text;
          //  editts.SupportingDocument_Id = rm.getDocID(b);
            editts.SupportingDocument_Id = ddSDocName.SelectedValue;

            editts.Modified_By = session.User_Id;
           
                if (rm.CheckTaTempIDSupID(editts.Template_Id, editts.SupportingDocument_Id) == false)
                {
                    rm.ModifyTemplateSupportingDocument(editts);
                }
                else
                {
                    if (TxtSupDOcid.Text == ddSDocName.SelectedValue)
                    {
                        rm.ModifyTemplateSupportingDocument(editts);
                    }
                    else
                    {

                        lblError.Text = " This Supporting Document is Already Assigned  to the Template.";
                        mp1.Show();
                        return;
                    }
                }

              



          //  rm.ModifyReasons(editrm);

            Response.Redirect("TemplateSupportingDocument.aspx", false);


        }
        protected void LinkButtonAdnew_Click(object sender, EventArgs e)
        {
           
            ddTemplateName.SelectedIndex = -1;
            ddAddDocumentName.SelectedIndex = -1;
        
            mp2.Show();

        }

        protected void btnSubmitA_Click(object sender, EventArgs e)
        {

            if (ddTemplateName.SelectedValue == "")
            {
                lblerrorr.Text = "Please Select Template Name to continue.";
                mp2.Show();
                return;
            }
            if (ddAddDocumentName.SelectedValue == "")
            {
                lblerrorr.Text = "Please Select Document Name to continue.";
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
                
                

                DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument addts = new DCISDBManager.objLib.MasterMaintenance.TemplateSupportingDocument();

               // String tempID=rm.getTemplateID(ddTemplateName.SelectedValue);
              //  String supDoc = rm.getDocID(ddAddDocumentName.SelectedValue);

                addts.Template_Id = ddTemplateName.SelectedValue;
                addts.SupportingDocument_Id = ddAddDocumentName.SelectedValue; 
                addts.Created_By = session.User_Id;
                addts.Is_Active = "y";
                if (RadioButtonList1.SelectedValue =="Yes")
                {

                    addts.Is_Mandatory = "y";
                }
                else {

                    addts.Is_Mandatory = "n";
                
                }

                if (rm.CheckTaTempIDSupID(addts.Template_Id, addts.SupportingDocument_Id) == false)
                {
                    rm.CreateTemplateSupportingDocument(addts);
                }
                else
                {

                    lblerrorr.Text = " This Supporting Document is Already Assigned  to the Template.";
                    mp2.Show();
                    return;

                }



                Response.Redirect("TemplateSupportingDocument.aspx", false);


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