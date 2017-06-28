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
using System.IO;
using DCISDBManager.trnLib.CheckAuth;



namespace DSCMS.Views.Maintenance
{
    public partial class UploadTemplate : System.Web.UI.Page
    {
      UserSession session;
        PackageTypeManagement pt = new PackageTypeManagement();
        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            session = new UserSession();
            if (!Page.IsPostBack)
            {
               
                BindGrid();
                
                

                if (session.User_Id == "")
                {
                    Response.Redirect("~/Views/Home/Login.aspx");
                }

                string groupId = session.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "upt");
                //if (auth == false)
                //{
                //    Response.Redirect("~/Views/Home/Login.aspx");
                //}

             
            }
        }

        public void BindGrid()
        {
            try
            {
               
                TemplateManagement tm = new TemplateManagement();
                GridView1.DataSource = tm.getTemplateData("%", "y");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                System.Console.Error.Write(ex.Message);

            }

        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void Upload(object sender, EventArgs e)
        {
            try
            {
                string subPath = "~/img/Images/"; // your code goes here

                bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

                if (!exists)
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

                if (FileUpload1.HasFile)
                {
                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/Images/") + fileName);
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {

                    Label1.Text = "Error Uploading the file. Make sure to select A correct file type";
                }
            }
            catch {

                Label1.Text = "Error Uploading the file. Make sure to select A correct file type";
            
            }
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            btnShow.Visible = true;
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                 txtPackageID.Text = row.Cells[0].Text;
                txtPackageDescription.Text = row.Cells[1].Text;
                // txtPersonName.Text = row.Cells[2].Text;
                mp1.Show();
            }
           

        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnShow.Visible = false;
            Response.Redirect("UploadTemplate.aspx", false);


}

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            TemplateManagement tm = new TemplateManagement();
            TemplateHeader th = new TemplateHeader();
            th.Template_Name = txtPackageID.Text;
             th.Modified_By = session.User_Id;
           // th.Modified_By = "1";
            th.Is_Active = "N";
            tm.ModifyTemplateHeaderStatus(th);

            Response.Redirect("UploadTemplate.aspx", false);
        
        
        
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                
                txtPackageID.Text = row.Cells[0].Text;
               // th.Modified_By = session.User_Id;
             
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            


            if (txtPackageDescription.Text == "")
            {
                lblError.Text = "Please Fill out the Package Name to continue.";
                mp1.Show();
                return;
            }


            DCISDBManager.objLib.MasterMaintenance.Packagetype editpt = new Packagetype();


            
            editpt.Package_Type = txtPackageID.Text;

            editpt.Package_Description = txtPackageDescription.Text;
            editpt.Modified_By = session.User_Id;



           // sdm.ModifySupportingDocument(editsd);
            pt.ModifyPackageType(editpt);
            btnShow.Visible = false;

            Response.Redirect("UploadTemplate.aspx", false);


        }

        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTemplateNameAdd.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the Template Name to continue.";
                    mp2.Show();
                    return;
                }
                if (txtTemplateDescriptionAdd.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the Template Desciption to continue.";
                    mp2.Show();
                    return;
                }

                String ext = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (ext.ToLower() != ".jpg" && ext.ToLower() != ".png" && ext.ToLower() != ".gif" && ext.ToLower() != ".jpeg")
                {
                    Label1.Text = "Please Upload a Correct File Type to Continue.";
                    mp2.Show();
                    return;
                }
                string subPath = "~/img/Images/"; // your code goes here

                bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

                if (!exists)
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));



                if (FileUpload1.HasFile)
                {
                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/Images/") + fileName);
                   // Response.Redirect(Request.Url.AbsoluteUri);
                    TemplateHeader th = new TemplateHeader();
                    th.Template_Name = txtTemplateNameAdd.Text;
                   th.Modified_By = session.User_Id;
                  //  th.Created_By = session.User_Id;
                  //  th.Modified_By = "1";
                    th.Created_By = session.User_Id;
                    th.Description_ = txtTemplateDescriptionAdd.Text;
                    th.Img_Url = "/img/Images/" + fileName;
                    th.Is_Active = "Y";
                    TemplateManagement tm = new TemplateManagement();
                    tm.CreateTemplate(th);


                }


                else {

                    lblerroradddn.Text = "no File Selected";
                    mp2.Show();
                    return;
                }

/*
                if (txtPackageTypeAdd.Text == "")
                {
                    lblerroradddid.Text = "Please Fill out the Package type to continue.";
                    mp2.Show();
                    return;
                }  */
              

               
               

                Response.Redirect("UploadTemplate.aspx", false);


            }
            catch (Exception es)
            {
                //lblerroradddn.Text = "chose correct file type";
                //mp2.Show();
                //return;

              System.Console.Error.Write(es.Message);

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