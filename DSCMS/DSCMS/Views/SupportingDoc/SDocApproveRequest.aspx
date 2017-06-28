<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SDocApproveRequest.aspx.cs" Inherits="DSCMS.Views.SupportingDoc.SDocApproveRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Supporting Document Approval Request
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                <small>Supporting Document</small>
            </h1>
            <ol class="breadcrumb">
                <li class="active">
                    <i class="fa fa-th-large"></i>Supporting Document Approve Request
                </li>
            </ol>
        </div>
        <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
            <%--Error Msg goes here--%>
        </div>
    </div>


    <div class="row">

        <div class="container col-md-8 col-md-offset-2 ">

            <div class="panel panel-default panel-table boxshadow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-7">
                            <h3 class="panel-title">Supporting Document Approve Request Upload</h3>

                        </div>
                        <div class="col col-xs-3 text-right" style="float: right;">
                            <%--<asp:Button ID="btnSyncEmails" CssClass="btn btn-sm btn-default btn-create" runat="server" Text="Synchronize" OnClick="btnSyncEmails_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="panel-body">

                    <div class="form-horizontal" role="form" style="font-family: Cambria; font-size: medium;">

                        <div class="panel-body">

                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Supporting Document Type :</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpDocType" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Supporting Document :</label>
                                <div class="col-sm-7">
                                    <asp:FileUpload ID="btnSupDocUpload" CssClass="btn btn-default" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ControlToValidate="btnSupDocUpload"
                                        runat="server" Display="Dynamic" ForeColor="Red" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.pdf)$"
                                        ControlToValidate="btnSupDocUpload" runat="server" ForeColor="Red" ErrorMessage="Please select a valid PDF File."
                                        Display="Dynamic" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="form-group text-right">
                            <div class="col-sm-12">
                                <asp:Button ID="btnRequest" runat="server" Text="Request Approval" CssClass="btn btn-primary" Width="200px" OnClick="btnRequest_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
