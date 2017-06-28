using DCISDBManager.objLib.Certificate;
using DCISDBManager.objLib.Master;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;


namespace DSCMS.Views.Certificate
{
    public partial class CertificateUpload : System.Web.UI.Page
    {
        CertificateRequestManager CerRqM = new CertificateRequestManager();

        UserSession usrSession;
        CheckAuthManager authorized;

        protected void Page_Load(object sender, EventArgs e)
        {
            usrSession = new UserSession();
            authorized = new CheckAuthManager();

            if (usrSession.User_Id == "" || usrSession.Customer_ID == "")
            {
                Response.Redirect("~/Views/Home/Logout.aspx");
            }
            bool resutl = authorized.IsUserGroupAuthorised(usrSession.User_Group, "CEUPL");
            if (resutl == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            if (usrSession.Template_ID == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error! </strong>Unable to detect Your Certificate Template...!";
                qu += "<div>";

                ErrorMessage.InnerHtml = qu;
                btnRequestCertificate.Visible = false;
                return;
            }
            if (!IsPostBack)
            {
                getSupportingDocuments();
            }
        

        }

        protected void getSupportingDocuments()
        {
            try
            {
                SupportingDocList newlist = new SupportingDocList();
                newlist = CerRqM.getSupportindDOCs(usrSession.User_Id, usrSession.Template_ID);//usrSessiong.User_Id, usrSessiong.Template_ID
                gvSupportingDOc.DataSource = newlist.SupportingDOCset;
                gvSupportingDOc.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        private int checkGridView()
        {
            int count = 0;
            foreach (GridViewRow row in gvSupportingDOc.Rows)
            {
                Label DocID = (Label)row.FindControl("lbleid");
                Label isMandotory = (Label)row.FindControl("lblIsmandatory");
                FileUpload fu = (FileUpload)row.FindControl("btnFileUpload");

                if (fu.HasFile == false)
                {
                    if (isMandotory.Text.ToUpper() == "Y")
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int isPDF()
        {
            int count = 0;
            foreach (GridViewRow row in gvSupportingDOc.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("chkRow");
                FileUpload fu = (FileUpload)row.FindControl("btnFileUpload");
                if (chkRow.Checked && fu.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(fu.PostedFile.FileName);
                    if (extension.ToLower() != ".pdf")
                    {
                        count++;
                    }
                }

            }
            return count;
        }

        private void UploadCertificate()
        {
            
                if (checkGridView() != 0)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error! </strong>Please Upload the Mandatory Supporting Documents Before Submitting.";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }

                if (isPDF() != 0)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error! </strong>Please Upload '.pdf' Format Supporting Documents if Needed to Be Signed. | or Rename the file if the File Name Has ()";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }

                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        string CertDirectoryPath = "~/Uploads/" + DateTime.Now.ToString("yyyy") + "/Upload-Based-Certifcates/" + DateTime.Now.ToString("yyyy_MM_dd");
                        string CertSavepath = string.Empty;
                        DCISDBManager.objLib.Certificate.CertificateRequest Cr = new DCISDBManager.objLib.Certificate.CertificateRequest();
                        if (btnCertUpload.HasFile)
                        {
                            CertSavepath = CertDirectoryPath + "/" + btnCertUpload.FileName.Replace(" ", "_");
                        }
                        Cr.Created_By = usrSession.User_Id;
                        Cr.Customer_ID = usrSession.Customer_ID;
                        Cr.Upload_Path = CertSavepath;
                        Cr.Invoice_No = txtInvoiceNo.Text;
                        Cr.Seal_Required = chckSealRequired.Checked.ToString();

                        string result = CerRqM.setUploadBasedCertificateRequest(Cr);
                        if (result != null)
                        {
                            if (!Directory.Exists(Server.MapPath(CertDirectoryPath)))
                            {
                                Directory.CreateDirectory(Server.MapPath(CertDirectoryPath));
                            }
                            string file = Server.MapPath(CertSavepath);
                            btnCertUpload.SaveAs(file);
                        }
                        foreach (GridViewRow row in gvSupportingDOc.Rows)
                        {
                            Label DocID = (Label)row.FindControl("lbleid");
                            FileUpload FileUploader = (FileUpload)row.FindControl("btnFileUpload");
                            CheckBox chkRow = (CheckBox)row.FindControl("chkRow");

                            string DirectoryPath = "~/Uploads/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("yyyy_MM_dd") + "/" + result;
                            if (FileUploader.HasFile)
                            {
                                if (!Directory.Exists(Server.MapPath(DirectoryPath)))
                                {
                                    Directory.CreateDirectory(Server.MapPath(DirectoryPath));
                                }
                                string file1 = Path.Combine(Server.MapPath(DirectoryPath + "/"), FileUploader.FileName.Replace(" ", "_"));
                                FileUploader.SaveAs(file1);

                                SupportingDocUpload objsup = new SupportingDocUpload();

                                objsup.Request_Ref_No = result;
                                objsup.Document_Id = DocID.Text.ToString();
                                if (chkRow.Checked)
                                {
                                    objsup._Remarks = "NCE_Certification";
                                    objsup.Signature_Required = true;
                                }
                                else { objsup._Remarks = ""; objsup.Signature_Required = false; }
                                objsup.Uploaded_By = usrSession.User_Id;
                                objsup.Uploaded_Path = DirectoryPath + "/" + FileUploader.FileName.Replace(" ", "_");
                                objsup.Document_Name = FileUploader.FileName.Replace(" ", "_");

                                CerRqM.setSupportingDocumentFRequest(objsup);

                            }

                        }

                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-success\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " Certificate Request Successfull. Certificate Request ID : " + result.ToString();
                        qu += "</div>";


                        ErrorMessage.InnerHtml = qu;

                        transactionScope.Complete();
                        transactionScope.Dispose();
                        getSupportingDocuments();

                        txtInvoiceNo.Text = string.Empty;
                        chckSealRequired.Checked = false;
                    }
                    catch (TransactionException Ex)
                    {
                        transactionScope.Dispose();
                        ErrorLog.LogError("Transaction Error (CertificateUpload.aspx)", Ex);

                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warning\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " <strong> Error (Transaction) ! </strong> Unable to Performe the Request Please Try Again Later. : ";//+ result.String_Value;
                        qu += "</div>";

                        ErrorMessage.InnerHtml = qu;
                    }
                    catch (Exception Ex)
                    {
                        ErrorLog.LogError("Upload Certificate (CertificateUpload.aspx)", Ex);
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warning\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " <strong> Error ! </strong> Unable to Performe the Request Please Try Again Later. : ";//+ result.String_Value;
                        qu += "</div>";

                        ErrorMessage.InnerHtml = qu;
                    }
                }
        }

        protected void btnRequestCertificate_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text.Equals(""))
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error! </strong>Please Enter the Certificate Inovice Number.";
                qu += "</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            UploadCertificate();
        }
    }
}