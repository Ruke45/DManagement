/*
//PROGRAM-ID.                   CustomerRegistration.cs
//AUTHOR.                             Nipun Munipura
//COMPANY.                         VOTRE IT (Pvt.) Ltd.
 
//DATE-WRITTEN.                                2016-11-08
 
//Version.                               1.0.0
 
//*******************************************************************************
 
//                                Copyright(c) 2016-2017 VOTRE IT Pvt Ltd
 
//                                                        ALL RIGHTS RESERVED
 
//*******************************************************************************
 
//This software is the confidential and proprietary information of VOTRE IT Pvt. Ltd.
 
//("Confidential Information").
 
//You shall not disclose such Confidential Information and shall use it only in
 
//accordance with the terms of the license agreement you entered into with VOTRE IT.
 
//*******************************************************************************
 
//AMENDMENT HISTORY.
 
//===================
 
//  1.  PROGRAMMER   : NIPUN MUNIPURA
 
//      DATE         : 2016-Dec-19
//      Version             : 1.0.1
//      DESCRIPTION  : Add Direct print button and bulk print button
//      the command is:;
 
 

//******************************************************************************
 
//  ABSTRACT ( PROGRAM DESCRIPTION )
 
//  ================================
 
//******************************************************************************
 
//*/


using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.Utility;
using DSCMS.PDFCreator;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Report
{
    public partial class CoStatistic : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            CheckAutentication();
            
                FistPageLoad();
                if (!IsPostBack)
                {
                    txtFromDate.Text = DateTime.Today.ToShortDateString();
                    txtTodate.Text = DateTime.Today.ToShortDateString();
                    GetDataforGrid();
                }
                
            }

        private void FistPageLoad()
        {
            try
            {
                CustomerDetailManager cm = new CustomerDetailManager();

                string AGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
                string SGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
                string FGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_FAdmin"];
                string group = userSession.User_Group;
                string CustomerId = userSession.Customer_ID;

                if (AGroupId == group || SGroupId == group || FGroupId == group)
                {

                    if (!IsPostBack)
                    {
                        drpSearch.DataSource = cm.getAllCustomer("Y");
                        drpSearch.DataValueField = "CustomerId1";
                        drpSearch.DataTextField = "CustomerName1";
                        drpSearch.DataBind();
                        lblcusid.InnerText = "Customer Name";
                    }
                }
                else
                {

                    drpSearch.Visible = false;
                    gvCertificate.Columns[0].Visible = false;

                }

              
                   

            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }
        }
        private void CheckAutentication()
        {
            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            try
            {
                string groupId = userSession.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "Costa");
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

        protected void Find_onClick(object sender, EventArgs e) {
            GetDataforGrid();
            
        }

        private void GetDataforGrid()
        {
            try
            {
                string UserGroupID_Customer = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
                string UserGroupID_CustomerAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
                string group = userSession.User_Group;
                

                


                string CustomerId = drpSearch.SelectedValue;
                string start = txtFromDate.Text;
                string End = txtTodate.Text;
                string certNo = txtcertNo.Text;
                if (txtcertNo.Text=="")
                {
                    certNo="%";
                }
                   
                
                DateTime start1 = Convert.ToDateTime(start);
                DateTime End1 = Convert.ToDateTime(End);
                if (CustomerId == "All")
                {
                    CustomerId = "%";
                }
                if (UserGroupID_Customer == group || UserGroupID_CustomerAdmin==group)
                {
                   CustomerId = userSession.Customer_ID;
                }
                
                if (txtFromDate.Text != "01/01/0001" && txtTodate.Text != "01/01/0001")
                {
                   // CertificateManager CM = new CertificateManager();
                   // gvCertificate.DataSource = CM.getAllConsignee(CustomerId, "A", start1, End1, certNo);
                   // gvCertificate.DataBind();
                    string FromDate = null;
                    string todate = null;
                    string invoiceNo=txtInvoiceNo.Text;
                    if (txtInvoiceNo.Text=="")
                    {
                       invoiceNo = "%";
                       
                   }
                       
                    
                    DownloadCertificate DC = new DownloadCertificate();
                    if (txtInvoiceNo.Text != "" || txtcertNo.Text != "")
                    {

                        todate = DateTime.Now.ToString("yyyyMMdd");
                        FromDate = DateTime.Now.AddYears(-20).ToString("yyyyMMdd");


                    }
                    else {
                        FromDate = start1.ToString("yyyyMMdd");
                        todate = End1.ToString("yyyyMMdd");


                    }
                   
                        
                        gvCertificate.DataSource = DC.getRequestIDUserDate("%", CustomerId, FromDate, todate, certNo, "%", invoiceNo);
                    
                    gvCertificate.DataBind();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string DirectPath;
                string path1;
                string path2;
                string viewDirectPath1;
                string viewDirectPath;
                createpdf(sender, out DirectPath, out path1, out path2, out viewDirectPath1, out viewDirectPath);
                if (!File.Exists(Server.MapPath(viewDirectPath1)))
                {
                    AddText(DirectPath, path1);

                  


                    string firstpath = MapPath(path2);

                    File.Move(firstpath, MapPath(viewDirectPath1));
                    Session["PDFUrl"] = viewDirectPath;
                    string pageurl = "../Certificate/PdfView.aspx";
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
                  //  pop.Visible = true;
                    //string iframe = "<iframe src='" + viewDirectPath + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
                   // diviframe.InnerHtml = iframe;
                }
                else
                {
                    Session["PDFUrl"] = viewDirectPath;
                    string pageurl = "../Certificate/PdfView.aspx";
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
                   // pop.Visible = true;
                   // string iframe = "<iframe src='" + viewDirectPath + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
                    //diviframe.InnerHtml = iframe;
                }
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }
        }

        private void AddText(string DirectPath, string path1)
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
        }

        private void createpdf(object sender, out string DirectPath, out string path1, out string path2, out string viewDirectPath1, out string viewDirectPath)
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
                DirectPath = "~/Documents/Copy/" + DateTime.Now.ToString("yyyy_MM_dd") + "/";
                Label Path = null;
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Path = (Label)row.FindControl("CertificatePath");
                }

                // pop.Visible = true;
                string Fpath = Path.Text;
                path1 = Fpath;// Fpath.Replace("~", "../..");
                path2 = path1.Replace(".pdf", "(copy).pdf");
                char[] splitchar = { '/' };
                string filename = null;
                string[] strarry = path2.Split(splitchar);
                for (count = 0; count <= strarry.Length - 1; count++)
                {
                    filename = strarry[strarry.Length - 1];
                }
                viewDirectPath1 = DirectPath + filename;
                viewDirectPath = viewDirectPath1;//viewDirectPath1.Replace("~", "../..");
           
        }
       
        
        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvCertificate.PageIndex = e.NewPageIndex;
            GetDataforGrid();
            
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
           // pop.Visible = false;
        }


        protected Boolean InvoicedCertificateBtn(string CertificatePath)
        {
            if (CertificatePath == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

         protected Boolean Certificatelable(string CertificatePath)
        {
            if (CertificatePath != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


         protected void Print_Click(object sender, EventArgs e)
         {
             try
             {
                 string DirectPath;
                 string path1;
                 string path2;
                 string viewDirectPath1;
                 string viewDirectPath;
                 createpdf(sender, out DirectPath, out path1, out path2, out viewDirectPath1, out viewDirectPath);
                 string finalviewDirectPath1 = null;
                 finalviewDirectPath1 = viewDirectPath1.Replace("~", "../..");
                 if (!File.Exists(Server.MapPath(viewDirectPath1)))
                 {
                     AddText(DirectPath, path1);




                     string firstpath = MapPath(path2);

                     File.Move(firstpath, MapPath(viewDirectPath1));
                     
                      // pop.Visible = true;
                     string iframe = "<iframe id='iFramePdf' src='" + finalviewDirectPath1 + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
                      diviframe.InnerHtml = iframe;
                      Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "printTrigger()", true);
                 }
                 else
                 {
                    
                     // pop.Visible = true;
                     string iframe = "<iframe id='iFramePdf' src='" + finalviewDirectPath1 + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
                     diviframe.InnerHtml = iframe;
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "printTrigger()", true);
                 }
             }
             catch (Exception ex)
             {
                 ErrorLog.LogError(ex);
             }
         }



         protected void down(object sender, EventArgs e)
         {
             try
             {
             string[] subdirectoryEntries = Directory.GetDirectories(Server.MapPath("~/Documents/Copy/"));
             foreach (string subdirectory in subdirectoryEntries)
             {
                 if (subdirectory != MapPath("~/Documents/Copy/" + DateTime.Now.ToString("yyyy_MM_dd")))
                 {
                     Directory.Delete(subdirectory, true);
                 }
             }

             if (!Directory.Exists(Server.MapPath("~/Documents/Copy/" + DateTime.Now.ToString("yyyy_MM_dd"))))
             {
                 Directory.CreateDirectory(Server.MapPath("~/Documents/Copy/" + DateTime.Now.ToString("yyyy_MM_dd")));
             }


             Label lblTemp = null;
             var listOfStrings = new List<string>();


             ArrayList paths = new ArrayList();
             foreach (GridViewRow row in gvCertificate.Rows)
             {
                 lblTemp = (Label)row.FindControl("CertificatePath");

                 CheckBox ChkBoxRows = (CheckBox)row.FindControl("CheckBox1");


                 if (ChkBoxRows.Checked == true)
                 {
                     
                     String A = lblTemp.Text;
                     string strFileFullPath = Server.MapPath(A);

                     if (System.IO.File.Exists(strFileFullPath))
                     {
                         listOfStrings.Add(Server.MapPath(A));
                     }
                     paths.Add(A);



                 }


             }
            
                


                 string[] arrayOfStrings = listOfStrings.ToArray();


                 String filename = DateTime.Now.ToString();

                 // Response.Redirect("CertifcateDownload.aspx", true);

                 string newString = filename.Replace("/", ".");
                 string newString2 = newString.Replace(" ", ".");
                 string newString3 = newString2.Replace(":", ".");
                 string path = Server.MapPath("~/Documents/Copy/" +DateTime.Now.ToString("yyyy_MM_dd")+"/"+ newString3 + ".pdf");
                 CombineMultiplePDFs(arrayOfStrings, path);
                // Response.ContentType = "application/octem-Stream";
                // Response.AppendHeader("Content-Disposition", "attachment; filename=" + newString3 + ".pdf");
                 // Response.TransmitFile(Server.MapPath("~/Uploads/" + filename));
              //   Response.TransmitFile(Server.MapPath("~/Documents/Copy/" + newString3 + ".pdf"));





                
                 int count = 0;
                 string DirectPath = "~/Documents/Copy/" + DateTime.Now.ToString("yyyy_MM_dd") + "/";




                 string Fpath = "~/Documents/Copy/"+DateTime.Now.ToString("yyyy_MM_dd")+"/" + newString3 + ".pdf";
                 string path1 = Fpath.Replace("~", "../..");
                 string path2 = path1.Replace(".pdf", "(copy).pdf");
                 char[] splitchar = { '/' };
                 string filename1 = null;
                 string[] strarry = path2.Split(splitchar);
                 for (count = 0; count <= strarry.Length - 1; count++)
                 {
                     filename1 = strarry[strarry.Length - 1];
                 }
                 string viewDirectPath1 = DirectPath + filename1;
                 string viewDirectPath = viewDirectPath1.Replace("~", "../..");
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
                      pdfReader.Close();
                     // now delete the original file and rename the temp file to the original file
                     //File.Delete(FileLocation);
                     // File.Move(FileLocation.Replace(".pdf", "(copy).pdf"), FileLocation);

                     DateTime today = DateTime.Today;

                     //DirectoryPath which will save the NOT singed PDF File as NOT_Signed.pdf in the given Path
                    

                  


                     string firstpath = MapPath(path2);

                     File.Move(firstpath, MapPath(viewDirectPath1));

                     string iframe = "<iframe id='iFramePdf' src='" + viewDirectPath + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
                     diviframe.InnerHtml = iframe;
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "printTrigger()", true);
                    
                 }
                 else
                 {

                     string iframe = "<iframe id='iFramePdf' src='" + viewDirectPath + "#toolbar=0' class='col-lg-12' style='height:90%;width:90%'  ></iframe>";
                     diviframe.InnerHtml = iframe;
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "printTrigger()", true);
                   
                 }

                 


                 //Response.End();

                 Response.Flush();
                 //Response.SuppressContent = true;
                 //HttpContext.Current.ApplicationInstance.CompleteRequest();


             }

             catch (Exception ex)
             {
                 System.Console.Error.Write(ex.Message);
               
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
        
         
        
    }
}