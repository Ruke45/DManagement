using DCISDBManager.objLib.Template;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.MasterDataManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * Made By : Tharaka
 * Changed date : 12/15/2016
 * Change Done : Disable showing CO forms of MASS, Nidro & Orient global for other customers.
 * Requested Date : 12/14/2016
 * Version No : 12.2
 * **/

namespace DSCMS.Views.Home
{
    public partial class TemplateDownload : System.Web.UI.Page
    {
        TemplateDownloadManager TDManager = new TemplateDownloadManager();
        List<CertificateTemplate> TemplateList = new List<CertificateTemplate>();

        string GOLOBALTMP = System.Configuration.ConfigurationManager.AppSettings["GOLOBALTMP"];
        string MASSACTIVE = System.Configuration.ConfigurationManager.AppSettings["MASSACTIVE"];
        string NINDROTMP = System.Configuration.ConfigurationManager.AppSettings["NINDROTMP"];

        string UserGroupID_SAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
        string UserGroupID_Admin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
        UserSession userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            string TempID = Request.QueryString["TempID"];
            userSession = new UserSession();
            if (!IsPostBack)
            {
                DisplayTemplates();
            }
            if (TempID != null)
            {
                DownloadTemplate(TempID);
            }


        }

        private void DisplayTemplates()
        {
            TemplateList = TDManager.getDownloadTemplates();

            string Qu = null;
            int count = 0;
            int printed = 0;
            for (int x = 0; x < TemplateList.Count; x++)
            {
                
                if (count == 0 && printed == 0)
                {
                    Qu += "<div class=\"row\">";
                    printed = 1;
                }
                if (userSession.User_Group.Equals(UserGroupID_SAdmin) || userSession.User_Group.Equals(UserGroupID_Admin))
                {

                    Qu += "<div class=\"col-md-4 text-center\"><div class=\"panel panel-pricing\">";
                    Qu += "<div class=\"panel-body text-center\">";
                    Qu += "<img src=\"" + TemplateList[x].Template_IMG_Path + "\" class=\"img-thumbnail\" width=\"304\" height=\"236\"/></div>";
                    Qu += "<ul class=\"list-group text-center\">";
                    Qu += "<li class=\"list-group-item\">" + TemplateList[x].Template_Display_Name + "</li></ul>";
                    Qu += "<div class=\"panel-footer\">";
                    Qu += "<a class=\"btn btn-lg btn-block btn-default\" href=\"TemplateDownload.aspx?TempID=" + TemplateList[x].Template_ID + "\">Download</a>";
                    Qu += "</div></div></div>";
                    count++;
                }
                else if (TemplateList[x].Template_ID.Equals(GOLOBALTMP) && userSession.Template_ID.Equals(GOLOBALTMP))
                {
                    Qu += "<div class=\"col-md-4 text-center\"><div class=\"panel panel-pricing\">";
                    Qu += "<div class=\"panel-body text-center\">";
                    Qu += "<img src=\"" + TemplateList[x].Template_IMG_Path + "\" class=\"img-thumbnail\" width=\"304\" height=\"236\"/></div>";
                    Qu += "<ul class=\"list-group text-center\">";
                    Qu += "<li class=\"list-group-item\">" + TemplateList[x].Template_Display_Name + "</li></ul>";
                    Qu += "<div class=\"panel-footer\">";
                    Qu += "<a class=\"btn btn-lg btn-block btn-default\" href=\"TemplateDownload.aspx?TempID=" + TemplateList[x].Template_ID + "\">Download</a>";
                    Qu += "</div></div></div>";
                    count++;
                }
                else if (TemplateList[x].Template_ID.Equals(MASSACTIVE) && userSession.Template_ID.Equals(MASSACTIVE))
                {
                    Qu += "<div class=\"col-md-4 text-center\"><div class=\"panel panel-pricing\">";
                    Qu += "<div class=\"panel-body text-center\">";
                    Qu += "<img src=\"" + TemplateList[x].Template_IMG_Path + "\" class=\"img-thumbnail\" width=\"304\" height=\"236\"/></div>";
                    Qu += "<ul class=\"list-group text-center\">";
                    Qu += "<li class=\"list-group-item\">" + TemplateList[x].Template_Display_Name + "</li></ul>";
                    Qu += "<div class=\"panel-footer\">";
                    Qu += "<a class=\"btn btn-lg btn-block btn-default\" href=\"TemplateDownload.aspx?TempID=" + TemplateList[x].Template_ID + "\">Download</a>";
                    Qu += "</div></div></div>";
                    count++;
                }
                else if (TemplateList[x].Template_ID.Equals(NINDROTMP) && userSession.Template_ID.Equals(NINDROTMP))
                {
                    Qu += "<div class=\"col-md-4 text-center\"><div class=\"panel panel-pricing\">";
                    Qu += "<div class=\"panel-body text-center\">";
                    Qu += "<img src=\"" + TemplateList[x].Template_IMG_Path + "\" class=\"img-thumbnail\" width=\"304\" height=\"236\"/></div>";
                    Qu += "<ul class=\"list-group text-center\">";
                    Qu += "<li class=\"list-group-item\">" + TemplateList[x].Template_Display_Name + "</li></ul>";
                    Qu += "<div class=\"panel-footer\">";
                    Qu += "<a class=\"btn btn-lg btn-block btn-default\" href=\"TemplateDownload.aspx?TempID=" + TemplateList[x].Template_ID + "\">Download</a>";
                    Qu += "</div></div></div>";
                    count++;
                }
                else
                {
                    if (TemplateList[x].Template_ID != MASSACTIVE && TemplateList[x].Template_ID != GOLOBALTMP && TemplateList[x].Template_ID != NINDROTMP)
                    {
                        Qu += "<div class=\"col-md-4 text-center\"><div class=\"panel panel-pricing\">";
                        Qu += "<div class=\"panel-body text-center\">";
                        Qu += "<img src=\"" + TemplateList[x].Template_IMG_Path + "\" class=\"img-thumbnail\" width=\"304\" height=\"236\"/></div>";
                        Qu += "<ul class=\"list-group text-center\">";
                        Qu += "<li class=\"list-group-item\">" + TemplateList[x].Template_Display_Name + "</li></ul>";
                        Qu += "<div class=\"panel-footer\">";
                        Qu += "<a class=\"btn btn-lg btn-block btn-default\" href=\"TemplateDownload.aspx?TempID=" + TemplateList[x].Template_ID + "\">Download</a>";
                        Qu += "</div></div></div>";
                        count++;
                    }
                    //else if (TemplateList[x].Template_ID != NINDROTMP)
                    //{
                    //    Qu += "<div class=\"col-md-4 text-center\"><div class=\"panel panel-pricing\">";
                    //    Qu += "<div class=\"panel-body text-center\">";
                    //    Qu += "<img src=\"" + TemplateList[x].Template_IMG_Path + "\" class=\"img-thumbnail\" width=\"304\" height=\"236\"/></div>";
                    //    Qu += "<ul class=\"list-group text-center\">";
                    //    Qu += "<li class=\"list-group-item\">" + TemplateList[x].Template_Display_Name + "</li></ul>";
                    //    Qu += "<div class=\"panel-footer\">";
                    //    Qu += "<a class=\"btn btn-lg btn-block btn-default\" href=\"TemplateDownload.aspx?TempID=" + TemplateList[x].Template_ID + "\">Download</a>";
                    //    Qu += "</div></div></div>";
                    //}
                    //else if (TemplateList[x].Template_ID != GOLOBALTMP)
                    //{
                    //    Qu += "<div class=\"col-md-4 text-center\"><div class=\"panel panel-pricing\">";
                    //    Qu += "<div class=\"panel-body text-center\">";
                    //    Qu += "<img src=\"" + TemplateList[x].Template_IMG_Path + "\" class=\"img-thumbnail\" width=\"304\" height=\"236\"/></div>";
                    //    Qu += "<ul class=\"list-group text-center\">";
                    //    Qu += "<li class=\"list-group-item\">" + TemplateList[x].Template_Display_Name + "</li></ul>";
                    //    Qu += "<div class=\"panel-footer\">";
                    //    Qu += "<a class=\"btn btn-lg btn-block btn-default\" href=\"TemplateDownload.aspx?TempID=" + TemplateList[x].Template_ID + "\">Download</a>";
                    //    Qu += "</div></div></div>";
                    //}
                }

                
                
                if (count == 3)
                {
                    Qu += "</div>";
                    count = 0;
                    printed = 0;
                }
                divTemplateHolder.InnerHtml = Qu;
            }
            
        }

        private void DownloadTemplate(string TempID)
        {
            try
            {
                for (int x = 0; x < TemplateList.Count; x++)
                {
                    if (TemplateList[x].Template_ID.Equals(TempID))
                    {
                        string FilePath = Server.MapPath(TemplateList[x].Download_Path);
                        Response.ContentType = "APPLICATION/OCTET-STREAM";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(FilePath));
                        System.IO.FileInfo Dfile = new System.IO.FileInfo(FilePath);
                        Response.WriteFile(Dfile.FullName);
                        HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                        HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("DownloadTemplate - TemplateDownload.aspx", Ex);
            }
        }
    }
}