<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="ECertificateRequests.aspx.cs" Inherits="DSCMS.Views.Certificate.ECertificateRequests" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
   NCEDCOS | Email Certificate Requests
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <style type="text/css">
        .loading {
            font-family: Cambria;
            font-size: 12pt;
            width: 600px;
            display: none;
            position: fixed;
            background-color: none;
            z-index: 999;
        }

        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: blue;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
    </style>



    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script src="../../js/jquery.min.js"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>





    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Certificate</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i> Email Certificate Requests
                    </li>
                </ol>
            </div>

            <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
                <%--Error Msg goes here--%>
            </div>
        </div>

        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-6">
                            <h3 class="panel-title">Email Certificate Requests</h3>

                        </div>
                        <div class="col col-xs-6 text-right" style="float: right;">
                            <asp:Button ID="btnSyncEmails" CssClass="btn btn-sm btn-default btn-create" runat="server" Text="Synchronize" OnClick="btnSyncEmails_Click" />
                            <asp:Button ID="btnSendEmail" CssClass="btn btn-sm btn-default btn-create" runat="server" Text="Send Approved Certificates" OnClick="btnSendEmail_Click" />
                            <asp:Button ID="btnLoading" Visible="false" runat="server" />

                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <asp:GridView ID="gvPendigECR" BorderStyle="NotSet" runat="server" Font-Names="Cambria"
                        CssClass="table  table-bordered  table-hover table-list-search"
                        AutoGenerateColumns="False">
                        <%--OnRowDataBound="gvPendigECR_RowDataBound"--%>
                        <%--AllowPaging="true" PageSize="2"
                               OnPageIndexChanging="gvPendigCR_PageIndexChanging">--%>
                        <Columns>
                            <asp:BoundField HeaderText="Request Id" DataField="Request_ID" SortExpression="Request_ID" />
                            <asp:BoundField HeaderText="Recived Date" DataField="Recived_Date" SortExpression="Recived_Date" />
                            <asp:BoundField HeaderText="Customer Id" DataField="Customer_ID" SortExpression="Customer_ID" />
                            <asp:BoundField HeaderText="Customer Name" DataField="Customer_Name" SortExpression="Customer_Name" />
                            <asp:BoundField HeaderText="E-Mail" DataField="Email_" SortExpression="Email_" />

                            <%--<asp:TemplateField HeaderText="Certificate">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="DrpdCertificate" CssClass="dropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DrpdCertificate_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                            <%--                                    <asp:TemplateField HeaderText="Supporting Documents">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="DrpSupportingDocuments" CssClass="dropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DrpSupportingDocuments_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Certificate Doc">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequestID" runat="server" Text='<%# Eval("Request_ID") %>' Visible="false" />
                                    <asp:LinkButton ID="lblbtnCertificateDoc" CssClass="btn btn-primary btn-sm" runat="server" OnClick="lblbtnCertificateDoc_Click">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supporting Doc">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblbtnSupportdoc" CssClass="btn btn-primary btn-sm" runat="server" OnClick="lblbtnSupportdoc_Click">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linbtnApprove" CssClass="btn btn-primary btn-sm" runat="server" OnClick="linbtnApprove_Click">Approve</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">

                                <ItemTemplate>
                                    <asp:LinkButton ID="linbtnReject" CssClass="btn btn-primary btn-sm" runat="server" OnClick="linbtnReject_Click">Reject</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    </asp:GridView>
                    <%--  </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnApproveCertificate" />
                            <asp:PostBackTrigger ControlID="btnRejectCertificateReq" />
                             <asp:PostBackTrigger ControlID="linbtnApprove" />
                             <asp:PostBackTrigger ControlID="linbtnReject" />
                            <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnRjClose" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                </div>
                <div class="panel-footer">
                    <div class="row">
                    </div>
                </div>
            </div>

        </div>


    </div>
    <%---------------------------------------------------------%>
    <%---------------------------------------------------------%>
    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="linkDum" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->

    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Genarate Certificate</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Selecte Certificate</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="drpCertificateS" CssClass="form-control" runat="server">
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Password</label>
                        <asp:Label ID="lblApporveRequestID" runat="server" Text="" Visible="false"></asp:Label>
                        <%--                        <asp:Label ID="lblNotSignCertPath" runat="server" Text="" Visible="false" ></asp:Label>--%>
                        <asp:Label ID="lblCustomerId" runat="server" Text="" Visible="false"></asp:Label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCertificatePass" CssClass="form-control" Height="32px" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Comments</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtComment" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email"></label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <%--End of form-horizontal--%>
            </div>
            <div class="modal-footer">

                <asp:Button ID="btnApproveCertificate" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnApproveCertificate_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mpApprove" BehaviorID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="linkDum"
        CancelControlID="lnkDummy" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>




    <%---------------------------------------------------------%>
    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->

    <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Reject Certificate Request</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Reject Reason</label>
                        <asp:Label ID="lblRejectRequestID" runat="server" Text="" Visible="false"></asp:Label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="drpRejectReason" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <%--                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Comments</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email"></label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblRejectError" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <%--End of form-horizontal--%>
            </div>
            <div class="modal-footer">

                <asp:Button ID="btnRejectCertificateReq" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnRejectCertificateReq_Click" />
                <asp:Button ID="btnRjClose" runat="server" Text="Close" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mpReject" runat="server" PopupControlID="Panel2" TargetControlID="LinkButton2"
        CancelControlID="LinkButton2" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>


    <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->

    <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Certificate Supporting Document</h4>

            </div>
            <div class="modal-body">
                <asp:GridView ID="gridSDoc" runat="server" CssClass="table table-responsive  table-bordered  table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <%--                        <asp:BoundField HeaderText="Upload Id" DataField="Seq_No" SortExpression="Seq_No" ItemStyle-Width="100px" />
                        <asp:BoundField HeaderText="Document Id" DataField="Document_Id" SortExpression="Document_Id" ItemStyle-Width="150px" />--%>
                        <asp:BoundField HeaderText="Document Name" DataField="Text" />
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="60px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="linkDownloadSD" runat="server" CommandArgument='<%# Eval("Value") %>' OnClick="linkDownloadSD_Click" CssClass="btn btn-sm btn-default">View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                </asp:GridView>
            </div>
            <div class="modal-footer">
                <asp:Button ID="Button2" runat="server" Text="Close" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="ModelSupDoc" runat="server" PopupControlID="Panel3" TargetControlID="LinkButton4"
        CancelControlID="LinkButton3" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>




    <%-- -----------------------Certificate View --%>

    <asp:LinkButton ID="LinkButton5" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="LinkButton6" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->

    <asp:Panel ID="Panel4" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Certificate Document</h4>

            </div>
            <div class="modal-body">
                <asp:GridView ID="gridCertificate" runat="server" CssClass="table table-responsive  table-bordered  table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <%--                        <asp:BoundField HeaderText="Upload Id" DataField="Seq_No" SortExpression="Seq_No" ItemStyle-Width="100px" />
                        <asp:BoundField HeaderText="Document Id" DataField="Document_Id" SortExpression="Document_Id" ItemStyle-Width="150px" />--%>
                        <asp:BoundField HeaderText="Document Name" DataField="Text" />
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="60px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="linkDownloadCert" runat="server" CommandArgument='<%# Eval("Value") %>' OnClick="linkDownloadSD_Click" CssClass="btn btn-sm btn-default">View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                </asp:GridView>
            </div>
            <div class="modal-footer">
                <asp:Button ID="Button4" runat="server" Text="Close" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="ModelCertificate" runat="server" PopupControlID="Panel4" TargetControlID="LinkButton6"
        CancelControlID="LinkButton5" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>


    <%-- Certificate View End --%>



    <div class="loading" align="center">
        <div class="modal-content">
            <%--                <div class="modal-header">
                    <h4 class="modal-title">Certificate Document</h4>

                </div>--%>
            <div class="modal-body">
                    <asp:Label ID="Label2" runat="server" Text="Label">Please wait while the Operation gets Completed.</asp:Label>
            </div>
            <%--<div class="modal-footer">
                    <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-default" />
                </div>--%>
        </div>
        <br />
    </div>

</asp:Content>
