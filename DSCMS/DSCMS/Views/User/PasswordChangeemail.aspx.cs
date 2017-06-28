using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.UserManagement;
using System.Reflection;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.Utility;



namespace DSCMS.Views.User
{
    public partial class PasswordChangeemail : System.Web.UI.Page
    {
        static string DECKey = System.Configuration.ConfigurationManager.AppSettings["DecKey"];
        string Password = DECKey.Substring(12);
        UserSession session;
        UserManager um = new UserManager();
         public string RandomID ;

         public string UserIDH;
         UserManager usrM = new UserManager();

        UserGroupManager ugm = new UserGroupManager();
        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
    
                                                                                         
        protected void Page_Load(object sender, EventArgs e)
        {

         UserIDH   = Request.QueryString["Username"];
         RandomID = Request.QueryString["No"];


           string compare= usrM.getRandomID(UserIDH);

           if (RandomID.ToString() != compare) {

               Response.Redirect("~/Views/Home/Login.aspx");
           
           
           }

           UserID.Text = UserIDH;



            //Random rnd = new Random();
            //int myRandomNo = rnd.Next(10000000, 99999999);

            //session = new UserSession();
            ////if (session.User_Id == "")
            ////{
            ////    Response.Redirect("~/Views/Home/Login.aspx");
            ////}

            //string groupId = session.User_Group;
            //CheckAuthManager Am = new CheckAuthManager();
            //bool auth = Am.IsUserGroupAuthorised(groupId, "proc");
            //if (auth == false)
            //{
            //    Response.Redirect("~/Views/Home/Login.aspx");
            //}
            //UserID.Text = session.User_Id;



        }


        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                //Object a;
                String b = UserID.Text;

              //  string pass = EncDec.Encrypt(OldPassword.Text, Password);
                DCISDBManager.objLib.Usr.User passwordcheck = new DCISDBManager.objLib.Usr.User();

               



                   
                    DCISDBManager.objLib.Usr.User adUser = new DCISDBManager.objLib.Usr.User();
                    adUser.User_ID = UserID.Text;
                    adUser.Password_ = NewPassword.Text;
                    // a = um.getUserPassword(adUser.User_ID, "%");
                    /*  foreach (Object value in a)
                      {
                          b = Convert.ToString(value);
                      }*/
                    um.ModifyUserPassword(adUser.User_ID, adUser.Password_);
                   
                   
                    string qu = null;
                    qu += "<div style='color:green' class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong>Save Success...!</strong> </div>";

                    ErrorMessage.InnerHtml = qu;

                    Random rnd = new Random();
                    int myRandomNo = rnd.Next(10000000, 99999999);

                    DCISDBManager.objLib.Usr.User adUserx = new DCISDBManager.objLib.Usr.User();
                    adUserx.Password_ = myRandomNo.ToString();
                    adUserx.User_ID = UserID.Text;

                    usrM.ModifyRandomNo(adUserx);
                    UserID.Text = null;
              

            }

            catch (Exception es)
            {


                System.Console.Error.Write(es.Message);

            }

        }





    }
}