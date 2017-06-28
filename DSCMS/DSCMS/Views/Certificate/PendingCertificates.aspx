<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PendingCertificates.aspx.cs" Inherits="DSCMS.Views.Certificate.CertificateBulkSign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Pending Certificate Requests
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Certificate</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i>Pending Certificate Requests
                    </li>
                </ol>
            </div>
        </div>
        <div class="row" runat="server" id="ErrorMessage" style="font-family: Cambria;">
        </div>


        <div class="col-md-12">
            <%--col-md-offset-1 --%>

            <div class="panel panel-default panel-table boxshadow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-3">
                            <h3 class="panel-title">Pending Certificate Requests</h3>

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
                        <%--<div class="col col-xs-3 text-right">
                            <button type="button" class="btn btn-sm btn-default btn-create">Create New</button>
                            <asp:HyperLink ID="linkEcertificate" CssClass="btn btn-sm btn-default btn-create" runat="server" NavigateUrl="~/Views/Certificate/UploadBCertificateRequests.aspx">
                                View Uploaded Certificates</asp:HyperLink>
                                                    </div>--%>
                    </div>

                    
                </div>
                <div class="panel-body">
                    <div class="row" style="margin-top:10px;">
                        <div class="form-group ">
                            <div class="col-sm-5">
                                <%--<asp:Button ID="btnSendApproval" runat="server" Text="Send Approval E-Mail" CssClass="btn btn-primary" OnClick="btnSendApproval_Click" />--%>
                            </div>
                            <div class="col-sm-7 text-right">
                                <asp:Button ID="Button4" runat="server" Text="Approve/Sign Certificates" CssClass="btn btn-primary" OnClick="btnBulkSign_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:GridView ID="gvPendigCR" BorderStyle="NotSet" runat="server" Font-Names="Cambria"
                        CssClass="table  table-bordered  table-hover table-list-search"
                        AutoGenerateColumns="False" OnSelectedIndexChanged="gvPendigCR_SelectedIndexChanged"
                        AllowPaging="true" PageSize="50"
                        OnPageIndexChanging="gvPendigCR_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Request Id" DataField="RequestId" SortExpression="RequestId" />
                            <asp:BoundField HeaderText="Request Type" DataField="CType" SortExpression="CType" />
                            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" SortExpression="CustomerName" />
                            <asp:BoundField HeaderText="Request Date" DataField="RequestDate" SortExpression="RequestDate" />
                            <asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo" SortExpression="InvoiceNo" />
                            <asp:BoundField HeaderText="Submitted By" DataField="Createdby" SortExpression="Createdby" />
                            <asp:BoundField HeaderText="Stamp Applied" DataField="CollectionType" SortExpression="CollectionType" ItemStyle-HorizontalAlign="Center" />

                            <asp:TemplateField ControlStyle-Width="50px" ItemStyle-Width="50px" HeaderText="Certificate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCertificateType" runat="server" Text='<%# Eval("CertificateType") %>' Visible="false" />
                                    <asp:Label ID="lblRequestID" runat="server" Text='<%# Eval("RequestID") %>' Visible="false" />
                                    <asp:Label ID="lblCustomerID" runat="server" Text='<%# Eval("CustomerId") %>' Visible="false" />
                                    <asp:Label ID="lblTemplateID" runat="server" Text='<%# Eval("TemplateId") %>' Visible="false" />
                                    <asp:Label ID="lblSealRequired" runat="server" Text='<%# Eval("SealRequired") %>' Visible="false" />
                                    <asp:Label ID="lblCEmail" runat="server" Text='<%# Eval("ContactPersonEmail") %>' Visible="false" />
                                    <%--                                    <asp:HyperLink ID="linkCertificateView" runat="server" CssClass="btn btn-sm btn-default" Target="_blank" NavigateUrl='<%# Eval("CertificatePath") %>'>View</asp:HyperLink>--%>
                                    <asp:LinkButton ID="LinkButton7" title="#Summary Desciption" data-toggle="popover" data-trigger="hover" data-html="true" data-content=' <%# (Eval("SummaryDesc").ToString()).Replace("\n", "<br />") %>' runat="server" CssClass="btn btn-sm btn-default" OnClick="LinkButton7_Click">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Support Doc" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblUploadPath" runat="server" Text='<%# Eval("CertificatePath") %>' Visible="false" />
                                    <asp:LinkButton ID="likViewSupportingDoc" runat="server" OnClick="likViewSupportingDoc_Click" CssClass="btn btn-sm btn-default">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Approve | Reject " ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnApprove" runat="server" OnClick="btnApprove_Click" CssClass="btn btn-sm btn-primary">Approve</asp:LinkButton>
                                    <asp:LinkButton ID="btnReject" runat="server" OnClick="btnReject_Click" CssClass="btn btn-sm btn-danger">Reject</asp:LinkButton>
                                    <%--                                    <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-sm btn-primary" OnClick="btnApprove_Click"/>
                                    <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-sm btn-danger" OnClick="btnReject_Click"/>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>

                </div>
                <div class="panel-footer">
                    <%--<div class="row">
                        <div class="form-group ">
                            <div class="col-sm-4">
                                <asp:Button ID="btnSendApproval" runat="server" Text="Send Approval E-Mail" CssClass="btn btn-primary" OnClick="btnSendApproval_Click" />
                            </div>
                            <div class="col-sm-8 text-right">
                                <asp:Button ID="btnBulkSign" runat="server" Text="Approve/Sign Certificates" CssClass="btn btn-primary" OnClick="btnBulkSign_Click" />
                            </div>
                        </div>
                    </div>--%>
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
                <h4 class="modal-title">Approve Certificate :</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Password</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCertificatePass" CssClass="form-control" Height="32px" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>

                    <%--                    <div class="form-group">
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
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp1" BehaviorID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="linkDum"
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
                <h4 class="modal-title">Approve Certificate ::</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Password</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtRequestID" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtCustomerID" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSealBoolen" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtUploadPath" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtTemplateID" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtCRequestType" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtCpassword" CssClass="form-control" Height="32px" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>

                    <%--                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Comments</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email"></label>
                        <div class="col-sm-8">
                            <asp:Label ID="LblError2" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <%--End of form-horizontal--%>
            </div>
            <div class="modal-footer">

                <asp:Button ID="btnApproveCertificate" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnApproveCertificate_Click" />
                <asp:Button ID="Button2" runat="server" Text="Close" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp2" BehaviorID="mpe2" runat="server" PopupControlID="Panel2" TargetControlID="LinkButton1"
        CancelControlID="LinkButton2" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>



    <%---------------------------------------------------------%>
    <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->

    <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Reject Certificate Request</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Reject Reason</label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblRejectRequestID" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblRCertificateType" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblCUSEmail" runat="server" Visible="false"></asp:Label>
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
                <asp:Button ID="Button3" runat="server" Text="Close" CssClass="btn btn-default" OnClientClick="return HideModalPopup()" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="Panel3" TargetControlID="LinkButton3"
        CancelControlID="LinkButton4" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>


    <%---------------------------------------------------------%>
    <asp:LinkButton ID="LinkButton5" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="LinkButton6" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->

    <asp:Panel ID="Panel4" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
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
                                <asp:Label ID="lblRefNo" runat="server" Visible="false" Text='<%# Eval("Request_Ref_No") %>'></asp:Label>
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
                <asp:Label ID="lblCType" runat="server" Visible="false"></asp:Label>
                <%-- <asp:Button ID="btnCerateCertificate" runat="server" Text="Submit" CssClass="btn btn-primary" />--%>
                <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mpSD" runat="server" PopupControlID="Panel4" TargetControlID="LinkButton6"
        CancelControlID="LinkButton5" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
        <script>
            $(document).ready(function () {
                $('[data-toggle="popover"]').popover({ container: 'body' });
                
            });
            $("[id*=chkHeader]").on("click", function () {
                var chkHeader = $(this);
                var grid = $(this).closest("table");
                $("input[type=checkbox]", grid).each(function () {
                    if (chkHeader.is(":checked")) {
                        $(this).attr("checked", "checked");
                        $("td", $(this).closest("tr")).addClass("selected");
                    } else {
                        $(this).removeAttr("checked");
                        $("td", $(this).closest("tr")).removeClass("selected");
                    }
                });

            });
            
    </script>

</asp:Content>
