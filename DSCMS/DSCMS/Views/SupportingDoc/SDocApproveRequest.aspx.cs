using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Certificate;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.ParameterManagement;
using System.IO;
using System.Transactions;
using DCISDBManager.trnLib.SupportDocumentSignManagement;

using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;


namespace DSCMS.Views.SupportingDoc
{
    public partial class SDocApproveRequest : System.Web.UI.Page
    {
        SupportingDocumentManagement SDManager = new SupportingDocumentManagement();
        SDocSignRequsetManager SDsign = new SDocSignRequsetManager();
        SupportingDocUpload SDocumnt = new SupportingDocUpload();

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
            bool resutl = authorized.IsUserGroupAuthorised(usrSession.User_Group, "SDAR");
            if (resutl == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }

            if (!IsPostBack)
            {
                getSupportingDoc();
            }

        }

        private void getSupportingDoc()
        {
            try
            {
                drpDocType.DataSource = SDManager.getSupportingDocumentn("%","Y");
                drpDocType.DataValueField = "SupportingDocument_Id";
                drpDocType.DataTextField = "SupportingDocument_Name";
                drpDocType.DataBind();
                drpDocType.Items.Insert(0, new ListItem(""));
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("SDcoApproveRequest.aspx (getSupportingDoc())",Ex);
            }
        }

        private void setSupportingDocReq()
        {
            if (drpDocType.SelectedIndex == 0)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error! </strong>Please Select a Supporting Document Type.";
                qu += "</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            try
            {
                //DirectoryPath which will save the NOT singed PDF File as NOT_Signed.pdf in the given Path
                if (btnSupDocUpload.HasFile)
                {
                    string DirectoryPath = "~/Documents/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("yyyy_MM_dd") + "/Supporting-Doc";

                    SDocumnt.Document_Id = drpDocType.SelectedValue;
                    SDocumnt.Customer_ID = usrSession.Customer_ID;
                    SDocumnt.Uploaded_By = usrSession.User_Id;
                    SDocumnt.Uploaded_Path = DirectoryPath;
                    SDocumnt.Status_ = "P";
                    SDocumnt.SupportingDoc_Name = btnSupDocUpload.FileName.Replace(" ", "_");

                    string Result = SDsign.setSupportingDocSignRequest(SDocumnt);

                    if (Result != null)
                    {

                        if (!Directory.Exists(Server.MapPath(DirectoryPath + "/" + Result)))
                        {
                            Directory.CreateDirectory(Server.MapPath(DirectoryPath + "/" + Result));
                        }
                        string file = Path.Combine(Server.MapPath(DirectoryPath + "/" + Result + "/"), btnSupDocUpload.FileName.Replace(" ", "_"));
                        btnSupDocUpload.SaveAs(file);

                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-success\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " <strong> Successful ! </strong>Request Successfull. Certificate Request ID : " + Result.ToString();
                        qu += "</div>";

                        ErrorMessage.InnerHtml = qu;

                    }
                    else
                    {
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warnnig\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " <strong> Error ! </strong> Unable to Performe the Request Please Try Again Later. : ";//+ result.String_Value;
                        qu += "</div>";

                        ErrorMessage.InnerHtml = qu;
                    }
                }
            }

            catch (Exception Ex)
            {
                ErrorLog.LogError("(SDcoApproveRequest.aspx)", Ex);

                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong> Unable to Performe the Request Please Try Again Later. ";//+ result.String_Value;
                qu += "</div>";

                ErrorMessage.InnerHtml = qu;
            }
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            setSupportingDocReq();
        }
    }
}