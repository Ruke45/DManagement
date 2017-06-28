<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="CertificateDetails.aspx.cs" Inherits="DSCMS.Views.Certificate.CertificateDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Certificate Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                <small>Certificate</small>
            </h1>
            <ol class="breadcrumb">
                <li class="active">
                    <i class="fa fa-th-large"></i> Certificate Request Details
                </li>
            </ol>
        </div>
        		<div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
                     <%--Error Msg goes here--%>
                
                </div>
    </div>

    <div class="row">

        <div class="container boxshadow">
            <div class="col-lg-11">
                				
                <div class="form-horizontal" role="form" style="font-family: Cambria;">

                    <div class="col-lg-12" style="font-family: Cambria;">
                        <h1 class="page-header">
                            <small>Certificate Details (Certificate Request ID : <asp:Label ID="lblRequestID" runat="server" Text=""></asp:Label>)</small>
                        </h1>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Consignor / Exporter</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtExporter" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Consignee</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtConsignee" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Invoice No</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoNo" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <label class="control-label col-sm-2" for="email">Invoice Date</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoDate" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Country Of Origin</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtCountryOfOrigin" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <label class="control-label col-sm-2" for="email">Vessel</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtVessel" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Port of Loading</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPortLoading" ReadOnly="true" BackColor="White"  CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" id="divPortofDischarg" runat="server">Port of Discharge</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPortDischrg" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" id="divePlaceofDel" runat="server" >Place of Delivery</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPlcofDelivry" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                   <div class="form-group" id="divOtherComments" runat="server">
                        <label class="control-label col-sm-2" for="email">Other Comments</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtOtherComments" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group" id="diveRemarkGlobl" runat="server">
                        <label class="control-label col-sm-2" for="email">Other Details</label>
                        <div class="col-sm-8">

                            <asp:TextBox ID="TextBox1" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <h1 class="page-header">
                            <small>Certificate Items</small>
                        </h1>
                    </div>
                    <div class="container">
                        <div class="col-lg-11">

                            <div class="panel panel-default panel-table boxshadow">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col col-xs-7">
                                            <h3 class="panel-title">Items</h3>

                                        </div>

                                    </div>
                                </div>
                                <div class="panel-body">
                                            <asp:GridView ID="gvCItems" runat="server"
                                                CssClass="table  table-bordered table-responsive  table-hover table-list-search"
                                                AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="GoodItem" DataField="GoodItem1" SortExpression="GoodItem1" />
                                                    <asp:BoundField HeaderText="Shipping Mark" DataField="ShippingMark1" SortExpression="ShippingMark1" />
                                                    <asp:BoundField HeaderText="Package Type" DataField="PackageDescription1" SortExpression="PackageType1" />
                                                    <asp:BoundField HeaderText="Summary" DataField="SummaryDesc1" SortExpression="SummaryDesc1" />
                                                    <asp:BoundField HeaderText="Qunatity" DataField="Quantity1" SortExpression="Quantity1" />
                                                    <asp:BoundField HeaderText="HS Code" DataField="HSCode1" SortExpression="HSCode1" />
                                                </Columns>
                                            </asp:GridView>
                                </div>
                                <div class="panel-footer">
                                    <div class="row">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Total Quantity</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtTotQunatity" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                  <%--  </div>
                    <div class="form-group">--%>
                        <label class="control-label col-sm-2" for="email">Total Invoice Value</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoVal" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <h1 class="page-header">
                            <small>Supporting Documents</small>
                        </h1>
                    </div>


                                        <div class="container">
                        <div class="col-lg-11">

                            <div class="panel panel-default panel-table boxshadow">
                      
                                <div class="panel-body">
                                <asp:GridView ID="gvSupportingDOc" runat="server" CssClass="table table-responsive  table-bordered  table-hover" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField HeaderText="Upload Id" DataField="Seq_No" SortExpression="Seq_No" ItemStyle-Width="100px" />
                                        <asp:BoundField HeaderText="Document Id" DataField="Document_Id" SortExpression="Document_Id" ItemStyle-Width="150px" />
                                       <%-- <asp:BoundField HeaderText="Document Name" DataField="SupportingDoc_Name" SortExpression="Uploaded_Path" />--%>
                                       <asp:TemplateField HeaderText="Document Name">
                                         <ItemStyle />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("SupportingDoc_Name") %>'></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text="|"></asp:Label>
                                            <asp:Label ID="lblCertification" ForeColor="Blue" runat="server" Text='<%# Eval("_Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="">
                                         <ItemStyle Width="60px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkDownload" runat="server" OnClick="linkDownload_Click">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    </Columns>
                                 </asp:GridView>
                                      </div>
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server" ID="upd1">
                        <ContentTemplate>
                    <div class="form-group ">
                        
                        <div class="col-sm-12 text-right" >
                            <asp:Button ID="btnRejectRequest" runat="server" Text="Reject Request" CssClass="btn btn-danger" Width="200px" OnClick="btnRejectRequest_Click" />
                           <%-- </div>
                            <div class="col-sm-4 text-right">--%>
                            <asp:Button ID="btnRequestCertificate" runat="server" Text="Generate Certificate" CssClass="btn btn-primary" Width="200px" OnClick="btnRequestCertificate_Click" />
                            </div>
                           
                        </div>
                            </ContentTemplate>
                         </asp:UpdatePanel>
                </div>
            </div>
            <%--End of form-horizontal--%>
        </div>
        <%-- End of col-lg-11--%>



                                            <%--<asp:Timer ID="Timer1" runat="server" Interval="3600" ontick="Timer1_Tick"></asp:Timer>--%>



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
                        <label class="control-label col-sm-2" for="email">Password</label>
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
                <h4 class="modal-title">Reject Certificate Request</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Reject Reason</label>
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
                <asp:Button ID="Button3" runat="server" Text="Close" CssClass="btn btn-default" OnClientClick="return HideModalPopup()" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp2"  runat="server" PopupControlID="Panel2" TargetControlID="LinkButton2"
        CancelControlID="LinkButton2" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>




    </div>
    <%--End of Row--%>




</asp:Content>
