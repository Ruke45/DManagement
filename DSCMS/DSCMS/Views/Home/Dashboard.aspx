<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DSCMS.Views.Home.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
   NCEDCOS | Dashboard
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                <small>Home</small>
            </h1>
            <ol class="breadcrumb">
                <li class="active">
                    <i class="fa fa-dashboard"></i> Dashboard
                </li>
            </ol>
        </div>
    </div>


    <div class="container">

        <div class="row" runat="server" id="RowNCEAdmin">

            <div class="col-lg-3 col-md-6" runat="server" id="NCEAdmin_CusReqApproval">
                <asp:HyperLink ID="linkCusAp" runat="server" NavigateUrl="~/Views/Customer/Approval.aspx"> <%--link Customer Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Customer Requests Approval</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div1">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/User/UserRequestApproval.aspx"> <%--link User Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user-plus  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>User Requests Approval</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div2">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Views/Customer/CustomerRegistration.aspx"> <%--link Customer Requests NCE Admin--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-male  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Customer Requests</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div3">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Views/User/AddUser.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-users  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>User Requests</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div4">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Views/Report/CoStatistic.aspx"> <%--link Customer Requests NCE Admin--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-file-text-o  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Certificate Details</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div5">
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Views/Customer/CustomerEditList.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Customer Details</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div6">
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Views/Report/Reports.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-file-o  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Certificate Issuance History</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div7">
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Views/Home/TemplateDownload.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-download  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Template Download</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>


             <div class="col-lg-3 col-md-6" runat="server" id="Div23">
                <asp:HyperLink ID="HyperLink24" runat="server" NavigateUrl="~/Views/Parameter/AdminEmailDetail.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-table   fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Email Configuration</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>


        </div>

        
        <div class="row" runat="server" id="ROWNCESignatory">
            <div class="col-lg-3 col-md-6" runat="server" id="Div8">
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Views/Certificate/PendingCertificates.aspx"> <%--link Customer Requests NCE Admin--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-file-text-o  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Pending For Approval
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

                        <div class="col-lg-3 col-md-6" runat="server" id="Div17">
                <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Views/SupportingDoc/SDApproval.aspx"> <%--link Customer Requests NCE Admin--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-file-text-o  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Pending Support Doc For Approval
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>
              <div class="col-lg-3 col-md-6" runat="server" id="Div31">
                <asp:HyperLink ID="HyperLink32" runat="server" NavigateUrl="~/Views/Certificate/CertifcateDownload.aspx"> <%--link Customer Requests NCE Admin--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-file-text-o  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Approved Certificate Download</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div24">
                <asp:HyperLink ID="HyperLink25" runat="server" NavigateUrl="~/Views/Report/CoStatistic.aspx"> <%--link Customer Requests NCE Admin--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-file-text-o  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Approved Certificate Details</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>


            <div class="col-lg-3 col-md-6" runat="server" id="Div9">
                <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Views/Maintenance/SupportingDocumentDownload.aspx"> <%--link Customer Requests NCE Admin--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-file-text  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Approved Supporting Document Download</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div10">
                <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Views/Report/Reports.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-file-o  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Certificate Issuance History</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div11">
                <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Views/Customer/CustomerEditList.aspx"> <%--link Customer Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Customer Details</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div32">
                <asp:HyperLink ID="HyperLink33" runat="server" NavigateUrl="~/Views/Maintenance/CustomerRequestStatus.aspx"> <%--link Customer Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-file-o  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Certificate Request Status</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>


        </div>
    

        <div class="row" runat="server" id="ROWCADMINNCUSTOMER">

            <div class="col-lg-3 col-md-6" runat="server" id="Div12">
                <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Views/Maintenance/CustomerRequestStatus.aspx"> <%--link Customer Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-retweet fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Certificate Request Status</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div13">
                <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Views/Customer/ViewCustomerDetails.aspx"> <%--link Customer Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Customer Details</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div14">
                <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Views/Report/CoStatistic.aspx"> <%--link Customer Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-circle-o-notch fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Certificate Issuance Details</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div15">
                <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Views/Certificate/CertificateRequest.aspx"> <%--link Customer Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-clipboard fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Certificate Request</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div16">
                <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Views/Certificate/CertificateUpload.aspx"> <%--link Customer Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-upload fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Upload Based Certificate Request</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            

            <div class="col-lg-3 col-md-6" runat="server" id="Div18">
                <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/Views/Maintenance/SupportingDocumentDownload.aspx"> <%--link Customer Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-download fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Download Approved Documents</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div19">
                <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/Views/Certificate/CertifcateDownload.aspx"> <%--link Customer Requests Approval--%>
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-download fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Download Approved CO</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="Div20">
                <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="~/Views/Home/TemplateDownload.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-download  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Template Download</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

            <div class="col-lg-3 col-md-6" runat="server" id="CAdminNuserR">
                <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="~/Views/User/UserRequest.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user-plus  fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>New User Request</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

        </div>


                <div class="row" runat="server" id="ROWFINANCEADMIN">


              <div class="col-lg-3 col-md-6" runat="server" id="Div21">
                <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="~/Views/Invoice/MonthlyAllInvoice.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-usd fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Invoice</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

                      <div class="col-lg-3 col-md-6" runat="server" id="Div22">
                <asp:HyperLink ID="HyperLink23" runat="server" NavigateUrl="~/Views/Invoice/MonthlyInvoiceReport.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-table   fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Invoice Detail Report</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

              <div class="col-lg-3 col-md-6" runat="server" id="Div25">
                <asp:HyperLink ID="HyperLink26" runat="server" NavigateUrl="~/Views/Report/CORegistryReport.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-table   fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>CO Registry Report</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

                                  <div class="col-lg-3 col-md-6" runat="server" id="Div26">
                <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="~/Views/Report/CustomerStatementReport.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-table   fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Customer Statement</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>

              <div class="col-lg-3 col-md-6" runat="server" id="Div27">
                <asp:HyperLink ID="HyperLink28" runat="server" NavigateUrl="~/Views/Report/CustomTransacDetailRprt.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-table   fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Customer Transaction Details</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>
                                  <div class="col-lg-3 col-md-6" runat="server" id="Div28">
                <asp:HyperLink ID="HyperLink29" runat="server" NavigateUrl="~/Views/Report/SalesbyCustomer.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-table   fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Sales By Customer</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>
              <div class="col-lg-3 col-md-6" runat="server" id="Div29">
                <asp:HyperLink ID="HyperLink30" runat="server" NavigateUrl="~/Views/Report/SalesByItemSummaryMNRprt.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-table   fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Sales By Item Summary M or N/m</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>
                                  <div class="col-lg-3 col-md-6" runat="server" id="Div30">
                <asp:HyperLink ID="HyperLink31" runat="server" NavigateUrl="~/Views/Report/WeeklySummaryRprt.aspx">
                    <div class="panel panel-default boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-table   fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div>Weekly Summary</div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer">
                                <%--<span class="pull-left">View Details</span>--%>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                       
                     </div>
                </asp:HyperLink>
            </div>
                    
                    </div>
    </div>
</asp:Content>
