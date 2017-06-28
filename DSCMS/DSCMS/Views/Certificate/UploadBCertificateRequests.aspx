<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UploadBCertificateRequests.aspx.cs" Inherits="DSCMS.Views.Certificate.UploadBCertificateRequests" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Uploaded Certificate Requests
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        function SetTarget() {

            document.forms[0].target = "_blank";

        }

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Certificate</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i>Upload Based Certificate Request
                    </li>
                </ol>
            </div>
        </div>
        <div class="row" runat="server" id="ErrorMessage" style="font-family: Cambria;">
        </div>


        <div class="col-md-12"><%--col-md-10 col-md-offset-1--%>

            <div class="panel panel-default panel-table boxshadow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-3">
                            <h3 class="panel-title">Upload Based Certificate Request</h3>

                        </div>
                        <div class="col col-xs-9 text-right">
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email" style="padding-top: 6px;">Customer</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="drpCustomer" AppendDataBoundItems="true" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="btnByCustomer_Click">
                                        <asp:ListItem Value="%">All Customers</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <%--<div class="col col-sm-1 text-right">
                                    <asp:Button ID="btnByCustomer" CssClass="btn btn-sm btn-default btn-create" OnClick="btnByCustomer_Click" runat="server" Text="Submit" />
                                </div>--%>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvPendigUCR" BorderStyle="NotSet" runat="server" Font-Names="Cambria"
                        CssClass="table  table-bordered  table-hover table-list-search"
                        AutoGenerateColumns="False">
                        <%--AllowPaging="true" PageSize="10"
                               OnPageIndexChanging="gvPendigCR_PageIndexChanging"--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Request No" ItemStyle-Width="130px">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequestID" runat="server" Text='<%# Eval("RequestId") %>' />
                                    <asp:Label ID="lblSealRequired" runat="server" Visible="false" Text='<%# Eval("SealRequired") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer Name" ItemStyle-Width="400px">
                                <ItemTemplate>
                                    <asp:Label ID="lblCid" runat="server" Text='<%# Eval("CustomerId") %>' Visible="false" />
                                    <asp:Label ID="lblCName" runat="server" Text='<%# Eval("CustomerName") %>' Visible="true" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Uploaded By" ItemStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:Label ID="lblUploadBy" runat="server" Text='<%# Eval("CreatedBy") %>' Visible="true" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Uploaded Date" ItemStyle-Width="170px">
                                <ItemTemplate>
                                    <asp:Label ID="lblUploadDate" runat="server" Text='<%# Eval("RequestDate") %>' Visible="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stamp Applied">
                                <ItemTemplate>
                                    <asp:Label ID="lblCollectionType" runat="server" Text='<%# Eval("CollectionType") %>' Visible="true" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Certificate" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblUploadPath" runat="server" Text='<%# Eval("UploadPath") %>' Visible="false" />
                                    <asp:LinkButton ID="linkViewPDF" runat="server" CssClass="btn btn-sm btn-default" OnClick="linkViewPDF_Click">View</asp:LinkButton>
                                    <%--                                    <asp:HyperLink ID="View" runat="server" Target="_blank" NavigateUrl='<%# Eval("UploadPath") %>' CssClass="btn btn-sm btn-default">View</asp:HyperLink>--%>
                                    <%--<asp:LinkButton ID="linkDownDoc"  runat="server" OnClick="linkDownDoc_Click" CssClass="btn btn-sm btn-default">Download</asp:LinkButton>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Support Docs" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="likViewSupportingDoc" runat="server" OnClick="likViewSupportingDoc_Click" CssClass="btn btn-sm btn-default">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bulk Sign" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="160px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkbtnApprove" runat="server" OnClick="linkbtnApprove_Click" CssClass="btn btn-sm btn-primary">Approve</asp:LinkButton>
                                    <%--</ItemTemplate>
                                </asp:TemplateField>l
                            <asp:TemplateField HeaderText = "" ItemStyle-HorizontalAlign="Center">
                                   <ItemTemplate>--%>
                                    <asp:LinkButton ID="linkbtnReject" runat="server" OnClick="linkbtnReject_Click" CssClass="btn btn-sm btn-danger">Reject </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Bulk Sign">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    </asp:GridView>

                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="form-group text-right">
                            <div class="col-sm-12">
                                <asp:Button ID="btnBulkSign" runat="server" Text="Approve/Sign Certificates" CssClass="btn btn-primary" OnClick="btnBulkSign_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-9">
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
                <h4 class="modal-title">Certificate Supporting Documents</h4>

            </div>
            <div class="modal-body">
                <asp:GridView ID="gvSupportingDOc" runat="server" CssClass="table table-responsive  table-bordered  table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Upload Id" DataField="Seq_No" SortExpression="Seq_No" ItemStyle-Width="100px" />
                        <asp:BoundField HeaderText="Document Id" DataField="Document_Id" SortExpression="Document_Id" ItemStyle-Width="150px" />
                        <asp:TemplateField HeaderText="Document Name">
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("SupportingDoc_Name") %>'></asp:Label>
                                <asp:Label ID="lblSDUppathe" runat="server" Visible="false" Text='<%# Eval("Uploaded_Path") %>'></asp:Label>
                                <asp:Label ID="lblRefNo" runat="server" Visible="false"  Text='<%# Eval("Request_Ref_No") %>'></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text="|"></asp:Label>
                                <asp:Label ID="lblCertification" ForeColor="Blue" runat="server" Text='<%# Eval("_Remarks") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="60px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="linkDownloadSD" runat="server" OnClick="linkDownloadSD_Click" CssClass="btn btn-sm btn-default">View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                </asp:GridView>
                <%--End of form-horizontal--%>
            </div>
            <div class="modal-footer">

                <%-- <asp:Button ID="btnCerateCertificate" runat="server" Text="Submit" CssClass="btn btn-primary" />--%>
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp1" BehaviorID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="linkDum"
        CancelControlID="lnkDummy" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>




    <%---------------------------------------------------------%>
    <asp:LinkButton ID="linkApprove" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="linkApprove2" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->

    <asp:Panel ID="PanelApprove" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Approve Certificate</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Password</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblAReqID" runat="server" Visible="false" />
                            <asp:Label ID="lblACid" runat="server" Visible="false" />
                            <asp:Label ID="lblSealNeeded" runat="server" Visible="false" />
                            <asp:Label ID="lblAPath" runat="server" Visible="false" />
                            <asp:TextBox ID="txtCertificatePass" CssClass="form-control" Height="32px" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>

                    <%--<div class="form-group">
                        <label class="control-label col-sm-2" for="email">Comments</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtComment" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>--%>
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

                <asp:Button ID="btnCerateCertificate" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnCerateCertificate_Click" />
                <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="ModelApprove" BehaviorID="mpe1" runat="server" PopupControlID="PanelApprove" TargetControlID="linkApprove"
        CancelControlID="linkApprove" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>


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
    <cc1:ModalPopupExtender ID="mpReject" runat="server" PopupControlID="Panel2" TargetControlID="LinkButton1"
        CancelControlID="LinkButton2" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>



    <%---------------------------------------------------------%>
    <asp:LinkButton ID="linkA" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="linkA1" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->

    <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Approve Certificate :</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Password</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSignatoryPass" CssClass="form-control" Height="32px" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>

                    <%--<div class="form-group">
                        <label class="control-label col-sm-2" for="email">Comments</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtComment" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email"></label>
                        <div class="col-sm-8">
                            <asp:Label ID="Label4" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <%--End of form-horizontal--%>
            </div>
            <div class="modal-footer">

                <asp:Button ID="Button2" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnBulkSignPop_Click" />
                <asp:Button ID="Button3" runat="server" Text="Close" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mpBulk" runat="server" PopupControlID="Panel3" TargetControlID="linkA"
        CancelControlID="linkA1" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>


</asp:Content>
