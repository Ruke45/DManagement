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
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.objLib.CustomerRequest;

using DCISDBManager.objLib.Parameters;
using DCISDBManager.objLib.Email;
using DCISDBManager.trnLib.ParameterManagement;

using System.Net;
using System.Net.Mail;
using DCISDBManager.trnLib.Utility;

namespace DSCMS.Views.Maintenance
{
    public partial class CertificateStatus : System.Web.UI.Page
    {
       
             UserSession session;
             CustomerDetailManager cdm = new CustomerDetailManager();
             DownloadCertificate dc = new DownloadCertificate();
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


                String cusID = session.Customer_ID;

                GridView1.DataSource = dc.getcertificateStatus("%", "%", cusID);
                GridView1.DataBind();
               

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }
        protected void btnDelete_DataBinding(object sender, System.EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            LinkButton btn2 = (LinkButton)(sender);
            btn.Enabled = !Eval("Is_Downloaded").ToString().Equals("Rejected");
           
            btn2.Enabled = !Eval("Is_Downloaded").ToString().Equals("Approved"); 
      

        }

        protected override void OnInit(EventArgs e)
        {
            GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
            base.OnInit(e);
        }
        void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

          //  string Is_Downloaded;

            if (e.Row.Cells[1].Text == "Approved" || e.Row.Cells[1].Text == "Rejected")
                {
                    LinkButton btnEdit = (LinkButton)e.Row.FindControl("LinkDelete");
                    btnEdit.Visible = false;
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
                 txtPackageID.Text = row.Cells[0].Text;
                txtPackageDescription.Text = row.Cells[1].Text;
                // txtPersonName.Text = row.Cells[2].Text;
                mp1.Show();
            }
           

        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnShow.Visible = false;
            Response.Redirect("CertifcateDownload.aspx", false);


}
        protected void Confirm_Click(object sender, EventArgs e)
        {
            mp3.Show();
           
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                txtPackageID.Text = row.Cells[0].Text;
                //txtPackageID.Text = row.Cells[0].Text;
              //  DCISDBManager.objLib.MasterMaintenance.Packagetype inactive = new Packagetype();
              //  inactive.Modified_By = session.User_Id;
               // inactive.Package_Type = row.Cells[0].Text;
                //inactive.Is_Active = "n";
               // pt.ModifyPackageTypeStatus(inactive);
               

              //  Response.Redirect("PackageType.aspx",false);
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            String CustID;
            string SendEmailAddress;

            CustID = session.Customer_ID;
            

                 
            CustomerDetails cd = cdm.getRequestDetails(CustID);
            SendEmailAddress = cd.Email1;

            String AdminMsg="Certificate remider from Customer ID-"+CustID+" "+SendEmailAddress;
           string ClientEmailaddress="rangamaheshitha@gmail.com";

           sendEmail(AdminMsg, ClientEmailaddress);




           
            Response.Redirect("PackageType.aspx", false);




        }
        private bool sendEmail(string AdminMsg, string ClientEmailaddress)
        {

            ParameateManager pm = new ParameateManager();
            //   Parameters cryip = pm.getEmailPassword("EmailPassword");
            //   string cipherText = cryip.ParameterValue1;
            //    string AdminEmailaddress = cryip.ParameterDescription1;
            string AdminEmailaddress = "piumangunaratne@gmail.com";
            // string AdminEmailaddress = "rangamaheshitha123@yahoo.com";
            // string AdminPassword = Decrypt(cipherText, Key);

            string AdminPassword = "19910328";
            // string AdminPassword = "3ziobest";
            if (ClientEmailaddress == null)
            {
                try
                {
                    //CustomerDetailManager cm = new CustomerDetailManager();
                    //CustomerDetails cd = cm.getRequestDetails(CustometId);
                    //ClientEmailaddress = cd.Email1;
                    ClientEmailaddress = "rangamaheshitha@gmail.com";
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError(ex);
                }
            }
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(AdminEmailaddress);
                msg.To.Add(ClientEmailaddress);
                msg.Body = AdminMsg;
                //msg.Body = "asc";
                msg.IsBodyHtml = true;
                SmtpClient smpt = new SmtpClient();
                smpt.Host = "smtp.gmail.com";
                // smpt.Host = "smtp.mail.yahoo.com";

                System.Net.NetworkCredential net = new System.Net.NetworkCredential();
                net.UserName = AdminEmailaddress;
                net.Password = AdminPassword;
                smpt.UseDefaultCredentials = true;
                smpt.Credentials = net;
                smpt.Port = 587;
                // smpt.Port = 465;
                smpt.EnableSsl = true;
                smpt.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);


                // EmailManager em = new EmailManager();
                // Email msg = new Email();
                //msg.EmailAddress1 = ClientEmailaddress;
                // msg.EmailBody1 = AdminMsg;
                // checkmailInsert = em.setEmail(msg);
                return false;
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
                txtPackageID.Text = null;
                txtPackageDescription.Text = null;

                Response.Redirect("PackageType.aspx", false);
            
            


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
                if (txtPackageDescriptionAdd.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the Package description to continue.";
                    mp2.Show();
                    return;
                }
                if (txtPackageDescriptionAdd.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the Package description to continue.";
                    mp2.Show();
                    return;
                }
                if (pt.CheckPackageDescription(txtPackageDescriptionAdd.Text.Trim()) == false)
                {
                    DCISDBManager.objLib.MasterMaintenance.Packagetype PT = new Packagetype();
                    //PT.Package_Type = txtPackageTypeAdd.Text;
                    PT.Package_Description = txtPackageDescriptionAdd.Text;
                    PT.Created_By = session.User_Id;
                    PT.Is_Active = "y";
                    // sd.Created_By = "1";
                    pt.CreatePackageType(PT);
                    txtPackageID.Text = null;
                    txtPackageDescription.Text = null;

                    Response.Redirect("PackageType.aspx", false);
                }
                else {

                    lblerroradddn.Text = "This Package Name Already Exist.";
                    mp2.Show();
                    return;
                
                }

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
