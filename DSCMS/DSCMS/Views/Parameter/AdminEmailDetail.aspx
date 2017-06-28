<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminEmailDetail.aspx.cs" Inherits="DSCMS.Views.Parameter.AdminEmailDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Admin Email
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Admin Email Details</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-cogs"></i> Configure Email
                    </li>
                </ol>
            </div>
            <div id="Msg" class="container col-lg-12" style="font-family: Cambria;" runat="server">
               
          </div>
     

        <div class="col-md-10 col-md-offset-1">
             <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
             <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Email Address</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtEmailAddress" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                 <asp:RegularExpressionValidator ID="cvEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmailAddress" ErrorMessage="Invalid Email Address." ForeColor="Red"></asp:RegularExpressionValidator>
                           <br />
                               <asp:RequiredFieldValidator ID="cvCustName" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Email Address is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>


         
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Password</label>
                            <div class="col-sm-6">
                                <asp:TextBox Height="32px"  ID="txtPassword" TextMode="password" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator  ID="reAddress" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is Required." ForeColor="Red" ></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Confirm Password</label>
                            <div class="col-sm-6">
                                <asp:TextBox Height="32px"  ID="ConfigPassword" TextMode="password" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ControlToValidate="ConfigPassword" ErrorMessage="Confirm Password is Required." ForeColor="Red" ></asp:RequiredFieldValidator><br />
                                <asp:CompareValidator ID="cvpassword1" runat="server"
                                    ControlToValidate="ConfigPassword"
                                    ControlToCompare="txtPassword"
                                    ErrorMessage="Password Confirmation Failed." ForeColor="Red">
                                </asp:CompareValidator>
                            </div>

                        </div>


                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-6">
                                 </div>
                            <div class="col-sm-3">
                                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Configure" OnClick="Button1_Click" />
                            </div>
                        </div>
                        </div>
                 
        </div>
        </div>
    </div>
</div>
</asp:Content>
