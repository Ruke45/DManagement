<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SDApproval.aspx.cs" Inherits="DSCMS.Views.SupportingDoc.SDApproval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Supporting Document Approval
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Supporting Document</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i> Supporting Document Approval
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
                        <div class="col col-xs-7">
                            <h3 class="panel-title">Supporting Document Approval Requests</h3>

                        </div>
                        <%--<div class="col col-xs-3 text-right" style="float: right;">
                            <asp:Button ID="btnSyncEmails" CssClass="btn btn-sm btn-default btn-create" runat="server" Text="Synchronize" OnClick="btnSyncEmails_Click" />
                        </div>--%>
                    </div>
                </div>
                <div class="panel-body">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                            <asp:GridView ID="gvPendigSDR" BorderStyle="NotSet" runat="server" Font-Names="Cambria"
                                CssClass="table  table-bordered  table-hover table-list-search"
                                AutoGenerateColumns="False"
                                AllowPaging="true" PageSize="10"
                               OnPageIndexChanging="gvPendigSDR_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Request Id" DataField="RequestID" SortExpression="Request_ID" />

                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequestID" runat="server" Text='<%# Eval("RequestID") %>' Visible="false" />
                                            <asp:Label ID="lblDocID" runat="server" Text='<%# Eval("SupportingDocID") %>' Visible="true" />
                                            <asp:Label ID="lblww" runat="server" Text=" | " Visible="true" />
                                            <asp:Label ID="lblSDocName" runat="server" Text='<%# Eval("SupportingDocumentName") %>' Visible="true" />                  
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCID" runat="server" Text='<%# Eval("CustomerID") %>' Visible="true" />
                                            <asp:Label ID="lblw" runat="server" Text=" | " Visible="true" />
                                            <asp:Label ID="lblCname" runat="server" Text='<%# Eval("CustomerName") %>' Visible="true" />                  
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField HeaderText="Request By" DataField="RequestBy" SortExpression="RequestBy" />
                                    <asp:BoundField HeaderText="Request Date" DataField="RequestDate" SortExpression="RequestDate" />

                                    <asp:TemplateField HeaderText="Document">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUploadPath" runat="server" Text='<%# Eval("UploadPath") %>' Visible="false" /> 
                                            <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("UploadDocName") %>' Visible="false" />
                                            <asp:LinkButton ID="linkDownDoc"  runat="server" OnClick="linkDownDoc_Click" CssClass="btn btn-default btn-sm">View</asp:LinkButton>
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
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
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



        <%---------------------------------------------------------%>
        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
        <asp:LinkButton ID="linkDum" runat="server"></asp:LinkButton>
        <!-- ModalPopupExtender -->

        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Sign / Approve Document</h4>

                </div>
                <div class="modal-body">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Password</label>
                            <asp:Label ID="lblApporveRequestID" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lblApprovDocPath" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lblSDID" runat="server" Text="" Visible="false"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtCertificatePass" CssClass="form-control" Height="32px" runat="server" TextMode="Password"></asp:TextBox>
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

                    <asp:Button ID="btnApproveDcouemnt" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnApproveDcouemnt_Click" />
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
                    <h4 class="modal-title">Reject Request</h4>

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

                    <asp:Button ID="btnRejectReq" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnRejectReq_Click" />
                    <asp:Button ID="btnRjClose" runat="server" Text="Close" CssClass="btn btn-default" />
                </div>
            </div>
        </asp:Panel>
        <!-- ModalPopupExtender -->
        <cc1:ModalPopupExtender ID="mpReject" runat="server" PopupControlID="Panel2" TargetControlID="LinkButton2"
            CancelControlID="LinkButton2" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>


    </div>
</asp:Content>
