<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CertificateUpload.aspx.cs" Inherits="DSCMS.Views.Certificate.CertificateUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Certificate Upload
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <style type="text/css">.mycheckBig input {width:25px; height:25px;}</style>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Certificate</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i> Certificate Upload
                    </li>
                </ol>
            </div>

            <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
                <%--Error Msg goes here--%>
            </div>
        </div>

        <div class="container col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-7">
                            <h3 class="panel-title">Certificate Upload</h3>

                        </div>
                        <div class="col col-xs-3 text-right" style="float: right;">
                            <%--<asp:Button ID="btnSyncEmails" CssClass="btn btn-sm btn-default btn-create" runat="server" Text="Synchronize" OnClick="btnSyncEmails_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                                        <div class="col-lg-12">
                        <h1 class="page-header">
                            <small>Certificate Document</small>
                        </h1>
                    </div>
                    <div class="form-horizontal" role="form" style="font-family: Cambria; font-size: medium;">
                        <br />
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Certificate :</label>
                            <div class="col-sm-10">
                                <asp:FileUpload ID="btnCertUpload" CssClass="btn btn-default" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ControlToValidate="btnCertUpload"
                                    runat="server" Display="Dynamic" ForeColor="Red" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.pdf)$"
                                    ControlToValidate="btnCertUpload" runat="server" ForeColor="Red" ErrorMessage="Please select a valid PDF File. | or Rename the file if the File Name Has ()"
                                    Display="Dynamic" />
                            </div>
                        </div>
                        <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Invoice No</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtInvoiceNo" required="" CssClass="form-control" runat="server" ></asp:TextBox>
                        </div>
                        </div>
                                            <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Digital Authentication Required </label>
                        <div class="col-sm-4">
                            <asp:CheckBox ID="chckSealRequired" runat="server" CssClass="mycheckBig"  Checked="true"/>
                        </div>
                    </div>
                                            <div class="col-lg-12">
                        <h1 class="page-header">
                            <small>Supporting Documents</small>
                        </h1>
                    </div>
                        <%--<div class="container">--%>
                            <div class="col-lg-12">

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
                                                        <asp:Label ID="hlbleid" runat="server" Text="Upload Document"></asp:Label>
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
                                            <EmptyDataTemplate>No Supporting Document Required</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                       <%-- </div>--%>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="form-group text-right">
                            <div class="col-sm-12">
                                <asp:Button ID="btnRequestCertificate" runat="server" Text="Request Certificate" CssClass="btn btn-primary" Width="200px" OnClick="btnRequestCertificate_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>


    </div>

</asp:Content>
