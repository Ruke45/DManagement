<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EBCConfig.aspx.cs" Inherits="DSCMS.Views.Maintenance.EBCConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | E-Mail Configuration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                <small>Maintenance</small>
            </h1>
            <ol class="breadcrumb">
                <li class="active">
                    <i class="fa fa-cogs"></i> Email Configuration
                </li>
            </ol>
        </div>
        <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
            <%--Error Msg goes here--%>
        </div>
    </div>
    <div class="col-lg-12">

        <div class="col-lg-6">
            <div class="row">
                <div class="col-lg-11 boxshadow">

                    <div class="form-horizontal" role="form" style="font-family: Cambria;">

                        <div class="col-lg-12" style="font-family: Cambria;">
                            <h1 class="page-header">
                                <small>E-Mail Port Configuration</small>
                            </h1>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">E-Mail</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:Button ID="btnUpdateEmail" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdateEmail_Click" />
                            </div>
                        </div>
                        <%--                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Password</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>--%>
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">Server Protocol (Imap4/Pop3)</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="drpPopimap" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="POP3">Pop3</asp:ListItem>
                                    <asp:ListItem Value="IMAP4">Imap4</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4">
                                <asp:Button ID="btnImapPopProtocol" runat="server" CssClass="btn btn-primary" OnClick="btnImapPopProtocol_Click" Text="Update" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">Server Name (Imap4/Pop3)</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtPopIMapSname" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:Button ID="btnPopImapServerName" runat="server" CssClass="btn btn-primary" OnClick="btnPopImapServerName_Click" Text="Update" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">Server Port (Imap4/Pop3)</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtPopImapPort" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:Button ID="IPserverPort" runat="server" CssClass="btn btn-primary" OnClick="IPserverPort_Click" Text="Update" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">SMTP Server Name</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtSMTPName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:Button ID="btnSMTPName" runat="server" CssClass="btn btn-primary" OnClick="btnSMTPName_Click" Text="Update" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">SMTP Server Port</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtSMTPPort" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:Button ID="btnSMTPPort" runat="server" CssClass="btn btn-primary" OnClick="btnSMTPPort_Click" Text="Update" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-6">

            <div class="row">
                <div class="col-lg-12 boxshadow">

                    <div class="form-horizontal" role="form" style="font-family: Cambria;">

                        <div class="col-lg-12" style="font-family: Cambria;">
                            <h1 class="page-header">
                                <small>E-Mail Password Change</small>
                            </h1>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">E-Mail</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmailP" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">Password</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtPassword" Height="34" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">New Password</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtNewpass" Height="34" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-4" for="email">Confirm Password</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtConfirmPass" Height="34" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-8 text-right">
                                <asp:Button ID="btnChangePass" runat="server" CssClass="btn btn-primary" Text="Change Password" OnClick="btnChangePass_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container col-lg-12" runat="server" id="PassError" style="font-family: Cambria;">
        <%--Error Msg goes here--%>
    </div>

</asp:Content>
