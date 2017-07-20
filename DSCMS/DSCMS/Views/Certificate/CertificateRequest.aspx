<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="CertificateRequest.aspx.cs" Inherits="DSCMS.CertificateRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Certificate Request
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .mycheckBig input {
            width: 15px;
            height: 15px;
            margin-top:10px;
        }
    </style>
    <script src="../../js/jquery-1.11.1.min.js"></script>

    <script type="text/javascript">
        function ShowModalPopup() {
            $find("mpe").show();
            return false;
        }
        function HideModalPopup() {
            $find("mpe").hide();
            return false;
        }
    </script>

    <script type="text/javascript">
        function hi(ob) {
            debugger;
            var grid = document.getElementById("<%= gvSupportingDOc.ClientID %>");
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
    </script>
    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select a future date !");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }
    </script>

    <%--<asp:Timer ID="Timer1" runat="server" Interval="3600" ontick="Timer1_Tick"></asp:Timer>--%>

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                <small>Certificate</small>
            </h1>
            <ol class="breadcrumb">
                <li class="active">
                    <i class="fa fa-th-large"></i>New Certificate Request
                </li>
            </ol>
        </div>
        <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
            <%--Error Msg goes here--%>
        </div>
        <div class="container col-lg-12" runat="server" id="NotificationDiv" style="font-family: Cambria;">
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
                        <label class="control-label col-sm-2" for="email">Consignor / Exporter *</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtExporter" CssClass="form-control" onkeypress="if (this.value.length > 500) { this.value = this.value.substring(0, 500); }" TextMode="MultiLine" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    <hr />
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Select Consignee </label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="drpConsignee" AppendDataBoundItems="true" runat="server" CssClass="select2_Con form-control" AutoPostBack="true" OnSelectedIndexChanged="drpConsignee_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:Button ID="btngeConsignee" runat="server" Text="Load" CssClass="btn btn-primary" OnClick="btngeConsignee_Click" /> | 
                            <asp:Button ID="btnRemoveConsignee" runat="server" Text="Remove" ToolTip="Remove Selected Refference Template" CssClass="btn btn-default" OnClick="btnRemoveConsignee_Click" />
                        </div>
                    </div>
                    <hr />
                    <%--<div class="form-group">
                        <label class="control-label col-sm-2" for="email">Consignee *</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtConsigneeName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Consignee*</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtConsignee" CssClass="form-control" onkeypress="if (this.value.length > 500) { this.value = this.value.substring(0, 500); }" TextMode="MultiLine" Height="110" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Invoice No *</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtInvoNo" CssClass="form-control" MaxLength="20" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Invoice Date *</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtDate"
                                Format="MM/dd/yyyy" />
                            <%--<input class="form-control" id="date" name="date" placeholder="MM/DD/YYYY" type="text"/>--%>
                        </div><%--OnClientDateSelectionChanged="checkDate"--%>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Country Of Origin *</label>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="drpCountry" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Port of Loading *</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPortLoading" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group" runat="server" id="divPOD">
                        <label class="control-label col-sm-2" for="email" runat="server">Port of Discharge *</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPortDischrg" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Vessel *</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtVessel" CssClass="form-control" runat="server" MaxLength="36"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="divPODE" runat="server">
                        <label class="control-label col-sm-2" for="email">Place of Delivery</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPlcofDelivry" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group" id="divOtherComments" runat="server">
                        <label class="control-label col-sm-2" for="email">Other Comments</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtOtherComments" CssClass="form-control" runat="server" onkeypress="if (this.value.length > 110) { this.value = this.value.substring(0, 110); }"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group" id="diveRemarkGlobl" runat="server">
                        <label class="control-label col-sm-2" for="email">Other Details</label>
                        <div class="col-sm-8">

                            <asp:TextBox ID="txtOtherDetails" TextMode="MultiLine" CssClass="form-control" runat="server" onkeypress="if (this.value.length > 245) { this.value = this.value.substring(0, 245); }"></asp:TextBox>
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
                                            <asp:Button ID="btnAddNewItem" CssClass="btn btn-sm btn-default btn-create" runat="server" Text="Add Goods / Item" OnClick="btnAddNewItem_Click" />
                                        </div>

                                    </div>
                                </div>
                                <div class="panel-body">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                                            <asp:GridView ID="GridView1" runat="server"
                                                CssClass="table  table-bordered  table-hover table-list-search"
                                                AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="GoodItem" DataField="GoodItem1" SortExpression="GoodItem1" />
                                                    <asp:BoundField HeaderText="Shipping Mark" DataField="ShippingMark1" SortExpression="ShippingMark1" />
                                                    <asp:BoundField HeaderText="Package Type" DataField="PackageType1" SortExpression="PackageType1" />
                                                    <%--                                                    <asp:BoundField HeaderText="Summary" DataField="SummaryDesc1" SortExpression="SummaryDesc1" />--%>
                                                    <asp:TemplateField HeaderText="Summary" SortExpression="Summary">
                                                        <ItemTemplate>
                                                            <%# (Eval("SummaryDesc1").ToString()).Replace("\n", "<br />") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Qunatity" DataField="Quantity1" SortExpression="Quantity1" />
                                                    <asp:BoundField HeaderText="HS Code" DataField="HSCode1" SortExpression="HSCode1" />
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSeqNo" runat="server" Visible="false" Text='<%# Eval("SeqNo1") %>'></asp:Label>
                                                            <asp:Label ID="lblSummary" runat="server" Visible="false" Text='<%# Eval("SummaryDesc1") %>'></asp:Label>
                                                            <asp:Label ID="lblPackageType" runat="server" Visible="false" Text='<%# Eval("PackageType1") %>'></asp:Label>
                                                            <asp:LinkButton ID="linkEditItem" runat="server" OnClick="linkEditItem_Click">Edit</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkRemoveItem" runat="server" OnClick="linkRemoveItem_Click">Remove</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>Empty</EmptyDataTemplate>
                                            </asp:GridView>

                                                 <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
     <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mpedit" runat="server" PopupControlID="Panel2"  TargetControlID="LinkButton2"
        CancelControlID="LinkButton1" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>

    <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Edit Item Details</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Goods/Item </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtg" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 300) { this.value = this.value.substring(0, 300); }"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Shipping Mark </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txts" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 300) { this.value = this.value.substring(0, 300); }"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Package Type </label>
                        <div class="col-sm-8">
                            <%--<asp:DropDownList ID="drpPakgType" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>--%>
                            <asp:TextBox ID="txtp" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 300) { this.value = this.value.substring(0, 300); }"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Summary/Desc *</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtsd" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 800) { this.value = this.value.substring(0, 800); }"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Quantity </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtq" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 300) { this.value = this.value.substring(0, 300); }"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email" id="Label1" runat="server">HS Code</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txth" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 300) { this.value = this.value.substring(0, 300); }"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email"></label>
                        <div class="col-sm-8">
                            <asp:Label ID="lblEditErri" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <%--End of form-horizontal--%>
            </div>
            <div class="modal-footer">

                <asp:Button ID="btnEdit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                <asp:Button ID="Button2" runat="server" Text="Close" CssClass="btn btn-default"/>
            </div>
        </div>
    </asp:Panel>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnAddItem" />
                                            <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
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
                            <label class="control-label col-sm-2" for="email">Goods Details *</label>
                            <div class="col-sm-8">

                                <asp:textbox id="txtGoodDetails" textmode="MultiLine" onkeypress="if (this.value.length > 500) { this.value = this.value.substring(0, 500); }" xmlns:asp="#unknown" height="200" cssclass="form-control" runat="server"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group" id="div2" runat="server">
                            <label class="control-label col-sm-2" for="email">Quantity Details *</label>
                            <div class="col-sm-8">

                                <asp:TextBox ID="txtQuantityDetails" TextMode="MultiLine" onkeypress="if (this.value.length > 200) { this.value = this.value.substring(0, 200); }" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" id="HSDetails" runat="server">
                            <label class="control-label col-sm-2" for="email">HS Code Details</label>
                            <div class="col-sm-8">

                                <asp:TextBox ID="txtHSDetails"  TextMode="MultiLine" onkeypress="if (this.value.length > 200) { this.value = this.value.substring(0, 200); }" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Total Quantity *</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtTotQunatity" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <%--  </div>
                    <div class="form-group">--%>
                        <label class="control-label col-sm-2" for="email">Total Invoice Value *</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoVal" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-3" for="email" style="color:#1768a3">Digital Authentication Required </label>
                        <div class="col-sm-4">
                            <asp:CheckBox ID="chckSealRequired" runat="server" CssClass="mycheckBig"  Checked="true"/>
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
                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="hdrow" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="hlbleid" runat="server" Text="Document ID"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbleid" runat="server" CssClass="control-label col-sm-2" Text='<%# Eval("SupportingDocumentId") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="hdrow" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="hlbleid" runat="server" Text="Document Name"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbleNAME" runat="server" Text='<%# Eval("SupportingDocumentName") %>'></asp:Label>
                                                    <%--<asp:Label ID="lblDocname" runat="server" CssClass="control-label col-sm-2" Text='<%# Eval("TemplateId") %>'></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="hdrow" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="hlbleid" runat="server" Text="Mandatory"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIsmandatory" runat="server" CssClass="control-label col-sm-1" Text='<%# Eval("IsMandatory") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="hdrow" />
                                                <HeaderTemplate>
                                                    <asp:Label ID="hlbleid" runat="server" Text=""></asp:Label>
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
                                            <asp:TemplateField HeaderText="Signature Required">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRow" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <%--<asp:LinkButton ID="linClear" runat="server" OnClientClick="javascript:hi(this);">Remove</asp:LinkButton>--%>
                                                    <asp:Image ID="ibtnReset" runat="server" AlternateText="Remove" BackColor="White" BorderStyle="None" ForeColor="Blue" onClick="javascript:hi(this);" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataTemplate>Empty</EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email" style="color:#1768a3">Save as a Template</label>
                        <div class="col-sm-4">
                            <asp:CheckBox ID="chkRefference" runat="server" CssClass="mycheckBig" />
                        </div>
                    </div>
                    <div class="form-group text-right">
                        <div class="col-sm-12">
                            <asp:Button ID="btnRequestCertificate" runat="server" ToolTip="Only Save the Certificate Request" Text="Save Certificate" CssClass="btn btn-primary" Width="200px" OnClick="btnRequestCertificate_Click" />
                            <asp:Button ID="btnSendForApproval" runat="server" ToolTip="Send the Certificate Request to NCE Inorder to Sign" Text="Send For Approval" CssClass="btn btn-primary" Width="200px" OnClick="btnSendForApproval_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <%--End of form-horizontal--%>
        </div>
        <%-- End of col-lg-11--%>
    </div>
    <%--End of Row--%>


    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp1" BehaviorID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="LinkButton3"
        CancelControlID="lnkDummy" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>

    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" Style="display: none">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Add New Item Details</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Goods/Item </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtGoodItem" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 300) { this.value = this.value.substring(0, 300); }"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Shipping Mark </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtShippingMark" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 300) { this.value = this.value.substring(0, 300); }"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Package Type </label>
                        <div class="col-sm-8">
                            <%--<asp:DropDownList ID="drpPakgType" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>--%>
                            <asp:TextBox ID="drpPakgType" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 300) { this.value = this.value.substring(0, 300); }"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Summary/Desc *</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSummary" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 800) { this.value = this.value.substring(0, 800); }"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Quantity </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtQuntity" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 300) { this.value = this.value.substring(0, 300); }"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email" id="lblHScode" runat="server">HS Code</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtHScode" CssClass="form-control" runat="server" TextMode="MultiLine" onkeypress="if (this.value.length > 300) { this.value = this.value.substring(0, 300); }"></asp:TextBox>
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

                <asp:Button ID="btnAddItem" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddItem_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" OnClientClick="return HideModalPopup()" />
            </div>
        </div>
    </asp:Panel>
    <!-- ModalPopupExtender -->



    <script>
        $(document).ready(function () {
            $(".select2_Con").select2({
                placeholder: "Select a Consignee",
                allowClear: true,
                width: '100%'
            });

        });
    </script>
</asp:Content>
