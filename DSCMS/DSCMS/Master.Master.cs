using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.UserManagement;
using DCISDBManager.trnLib.ParameterManagement;
using DCISDBManager.trnLib.Utility;

namespace DSCMS
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public static int ab = 2;







        public string FromServer = ab.ToString();
        NotitificationCount NC = new NotitificationCount();



        //string a;
        //public string ErrorMessage
        //{

        //    get
        //    {
        //        return a;



        //    }
        //    set
        //    {

        //        a = value;

        //    }



        //}








        UserSession userSession;
        string UserGroupID_Customer = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
        string UserGroupID_Admin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
        string UserGroupID_FAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_FAdmin"];
        string UserGroupID_SAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
        string UserGroupID_PAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_PAdmin"];
        string UserGroupID_CustomerAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];

        public void Page_Load(object sender, EventArgs e)
        {

            //    Response.AppendHeader("Refresh", "5");
            string b;



            if (!IsPostBack)
            {
                userSession = new UserSession();
                NavigationRight_Print();

                if (userSession.User_Group != UserGroupID_FAdmin)
                {
                    Show();
                    FromServer = ab.ToString();

                }
                else
                {

                    noti_Counter.Visible = false;
                    noti_Button.Visible = false;
                    notifications1.Visible = false;

                }
            }
            else
            {
                userSession = new UserSession();


                if (userSession.User_Group != UserGroupID_FAdmin)
                {
                    Show();
                    FromServer = ab.ToString();

                }
                else
                {

                    noti_Counter.Visible = false;
                    noti_Button.Visible = false;
                    notifications1.Visible = false;

                }
            }

        }

        protected void NavigationRight_Print()
        {
            //  string print = null;

            if (userSession.User_Id.Equals(""))
            {

                linkDashboard.Visible = false;

                listItemCAdminRequest.Visible = false;
                listItemCAdminViews.Visible = false;
                listItemCAdminDownload.Visible = false;
                listItemCAdminEdit.Visible = false;
                listItemCertificateCancel.Visible = false;

                listItemFAdminInvoiceing.Visible = false;
                listItemFAdminViews.Visible = false;

                listItemNCEAdminApproval.Visible = false;
                listItemNCEAdminDownload.Visible = false;
                listItemNCEAdminViews.Visible = false;
                listItemUser.Visible = false;
                listItemCertificate.Visible = false;
                listItemCustomer.Visible = false;

                listItemProfile.Visible = false;

                listItemSigApproval.Visible = false;
                listItemSigDownload.Visible = false;
                listItemSigViews.Visible = false;

                lisReportsViwer.Visible = false;

                listNCEAdminMaintenance.Visible = false;


            }
            else if (userSession.User_Group.Equals(UserGroupID_Customer))
            {
                linkHome.Visible = false;

                listItemFAdminInvoiceing.Visible = false;
                listItemFAdminViews.Visible = false;
                listItemCertificateCancel.Visible = false;
                listItemNCEAdminApproval.Visible = false;
                listItemNCEAdminDownload.Visible = false;
                listItemNCEAdminViews.Visible = false;
                listItemUser.Visible = false;
                listItemCertificate.Visible = false;
                listItemCustomer.Visible = false;
                listItemCAdminEdit.Visible = false;
                // listItemProfile.Visible = false;

                listItemSigApproval.Visible = false;
                listItemSigDownload.Visible = false;
                listItemSigViews.Visible = false;

                listNCEAdminMaintenance.Visible = false;

                linkCAdminUsrRequest.Visible = false;

                linkRegister.Visible = false;
                linkLogin.Visible = false;

                lisReportsViwer.Visible = false;

                userName.InnerHtml = userSession.User_Id;
            }
            //else if (userSession.User_Group.Equals(UserGroupID_PAdmin))
            //{

            //    userName.InnerHtml = userSession.User_Id;
            //}
            else if (userSession.User_Group.Equals(UserGroupID_FAdmin))
            {
                linkHome.Visible = false;

                listItemCAdminRequest.Visible = false;
                listItemCAdminViews.Visible = false;
                listItemCAdminDownload.Visible = false;
                listItemCAdminEdit.Visible = false;
                listItemCertificate.Visible = false;

                listItemNCEAdminApproval.Visible = false;
                listItemNCEAdminDownload.Visible = false;
                listItemNCEAdminViews.Visible = false;
                listItemUser.Visible = false;
                listItemCertificate.Visible = false;
                listItemCustomer.Visible = false;

                listNCEAdminMaintenance.Visible = false;

                linkRegister.Visible = false;
                linkLogin.Visible = false;


                listItemSigApproval.Visible = false;
                listItemSigDownload.Visible = false;
                listItemSigViews.Visible = false;

                userName.InnerHtml = userSession.User_Id;
            }
            else if (userSession.User_Group.Equals(UserGroupID_SAdmin))
            {
                linkHome.Visible = false;

                listItemCAdminRequest.Visible = false;
                listItemCAdminViews.Visible = false;
                listItemCAdminDownload.Visible = false;
                listItemCAdminEdit.Visible = false;
                listItemCertificate.Visible = false;

                listItemFAdminInvoiceing.Visible = false;
                listItemFAdminViews.Visible = false;

                listItemNCEAdminApproval.Visible = false;
                listItemNCEAdminDownload.Visible = false;
                listItemNCEAdminViews.Visible = false;
                listItemUser.Visible = false;
                listItemCertificate.Visible = false;
                listItemCustomer.Visible = false;

                listNCEAdminMaintenance.Visible = false;

                linkRegister.Visible = false;
                linkLogin.Visible = false;

                //lisReportsViwer.Visible = false;

                userName.InnerHtml = userSession.User_Id;
            }
            else if (userSession.User_Group.Equals(UserGroupID_CustomerAdmin))
            {
                linkHome.Visible = false;
                listItemCertificateCancel.Visible = false;
                listItemCertificate.Visible = false;
                listItemUser.Visible = false;
                listItemCustomer.Visible = false;
                listNCEAdminMaintenance.Visible = false;

                listItemFAdminInvoiceing.Visible = false;
                listItemFAdminViews.Visible = false;

                listItemNCEAdminApproval.Visible = false;
                listItemNCEAdminDownload.Visible = false;
                listItemNCEAdminViews.Visible = false;




                listItemSigApproval.Visible = false;
                listItemSigDownload.Visible = false;
                listItemSigViews.Visible = false;

                linkRegister.Visible = false;
                linkLogin.Visible = false;

                lisReportsViwer.Visible = false;

                userName.InnerHtml = userSession.User_Id;
            }
            else
            {
                linkHome.Visible = false;
                listItemCertificateCancel.Visible = false;
                listItemCAdminRequest.Visible = false;
                listItemCAdminViews.Visible = false;
                listItemCAdminDownload.Visible = false;
                listItemCAdminEdit.Visible = false;
                listItemFAdminInvoiceing.Visible = false;
                listItemFAdminViews.Visible = false;

                listItemSigApproval.Visible = false;
                listItemSigDownload.Visible = false;
                listItemSigViews.Visible = false;

                linkRegister.Visible = false;
                linkLogin.Visible = false;

                userName.InnerHtml = userSession.User_Id;

            }
        }

        public void Show()
        {
            try
            {

                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "notifi()", true);

                UserSession us = new UserSession();
                if (us.User_Group == "")
                {
                    noti_Counter.Visible = false;
                    noti_Button.Visible = false;
                    notifications1.Visible = false;



                }
                // SHOW THE ENTIRE LIST FILES FROM THE FOLDER.
                string contactformcount = NC.ContactformCount();
                string pendingCertificate = NC.getCertificateEntryCount("%");
                string penidngUserCount = NC.pendinguserCount();
                string pendingCertifiReq = NC.pendingCertificateRequestCount();
                string emailreq = NC.pendingEmailCertificateRequestCount();
                string uploadreq = NC.pendinguploadCertificateRequestCount();
                string DonwloadCount;
                if (us.User_Group == "CUSTOMER")
                {
                    DonwloadCount = NC.DownloadCount(us.Customer_ID, us.User_Id);
                }
                else {
                    DonwloadCount = NC.DownloadCount(us.Customer_ID,"%");
                
                }
                string supdocCount = NC.supDOcCount(us.Customer_ID);
                string CusCount = NC.pendingCustomerCount();
                string PendingSup = NC.PendingsupDOcCount();
                if (us.User_Group == "ADMIN")
                {

                    if (penidngUserCount.Equals("0") && CusCount.Equals("0") && contactformcount.Equals("0"))
                    {
                        noti_Counter.Visible = false;
                        noti_Button.Visible = false;
                        notifications1.Visible = false;


                    }
                    if (!penidngUserCount.Equals("0") && pendingCertificate.Equals("0") && CusCount.Equals("0"))
                    {
                        ab = 1;


                    }
                    if (!penidngUserCount.Equals("0") && !pendingCertificate.Equals("0") && CusCount.Equals("0"))
                    {
                        ab = 2;


                    }
                    if (!penidngUserCount.Equals("0") && pendingCertificate.Equals("0") && !CusCount.Equals("0"))
                    {
                        ab = 2;


                    }
                    if (penidngUserCount.Equals("0") && !pendingCertificate.Equals("0") && CusCount.Equals("0"))
                    {
                        ab = 1;


                    }
                    if (penidngUserCount.Equals("0") && !pendingCertificate.Equals("0") && !CusCount.Equals("0"))
                    {
                        ab = 2;


                    }
                    if (penidngUserCount.Equals("0") && pendingCertificate.Equals("0") && !CusCount.Equals("0"))
                    {
                        ab = 1;


                    }
                    if (!penidngUserCount.Equals("0") && !pendingCertificate.Equals("0") && !CusCount.Equals("0"))
                    {
                        ab = 3;


                    }









                    String count = penidngUserCount;
                    String countc = pendingCertificate;
                    String countcus = CusCount;
                    string contact = contactformcount;
                    if (!count.Equals("0"))
                    {
                        HyperLink50.Visible = true;
                        HyperLink50.Text = "You have " + count + " Pending User Requests to approve";
                        HyperLink50.NavigateUrl = "~/Views/User/UserRequestApproval.aspx";


                        if (!countcus.Equals("0"))
                        {
                            HyperLink51.Visible = true;
                            HyperLink51.Text = "You have " + countcus + " Customer Requests";
                            HyperLink51.NavigateUrl = "~/Views/Customer/Approval.aspx";
                            if (!contact.Equals("0"))
                            {
                                HyperLink52.Visible = true;
                                HyperLink52.Text = "You have " + contact + " Certificates for Verification ";
                                HyperLink52.NavigateUrl = "~/Views/Contact/MessageList.aspx";



                            }


                        }
                        else
                        {

                            if (!contact.Equals("0"))
                            {
                                HyperLink51.Visible = true;
                                HyperLink51.Text = "You have " + contact + " Certificates for Verification";
                                HyperLink51.NavigateUrl = "~/Views/Contact/MessageList.aspx";



                            }


                        }



                    }

                    else
                    {


                        if (!countcus.Equals("0"))
                        {
                            HyperLink50.Visible = true;
                            HyperLink50.Text = "You have " + countcus + " Customer Requests";
                            HyperLink50.NavigateUrl = "~/Views/Customer/Approval.aspx";

                            if (!contact.Equals("0"))
                            {
                                HyperLink51.Visible = true;
                                HyperLink51.Text = "You have " + contact + " Certificates for Verification";
                                HyperLink51.NavigateUrl = "~/Views/Contact/MessageList.aspx";



                            }
                        }


                        else
                        {

                            if (!contact.Equals("0"))
                            {
                                HyperLink50.Visible = true;
                                HyperLink50.Text = "You have " + contact + "Certificates for Verification";
                                HyperLink50.NavigateUrl = "~/Views/Contact/MessageList.aspx";



                            }



                        }


                    }



                    //    if (!countc.Equals("0"))
                    //    {
                    //    HyperLink51.Visible = true;
                    //    HyperLink51.Text = "You have " + countc + " Certificate Data sets to be entered";
                    //    HyperLink51.NavigateUrl = "~/Views/Certificate/ManualEntry.aspx";
                    //}

                    //    if (!countcus.Equals("0"))
                    //    {
                    //        HyperLink52.Visible = true;
                    //        HyperLink52.Text = "You have " + countcus + " Customer Requests";
                    //        HyperLink52.NavigateUrl = "~/Views/Customer/Approval.aspx";
                    //    }



                    ab = Convert.ToInt32(penidngUserCount) + Convert.ToInt32(pendingCertificate) + Convert.ToInt32(CusCount);

                    ab = Convert.ToInt32(penidngUserCount) + Convert.ToInt32(CusCount) + Convert.ToInt32(contact);
                }
                if (us.User_Group == "SADMIN")
                {

                    if (pendingCertifiReq.Equals("0") && emailreq.Equals("0") && uploadreq.Equals("0") && PendingSup.Equals("0"))
                    {
                        noti_Counter.Visible = false;
                        noti_Button.Visible = false;
                        notifications1.Visible = false;


                    }
                    if (!pendingCertifiReq.Equals("0") && emailreq.Equals("0") && uploadreq.Equals("0") && PendingSup.Equals("0"))
                    {
                        ab = 1;



                    }
                    if (pendingCertifiReq.Equals("0") && !emailreq.Equals("0") && uploadreq.Equals("0") && PendingSup.Equals("0"))
                    {
                        ab = 1;



                    }
                    if (pendingCertifiReq.Equals("0") && emailreq.Equals("0") && !uploadreq.Equals("0") && PendingSup.Equals("0"))
                    {
                        ab = 1;



                    }
                    if (pendingCertifiReq.Equals("0") && emailreq.Equals("0") && uploadreq.Equals("0") && !PendingSup.Equals("0"))
                    {
                        ab = 1;


                    }
                    if (!pendingCertifiReq.Equals("0") && !emailreq.Equals("0") && uploadreq.Equals("0") && PendingSup.Equals("0"))
                    {
                        ab = 2;

                    }
                    if (!pendingCertifiReq.Equals("0") && emailreq.Equals("0") && !uploadreq.Equals("0") && PendingSup.Equals("0"))
                    {
                        ab = 2;


                    }
                    if (!pendingCertifiReq.Equals("0") && emailreq.Equals("0") && uploadreq.Equals("0") && !PendingSup.Equals("0"))
                    {
                        ab = 2;


                    }
                    if (pendingCertifiReq.Equals("0") && !emailreq.Equals("0") && !uploadreq.Equals("0") && PendingSup.Equals("0"))
                    {
                        ab = 2;


                    }
                    if (pendingCertifiReq.Equals("0") && !emailreq.Equals("0") && uploadreq.Equals("0") && !PendingSup.Equals("0"))
                    {
                        ab = 2;


                    }
                    if (pendingCertifiReq.Equals("0") && emailreq.Equals("0") && !uploadreq.Equals("0") && !PendingSup.Equals("0"))
                    {
                        ab = 2;

                    }
                    if (!pendingCertifiReq.Equals("0") && !emailreq.Equals("0") && !uploadreq.Equals("0") && PendingSup.Equals("0"))
                    {
                        ab = 3;



                    }
                    if (!pendingCertifiReq.Equals("0") && !emailreq.Equals("0") && uploadreq.Equals("0") && !PendingSup.Equals("0"))
                    {
                        ab = 3;

                    }
                    if (pendingCertifiReq.Equals("0") && !emailreq.Equals("0") && !uploadreq.Equals("0") && !PendingSup.Equals("0"))
                    {
                        ab = 3;


                    }
                    if (!pendingCertifiReq.Equals("0") && emailreq.Equals("0") && !uploadreq.Equals("0") && !PendingSup.Equals("0"))
                    {
                        ab = 3;

                    }
                    if (!pendingCertifiReq.Equals("0") && !emailreq.Equals("0") && !uploadreq.Equals("0") && !PendingSup.Equals("0"))
                    {

                        ab = 4;

                    }


                    String count = pendingCertifiReq;
                    String counts = emailreq;
                    String countu = uploadreq;
                    String countsup = PendingSup;

                    int pendingcert = Convert.ToInt32(count) + Convert.ToInt32(countu);


                    if (!count.Equals("0"))
                    {
                        HyperLink50.Visible = true;
                        HyperLink50.Text = "You have " + pendingcert.ToString() + " Pending Certificate Requests to Approve";
                        HyperLink50.NavigateUrl = "~/Views/Certificate/PendingCertificates.aspx";

                        if (!counts.Equals("0"))
                        {

                            HyperLink51.Visible = true;
                            HyperLink51.Text = "You have " + counts + " Email Certificate Requests to Approve";
                            HyperLink51.NavigateUrl = "~/Views/Certificate/ECertificateRequests.aspx";


                            if (!countsup.Equals("0"))
                            {
                                HyperLink52.Visible = true;
                                HyperLink52.Text = "You have " + countsup + " Pending Supporting Documents to Approve";
                                HyperLink52.NavigateUrl = "~/Views/SupportingDoc/SDApproval.aspx";
                            }




                        }
                        else
                        {


                            if (!countsup.Equals("0"))
                            {
                                HyperLink51.Visible = true;
                                HyperLink51.Text = "You have " + countsup + " Pending Supporting Documents to Approve";
                                HyperLink51.NavigateUrl = "~/Views/SupportingDoc/SDApproval.aspx";

                            }







                        }



                    }
                    //1count
                    else
                    {
                        if (!counts.Equals("0"))
                        {

                            HyperLink50.Visible = true;
                            HyperLink50.Text = "You have " + counts + " Email Certificate Requests to Approve";
                            HyperLink50.NavigateUrl = "~/Views/Certificate/ECertificateRequests.aspx";

                            if (!countu.Equals("0"))
                            {
                                HyperLink51.Visible = true;
                                HyperLink51.Text = "You have " + countu + " Uploaded Certificate Requests to Approve";
                                HyperLink51.NavigateUrl = "~/Views/Certificate/UploadBCertificateRequests.aspx";
                                if (!countsup.Equals("0"))
                                {
                                    HyperLink52.Visible = true;
                                    HyperLink52.Text = "You have " + countsup + " Pending Supporting Documents to Approve";
                                    HyperLink52.NavigateUrl = "~/Views/SupportingDoc/SDApproval.aspx";
                                }

                            }
                            else
                            {
                                if (!countsup.Equals("0"))
                                {
                                    HyperLink51.Visible = true;
                                    HyperLink51.Text = "You have " + countsup + " Pending Supporting Documents to Approve";
                                    HyperLink51.NavigateUrl = "~/Views/SupportingDoc/SDApproval.aspx";
                                }

                            }

                        }
                        else
                        {
                            if (!countu.Equals("0"))
                            {

                                HyperLink50.Visible = true;
                                HyperLink50.Text = "You have " + countu + " Uploaded Certificate Requests to Approve";
                                HyperLink50.NavigateUrl = "~/Views/Certificate/UploadBCertificateRequests.aspx";
                                if (!countsup.Equals("0"))
                                {
                                    HyperLink51.Visible = true;
                                    HyperLink51.Text = "You have " + countsup + " Pending Supporting Documents to Approve";
                                    HyperLink51.NavigateUrl = "~/Views/SupportingDoc/SDApproval.aspx";
                                }
                            }
                            else
                            {
                                if (!countsup.Equals("0"))
                                {
                                    HyperLink50.Visible = true;
                                    HyperLink50.Text = "You have " + countsup + " Pending Supporting Documents to Approve";
                                    HyperLink50.NavigateUrl = "~/Views/SupportingDoc/SDApproval.aspx";

                                }

                            }




                        }


                    }


                    //if (!counts.Equals("0"))
                    //{
                    //    HyperLink51.Visible = true;
                    //    HyperLink51.Text = "You have " + counts + " Email Certificate Requests to Approve";
                    //    HyperLink51.NavigateUrl = "~/Views/Certificate/ECertificateRequests.aspx";
                    //}


                    //if (!countu.Equals("0"))
                    //{
                    //    HyperLink52.Visible = true;
                    //    HyperLink52.Text = "You have " + countu + " Uploaded Certificate Requests to Approve";
                    //    HyperLink52.NavigateUrl = "~/Views/Certificate/UploadBCertificateRequests.aspx";
                    //}

                    //if (!countsup.Equals("0"))
                    //{
                    //    HyperLink53.Visible = true;
                    //    HyperLink53.Text = "You have " + countsup + " Pending Supporting Documents to Approve";
                    //    HyperLink53.NavigateUrl = "~/Views/SupportingDoc/SDApproval.aspx";

                    //}

                    ab = Convert.ToInt32(pendingCertifiReq) + Convert.ToInt32(PendingSup) + Convert.ToInt32(emailreq) + Convert.ToInt32(uploadreq);

                }

                if (us.User_Group == "CADMIN")
                {
                    if (DonwloadCount.Equals("0") && supdocCount.Equals("0"))
                    {
                        noti_Counter.Visible = false;
                        noti_Button.Visible = false;
                        notifications1.Visible = false;


                    }
                    if (DonwloadCount.Equals("0") && !supdocCount.Equals("0"))
                    {
                        ab = 1;


                    }
                    if (!DonwloadCount.Equals("0") && supdocCount.Equals("0"))
                    {
                        ab = 1;


                    }
                    if (!DonwloadCount.Equals("0") && !supdocCount.Equals("0"))
                    {
                        ab = 2;


                    }


                    String count = DonwloadCount;
                    String countc = supdocCount;
                    if (!count.Equals("0"))
                    {
                        HyperLink50.Visible = true;
                        HyperLink50.Text = "You have " + count + " Certificates to Download";
                        HyperLink50.NavigateUrl = "~/Views/Certificate/CertifcateDownload.aspx";
                        if (!countc.Equals("0"))
                        {
                            HyperLink51.Visible = true;
                            HyperLink51.Text = "You have " + countc + " Supporting Documents to Download";
                            HyperLink51.NavigateUrl = "~/Views/Maintenance/SupportingDocumentDownload.aspx";
                        }
                    }
                    else
                    {
                        if (!countc.Equals("0"))
                        {
                            HyperLink50.Visible = true;
                            HyperLink50.Text = "You have " + countc + " Supporting Documents to Download";
                            HyperLink50.NavigateUrl = "~/Views/Maintenance/SupportingDocumentDownload.aspx";
                        }



                    }



                    ab = Convert.ToInt32(DonwloadCount) + Convert.ToInt32(supdocCount);


                }
                if (us.User_Group == "CUSTOMER")
                {
                    if (DonwloadCount.Equals("0") && supdocCount.Equals("0"))
                    {
                        noti_Counter.Visible = false;
                        noti_Button.Visible = false;
                        notifications1.Visible = false;


                    }
                    if (DonwloadCount.Equals("0") && !supdocCount.Equals("0"))
                    {
                        ab = 1;


                    }
                    if (!DonwloadCount.Equals("0") && supdocCount.Equals("0"))
                    {
                        ab = 1;


                    }
                    if (!DonwloadCount.Equals("0") && !supdocCount.Equals("0"))
                    {
                        ab = 2;


                    }

                    String count = DonwloadCount;
                    String countc = supdocCount;
                    if (!count.Equals("0"))
                    {
                        HyperLink50.Visible = true;
                        HyperLink50.Text = "You have " + count + " Certificates to Download";
                        HyperLink50.NavigateUrl = "~/Views/Certificate/CertifcateDownload.aspx";
                        if (!countc.Equals("0"))
                        {
                            HyperLink51.Visible = true;
                            HyperLink51.Text = "You have " + countc + " Supporting Documents to Download";
                            HyperLink51.NavigateUrl = "~/Views/Maintenance/SupportingDocumentDownload.aspx";
                        }
                    }
                    else
                    {
                        if (!countc.Equals("0"))
                        {
                            HyperLink50.Visible = true;
                            HyperLink50.Text = "You have " + countc + " Supporting Documents to Download";
                            HyperLink50.NavigateUrl = "~/Views/Maintenance/SupportingDocumentDownload.aspx";

                        }
                    }

                    ab = Convert.ToInt32(DonwloadCount) + Convert.ToInt32(supdocCount);
                }

                if (us.User_Group == "FADMIN")
                {
                    ab = 2;

                }






                ltrInfo.Text += "</ul>";
                // ((HyperLink)Master.FindControl("HyperLink49")).NavigateUrl = "~/Views/Home/Dashboard.aspx"; 

                // listh.Add(MapPath("~/Views/Customer/CustomerRegistration.aspx"));



                //BIND THE FILE LIST WITH THE REPEATER CONTROL.
                //rep.DataSource = listh;
                //rep.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
        }
    }
}