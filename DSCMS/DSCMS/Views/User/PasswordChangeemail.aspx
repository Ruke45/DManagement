<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordChangeemail.aspx.cs" MasterPageFile="~/Master.Master" Inherits="DSCMS.Views.User.PasswordChangeemail" %>








  
<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
   NCEDCOS | Profile Change Via Mail
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="LiteralMessage" runat="server"></asp:Literal>

                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>User</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-users"></i> Profile Change
                            </li>
                        </ol>
                    </div>
                </div>

             <div class="row">
                            
                 <div class="container boxshadow">
                 <div class="col-lg-11">
                     
                         <div class="col-lg-12" style="font-family:Cambria;">
                                <h1 class="page-header">
                                    <small>Profile Change</small>
                                </h1>
                            </div>

                      <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
                     <div class="form-horizontal" role="form" style="font-family:Cambria;">


                        <div class="form-group">
                            <label class="control-label col-sm-2" for="UserID"">User ID</label>
                            <div class="col-sm-6">
                             <asp:TextBox ID="UserID" Enabled="false" CssClass="form-control" width="500" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                             <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="UserID" ErrorMessage="User ID is a Required."  ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        </div>
                         


                         <div class="form-group">
                            <label class="control-label col-sm-2" for="Password">New Password</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="NewPassword" inputtype="password" TextMode="Password"  Height="30" CssClass="form-control" width="390" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-sm-3">
                             <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="NewPassword" ErrorMessage="New Password is a Required."  ForeColor="Red"></asp:RequiredFieldValidator><br/>
                                  <asp:RegularExpressionValidator ForeColor="Red" ID="RegExp1" runat="server" style="width:30%"    
                                    ErrorMessage="Weak Password or Password is too Long"
                                    ControlToValidate="NewPassword"    
                                    Tooltip="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character."
                                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,15}$"/>
                             
                        </div>
                        </div>
                           <div class="form-group">

                            <label class="control-label col-sm-2" for="ConfirmPassword">Confirm Password</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="ConfirmPassword" inputtype="password" TextMode="Password" Height="30"  CssClass="form-control" width="390" runat="server"></asp:TextBox>
                            </div>
                                <div class="col-sm-3">
                                                        <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="ConfirmPassword"  ErrorMessage="Confirm Password is a Required."  ForeColor="Red"></asp:RequiredFieldValidator><br/>
                            
                             <asp:CompareValidator ID="CompareValidator1" runat="server" 
  ControlToValidate="ConfirmPassword"
    CssClass="ValidationError"
    ControlToCompare="NewPassword"
    ErrorMessage="Password Confirmation Failed" 
      ForeColor="Red"
    ToolTip="Password must be the same" />
 
                              
                        </div> 
                        </div>

                       

                        

                        

                        

                        <div class="col-sm-5"></div>
                         <div class="col-sm-2"><div class="col-sm-1"></div>
                         <div class="btn pull-right">
 
                           
                            <asp:Button ID="BtnSubmit" runat="server" align="left"  Text="Change" CssClass="btn btn-primary" Width="200px"  OnClick="BtnSubmit_Click"/></div></div>
                            
                       

                         

                      </div> <%--End of form-horizontal--%>
                 </div><%-- End of col-lg-11--%>
                </div>
             </div> <%--End of Row--%>

</asp:Content>



