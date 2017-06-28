using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.objLib.Certificate;
using DCISDBManager.objLib.MasterMaintenance;
using System.IO;
using DCISDBManager.trnLib.UserManagement;
using System.Reflection;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.CheckAuth;
using System.Security.Cryptography;
using System.Text;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.objLib.Email;
using DCISDBManager.trnLib.ParameterManagement;
using System.Net;
using System.Net.Mail;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.CustomerRequestManagement;
using System.Drawing;

namespace DSCMS.Views.Maintenance
{
    public partial class SupportingDocumentDownload : System.Web.UI.Page
    {
        EmailManager em = new EmailManager();
        CustomerDetailManager cm = new CustomerDetailManager();




        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
        string grpSAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
        string grpCustomer = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];

        string grpCAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
        string Key = System.Configuration.ConfigurationManager.AppSettings["DecKey"];

        DownloadCertificate dc = new DownloadCertificate();
        SupportingDocumentManagement sdm = new SupportingDocumentManagement();

        UserSession session;
        ArrayList A = new ArrayList();



        protected void Page_Load(object sender, EventArgs e)
        {

            session = new UserSession();
            //if (session.User_Group == "CUSTOMER") {

            //    Button1.Visible = false;
              
            //    foreach (GridViewRow row in GridView1.Rows)
            //    {
            //        CheckBox check = (CheckBox)row.FindControl("CheckBox1");
            //        check.Visible = false;
                
            //    }
                
            
            //}

            //List<string> certificateList = new List<string>();

            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToShortDateString();
                txtTodate.Text = DateTime.Today.ToShortDateString();

            }


            if (Calendar2.SelectedDate.ToShortDateString() != "1/1/0001")
                txtFromDate.Text = Calendar2.SelectedDate.ToShortDateString();
            if (Calendar3.SelectedDate.ToShortDateString() != "1/1/0001")
                txtTodate.Text = Calendar3.SelectedDate.ToShortDateString();

            string a = Server.MapPath("~/Uploads/a.pdf");
           


            //  CombineMultiplePDFs(certificateList, a);

            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!IsPostBack)
            {
                BindGrid();
            }
            if (session.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();

            bool auth = Am.IsUserGroupAuthorised(groupId, "certd");
            //if (auth == false)
            //{
            //    Response.Redirect("~/Views/Home/Login.aspx");
            //}

            //    getEmailr();
            string AdminMsg = System.Configuration.ConfigurationManager.AppSettings["link"];

            

            // sendEmail(AdminMsg, ClientEmailaddress);
            //  sendEmaile();

            if (!IsPostBack)
            {
                BindDropDown();
            }


        }


        public void CertificateID_Click(object sender, EventArgs e)
        {

            BindGridR();



        }

        public void BindGridR()
        {
            try
            {
                UserSession session = new UserSession();


                var todate = txtFromDate.Text;
                var fromdate = txtTodate.Text;

                string[] startdate = todate.Split('-', '/');
                string[] enddate = fromdate.Split('-', '/');

                string sdays = startdate[1];
                string years = startdate[2];
                string month = startdate[0];

                string edays = enddate[1];
                string eyears = enddate[2

                    ];
                string emonth = enddate[0];


                DateTime frm = Convert.ToDateTime(txtFromDate.Text);
                DateTime tod = Convert.ToDateTime(txtTodate.Text);

                string fromdates = years + month + sdays;
                string todates = eyears + emonth + edays;
                fromdates = frm.ToString("yyyyMMdd");
                todates = tod.ToString("yyyyMMdd");



                //   GridView1.DataSource = pt.getPackageType("%");
                //  GridView1.DataSource = pt.getPackageTypen("%", "y");
                //  GridView1.DataBind();
                if (session.User_Group == grpidAdmin || session.User_Group == grpSAdmin)
                {
                    string reqID;
                    if (txtCertificateNo.Text != "")
                    {
                        reqID = txtCertificateNo.Text;

                    }

                    else
                    {
                        reqID = "%";

                    }
                    // GridView1.DataSource = dc.getRequestID(reqID);

                    string a = ddUserID.SelectedValue;
                    String b;

                    if (ddUserID.SelectedValue != "")
                    {
                        b = a;
                    }
                    else
                    {
                        b = "%";

                    }

                    if ( txtCertificateNo.Text != "")
                    {

                        DateTime frms = DateTime.Today.AddDays(-3000);

                        DateTime todated = DateTime.Today.AddDays(3000);
                        fromdates = frms.ToString("yyyyMMdd");
                        todates = todated.ToString("yyyyMMdd");


                    }



                    GridView1.DataSource = sdm.getSupportingDocumentDownloadDate("A", b, reqID, fromdates,todates);



                    GridView1.DataBind();

                }
                else if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                {

                    string reqID = txtCertificateNo.Text;
                    String a = session.User_Id;
                    String b = dc.getCustIDfrmUserID(a);


                    if ( txtCertificateNo.Text != "")
                    {

                        DateTime frms = DateTime.Today.AddDays(-3000);

                        DateTime todated = DateTime.Today.AddDays(3000);
                        fromdates = frms.ToString("yyyyMMdd");
                        todates = todated.ToString("yyyyMMdd");


                    }



                    GridView1.DataSource = sdm.getSupportingDocumentDownloadDate("A", b, reqID,fromdates,todates);
                    GridView1.DataBind();



                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }

        public void BindDropDown()
        {
            try
            {




                ddUserID.DataSource = cm.getAllCustomer("Y");

                ddUserID.DataValueField = "CustomerId1";
                ddUserID.DataTextField = "CustomerName1";
                ddUserID.DataBind();
                if (session.User_Group == "CADMIN" || session.User_Group == "CUSTOMER")
                {

                    ddUserID.Visible = false;
                    lblcusid.Visible = false;
                    divhid.Visible = false;


                }


                //ddUserID.DataSource = crm.getCustomerUser("%");
                //ddUserID.DataTextField = "Person_Name";
                //ddUserID.DataValueField = "User_ID";
                //ddUserID.DataBind();











            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }



        public void chkStatus_OnCheckedChanged(object sender, EventArgs e)
        {
            GridView1.AllowPaging = true;
            BindGrid();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (CheckB1.Checked == true)
                {
                    CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");
                    ChkBoxRows.Checked = false;

                }
            }
            SaveCheckedValues();
            GridView1.AllowPaging = true;
            BindGrid();
            PopulateCheckedValues();



        }

      

        public void BindGrid()
        {
            try
            {
                UserSession session = new UserSession();

                //   GridView1.DataSource = pt.getPackageType("%");
                //  GridView1.DataSource = pt.getPackageTypen("%", "y");
                //  GridView1.DataBind();
                if (session.User_Group == grpidAdmin || session.User_Group == grpSAdmin)
                {
                string customerID = session.Customer_ID;
                GridView1.DataSource = sdm.getSupportingDocumentDownload("A", "%","%");
                    GridView1.DataBind();

                }
                else if (session.User_Group.Equals(grpCustomer) || session.User_Group.Equals(grpCAdmin))
                {

                    string customerID = session.Customer_ID;
                    GridView1.DataSource = sdm.getSupportingDocumentDownload("A", customerID,"%");
                    GridView1.DataBind();


                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }

        public void CombineMultiplePDFs(string[] fileNames, string outFile)
        {
            // step 1: creation of a document-object
            Document document = new Document();

            // step 2: we create a writer that listens to the document
            PdfCopy writer = new PdfCopy(document, new FileStream(outFile, FileMode.Create));

            if (writer == null)
            {
                return;
            }

            // step 3: we open the document
            document.Open();

            foreach (string fileName in fileNames)
            {
                // we create a reader for a certain document
                PdfReader reader = new PdfReader(fileName);
                reader.ConsolidateNamedDestinations();

                // step 4: we add content
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    writer.AddPage(page);
                }

                PRAcroForm form = reader.AcroForm;
                if (form != null)
                {
                    writer.CopyAcroForm(reader);
                }

                reader.Close();
            }

            // step 5: we close the document and writer
            writer.Close();
            document.Close();
        }

        private string Decrypt(string cipherText, string key)
        {
            try
            {
                string EncryptionKey = key;

                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return null;
            }
        }
     

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SaveCheckedValues();
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
            PopulateCheckedValues();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }


        protected void OrderGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton lb = e.Row.FindControl("MarkAsCompleteButton") as LinkButton;
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lb);
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            try
            {
                Label Path = null;

                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Label1.Visible = false;


                    Path = (Label)row.FindControl("lblDownload_Path");

                    string name = row.Cells[1].Text;
                    String path = Path.Text;
                    string id = row.Cells[1].Text;
                    DateTime today = DateTime.Today;
                    DateTime expdate = dc.getCertificateExpireDate(id);
                    int result = DateTime.Compare(expdate, today);
                  //  UserSession session2 = new UserSession();
                    //if (result > 0 || session2.User_Group.Equals(grpidAdmin) || session2.User_Group.Equals(grpSAdmin))
                    //{

                    SupportDocuments sd = new SupportDocuments();

                    sd.Request_ID = row.Cells[3].Text; ;


                        CertificateDownld ocd = new CertificateDownld();
                        ocd.Request_Id = row.Cells[3].Text; ;
                        UserSession session = new UserSession();
                        if (session.User_Group.Equals("CUSTOMER") || session.User_Group.Equals("CADMIN"))
                        {
                            sd.Is_Downloaded= "y";
                        }
                        else { 
                        
                        
                        
                        }
                        sdm.ModifySupportingDocumentDownload(sd);

                      //  dc.ModifyCerficateDownload(ocd);

                        String Pathfile = path;


                        String filename = name+".pdf";
                        Response.ContentType = "application/octem-Stream";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                        // Response.TransmitFile(Server.MapPath("~/Uploads/" + filename));
                        Response.TransmitFile(Server.MapPath(Pathfile));
                        Response.End();
                        Response.Redirect("SupportingDocumentDownload.aspx", false);
                    //}
                    //else
                    //{

                    //    Label1.Visible = true;
                    //}

                }
            }

            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());  
                System.Console.Error.Write(ex.Message);
                //  return ex.Message;

            }



        }

        protected void down(object sender, EventArgs e)
        {
          //  string[][] dws;

        //    Response.AppendHeader("Refresh", "2");
            SaveCheckedValues();
            GridView1.AllowPaging = false;
            BindGrid();
            PopulateCheckedValues();
            Label lblTemp = null;
            Label lblReq = null;
            var listOfStrings = new List<string>();
            var listOfids = new List<string>();

          



            ArrayList paths = new ArrayList();
            foreach (GridViewRow row in GridView1.Rows)
            {
                
                lblTemp = (Label)row.FindControl("lblDownload_Path");
                lblReq = (Label)row.FindControl("lblDownload_RqID");
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");

                if (ChkBoxRows.Checked == true)
                {
                    SupportDocuments cdO = new SupportDocuments();
                    cdO.Request_ID = lblReq.Text;
                    cdO.Is_Downloaded = "y";
                    sdm.ModifySupportingDocumentDownload(cdO);


                    String A = lblTemp.Text;
                       string strFileFullPath = Server.MapPath(A);

                       if (System.IO.File.Exists(strFileFullPath))
                       {
                           listOfids.Add(lblReq.Text);

                           listOfStrings.Add(Server.MapPath(A));
                       }
                    paths.Add(A);

                   

                }


            }
            try
            {
                string strFileFullPath = Server.MapPath("~/Uploads/a.pdf");

                if (System.IO.File.Exists(strFileFullPath))
                {
                    System.IO.File.Delete(strFileFullPath);
                }
                String filename = DateTime.Now.ToString();
                string newStringy = filename.Replace("/", ".");
                string newStringx = newStringy.Replace("\\", ".");
                string newString = newStringx.Replace("-", ".");
                string newString2 = newString.Replace(" ", "");
                string newString3 = newString2.Replace(":", ".");
                string path = Server.MapPath("~/Uploads/" + newString3 + ".pdf");
                string b = "";
               
                string[] arrayOfStrings = listOfStrings.ToArray();
            


                 Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile();
                for (int i = 0; i < listOfStrings.Count; i++)
                {
                    String Pathfile = listOfStrings[i];
                    string fname=listOfids[i];
                    string fileNames = Path.GetFileName(Pathfile);

                    var Value1 = fname;
                 


                    if (Value1.Contains("CE"))
                    {
                       
                         b = Value1.ToString()+"__";
                    }

                  //  string filePath = Server.MapPath(Pathfile);
                    string filePath = Pathfile;
                   // zip.AddFile(filePath, "files");

                    zip.AddFile(filePath, Value1);
                    


                }
               


                Response.Clear();
                string fnm = DateTime.Now.ToString("");
                string nwString = fnm.Replace("/", ".");
                string nwString2 = nwString.Replace(" ", ".");
                string nwString3 = nwString2.Replace(":", ".");

                Response.AddHeader("Content-Disposition", "attachment; filename="+nwString3+".zip");
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                Response.Flush();

                Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();




                CombineMultiplePDFs(arrayOfStrings, path);
               
                Response.ContentType = "application/octem-Stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + newString3+".pdf");
                // Response.TransmitFile(Server.MapPath("~/Uploads/" + filename));
                Response.TransmitFile(Server.MapPath("~/Uploads/" + newString3 + ".pdf"));

                Response.End();

            }

            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());  
                System.Console.Error.Write(ex.Message);
                //  return ex.Message;




                //string strFileFullPath = Server.MapPath("~/Uploads/a.pdf");

                //if (System.IO.File.Exists(strFileFullPath))
                //{
                //    System.IO.File.Delete(strFileFullPath);
                //}

            }
            GridView1.AllowPaging = false;
            BindGrid();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");
                ChkBoxRows.Checked = true;
            }
            GridView1.AllowPaging = true;
            BindGrid();
          //  Response.Redirect("SupportingDocumentDownload.aspx", false);









        }

        protected void print(object sender, EventArgs e)
        {

            String day = DateTime.Now.Day.ToString();

            var folder = Server.MapPath("~/Uploads/PrintDtemp");
            var folder2 = Server.MapPath("~/Uploads/PrintDtemp/"+day);

            if (Directory.Exists(folder2))
            {
                if (Directory.Exists(folder))
                {

                    //   Directory.CreateDirectory(folder);
                    System.IO.Directory.Delete(folder, true);

                }
            }

            if (!Directory.Exists(folder2))
            {

                Directory.CreateDirectory(folder2);
                // System.IO.Directory.Delete(folder, true);

            }

            //    Response.AppendHeader("Refresh", "2");
            SaveCheckedValues();
            GridView1.AllowPaging = false;
            BindGrid();
            PopulateCheckedValues();
            Label lblTemp = null;
            Label lblReq = null;
            var listOfStrings = new List<string>();





            ArrayList paths = new ArrayList();
            foreach (GridViewRow row in GridView1.Rows)
            {

                lblTemp = (Label)row.FindControl("lblDownload_Path");
                lblReq = (Label)row.FindControl("lblDownload_RqID");
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");

                if (ChkBoxRows.Checked == true)
                {
                    SupportDocuments cdO = new SupportDocuments();
                    cdO.Request_ID = lblReq.Text;
                    cdO.Is_Downloaded = "y";
                    sdm.ModifySupportingDocumentDownload(cdO);


                    String A = lblTemp.Text;
                    string strFileFullPath = Server.MapPath(A);

                    if (System.IO.File.Exists(strFileFullPath))
                    {

                        listOfStrings.Add(Server.MapPath(A));
                    }
                    paths.Add(A);



                }


            }
            try
            {
              
                String filename = DateTime.Now.ToString();
                string newStringy = filename.Replace("/", ".");
                string newStringx = newStringy.Replace("\\", ".");
                string newString = newStringx.Replace("-", ".");
                string newString2 = newString.Replace(" ", "");
                string newString3 = newString2.Replace(":", ".");
                string path = Server.MapPath("~/Uploads/PrintDtemp/"+day+"/" + newString3 + ".pdf");


                string[] arrayOfStrings = listOfStrings.ToArray();
                CombineMultiplePDFs(arrayOfStrings, path);



                string finalviewDirectPath1 = "../../Uploads/PrintDtemp/" +day+"/"+ newString3 + ".pdf";
                //   Iframe1.Attributes["src"] = "~/Uploads/" + newString3 + ".pdf";

                //   Iframe1.Attributes["src"] = "../../Uploads/9.26.20162.52.45PM.pdf";

                string iframe = "<iframe id='iFramePdf' src='" + finalviewDirectPath1 + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
                diviframe.InnerHtml = iframe;

                //Response.ContentType = "application/octem-Stream";
                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + newString3 + ".pdf");
                //// Response.TransmitFile(Server.MapPath("~/Uploads/" + filename));
                //Response.TransmitFile(Server.MapPath("~/Uploads/" + newString3 + ".pdf"));

                //Response.End();

            }

            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());  
                System.Console.Error.Write(ex.Message);
                //  return ex.Message;




                //string strFileFullPath = Server.MapPath("~/Uploads/a.pdf");

                //if (System.IO.File.Exists(strFileFullPath))
                //{
                //    System.IO.File.Delete(strFileFullPath);
                //}

            }
            GridView1.AllowPaging = false;
            BindGrid();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");
                ChkBoxRows.Checked = true;
            }
            GridView1.AllowPaging = true;
            BindGrid();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "printTrigger()", true);
            //  Response.Redirect("SupportingDocumentDownload.aspx", false);









        }
        protected void View(object sender, EventArgs e)
        {

            String day = DateTime.Now.Day.ToString();

            var folder = Server.MapPath("~/Uploads/PrintDtemp");

            var folder2 = Server.MapPath("~/Uploads/PrintDtemp/"+day);
            if (!Directory.Exists(folder2))
            {
                if (Directory.Exists(folder))
                {

                    //   Directory.CreateDirectory(folder);
                    System.IO.Directory.Delete(folder, true);

                }
            }

            if (!Directory.Exists(folder2))
            {

                Directory.CreateDirectory(folder2);
                // System.IO.Directory.Delete(folder, true);

            }



            //    Response.AppendHeader("Refresh", "2");
            SaveCheckedValues();
            GridView1.AllowPaging = false;
            BindGrid();
            PopulateCheckedValues();
            Label lblTemp = null;
            Label lblReq = null;
            var listOfStrings = new List<string>();





            ArrayList paths = new ArrayList();
            foreach (GridViewRow row in GridView1.Rows)
            {

                lblTemp = (Label)row.FindControl("lblDownload_Path");
                lblReq = (Label)row.FindControl("lblDownload_RqID");
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");

                if (ChkBoxRows.Checked == true)
                {
                    SupportDocuments cdO = new SupportDocuments();
                    cdO.Request_ID = lblReq.Text;
                    cdO.Is_Downloaded = "y";
                    sdm.ModifySupportingDocumentDownload(cdO);


                    String A = lblTemp.Text;
                    string strFileFullPath = Server.MapPath(A);

                    if (System.IO.File.Exists(strFileFullPath))
                    {

                        listOfStrings.Add(Server.MapPath(A));
                    }
                    paths.Add(A);



                }


            }
            try
            {
                string strFileFullPath = Server.MapPath("~/Uploads/a.pdf");

                if (System.IO.File.Exists(strFileFullPath))
                {
                    System.IO.File.Delete(strFileFullPath);
                }
                String filename = DateTime.Now.ToString();
                string newStringy = filename.Replace("/", ".");
                string newStringx = newStringy.Replace("\\", ".");
                string newString = newStringx.Replace("-", ".");
                string newString2 = newString.Replace(" ", "");
                string newString3 = newString2.Replace(":", ".");
                string path = Server.MapPath("~/Uploads/PrintDtemp/"+day+"/" + newString3 + ".pdf");


                string[] arrayOfStrings = listOfStrings.ToArray();
                CombineMultiplePDFs(arrayOfStrings, path);

                string finalviewDirectPath1 = "../../Uploads/PrintDtemp/" + day + "/" + newString3 + ".pdf";


                Session["PDFUrl"] = finalviewDirectPath1;
                string pageurl = "../Certificate/PdfView.aspx";
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);

            }

            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());  
                System.Console.Error.Write(ex.Message);
                //  return ex.Message;




                //string strFileFullPath = Server.MapPath("~/Uploads/a.pdf");

                //if (System.IO.File.Exists(strFileFullPath))
                //{
                //    System.IO.File.Delete(strFileFullPath);
                //}

            }
            GridView1.AllowPaging = false;
            BindGrid();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");
                ChkBoxRows.Checked = true;
            }
            GridView1.AllowPaging = true;
            BindGrid();
            //  Response.Redirect("SupportingDocumentDownload.aspx", false);









        }

        protected void select(object sender, EventArgs e)
        {
            GridView1.AllowPaging = false;
            BindGrid();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");
                ChkBoxRows.Checked = true;
            }
            
            SaveCheckedValues();
            GridView1.AllowPaging = true;
            BindGrid();
            PopulateCheckedValues();

        }

        protected void unselect(object sender, EventArgs e)
        {
            GridView1.AllowPaging = false;
            BindGrid();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");
                ChkBoxRows.Checked = false;
            }
          
            SaveCheckedValues();
            GridView1.AllowPaging = true;
            BindGrid();
            PopulateCheckedValues();

        }


        private void PopulateCheckedValues()
        {
            ArrayList userdetails = (ArrayList)Session["CHECKED_ITEMS"];
            if (userdetails != null && userdetails.Count > 0)
            {
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    string subjectString = (string)GridView1.DataKeys[gvrow.RowIndex].Value;
                    string resultString = Regex.Match(subjectString, @"\d+").Value;
                    // index = (int)GridView1.DataKeys[gvrow.RowIndex].Value.;
                    int index = Int32.Parse(resultString);

                    //  int index = (int)GridView1.DataKeys[gvrow.RowIndex].Value;
                    if (userdetails.Contains(index))
                    {
                        CheckBox myCheckBox = (CheckBox)gvrow.FindControl("CheckBox1");
                        myCheckBox.Checked = true;
                    }
                }
            }
        }

        private void SaveCheckedValues()
        {
            ArrayList userdetails = new ArrayList();
            int index = -1;


            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                string subjectString = (string)GridView1.DataKeys[gvrow.RowIndex].Value;
                string resultString = Regex.Match(subjectString, @"\d+").Value;
                // index = (int)GridView1.DataKeys[gvrow.RowIndex].Value.;
                index = Int32.Parse(resultString);

                bool result = ((CheckBox)gvrow.FindControl("CheckBox1")).Checked;

                // Check in the Session
                if (Session["CHECKED_ITEMS"] != null)
                    userdetails = (ArrayList)Session["CHECKED_ITEMS"];
                if (result)
                {
                    if (!userdetails.Contains(index))
                        userdetails.Add(index);
                }
                else
                    userdetails.Remove(index);
            }
            if (userdetails != null && userdetails.Count > 0)
                Session["CHECKED_ITEMS"] = userdetails;
        }





        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        protected override void OnInit(EventArgs e)
        {
            GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
            base.OnInit(e);
        }
        void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow) return;

            Label lbldown = (Label)e.Row.FindControl("lblisdownloaded");
            if (lbldown.Text == "N" && session.User_Group == "CUSTOMER" )
            {
                e.Row.BackColor = Color.FromName("#FAFAD2");




            }
            if (lbldown.Text == "N" && session.User_Group == "CADMIN" )
            {
                e.Row.BackColor = Color.FromName("#FAFAD2");



            }

            if (e.Row.Cells[8].Text == "No" && session.User_Group == "CUSTOMER")
            {

                CheckBox ChkBoxRows = (CheckBox)e.Row.FindControl("CheckBox1");
                ChkBoxRows.Checked = false;
                ChkBoxRows.Enabled = false;


            }
            if (e.Row.Cells[8].Text == "No" && session.User_Group == "CADMIN")
            {

                CheckBox ChkBoxRows = (CheckBox)e.Row.FindControl("CheckBox1");
                ChkBoxRows.Checked = false;
                ChkBoxRows.Enabled = false;


            }


            if (e.Row.Cells[8].Text == "No" && session.User_Group == "CADMIN")
            {

                CheckBox ChkBoxRows = (CheckBox)e.Row.FindControl("CheckBox1");
                ChkBoxRows.Checked = false;
                ChkBoxRows.Enabled = false;

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton LinkButton2 = (LinkButton)e.Row.FindControl("LinkButton2");
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;

            }

            if (e.Row.Cells[8].Text == "No" && session.User_Group == "CUSTOMER")
            {

                CheckBox ChkBoxRows = (CheckBox)e.Row.FindControl("CheckBox1");
                ChkBoxRows.Checked = false;
                ChkBoxRows.Enabled = false;

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton LinkButton2 = (LinkButton)e.Row.FindControl("LinkButton2");
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;

            }

            if (session.User_Group == "SADMIN" || session.User_Group == "ADMIN")
            {

                CheckB1.Enabled = true;



            }











        }
    }
}