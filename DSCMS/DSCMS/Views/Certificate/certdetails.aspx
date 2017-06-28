<%@ Page Title="" Language="C#"  MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="certdetails.aspx.cs" Inherits="DSCMS.Views.Certificate.certdetails" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS |  Certificater Request Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">.mycheckBig input {width:25px; height:25px;}</style>
    <script type="text/javascript">

        function HideModalPopup() {
            $find("mpe").hide();
            return false;
        }
    </script>
    <script type="text/javascript">
        function hi(ob) {
            debugger;
            var grid = document.getElementById("<%= gvNotUploadedDOC.ClientID %>");
            var inputs = grid.getElementsByClassName("UPLOAD");
            var fileUpload;
            var strRowNo = ob.id.toString().split("_")[3];//get row number
            // alert(strRowNo);
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "file") {
                    fileUpload = inputs[i];
                    if (i == strRowNo) {
                        fileUpload.value = "";

                    }
                }
            }
        }

        function checkDate(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select a day earlier than today!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }
    </script>


    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                <small>Certificate</small>
            </h1>
            <ol class="breadcrumb">
                <li class="active">
                    <i class="fa fa-th-large"></i>Edit Certificate Request
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
                            <small>Certificate Details</small>
                        </h1>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Consignor / Exporter</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtExporter"  CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Consignee</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtConsignee" enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Invoice No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtInvoNo" enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Date</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtDate" enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtDate"
                                Format="MM/dd/yyyy"
                                OnClientDateSelectionChanged="checkDate"
                                PopupButtonID="Image1" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Country Of Origin</label>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="drpCountry" runat="server"  enabled="false" CssClass="form-control">
                                <asp:ListItem>Mr</asp:ListItem>
                                <asp:ListItem>Ms</asp:ListItem>
                                <asp:ListItem>Dr</asp:ListItem>
                                <asp:ListItem>Rev</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Port of Loading</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPortLoading" enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group" runat="server" id="divPOD">
                        <label id="Label1" class="control-label col-sm-2" for="email" runat="server">Port of Discharge</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPortDischrg" enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Vessel </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtVessel" enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="divPODE" runat="server">
                        <label class="control-label col-sm-2" for="email">Place of Delivery</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPlcofDelivry" enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
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

                            <asp:TextBox ID="txtOtherDetails" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <h1 class="page-header">
                            <small>Goods</small>
                        </h1>
                    </div>
                    <div class="container" id="DivNormal" runat="server">
                        <div class="col-lg-11">

                            <div class="panel panel-default panel-table boxshadow">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col col-xs-7">
                                            <h3 class="panel-title">Items</h3>

                                        </div>
                                        <div class="col col-xs-3 text-right">
                                            <%--<div>
                                                <div class="input-group">
                                                    <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                                                    <input class="form-control" id="system-search" name="q" placeholder="Search for"/>
                                                    <span class="input-group-btn">
                                                        <button type="submit" class="btn btn-default frm-btn"><i class="glyphicon glyphicon-search"></i></button>
                                                    </span>
                                                </div>
                                            </div>--%>
                                        </div>
                                        <div class="col col-xs-2 text-right">
                                            <%--<button type="button" class="btn btn-sm btn-default btn-create" id="btnShow" onclick="AddNewItem" runat="server" data-toggle="modal" data-target="#myModal">Create New</button>--%>
                                            <asp:Button ID="btnAddNewItem" CssClass="btn btn-sm btn-default btn-create" runat="server" Text="Add Good / Item" style="display:none" OnClick="btnAddNewItem_Click" />
                                        </div>

                                    </div>
                                </div>
                                <div class="panel-body">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <%--<asp:Timer ID="Timer1" runat="server" Interval="3600" ontick="Timer1_Tick"></asp:Timer>--%>

                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                            <asp:GridView ID="gvItemDetails" runat="server"
                                                CssClass="table  table-bordered  table-hover table-list-search"
                                                AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="GoodItem" DataField="GoodItem1" SortExpression="GoodItem1" />
                                                    <asp:BoundField HeaderText="Shipping Mark" DataField="ShippingMark1" SortExpression="ShippingMark1" />
                                                    <asp:BoundField HeaderText="Package Type" DataField="PackageDescription1" SortExpression="PackageDescription1" />
                                                    <asp:BoundField HeaderText="Summary" DataField="SummaryDesc1" SortExpression="SummaryDesc1" />
                                                    <asp:BoundField HeaderText="Qunatity" DataField="Quantity1" SortExpression="Quantity1" />
                                                    <asp:BoundField HeaderText="HS Code" DataField="HSCode1" SortExpression="HSCode1" />
                                                    <asp:BoundField HeaderText="" DataField="SeqNo1" SortExpression="SeqNo1" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                    <asp:TemplateField HeaderText="" visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkEditItem" runat="server" OnClick="linkEditItem_Click">Edit</asp:LinkButton>
                                                            <asp:Label ID="lblSeqNo" runat="server" Visible="false" Text='<%# Eval("SeqNo1") %>'></asp:Label>
                                                            <asp:Label ID="lblPackageType" runat="server" Visible="false" Text='<%# Eval("PackageType1") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkRemoveItem" runat="server" OnClick="linkRemoveItem_Click">Remove</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                            <%---------------------------------------------------------%>
                                            <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                                            <asp:LinkButton ID="linkDum" runat="server"></asp:LinkButton>
                                            <!-- ModalPopupExtender -->

                                            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
                                                <!-- Modal content-->
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">Add/Edit Item Details</h4>

                                                    </div>
                                                    <div class="modal-body">
                                                        <div class="form-horizontal" role="form" style="font-family: Cambria;">

                                                            <div class="form-group">
                                                                <label class="control-label col-sm-2" for="email">Good/Item</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox ID="txtSequence" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                                                                    <asp:TextBox ID="txtGoodItem" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label col-sm-2" for="email">Shipping Mark</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox ID="txtShippingMark" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label col-sm-2" for="email">Package Type</label>
                                                                <div class="col-sm-8">
                                                                    <%--<asp:DropDownList ID="drpPakgType" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                                                    <asp:TextBox ID="drpPakgType" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label col-sm-2" for="email">Summary/Desc</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox ID="txtSummary" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label col-sm-2" for="email">Quantity</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox ID="txtQuntity" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label col-sm-2" for="email" id="lblHScode" runat="server">HS Code</label>
                                                                <div class="col-sm-8">
                                                                    <asp:TextBox ID="txtHScode" Enabled="false"  CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="control-label col-sm-2"  for="email"></label>
                                                                <div class="col-sm-8">
                                                                    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <%--End of form-horizontal--%>
                                                    </div>
                                                    <div class="modal-footer">

                                                        <asp:Button ID="btnAddItem" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnAddItem_Click" />
                                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" OnClientClick="return HideModalPopup()" />
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                            <!-- ModalPopupExtender -->
                                            <cc1:ModalPopupExtender ID="mp1" BehaviorID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="linkDum"
                                                CancelControlID="lnkDummy" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>



                                            <%----------------------------------------------------------------%>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddItem" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="panel-footer">
                                    <div class="row">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="container-fulid" id="ROWBase" runat="server">
                        <div class="form-group" id="div1" runat="server">
                            <label class="control-label col-sm-2" for="email">Good Details</label>
                            <div class="col-sm-8">

                                <asp:TextBox ID="txtGoodDetails" Enabled="false"  TextMode="MultiLine" MaxLength="120" Height="200" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" id="div2" runat="server">
                            <label class="control-label col-sm-2" for="email">Quantity Details</label>
                            <div class="col-sm-8">

                                <asp:TextBox ID="txtQuantityDetails" Enabled="false"  TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" id="HSDetails" runat="server">
                            <label class="control-label col-sm-2" for="email">HS Code Details</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtSeqNo" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtHSDetails" Enabled="false"  TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Total Quantity</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtTotQunatity" Enabled="false"  CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <%--  </div>
                    <div class="form-group">--%>
                        <label class="control-label col-sm-2" for="email">Total Invoice Value</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoVal"  Enabled="false" CssClass="form-control" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Online Seal Required </label>
                        <div class="col-sm-4">
                            <asp:CheckBox ID="chckSealRequired" runat="server" Enabled="false" CssClass="mycheckBig" />
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <h1 class="page-header">
                            <small>Uploaded Supporting Documents</small>
                        </h1>
                    </div>
                    <div class="container">
                        <div class="col-lg-11">

                            <div class="panel panel-default panel-table boxshadow">

                                <div class="panel-body">
                                    <asp:GridView ID="gvSupportingDOc" runat="server" CssClass="table table-responsive  table-bordered  table-hover t" AutoGenerateColumns="False">
                                        <Columns>
                                            <%--<asp:BoundField HeaderText="Upload No" DataField="Seq_No" SortExpression="GoodItem1" />--%>
                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="hidden" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="hlbleid" runat="server" Text="Document Name"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemStyle CssClass="hidden" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblseqid" runat="server" CssClass="hidden" Text='<%# Eval("Seq_No") %>'></asp:Label>
                                                    <%--<asp:Label ID="lbleid" runat="server" CssClass="control-label col-sm-2" Text='<%# Eval("Document_Id") %>'></asp:Label>   --%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="hdrow" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text="Document Name"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbleid" runat="server" CssClass="control-label " Text='<%# Eval("SupportingDoc_Name") %>'></asp:Label>
                                                    <asp:Label ID="lblDocument_Name" runat="server" Visible="false" CssClass="control-label " Text='<%# Eval("Document_Name") %>'></asp:Label>
                                                    <asp:Label ID="lblUploadP" runat="server" CssClass="control-label" Visible="false" Text='<%# Eval("Uploaded_Path") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Signature Required">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" Enabled="false" Checked='<%# Eval("Signature_Required") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <HeaderStyle CssClass="hdrow" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text="Upload New Document"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:FileUpload ID="btnEditFileUpload" runat="server" />
                                                    <%--                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ControlToValidate="btnFileUpload"
    runat="server" Display="Dynamic" ForeColor="Red" />--%>
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$"
    ControlToValidate="btnEditFileUpload" runat="server" ForeColor="Red" ErrorMessage="Please select a valid Word or PDF File file."
    Display="Dynamic" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" ControlStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkDownload" runat="server" OnClick="linkDownload_Click">Download</asp:LinkButton>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkRemoveSD" runat="server" OnClick="linkRemoveSD_Click">Remove</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Supporting Doucment Required
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>



                    </div>

                    <div class="col-lg-12">
                        <h1 class="page-header">
                            <small>Not Uploaded Supporting Documents</small>
                        </h1>
                    </div>
                    <div class="container">
                        <div class="col-lg-11">

                            <div class="panel panel-default panel-table boxshadow">
                                <div class="panel-body">
                                    <asp:GridView ID="gvNotUploadedDOC" runat="server" CssClass="table table-responsive  table-bordered  table-hover" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="hdrow" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text="Document Name"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbleNAME" runat="server" Text='<%# Eval("SupportingDocumentName") %>'></asp:Label>
                                                    <asp:Label ID="SupDOCID" runat="server" Visible="false" Text='<%# Eval("SupportingDocumentId") %>'></asp:Label>
                                                    <%--<asp:Label ID="lblDocname" runat="server" CssClass="control-label col-sm-2" Text='<%# Eval("TemplateId") %>'></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="hdrow" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text="Mandatory"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIsmandatory" runat="server" CssClass="control-label col-sm-1" Text='<%# Eval("IsMandatory") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Signature Required">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRow2" runat="server" Enabled="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="hdrow" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:UpdatePanel ID="FileUpdateid" runat="server">
                                                        <ContentTemplate>
                                                            <asp:FileUpload ID="btnFileUpload" runat="server" Width="200px" CssClass="UPLOAD" />
                                                            <%--                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ControlToValidate="btnFileUpload"
    runat="server" Display="Dynamic" ForeColor="Red" />--%>
                                                            <%--                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$"
                                                        ControlToValidate="btnFileUpload" runat="server" ForeColor="Red" ErrorMessage="Please select a valid Word or PDF File file."
                                                        Display="Dynamic" />--%>
                                                        </ContentTemplate>
                                                        <%-- <Triggers>
                                                             <asp:AsyncPostBackTrigger ControlID="linClear" EventName="Click" />
                                                         </Triggers>--%>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkUploadSDOC" runat="server" OnClick="linkUploadSDOC_Click">Upload</asp:LinkButton>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <%--<asp:LinkButton ID="linClear" runat="server" OnClientClick="javascript:hi(this);">Remove</asp:LinkButton>--%>
                                                    <asp:Image ID="ibtnReset" runat="server" AlternateText="Remove" BackColor="White" BorderStyle="None" ForeColor="Blue" onClick="javascript:hi(this);" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            All Supporting Doucuments are Uploaded
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>



                    </div>


                    <div class="form-group text-right">
                        <div class="col-sm-12">
                            <asp:Button ID="btnUpdateCertificate" runat="server" Text="Update Certificate" CssClass="btn btn-primary" Width="200px"  style="display:none" OnClick="btnUpdateCertificate_Click" />
                            <asp:Button ID="btnSendForApproval" runat="server" Text="Send For Approval" CssClass="btn btn-primary" Width="200px" style="display:none"  OnClick="btnSendForApproval_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <%--End of form-horizontal--%>
        </div>
        <%-- End of col-lg-11--%>
    </div>
    <%--End of Row--%>
</asp:Content>
