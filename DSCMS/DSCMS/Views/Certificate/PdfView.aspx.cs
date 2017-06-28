using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Certificate
{
    public partial class PdfView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string RequestID = Request.QueryString["ID"];
            string DocumentName = Request.QueryString["DN"];
            string DocPath = Session["PDFUrl"].ToString();

            try
            {
                string isPDF = DocPath.Substring(Math.Max(0, DocPath.Length - 4));


                if (Session["PDFUrl"] != null)
                {
                    if (isPDF.ToLower().Equals(".pdf"))
                    {
                        WebClient user = new WebClient();
                        Byte[] FileBuffer = user.DownloadData(Server.MapPath(DocPath));
                        if (FileBuffer != null)
                        {
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", FileBuffer.Length.ToString());
                            Response.BinaryWrite(FileBuffer);
                            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                            HttpContext.Current.ApplicationInstance.CompleteRequest();

                        }
                    }
                    else
                    {
                        Response.ContentType = "APPLICATION/OCTET-STREAM";
                        String Header = "Attachment; Filename=" + DocumentName;
                        Response.AppendHeader("Content-Disposition", Header);
                        System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath(DocPath));
                        Response.WriteFile(Dfile.FullName);
                        //Don't forget to add the following line
                        HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                        HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }

                }
                Session["PDFUrl"] = null;
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }
    }
}