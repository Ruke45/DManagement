<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PendingCertificateRequest.aspx.cs" Inherits="DSCMS.ViewCertificaterRequest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | View Certificate Requests
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
                        <i class="fa fa-th-large"></i>  Pending for Approval
                    </li>
                </ol>
            </div>
        </div>
         <div class="row" runat="server" id="ErrorMessage" style="font-family: Cambria;">
        </div>
        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-9">
                            <h3 class="panel-title">Saved Certificate Requests</h3>

                        </div>
                       <%-- <div class="col col-xs-3 text-right">
                            <form action="#" method="get">
                                <div class="input-group">
                                    <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                                    <input class="form-control" id="system-search" name="q" placeholder="Search for" >
                                    <span class="input-group-btn">
                                        <button type="submit" class="btn btn-default frm-btn"><i class="glyphicon glyphicon-search"></i></button>
                                    </span>
                                </div>
                            </form>

                        </div>--%>
                        <div class="col col-xs-2 text-right">

                  </div>
                    </div>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvPendigCR" BorderStyle="NotSet" runat="server" Font-Names="Cambria"
                        CssClass="table  table-bordered  table-hover table-list-search"
                        AutoGenerateColumns="False" OnSelectedIndexChanged="gvPendigCR_SelectedIndexChanged" 
                        AllowPaging="true" PageSize="20"
                               OnPageIndexChanging="gvPendigCR_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Request Id" DataField="RequestId" SortExpression="RequestId" />
                            <asp:TemplateField HeaderText="Consignee" SortExpression="Consignor">
                            <ItemTemplate>
                                    <%# (Eval("Consignor").ToString()).Replace("\n", "<br />") %>
                                </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Consignee" SortExpression="Consignee">
                            <ItemTemplate>
                                    <%# (Eval("Consignee").ToString()).Replace("\n", "<br />") %>
                                </ItemTemplate>
                           </asp:TemplateField>
                            <asp:BoundField HeaderText="Request Date" DataField="RequestDate" SortExpression="RequestDate" />
                            <asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo" SortExpression="InvoiceNo" />
                            <asp:BoundField HeaderText="Country" DataField="CountryName" SortExpression="CountryName" />
                            <asp:BoundField HeaderText="Total Invoice Value" DataField="TotalInvoiceValue" SortExpression="TotalInvoiceValue" />
                            <asp:BoundField HeaderText="Total Quantity" DataField="TotalQuantity" SortExpression="TotalQuantity" />
                            <asp:ButtonField Text="Details" CommandName="Select" />

                            <%--<asp:TemplateField HeaderText = "">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="linbtnEdit" runat="server" OnClick="linbtnEdit_Click">Edit</asp:LinkButton>
                                   </ItemTemplate>
                                </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>

                </div>
                <div class="panel-footer">
                    <div class="row">
                    </div>
                </div>
            </div>

        </div>



        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-9">
                            <h3 class="panel-title">Web Based Certificate Requests</h3>

                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvPendigWCR" BorderStyle="NotSet" runat="server" Font-Names="Cambria"
                        CssClass="table  table-bordered  table-hover table-list-search"
                        AutoGenerateColumns="False"
                        AllowPaging="true" PageSize="20"
                               OnPageIndexChanging="gvPendigWCR_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Request Id" DataField="RequestId" SortExpression="RequestId" />
                            <asp:TemplateField HeaderText="Consignee" SortExpression="Consignor">
                            <ItemTemplate>
                                    <%# (Eval("Consignor").ToString()).Replace("\n", "<br />") %>
                                </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Consignee" SortExpression="Consignee">
                            <ItemTemplate>
                                    <%# (Eval("Consignee").ToString()).Replace("\n", "<br />") %>
                                </ItemTemplate>
                           </asp:TemplateField>
                            <asp:BoundField HeaderText="Request Date" DataField="RequestDate" SortExpression="RequestDate" />
                            <asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo" SortExpression="InvoiceNo" />
                            <asp:BoundField HeaderText="Country" DataField="CountryName" SortExpression="CountryName" />
<%--                            <asp:BoundField HeaderText="Total Invoice Value" DataField="TotalInvoiceValue" SortExpression="TotalInvoiceValue" />
                            <asp:BoundField HeaderText="Total Quantity" DataField="TotalQuantity" SortExpression="TotalQuantity" />--%>
                            <%--<asp:ButtonField Text="Details" CommandName="Select" />--%>
                            <asp:TemplateField ControlStyle-Width="50px" HeaderText = "Certificate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequestID" runat="server" Text='<%# Eval("RequestID") %>' Visible="false" />
                                    <asp:Label ID="lblCertificatePath" runat="server" Text='<%# Eval("CertificatePath") %>' Visible="false" />
                                    <asp:LinkButton ID="LinkButton7" runat="server" CssClass="btn btn-sm btn-default" OnClick="LinkButton7_Click"  >View</asp:LinkButton>
                                    <%--<asp:HyperLink ID="linkCertificateView" runat="server" CssClass="btn btn-sm btn-default" Target="_blank" NavigateUrl='<%# Eval("CertificatePath") %>' >View</asp:HyperLink>--%>
                                </ItemTemplate>
                               </asp:TemplateField>
                            <asp:TemplateField HeaderText="Support Document" HeaderStyle-Width="135px" ItemStyle-HorizontalAlign="Center">
                                   <ItemTemplate >
                                       <asp:LinkButton ID="linkViewWEBSD" runat="server" CssClass="btn btn-sm btn-default" OnClick="linkViewWEBSD_Click">View</asp:LinkButton>
                                   </ItemTemplate>
                                </asp:TemplateField>
                           <asp:TemplateField ControlStyle-Width="100px" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                               <asp:LinkButton ID="LinkButton1" runat="server"  Onclick="btnSend_Click" CssClass="btn btn-sm btn-default">Send Reminder </asp:LinkButton></ItemTemplate>
                               </asp:TemplateField>

                        </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>

                </div>
                <div class="panel-footer">
                    <div class="row">
                    </div>
                </div>
            </div>

        </div>

        <%-- -----------------------------Upload Based CertificateRequest----------------------------------------- --%>

                <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-7">
                            <h3 class="panel-title">Upload Based Certificate Request</h3>

                        </div>
                        <div class="col col-xs-3 text-right">
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvPendigUCR" BorderStyle="NotSet" runat="server" Font-Names="Cambria"
                        CssClass="table  table-bordered  table-hover table-list-search"
                        AutoGenerateColumns="False"
                        AllowPaging="true" PageSize="20"
                               OnPageIndexChanging="gvPendigUCR_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Request Id" ItemStyle-Width="130px">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequestID" runat="server" Text='<%# Eval("RequestId") %>'/>                 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer Details" ItemStyle-Width="400px">
                                <ItemTemplate>
<%--                                    <asp:Label ID="lblCid" runat="server" Text='<%# Eval("CustomerId") %>' Visible="true" />
                                    <asp:Label ID="lblC" runat="server" Text=" | " Visible="true" />--%>
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

                            <asp:TemplateField HeaderText="Certificate" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblUploadPath" runat="server" Text='<%# Eval("UploadPath") %>' Visible="false" />
                                    <asp:LinkButton ID="linkDownDoc"  runat="server" OnClick="linkDownUBDoc_Click" CssClass="btn btn-sm btn-default">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Support Document" ItemStyle-Width="160px" ItemStyle-HorizontalAlign="Center"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="likViewSupportingDoc"  runat="server" OnClick="likViewSupportingDoc_Click" CssClass="btn btn-sm btn-default">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ControlStyle-Width="100px" ItemStyle-Width="160px" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                               <asp:LinkButton ID="LinkButton1" runat="server"  Onclick="btnSend_Click" CssClass="btn btn-sm btn-default">Send Reminder </asp:LinkButton></ItemTemplate>
                               </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                        <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>

                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="form-group text-right">
                            <%--<div class="col-sm-12">
                                <asp:Button ID="btnBulkSign" runat="server" Text="Approve/Sign Certificates" CssClass="btn btn-primary" OnClick="btnBulkSign_Click" />
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <%-- -----------------------------------Supporting Doc Grid------------------------------------------------------------------ --%>

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
                                AllowPaging="true" PageSize="20"
                               OnPageIndexChanging="gvPendigSDR_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField HeaderText="Request Id" DataField="RequestID" SortExpression="Request_ID" />

                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequestSDID" runat="server" Text='<%# Eval("RequestID") %>' Visible="false" />
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
                                            <asp:Label ID="lblUploadSDPath" runat="server" Text='<%# Eval("UploadPath") %>' Visible="false" /> 
                                            <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("UploadDocName") %>' Visible="false" />
                                            <asp:LinkButton ID="linkDownDoc"  runat="server" OnClick="linkDownDoc_Click" CssClass="btn btn-default btn-sm">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ControlStyle-Width="100px" >
                                        <ItemTemplate>
                                             <asp:LinkButton ID="LinkButton1" runat="server"  width="100px" CssClass="btn btn-sm btn-default"  Onclick=" btnSupdocSend_Click"  >Send Reminder </asp:LinkButton>
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




        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-9">
            </div>
        </div>

    </div>


    <%-- --------------------------------Supporting Doc GridView------------------------------------------- --%>
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
                        <asp:BoundField HeaderText="Document Name" DataField="SupportingDoc_Name" SortExpression="Uploaded_Path" />
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDownloadSD" runat="server" OnClick="linkDownloadSD_Click" CssClass="btn btn-sm btn-default">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>


                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>
                <%--End of form-horizontal--%>
            </div>
            <div class="modal-footer">

               <%-- <asp:Button ID="btnCerateCertificate" runat="server" Text="Submit" CssClass="btn btn-primary" />--%>
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" OnClick="btnClose_Click"/>
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp1" BehaviorID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="linkDum"
        CancelControlID="lnkDummy" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>

    <%-- ---------------------------------------------------------------------------------------------------- --%>


        <%-- --------------------------------Supporting Doc GridView------------------------------------------- --%>
                                                      <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->

    <asp:Panel ID="PanelWEB" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Web Based Certificate Supporting Documents</h4>

            </div>
            <div class="modal-body">
                <asp:GridView ID="gvWEBSupDoc" runat="server" CssClass="table table-responsive  table-bordered  table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Upload Id" DataField="Seq_No" SortExpression="Seq_No" ItemStyle-Width="100px" />
                        <asp:BoundField HeaderText="Document Id" DataField="Document_Id" SortExpression="Document_Id" ItemStyle-Width="150px" />
                        <asp:BoundField HeaderText="Document Name" DataField="SupportingDoc_Name" SortExpression="Uploaded_Path" />
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDownloadSD" runat="server" OnClick="linkDownloadSD_Click" CssClass="btn btn-sm btn-default">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>
                <%--End of form-horizontal--%>
            </div>
            <div class="modal-footer">

               <%-- <asp:Button ID="btnCerateCertificate" runat="server" Text="Submit" CssClass="btn btn-primary" />--%>
                <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-default" OnClick="btnClose_Click"/>
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="Mpw1" BehaviorID="mpe1" runat="server" PopupControlID="PanelWEB" TargetControlID="LinkButton2"
        CancelControlID="LinkButton3" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>

    <%-- ---------------------------------------------------------------------------------------------------- --%>
</asp:Content>
