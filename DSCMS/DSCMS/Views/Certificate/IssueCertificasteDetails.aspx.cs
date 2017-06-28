using DCISDBManager.objLib.Certificate;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.MasterMaintenance;
using DCISDBManager.trnLib.Utility;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Certificate
{
    public partial class IssueCertificasteDetails : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();

            UserAutentication();
            string CertificateNo = Request.QueryString["CertificateNo"];
            string DocType = Request.QueryString["DocType"];
            try
            {
                if (CertificateNo != null)
                {
                    CertificateManager Cm = new CertificateManager();
                    CertificateRequestHeader value = Cm.getCertificateDetails(CertificateNo);
                    lblCertificateNo.Text = value.CertificateId1;
                    lblCertificateName.Text = value.CertificateName1;
                    lblApprovedDate.Text = value.SCreatedDate1;
                    lblExpiryDate.Text = value.SExpiryDate1;
                    lblApprovedBy.Text = value.CreatedBy1;
                    lblRequestId.Text = value.RequestId1;
                    lblDownload.Text = value.Download1;
                    lblCustomerName.Text = value.CustomerName1;
                    lblPath.Text = value.CertificatePath1;
                    lblDocType.Text = DocType;
                    lblCustomerId.Text = value.CustomerId1;
                    lblDocID.Text = CertificateNo;
                    if (lblPath.Text == "")
                    {
                        View.Visible = false;
                        lblmsg.Text = "Manually Entered Document";
                        lblmsg.Visible = true;
                    }
                    else {
                        View.Visible = true;
                        lblmsg.Visible = false;
                    }
                    ReasonsManagement rm = new ReasonsManagement();
                    string RejectCat = System.Configuration.ConfigurationManager.AppSettings["DocumentCancelationCategory"];
                    if (!IsPostBack)
                    {
                        drpRemark.DataSource = rm.getRejectReason(RejectCat);
                        drpRemark.DataTextField = "Reason_Name";
                        drpRemark.DataValueField = "Reject_Code";
                        drpRemark.DataBind();
                       
                    }

                }
            }
            catch(Exception ex){
                    ErrorLog.LogError(ex);
                }
        }
            


        private void UserAutentication()
        {
            try
            {
                if (userSession.User_Id == "")
                {
                    Response.Redirect("~/Views/Home/Login.aspx");
                }
                string groupId = userSession.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "DoCanc");
                if (auth == false)
                {
                    Response.Redirect("~/Views/Home/Forbidden.aspx");
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
        }


        protected void View_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Server.MapPath("~/Documents/Copy/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Documents/Copy/"));
                }


                string[] subdirectoryEntries = Directory.GetDirectories(Server.MapPath("~/Documents/Copy/"));

               
                foreach (string subdirectory in subdirectoryEntries)
                {
                    if (subdirectory != MapPath("~/Documents/Copy/" + DateTime.Now.ToString("yyyy_MM_dd")))
                    {
                        Directory.Delete(subdirectory, true);
                    }
                }

                int count = 0;
                string DirectPath = "~/Documents/Copy/" + DateTime.Now.ToString("yyyy_MM_dd") + "/";
                Label Path = null;

                Path = lblPath;
               
                
                string Fpath = Path.Text;
                string path1 = Fpath;// Fpath.Replace("~", "../..");
                string path2 = path1.Replace(".pdf", "(copy).pdf");
                char[] splitchar = { '/' };
                string filename = null;
                string[] strarry = path2.Split(splitchar);
                for (count = 0; count <= strarry.Length - 1; count++)
                {
                    filename = strarry[strarry.Length - 1];
                }
                string viewDirectPath1 = DirectPath + filename;
                string viewDirectPath = viewDirectPath1; //viewDirectPath1.Replace("~", "../..");
                if (!File.Exists(Server.MapPath(viewDirectPath1)))
                {
                    string WatermarkLocation = Server.MapPath("~/img/view_only.png");
                    string FileLocation = Server.MapPath(path1);

                    Document document = new Document();
                    PdfReader pdfReader = new PdfReader(FileLocation);
                    PdfStamper stamp = new PdfStamper(pdfReader, new FileStream(FileLocation.Replace(".pdf", "(copy).pdf"), FileMode.Create));

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(WatermarkLocation);
                    img.SetAbsolutePosition(125, 300); // set the position in the document where you want the watermark to appear (0,0 = bottom left corner of the page)



                    PdfContentByte waterMark;
                    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                    {
                        waterMark = stamp.GetOverContent(page);
                        waterMark.AddImage(img);
                    }
                    stamp.FormFlattening = true;

                    stamp.Close();
                    // pdfReader.Close();
                    // now delete the original file and rename the temp file to the original file
                    //File.Delete(FileLocation);
                    // File.Move(FileLocation.Replace(".pdf", "(copy).pdf"), FileLocation);

                    DateTime today = DateTime.Today;

                    //DirectoryPath which will save the NOT singed PDF File as NOT_Signed.pdf in the given Path
                    if (!Directory.Exists(Server.MapPath(DirectPath)))
                    {
                        Directory.CreateDirectory(Server.MapPath(DirectPath));
                    }

                   


                    string firstpath = MapPath(path2);

                    File.Move(firstpath, MapPath(viewDirectPath1));
                    Session["PDFUrl"] = viewDirectPath;
                    string pageurl = "PdfView.aspx";
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
                   // pop.Visible = true;
                   // string iframe = "<iframe src='" + viewDirectPath + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
                   // diviframe.InnerHtml = iframe;
                }
                else
                {
                    Session["PDFUrl"] = viewDirectPath;
                    string pageurl = "PdfView.aspx";
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
                    //pop.Visible = true;
                   // string iframe = "<iframe src='" + viewDirectPath + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
                   // diviframe.InnerHtml = iframe;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }


        protected void Hide_Click(object sender, EventArgs e)
        {
            //pop.Visible = false;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            confermation.Visible = true;
            string msg = "Are You Sure that You Want to Cancel ?";
                div2.InnerHtml=msg;
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            confermation.Visible = false;
           
        }

        protected void FinalSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                CertificateManager Cm = new CertificateManager();
                CertificateRequestHeader Values = new CertificateRequestHeader();
                Values.CertificateId1 = lblDocID.Text;
                Values.CustomerId1 = lblCustomerId.Text;
                Values.CreatedBy1 = userSession.User_Id;
                Values.InvoiceSupDocId1 =System.Configuration.ConfigurationManager.AppSettings["SupdocInvoiceRateId"];//get Supporting Document id For Invoice Rate

                if (lblDocType.Text == "CO")
                {
                    Values.DocType1 = "C";
                }
                else if (lblDocType.Text == "Invoice")
                {
                    Values.DocType1 = "I";

                }
                else
                {
                    Values.DocType1 = "O";

                }
                Values.Remark1 = drpRemark.SelectedValue;
                bool check = Cm.setCertificateCancelation(Values);
                if (check)
                {
                    string StartDate = Request.QueryString["StartDate"];
                    string EndDate = Request.QueryString["EndDate"];
                    string CustomerId = Request.QueryString["CustomerId"];
                    Response.Redirect("CertuificateDuplication.aspx?StartDate=" + StartDate + "&EndDate=" + EndDate + "&CustomerId=" + CustomerId, false);
                }
                else
                {
                    string msg = null;

                    msg += "<div class=\"alert alert-dismissable alert-warning\">";
                    msg += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    msg += " Save Fail, Try Agian.</div>";
                    ErrorMessage.InnerHtml = msg;
                    confermation.Visible = false;
                }
               
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            string StartDate = Request.QueryString["StartDate"];
            string EndDate = Request.QueryString["EndDate"];
            string CustomerId = Request.QueryString["CustomerId"];
            Response.Redirect("CertuificateDuplication.aspx?StartDate=" + StartDate + "&EndDate=" + EndDate + "&CustomerId=" + CustomerId, false);
                
            }
    }
}