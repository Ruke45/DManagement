using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Certificate;
using DCISDBManager.trnLib.SupportDocumentSignManagement;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.MasterDataManagement;
using System.IO;

using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.objLib.Master;

namespace DSCMS.Views.SupportingDoc
{
    public partial class SDApproval : System.Web.UI.Page
    {
        SDocSignRequsetManager SDSignMngr = new SDocSignRequsetManager();
        //SDSignatureConfig SDConfig = null;

        UserSession usrSession;
        CheckAuthManager authorized;

        //string Customer_GropID = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
        //string SAdmin_GropID = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
        //string UserGroupID_CustomerAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
        string ExpireDays = System.Configuration.ConfigurationManager.AppSettings["CertificateExpire"];

        protected void Page_Load(object sender, EventArgs e)
        {
            usrSession = new UserSession();
            authorized = new CheckAuthManager();

            if (usrSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Logout.aspx");
            }
            bool resutl = authorized.IsUserGroupAuthorised(usrSession.User_Group, "SDAP");
            if (resutl == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            if (!IsPostBack)
            {
                setGrid();
                getRejectResons();
            }
        }

        private void setGrid()
        {
            gvPendigSDR.DataSource = SDSignMngr.DCISgetPendingSDApprovals("P","%").SDPendingApproval_List;
            gvPendigSDR.DataBind();
        }

        private void getRejectResons()
        {
            try
            {
                RejectResonManagment ReM = new RejectResonManagment();
                drpRejectReason.DataSource = ReM.getSDRejectResons();
                drpRejectReason.DataTextField = "Reason_";
                drpRejectReason.DataValueField = "Reason_Code";
                drpRejectReason.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void linkDownDoc_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            //    {
            //        Label lblRequestID = (Label)row.Cells[0].FindControl("lblRequestID");
            //        Label lblUploadPath = (Label)row.Cells[0].FindControl("lblUploadPath");
            //        Label lblDocName = (Label)row.Cells[0].FindControl("lblDocName");
            //        Response.ContentType = "APPLICATION/OCTET-STREAM";
            //        String Header = "Attachment; Filename=" + lblDocName.Text;
            //        Response.AppendHeader("Content-Disposition", Header);
            //        System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath(lblUploadPath.Text));
            //        Response.WriteFile(Dfile.FullName);
            //        //Don't forget to add the following line
            //        Response.End();
            //    }
            //}
            //catch (Exception Ex)
            //{
            //    string qu = null;
            //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //    qu += " <strong> Error ! </strong>Unable To Download The File....</div>";
            //    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            //    ErrorMessage.InnerHtml = qu;
            //    ErrorLog.LogError(Ex);
            //}
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Label lblPath = (Label)row.FindControl("lblUploadPath");
                    Label lblRequestID = (Label)row.FindControl("lblRequestID");
                    Session["PDFUrl"] = lblPath.Text;
                    string pageurl = "PdfView.aspx?ID=" + lblRequestID.Text + "&DN=" + lblRequestID.Text + ".pdf";
                    // Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_blank');", true);
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void linbtnApprove_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                //Find the DropDownList in the Row
                Label lblRequestID = (Label)row.Cells[0].FindControl("lblRequestID");
                Label lblUploadPath = (Label)row.Cells[0].FindControl("lblUploadPath");
                Label lblDocID = (Label)row.Cells[0].FindControl("lblDocID");

                lblApporveRequestID.Text = lblRequestID.Text;
                lblApprovDocPath.Text = lblUploadPath.Text;
                lblSDID.Text = lblDocID.Text;

                
            }
            lblError.Text = "";
            mpApprove.Show();
        }

        protected void linbtnReject_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                lblRejectRequestID.Text = row.Cells[0].Text;
                mpReject.Show();
            }

        }

        protected void gvPendigSDR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.setGrid();
            gvPendigSDR.PageIndex = e.NewPageIndex;
            gvPendigSDR.DataBind();
        }

        protected void btnApproveDcouemnt_Click(object sender, EventArgs e)
        {
            //SDConfig = SDSignMngr.getSDSignatureConfig(lblSDID.Text);
            //if (SDConfig == null)
            //{
            //    string qu = null;
            //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //    qu += " <strong> Error ! </strong>Supporting Document Signature Placement is Not Configured..";
            //    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

            //    ErrorMessage.InnerHtml = qu;
            //    return;
            //}
              try
              {

                string DirectoryPath = "~/Documents/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("yyyy_MM_dd") + "/Supporting-Doc/" + lblApporveRequestID.Text;
                if (!Directory.Exists(Server.MapPath(DirectoryPath+ "/Temp")))
                {
                    Directory.CreateDirectory(Server.MapPath(DirectoryPath+ "/Temp"));
                }

                //SequenceManager seqmanager = new SequenceManager();
                //string Certificate_No = seqmanager.getNextSequence("CertificateSign").ToString();

                string NotSigned = Server.MapPath(lblApprovDocPath.Text);
                string Sealed = Server.MapPath(DirectoryPath + "/Temp/" + lblApporveRequestID.Text + "_Seald-Document.pdf");
                string Signed = Server.MapPath(DirectoryPath + "/" + lblApporveRequestID.Text + "_Signed-Document.pdf");
                string pathe = Server.MapPath(usrSession.PFX_path);//From DB
               // string pathe = Server.MapPath("~/Signature/Samitha/Samitha.pfx");//From DB
                string SignatureIMG = Server.MapPath(usrSession.SignatureIMG_Path);// From DB
              //  string SignatureIMG = Server.MapPath("~/Signature/Samitha/Chernenko_Signature.png");// From DB

                

                PDFCreator.Signature SignCertificate = new PDFCreator.Signature();

                SignCertificate.AddSealSD(NotSigned, Sealed, Server.MapPath(usrSession.SignatureIMG_Path));

                var PFX = new FileStream(pathe, FileMode.OpenOrCreate);

                bool singed = SignCertificate.signSupportingDoc(lblApporveRequestID.Text, Sealed, Signed, PFX, txtCertificatePass.Text);//Sign Confiauration need
                if (singed)
                {
                    SupportingDocUpload  Approve = new SupportingDocUpload();
                    Approve.Certified_Doc_Name = lblApporveRequestID.Text + "_Signed-Document.pdf";
                    Approve.Certified_Doc_Path = DirectoryPath + "/" + lblApporveRequestID.Text + "_Signed-Document.pdf";
                    Approve.Approved_By = usrSession.User_Id;
                   
                    Approve.Expire_Date = DateTime.Today.AddDays(Convert.ToInt64(ExpireDays)).ToString();
                    Approve.Request_Ref_No = lblApporveRequestID.Text;
                    bool result = SDSignMngr.ApproveSupportingDoc(Approve);
                    if (result)
                    {
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-success\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " <strong> Successful ! </strong>Document Approval Successful.";
                        qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                        ErrorMessage.InnerHtml = qu;
                        setGrid();
                    }
                    else
                    {
                        
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warning\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " <strong> Error ! </strong>Document Approval Faild.";
                        qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                        ErrorMessage.InnerHtml = qu;
                    }
                }
                else
                {
                    PFX.Close();
                    mpApprove.Show();
                    lblError.Text = "Wrong password or Corrupted Certificate file.";
                }
            }
            catch (Exception Ex)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong>Exception Error ! </strong>Document Approval Faild..Please Contact The Administrator";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                ErrorMessage.InnerHtml = qu;
                ErrorLog.LogError(Ex);
            }
        }

        protected void btnRejectReq_Click(object sender, EventArgs e)
        {
            if (drpRejectReason.SelectedIndex == 0)
            {
                lblRejectError.Text = "Please Select a Reject Reson First.";
                mpReject.Show();
                return;
            }

            SupportingDocUpload SD = new SupportingDocUpload();
            SD.Request_Ref_No = lblRejectRequestID.Text;
            SD.Approved_By = usrSession.User_Id;

            bool result = SDSignMngr.RejectSupportingDoc(SD, drpRejectReason.SelectedValue);
            if (result)
            {
                setGrid();
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-success\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Success ! </strong>Document Rejected...</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }
            else
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Faild to Complete the Task Please Try Again Later.</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }


        }
    }
}