using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.objLib.Certificate;
using System.IO;
using DCISDBManager.trnLib.UserManagement;
using System.Reflection;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.CheckAuth;
using System.Security.Cryptography;
using System.Text;
using DCISDBManager.trnLib.EmailManager;
using System.IO.Compression;

using DCISDBManager.objLib.Parameters;
using DCISDBManager.objLib.Email;
using DCISDBManager.trnLib.ParameterManagement;

using System.Net;
using System.Net.Mail;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using DCISDBManager.trnLib.CustomerRequestManagement;
using System.Drawing;
using Ionic.Zip;

namespace DSCMS.Views.Certificate
{
  
    public partial class CertifcateDownload : System.Web.UI.Page
    {
        
        
        static int numberofcert = 0;
        
        EmailManager em = new EmailManager();

        CertficateRequestDataManagement crm = new CertficateRequestDataManagement();

        CustomerDetailManager cm = new CustomerDetailManager();

        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
        string grpSAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];

        string Key = System.Configuration.ConfigurationManager.AppSettings["DecKey"];

        DownloadCertificate dc = new DownloadCertificate();

        UserSession session;
        ArrayList A  = new ArrayList();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                 txtFromDate.Text=DateTime.Today.ToShortDateString();
                 txtTodate.Text = DateTime.Today.ToShortDateString();
            
            }
           
            string a = txtFromDate.Text;
            string b = txtTodate.Text;

            if (Calendar2.SelectedDate.ToShortDateString() != "1/1/0001")
                txtFromDate.Text = Calendar2.SelectedDate.ToShortDateString();
            if (Calendar3.SelectedDate.ToShortDateString() != "1/1/0001")
                txtTodate.Text = Calendar3.SelectedDate.ToShortDateString();



            string TIme = "";
            string check = "";
            TIme = Request.QueryString["time"];
            
            check = Request.QueryString["check"];
             if (!Page.IsPostBack)
            {
            if (TIme == "5")
            {
              //  Response.Redirect("CertifcateDownload.aspx?time=6&check=" + check);


                string pageurl = "CertifcateDownload.aspx?time=6&check=" + check;
                Page.ClientScript.RegisterStartupScript(
              //  this.GetType(), "OpenWindow", "window.open('" + pageurl + ");", true);
                   this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);



            }
            

            if (TIme == "6")
            {

               


                Response.ContentType = "application/octem-Stream";

                Response.AppendHeader("Content-Disposition", "attachment; filename=" + check + ".pdf");

                Response.TransmitFile(Server.MapPath("~/Uploads/" + check + ".pdf"));



                Response.Flush();

                Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();

                string pageurl = "CertifcateDownload.aspx";
                Page.ClientScript.RegisterStartupScript(
               // this.GetType(), "OpenWindow", "window.open('" + pageurl + ");", true);
                   this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
            //    HttpContext.Current.ApplicationInstance.CompleteRequest();






            }
            }


            session = new UserSession();



            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToShortDateString();
                txtTodate.Text = DateTime.Today.ToShortDateString();
                BindGrid();
            }
            if (session.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();

            bool auth = Am.IsUserGroupAuthorised(groupId, "certd");

            string AdminMsg = System.Configuration.ConfigurationManager.AppSettings["link"];





            if (!IsPostBack)
            {
                BindDropDown();
            }
        }

        public void BindDropDown()
        {
            try
            {

                if (session.User_Group == "ADMIN" || session.User_Group == "SADMIN")
                {
                    GridView1.Columns[6].Visible = false;
                    GridView1.Columns[14].Visible = false;
                }

                if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                {
                    GridView1.Columns[6].Visible = false;
                    GridView1.Columns[7].Visible = false;
                }

                 




                ddUserID.DataSource = cm.getAllCustomer("Y");

                ddUserID.DataValueField = "CustomerId1";
                ddUserID.DataTextField = "CustomerName1";
                ddUserID.DataBind();
                if (session.User_Group == "CADMIN" || session.User_Group == "CUSTOMER")
                {

                    ddUserID.Visible = false;
                    lblcusid.Visible = false;
                  //  divhid.Visible = false;


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

        public void BindGridR()
        {
            try
            {
                UserSession session = new UserSession();

                string invoiceno = "";

                

                if (txtInvoiceNo.Text != "")
                {
                    invoiceno = txtInvoiceNo.Text;

                }

                else
                {
                    invoiceno = "%";

                }

                //   GridView1.DataSource = pt.getPackageType("%");
                //  GridView1.DataSource = pt.getPackageTypen("%", "y");
                //  GridView1.DataBind();
                if (session.User_Group == grpidAdmin || session.User_Group == grpSAdmin)
                {
                    GridView1.Columns[15].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView1.Columns[6].Visible = false;

                    string seal="%";
                    if (ddseal.SelectedValue == "All") {

                        seal = "%";
                    }
                    if (ddseal.SelectedValue == "True")
                    {

                        seal = "True";
                    }

                    if (ddseal.SelectedValue == "False")
                    {

                        seal = "False";
                    }
                    

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


                    DateTime frm =Convert.ToDateTime(txtFromDate.Text);
                    DateTime tod = Convert.ToDateTime(txtTodate.Text);
                    
                    string fromdates = years + month + sdays;
                    string todates = eyears + emonth + edays;
                    fromdates = frm.ToString("yyyyMMdd");
                    todates = tod.ToString("yyyyMMdd");
                    GridView1.DataSource = dc.getRequestIDUser(reqID, b,"%");

                    if (txtInvoiceNo.Text != "" || txtCertificateNo.Text !="")

                    {

                        DateTime frms = DateTime.Today.AddDays(-3000);

                        DateTime todated = DateTime.Today.AddDays(3000);
                        fromdates = frms.ToString("yyyyMMdd");
                        todates = todated.ToString("yyyyMMdd");
                    
                    
                    }

                    

                    GridView1.DataSource = dc.getRequestIDUserDate("%", b, fromdates, todates, reqID,seal,invoiceno);

                    GridView1.DataBind();

                }
                else if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                {

                    GridView1.Columns[6].Visible = false;
                  //  avc.Visible = false;
                    string seal="%";

                    if (ddseal.SelectedValue == "All")
                    {

                        seal = "%";
                    }
                    if (ddseal.SelectedValue == "True")
                    {

                        seal = "True";
                    }

                    if (ddseal.SelectedValue == "False")
                    {

                        seal = "False";
                    }
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




                    string reqID;
                    string fromdates = years + month + sdays;
                    string todates = eyears + emonth + edays;


                    DateTime frm = Convert.ToDateTime(txtFromDate.Text);
                    DateTime tod = Convert.ToDateTime(txtTodate.Text);
                    fromdates = frm.ToString("yyyyMMdd");
                    todates = tod.ToString("yyyyMMdd");

                    if (txtCertificateNo.Text == "") {
                        reqID = "%";
                    }
                    else
                    {
                         reqID = txtCertificateNo.Text;

                    }
                    String a = session.User_Id;
                    String b = dc.getCustIDfrmUserID(a);

                    if (txtInvoiceNo.Text != "" || txtCertificateNo.Text != "")
                    {

                        DateTime frms = DateTime.Today.AddDays(-3000);

                        DateTime todated = DateTime.Today.AddDays(3000);
                        fromdates = frms.ToString("yyyyMMdd");
                        todates = todated.ToString("yyyyMMdd");


                    }

                    GridView1.DataSource = dc.getRequestIDUserDate("%", b, fromdates, todates, reqID,seal,invoiceno);
                    GridView1.DataBind();



                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }

        protected void TextBox1_Click(object sender, EventArgs e)
        {
          //  Calendar1.Visible = true;
        }



        public void view(object sender, EventArgs e)
        {
            Label lblTemp = null;

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {

                lblTemp = (Label)row.FindControl("lblTemplateID");



                //    lblTemp=

            //    myIframe.Attributes["src"] = lblTemp.Text;



            }






          //  mp1.Show();



        }

        public void CertificateID_Click(object sender, EventArgs e)
        {

            BindGridR();



        }


        public void chkStatus_OnCheckedChanged(object sender, EventArgs e)
        {
         //   GridView1.AllowPaging = false;
            if (ddUserID.SelectedValue != "" || txtCertificateNo.Text != "")
            {

                BindGridR();


            }
            else
            {

                BindGrid();

            }

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
            if (ddUserID.SelectedValue == "")
            {
                BindGrid();
            }
            else
            {
                BindGridR();

            }



            PopulateCheckedValues();


        }


        protected void ReSelectSelectedRecords(object sender, GridViewRowEventArgs e)
        {
            List<int> list = ViewState["SelectedRecords"] as List<int>;
            if (e.Row.RowType == DataControlRowType.DataRow && list != null)
            {
                var autoId = int.Parse(GridView1.DataKeys[e.Row.RowIndex].Value.ToString());
                if (list.Contains(autoId))
                {
                    CheckBox chk = (CheckBox)e.Row.FindControl("CheckBox1");
                    chk.Checked = true;
                }
            }
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
                    GridView1.Columns[15].Visible = false;
                    //GridView1.DataSource = dc.getRequestID("%");
                    GridView1.DataSource = dc.getRequestIDUser("%", "%","%");


                    GridView1.DataBind();

                }
                else if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                {

                    GridView1.Columns[6].Visible = false;
                 //   avc.Visible = false;

                    String a = session.User_Id;
                    String b = dc.getCustIDfrmUserID(a);
                    string userid;
                    if (session.User_Group == "CUSTOMER")
                    {
                        userid = session.User_Id;
                    }
                    else { userid = "%"; }
                    GridView1.DataSource = dc.getRequestIDUser("%", b, userid);
                    GridView1.DataBind();

                //    txtFromDate.Text = DateTime.Today.ToShortDateString();
               //     txtTodate.Text = DateTime.Today.ToShortDateString();

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
                  
                 //   writer.AcroForm(reader);
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
            if (txtCertificateNo.Text != "" || ddUserID.SelectedValue != "")
            {
                BindGridR();
            }
            else
            {
                BindGrid();

            }
            PopulateCheckedValues();







        }

        public void paging()
        {
            ArrayList CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
            string checkAllIndex = "chkAll-" + GridView1.PageIndex;

            if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
            {
                CheckBox chkAll =
                 (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("chkAll");
                chkAll.Checked = true;
            }
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                    {
                        CheckBox chk =
                         (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                        chk.Checked = true;

                    }
                    else
                    {
                        int CheckBoxIndex = GridView1.PageSize * (GridView1.PageIndex) + (i + 1);
                        if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1)
                        {
                            CheckBox chk =
                            (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                            chk.Checked = true;

                        }
                    }
                }
            }



        }


        public void checkedinstance()
        {
            ArrayList CheckBoxArray;
            if (ViewState["CheckBoxArray"] != null)
            {
                CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
            }
            else
            {
                CheckBoxArray = new ArrayList();
            }



            if (IsPostBack)
            {
                int CheckBoxIndex;
                bool CheckAllWasChecked = false;
                CheckBox chkAll =
                 (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("chkAll");
                string checkAllIndex = "chkAll-" + GridView1.PageIndex;
                if (chkAll.Checked)
                {
                    if (CheckBoxArray.IndexOf(checkAllIndex) == -1)
                    {
                        CheckBoxArray.Add(checkAllIndex);
                    }
                }
                else
                {
                    if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                    {
                        CheckBoxArray.Remove(checkAllIndex);
                        CheckAllWasChecked = true;
                    }
                }
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk =
                        (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                        CheckBoxIndex = GridView1.PageSize * GridView1.PageIndex + (i + 1);
                        if (chk.Checked)
                        {
                            if (CheckBoxArray.IndexOf(CheckBoxIndex) == -1
                                && !CheckAllWasChecked)
                            {
                                CheckBoxArray.Add(CheckBoxIndex);
                            }
                        }
                        else
                        {
                            if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1
                                || CheckAllWasChecked)
                            {
                                CheckBoxArray.Remove(CheckBoxIndex);
                            }
                        }
                    }
                }
            }





        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {


        }


        protected void OrderGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton lb = e.Row.FindControl("MarkAsCompleteButton") as LinkButton;
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lb);
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

        protected void Document_Click(object sender, EventArgs e) {

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
               
                //Label CertificateID = (Label)row.FindControl("lblRefNo");
                
                String CertificateID = row.Cells[1].Text;

                gvSupportingDOc.DataSource = dc.getSupportingDocuments(CertificateID);
                gvSupportingDOc.DataBind();
               // dc.getSupportingDocuments(row.Cells[1].Text
              
            
            
            } 
            mp1.Show();
        
        
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            Label lblTemp = null;
          
            try
            {
                
  
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {

                    lblTemp = (Label)row.FindControl("lblTemplateID");
                    Label1.Visible = false;

                    string id = row.Cells[1].Text;
                    DateTime today = DateTime.Today;
                    DateTime expdate = dc.getCertificateExpireDate(id);
                 //   int result = DateTime.Compare(expdate, today);
                    int result = 1;
                    UserSession session2 = new UserSession();
                    if (result > 0 || session2.User_Group.Equals( grpidAdmin) || session2.User_Group.Equals(grpSAdmin) )
                    {

                       


                        CertificateDownld ocd = new CertificateDownld();
                        ocd.Request_Id = row.Cells[1].Text; ;
                        UserSession session = new UserSession();
                        
                            ocd.Is_Downloaded = "y";
                        
                    if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                    {
                        dc.ModifyCerficateDownload(ocd);
                    }

                 //   String Pathfile = dc.getCertificatePathe(id);
                    String Pathfile = lblTemp.Text;
            //        Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile();

                     

            //            string filePath = Server.MapPath(Pathfile);
            //    zip.AddFile(filePath, "files");
                
            
            //Response.Clear();
            //Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFile.zip");
            //Response.ContentType = "application/zip";
            //zip.Save(Response.OutputStream);
            //Response.End();
                    string invno = row.Cells[8].Text;
                 
                    string nwString = invno.Replace("/", ".");
                    string nwStringl = nwString.Replace(" ", "_");
                    string nwString2 = nwStringl.Replace("_Certificate", "");
                    string nwString3 = nwString2.Replace(":", ".");

                   
////////
               //     String filename = dc.getCertificateName(id);
                    String filename = Path.GetFileName(Pathfile);
                    string fileName2 = filename.Replace("_Certificate", "");  
                    Response.ContentType = "application/octem-Stream";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + nwString3 + "_" + fileName2);
                    // Response.TransmitFile(Server.MapPath("~/Uploads/" + filename));
                    Response.TransmitFile(Server.MapPath(Pathfile));
                  
                    Response.Flush();

                    Response.SuppressContent = true;
                    HttpContext.Current.ApplicationInstance.CompleteRequest();

///////

                        Response.Redirect("CertifcateDownload.aspx", false);
                    }
                    else {

                        Label1.Visible = true;
                    }

                }
            }

            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());  
                System.Console.Error.Write(ex.Message);
              //  return ex.Message;

            }

          

        }


        protected void btnSupView_Click(object sender, EventArgs e)
        {

            Label lblTemp = null;

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {

                lblTemp = (Label)row.FindControl("lblSDUppathe");

                string finalviewDirectPath1 = lblTemp.Text;


                Session["PDFUrl"] = finalviewDirectPath1;
                string pageurl = "../Certificate/PdfView.aspx";
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);



                //    lblTemp=

                //    myIframe.Attributes["src"] = lblTemp.Text;



            }

            
            
            
            
            }


        protected void btnSupDown_Click(object sender, EventArgs e)
        {

            Label lblTemp = null;
            Label lblTemp2 = null;
            Label lblTemp3 = null;

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {

                lblTemp = (Label)row.FindControl("lblSDUppathe");
                lblTemp2 = (Label)row.FindControl("lblDocName");
                lblTemp3 = (Label)row.FindControl("lblReqNo");


                String filename =   lblTemp3.Text + "_"+lblTemp2.Text;
                Response.ContentType = "application/octem-Stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                // Response.TransmitFile(Server.MapPath("~/Uploads/" + filename));
                Response.TransmitFile(Server.MapPath(lblTemp.Text));

                Response.Flush();

                Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();

              



                //    lblTemp=

                //    myIframe.Attributes["src"] = lblTemp.Text;



            }





        }















        protected void down(object sender, EventArgs e)
        {

           
         //   SaveCheckedValues();
         //   GridView1.AllowPaging = false;
         //   BindGrid();
         //   PopulateCheckedValues();
            Label lblTemp = null;
            Label lbldown = null;
           




            var listOfStrings = new List<string>();

            string reqidc = "";


            ArrayList paths = new ArrayList();
            foreach (GridViewRow row in GridView1.Rows)
            {
                lblTemp = (Label)row.FindControl("lblTemplateID");
                lbldown = (Label)row.FindControl("lblDownvery");

                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");


                if (ChkBoxRows.Checked == true)
                {
                    numberofcert = numberofcert + 1;
                    UserSession session2 = new UserSession();
                    if (session2.User_Group == "CUSTOMER" || session2.User_Group == "CADMIN")
                    {
                        if (row.Cells[10].Text == "Yes")
                        {

                            CertificateDownld ocd = new CertificateDownld();
                            ocd.Request_Id = row.Cells[1].Text; ;
                            UserSession session = new UserSession();

                            if (lbldown.Text == "Z")
                            {
                                ocd.Is_Downloaded = "ZY";
                            }
                            else if (lbldown.Text == "Y")
                            {


                                ocd.Is_Downloaded = "Y";
                            }
                            else if (lbldown.Text == "ZY")
                            {


                                ocd.Is_Downloaded = "ZY";
                            }
                            else
                            {

                                ocd.Is_Downloaded = "Y";


                            }

                            if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                            {
                                dc.ModifyCerficateDownload(ocd);
                            }

                            String A = lblTemp.Text;
                            string strFileFullPath = Server.MapPath(A);

                            if (System.IO.File.Exists(strFileFullPath))
                            {
                                listOfStrings.Add(Server.MapPath(A));
                            }
                            paths.Add(A);

                            foreach (var data in dc.getSupportingDocuments(row.Cells[1].Text))
                            {
                                string pathes = data.Certificate_Path;

                                string strFileFullPathe = Server.MapPath(pathes);

                                if (System.IO.File.Exists(strFileFullPathe))
                                {
                                    listOfStrings.Add(Server.MapPath(pathes));
                                }



                            }






                        }
                    }
                    else
                    {


                        CertificateDownld ocd = new CertificateDownld();
                        ocd.Request_Id = row.Cells[1].Text; ;
                        UserSession session = new UserSession();

                        ocd.Is_Downloaded = "Y";

                        if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                        {
                            dc.ModifyCerficateDownload(ocd);
                        }

                        String A = lblTemp.Text;
                        string strFileFullPath = Server.MapPath(A);

                        if (System.IO.File.Exists(strFileFullPath))
                        {
                            listOfStrings.Add(Server.MapPath(A));
                        }
                        paths.Add(A);

                        foreach (var data in dc.getSupportingDocuments(row.Cells[1].Text))
                        {
                            string pathes = data.Certificate_Path;

                            string strFileFullPathe = Server.MapPath(pathes);

                            if (System.IO.File.Exists(strFileFullPathe))
                            {
                                listOfStrings.Add(Server.MapPath(pathes));
                            }

                           

                        }
                       

                      
                      //  zip.AddFiles()



                    }

                    reqidc = row.Cells[1].Text;

                }


            }
            try
            {
                string strFileFullPath = Server.MapPath("~/Uploads/a.pdf");

                if (System.IO.File.Exists(strFileFullPath))
                {
                    System.IO.File.Delete(strFileFullPath);
                }

                if (listOfStrings.Count == 0) {


                    Response.Redirect("CertifcateDownload.aspx", false);
                
                
                
                }


                string[] arrayOfStrings = listOfStrings.ToArray();

                string b = "Certificates";
                Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile();
                for (int i = 0; i < listOfStrings.Count; i++)
                {
                    String Pathfile = listOfStrings[i];
                    string fileNames = Path.GetFileName(Pathfile);

                    var Value1 = fileNames;
                 


                    if (Value1.Contains("CE"))
                    {
                       
                         b = Value1.ToString()+"__";
                    }

                  //  string filePath = Server.MapPath(Pathfile);
                    string filePath = Pathfile;
                   // zip.AddFile(filePath, "files");

                    zip.AddFile(filePath, b);
                    


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

            //    Response.Redirect("CertifcateDownload.aspx", false);





               //  Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile();
                // zip.AddFiles(arrayOfStrings);

               string   outputFileName = DateTime.Now.ToString();
                 Response.ContentType = "application/zip";
                 Response.AddHeader("content-disposition", "attachment; filename=" + outputFileName);

                 using (Ionic.Zip.ZipFile zipfile = new Ionic.Zip.ZipFile())
                 {
                     zipfile.AddFiles(listOfStrings);
                     zipfile.Save(Response.OutputStream);
                 }

           



                int a = arrayOfStrings.Count();
                // reqidc


                String filename = DateTime.Now.ToString();

                //   Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "LoadOnce()", true);

                // Response.Redirect("CertifcateDownload.aspx", true);

                // Response.Buffer = true;
                string newString = filename.Replace("/", ".");
                string newString2 = newString.Replace(" ", ".");
                string newString3 = newString2.Replace(":", ".");
                if (numberofcert == 1)
                {
                    newString3 = "ReqNo_" + reqidc + "Time_" + newString3;
                }
                numberofcert = 0;
                string path = Server.MapPath("~/Uploads/" + newString3 + ".pdf");
                string zippath = Server.MapPath("~/Uploads/myZipfile.zip");



                CombineMultiplePDFs(arrayOfStrings, path);

                //new method
             

                //provide the folder to be zipped
                string folderToZip = @"d:\2.27\test";

                //provide the path and name for the zip file to create
                string zipFile = @"d:\2.27\MyZippedDocuments.zip";

                //call the ZipFile.CreateFromDirectory() method
              //  ZipFile.CreateFromDirectory(folderToZip, zipFile);
               
            

                

               

               


                //new method
                //Response.Redirect("CertifcateDownload.aspx?time=5&check=" + newString3, false);






                ///*
                //                string pageurl = "CertifcateDownload.aspx?time=5&check=" + newString3;
                //                Page.ClientScript.RegisterStartupScript(
                //                this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
                
               
                //               */

                ////  Response.Redirect("ManualEntry.aspx?time=5&check=" + newString3, false);

                ////string url = "../../Views/Certificate/CertificateDownload.aspx";

                ////string urlV = Server.MapPath(url);

                ////Response.Write("<script type='text/javascript'>");
                ////                //Response.Write("window.location = '" + urlV + "'</script>");
                ////                Response.ContentType = "application/octem-Stream";
                ////             //   Response.AppendHeader("Refresh", "2");
                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + newString3 + ".pdf");
                //// Response.TransmitFile(Server.MapPath("~/Uploads/" + filename));
                //Response.TransmitFile(Server.MapPath("~/Uploads/" + newString3 + ".pdf"));



                ////    Response.Redirect("CertifcateDownload.aspx", false);

                //// myIframe.Attributes["src"] = "~/Uploads/" + newString3 + ".pdf";

                ////  mp1.Show();



                ////Response.End();
                //////
                //Response.Flush();

                //Response.SuppressContent = true;
                //HttpContext.Current.ApplicationInstance.CompleteRequest();

                /////        



                ////  Response.Headers.Clear();
                ////   Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "LoadOnce()", true);




            }

            catch (Exception ex)
            {


                // MessageBox.Show(ex.ToString());  
                System.Console.Error.Write(ex.Message);
                //  return ex.Message;
           //     GridView1.AllowPaging = true;
           //     BindGrid();



                //string strFileFullPath = Server.MapPath("~/Uploads/a.pdf");

                //if (System.IO.File.Exists(strFileFullPath))
                //{
                //    System.IO.File.Delete(strFileFullPath);
                //}

            }

            //    Response.Redirect("CertifcateDownload.aspx", false);
            //Master master = new Master();
            //master.Show();


            //  master.Page_Load(ASP.master_master,);



           // GridView1.AllowPaging = true;
           // BindGrid();
























        }
       
        protected void PrintB(object sender, EventArgs e)
        {

            String day = DateTime.Now.Day.ToString();

         

           


            var folder = Server.MapPath("~/Uploads/Printtemp");


            var folder2 = Server.MapPath("~/Uploads/Printtemp/" + day);

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




            //SaveCheckedValues();
            //GridView1.AllowPaging = false;
            //BindGrid();
            //PopulateCheckedValues();
            Label lblTemp = null;
            Label lbldown = null;

            var listOfStrings = new List<string>();


            ArrayList paths = new ArrayList();
            foreach (GridViewRow row in GridView1.Rows)
            {
                lblTemp = (Label)row.FindControl("lblTemplateID");
                lbldown = (Label)row.FindControl("lblDownvery");

                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");


                if (ChkBoxRows.Checked == true)
                {
                    UserSession session2 = new UserSession();
                    if (session2.User_Group == "CUSTOMER" || session2.User_Group == "CADMIN")
                    {
                        if (true)
                        {




                            CertificateDownld ocd = new CertificateDownld();
                            ocd.Request_Id = row.Cells[1].Text; ;
                            UserSession session = new UserSession();

                            if (lbldown.Text == "Z")
                            {
                                ocd.Is_Downloaded = "Z";
                            }
                            else if (lbldown.Text == "Y")
                            {


                                ocd.Is_Downloaded = "ZY";
                            }
                            else if (lbldown.Text == "ZY")
                            {


                                ocd.Is_Downloaded = "ZY";
                            }

                            else
                            {
                                ocd.Is_Downloaded = "Z";
                            }

                            if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                            {
                                dc.ModifyCerficateDownload(ocd);
                            }




                            String A = lblTemp.Text;
                            string strFileFullPath = Server.MapPath(A);

                            if (System.IO.File.Exists(strFileFullPath))
                            {
                                listOfStrings.Add(Server.MapPath(A));
                            }
                            paths.Add(A);



                            foreach (var data in dc.getSupportingDocuments(row.Cells[1].Text))
                            {
                                string pathes = data.Certificate_Path;

                                string strFileFullPathe = Server.MapPath(pathes);

                                if (System.IO.File.Exists(strFileFullPathe))
                                {
                                    listOfStrings.Add(Server.MapPath(pathes));
                                }



                            }



                        }
                    }
                    else {


                        CertificateDownld ocd = new CertificateDownld();
                        ocd.Request_Id = row.Cells[1].Text; ;
                        UserSession session = new UserSession();

                        ocd.Is_Downloaded = "Z";

                        if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                        {
                            dc.ModifyCerficateDownload(ocd);
                        }




                        String A = lblTemp.Text;
                        string strFileFullPath = Server.MapPath(A);

                        if (System.IO.File.Exists(strFileFullPath))
                        {
                            listOfStrings.Add(Server.MapPath(A));
                        }
                        paths.Add(A);



                        foreach (var data in dc.getSupportingDocuments(row.Cells[1].Text))
                        {
                            string pathes = data.Certificate_Path;

                            string strFileFullPathe = Server.MapPath(pathes);

                            if (System.IO.File.Exists(strFileFullPathe))
                            {
                                listOfStrings.Add(Server.MapPath(pathes));
                            }



                        }

                    
                    
                    
                    
                    }

                }


            }
            try
            {
               


                string[] arrayOfStrings = listOfStrings.ToArray();

               
                


                String filename = DateTime.Now.ToString();



                string newString = filename.Replace("/", ".");
                string newString2 = newString.Replace(" ", "");
                string newString3 = newString2.Replace(":", ".");

                string path = Server.MapPath("~/Uploads/Printtemp/"+day+"/" + newString3 + ".pdf");
                CombineMultiplePDFs(arrayOfStrings, path);
               // Response.ContentType = "application/octem-Stream";
               // Response.AppendHeader("Content-Disposition", "attachment; filename=" + newString3 + ".pdf");
              //  Response.TransmitFile(Server.MapPath("~/Uploads/" + newString3 + ".pdf"));
               // myIframe.Attributes["src"] = "~/Uploads/" + newString3 + ".pdf";

                string finalviewDirectPath1 = "../../Uploads/Printtemp/" +day+"/"+ newString3 + ".pdf";
             //   Iframe1.Attributes["src"] = "~/Uploads/" + newString3 + ".pdf";
                
                  //   Iframe1.Attributes["src"] = "../../Uploads/9.26.20162.52.45PM.pdf";

                string iframe = "<iframe id='iFramePdf' src='" + finalviewDirectPath1 + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
                diviframe.InnerHtml = iframe;

               


                //GridView1.AllowPaging = true;
                //BindGrid();

             //   mp1.Show();



                //   Response.End();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "printTrigger()", true);
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
            

















           








        }


        protected void View(object sender, EventArgs e)
        {

            String day = DateTime.Now.Day.ToString();
           


            var folder = Server.MapPath("~/Uploads/Viewtemp");
            var folder2 = Server.MapPath("~/Uploads/Viewtemp/" + day);
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





            //SaveCheckedValues();
            //GridView1.AllowPaging = false;
            //BindGrid();
            //PopulateCheckedValues();
            Label lblTemp = null;
            Label lbldown = null;
            var listOfStrings = new List<string>();


            ArrayList paths = new ArrayList();
            foreach (GridViewRow row in GridView1.Rows)
            {
                lblTemp = (Label)row.FindControl("lblTemplateID");
                lbldown = (Label)row.FindControl("lblDownvery");

                CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");


                if (ChkBoxRows.Checked == true)
                {
                     UserSession session2 = new UserSession();
                     if (session2.User_Group == "CUSTOMER" || session2.User_Group == "CADMIN")
                     {
                         if (true)
                         {

                             CertificateDownld ocd = new CertificateDownld();
                             ocd.Request_Id = row.Cells[1].Text; ;
                             UserSession session = new UserSession();


                             if (lbldown.Text == "Z")
                             {
                                 ocd.Is_Downloaded = "ZY";
                             }
                             else if (lbldown.Text == "Y")
                             {


                                 ocd.Is_Downloaded = "Y";
                             }
                             else if (lbldown.Text == "ZY")
                             {


                                 ocd.Is_Downloaded = "ZY";
                             }


                             else
                             {

                                 ocd.Is_Downloaded = "Y";


                             }

                             if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                             {
                                 dc.ModifyCerficateDownload(ocd);
                             }




                             String A = lblTemp.Text;
                             string strFileFullPath = Server.MapPath(A);

                             if (System.IO.File.Exists(strFileFullPath))
                             {
                                 listOfStrings.Add(Server.MapPath(A));
                             }
                             paths.Add(A);



                             foreach (var data in dc.getSupportingDocuments(row.Cells[1].Text))
                             {
                                 string pathes = data.Certificate_Path;

                                 string strFileFullPathe = Server.MapPath(pathes);

                                 if (System.IO.File.Exists(strFileFullPathe))
                                 {
                                     listOfStrings.Add(Server.MapPath(pathes));
                                 }



                             }

                         }
                     }

                     else {
                         CertificateDownld ocd = new CertificateDownld();
                         ocd.Request_Id = row.Cells[1].Text; ;
                         UserSession session = new UserSession();

                         ocd.Is_Downloaded = "Y";

                         if (session.User_Group == "CUSTOMER" || session.User_Group == "CADMIN")
                         {
                             dc.ModifyCerficateDownload(ocd);
                         }




                         String A = lblTemp.Text;
                         string strFileFullPath = Server.MapPath(A);

                         if (System.IO.File.Exists(strFileFullPath))
                         {
                             listOfStrings.Add(Server.MapPath(A));
                         }
                         paths.Add(A);



                         foreach (var data in dc.getSupportingDocuments(row.Cells[1].Text))
                         {
                             string pathes = data.Certificate_Path;

                             string strFileFullPathe = Server.MapPath(pathes);

                             if (System.IO.File.Exists(strFileFullPathe))
                             {
                                 listOfStrings.Add(Server.MapPath(pathes));
                             }



                         }


                     
                     
                     }

                }


            }
            try
            {
              


                string[] arrayOfStrings = listOfStrings.ToArray();


                String filename = DateTime.Now.ToString();




                string newString = filename.Replace("/", ".");
                string newString2 = newString.Replace(" ", "");
                string newString3 = newString2.Replace(":", ".");
                string path = Server.MapPath("~/Uploads/Viewtemp/" + day + "/" + newString3 + ".pdf");


                CombineMultiplePDFs(arrayOfStrings, path);

           



                // Response.ContentType = "application/octem-Stream";
                // Response.AppendHeader("Content-Disposition", "attachment; filename=" + newString3 + ".pdf");
                //  Response.TransmitFile(Server.MapPath("~/Uploads/" + newString3 + ".pdf"));
                // myIframe.Attributes["src"] = "~/Uploads/" + newString3 + ".pdf";

                 string finalviewDirectPath1 = "../../Uploads/Viewtemp/" + day+"/" + newString3 + ".pdf";


                Session["PDFUrl"] = finalviewDirectPath1;
                string pageurl = "../Certificate/PdfView.aspx";
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
                //   Iframe1.Attributes["src"] = "~/Uploads/" + newString3 + ".pdf";

                //   Iframe1.Attributes["src"] = "../../Uploads/9.26.20162.52.45PM.pdf";

               // string iframe = "<iframe id='iFramePdf' src='" + finalviewDirectPath1 + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
               // diviframe.InnerHtml = iframe;




             //   GridView1.AllowPaging = true;
             //   BindGrid();

                //   mp1.Show();



                //   Response.End();
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "printTrigger()", true);
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



























        }

        protected void select(object sender, EventArgs e)
        {
           // GridView1.AllowPaging = false;
          //  BindGrid();

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

            Label lbldown = (Label)e.Row.FindControl("lblDownvery");
            if (lbldown.Text == "N" && session.User_Group == "CUSTOMER" && e.Row.Cells[10].Text == "Yes")
            {
                e.Row.BackColor = Color.FromName("#FAFAD2");




            }
            if (lbldown.Text == "N" && session.User_Group == "CADMIN" && e.Row.Cells[10
                
                
                
                
                
                ].Text == "Yes")
            {
                e.Row.BackColor = Color.FromName("#FAFAD2");



            }

            if (e.Row.Cells[10].Text == "No" && session.User_Group == "CUSTOMER")
            {

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton3");

                LinkButton1.Visible = true;


            }
            if (e.Row.Cells[10].Text == "No" && session.User_Group == "CADMIN")
            {

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton3");

                LinkButton1.Visible = true;


            }



            if (e.Row.Cells[10].Text == "No" && session.User_Group == "CUSTOMER")
            {

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");

                LinkButton1.Visible = false;


            }



            if (e.Row.Cells[10].Text == "No" && session.User_Group == "CADMIN")
            {

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
               
                LinkButton1.Visible = false;


            }



            if (e.Row.Cells[10].Text == "No" && session.User_Group == "CUSTOMER")
            {

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
             
                LinkButton1.Visible = false;


            }
            if (e.Row.Cells[10].Text == "No" && session.User_Group == "CADMIN")
            {

                //CheckBox ChkBoxRows = (CheckBox)e.Row.FindControl("CheckBox1");
                //ChkBoxRows.Checked = false;
                //ChkBoxRows.Enabled = false;


            }


            if (e.Row.Cells[10].Text == "No" && session.User_Group == "CADMIN")
            {

                //CheckBox ChkBoxRows = (CheckBox)e.Row.FindControl("CheckBox1");
                //ChkBoxRows.Checked = false;
                //ChkBoxRows.Enabled = false;

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton LinkButton2 = (LinkButton)e.Row.FindControl("LinkButton2");
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;

            }

            if (e.Row.Cells[10].Text == "No" && session.User_Group == "CUSTOMER")
            {

                //CheckBox ChkBoxRows = (CheckBox)e.Row.FindControl("CheckBox1");
                //ChkBoxRows.Checked = false;
                //ChkBoxRows.Enabled = false;

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

        protected void LinkButton2_Click(object sender, EventArgs e)
        {



            try
            {
                var listOfStrings = new List<string>();

                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Label1.Visible = false;

                    string id = row.Cells[1].Text;
                    DateTime today = DateTime.Today;
                    DateTime expdate = dc.getCertificateExpireDate(id);
                    //   int result = DateTime.Compare(expdate, today);
                    int result = 1;
                    UserSession session2 = new UserSession();


                    foreach (var data in dc.getSupportingDocuments(row.Cells[1].Text))
                    {
                        string pathes = data.Certificate_Path;

                        string strFileFullPathe = Server.MapPath(pathes);

                        if (System.IO.File.Exists(strFileFullPathe))
                        {
                            listOfStrings.Add(Server.MapPath(pathes));
                        }



                    }

                    string[] arrayOfStrings = listOfStrings.ToArray();


                    String filename = DateTime.Now.ToString();




                    string newString = filename.Replace("/", ".");
                    string newString2 = newString.Replace(" ", "");
                    string newString3 = newString2.Replace(":", ".");
                    string path = Server.MapPath("~/Uploads/" + newString3 + ".pdf");


                    CombineMultiplePDFs(arrayOfStrings, path);




                      

                        String Pathfile = dc.getCertificatePathe(id);
                      
                        //        Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile();



                        //            string filePath = Server.MapPath(Pathfile);
                        //    zip.AddFile(filePath, "files");


                        //Response.Clear();
                        //Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFile.zip");
                        //Response.ContentType = "application/zip";
                        //zip.Save(Response.OutputStream);
                        //Response.End();

                        ////////
                    
                        string finalviewDirectPath1 = "../../Uploads/" + newString3 + ".pdf";

                        var folder = Server.MapPath("~/Uploads/random");

                        if (!Directory.Exists(folder)) {

                            Directory.CreateDirectory(folder);
                        
                        }


                        Session["PDFUrl"] = finalviewDirectPath1;
                        string pageurl = "../Certificate/PdfView.aspx";
                        Page.ClientScript.RegisterStartupScript(
                        this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
                    
                   

                }
            }

            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());  
                System.Console.Error.Write(ex.Message);
                //  return ex.Message;

            }



        }


    }
}