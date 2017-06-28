<%--/*
PROGRAM-ID.                   UserRequest.Aspx
AUTHOR.                             Ranga
COMPANY.                         VOTRE IT (Pvt.) Ltd.
 
DATE-WRITTEN.                                2016-11-09
 
Version.                               1.0.0
 
*******************************************************************************
 
                                Copyright(c) 2016-2017 VOTRE IT Pvt Ltd
 
                                                        ALL RIGHTS RESERVED
 
*******************************************************************************
 
This software is the confidential and proprietary information of VOTRE IT Pvt. Ltd.
 
("Confidential Information").
 
You shall not disclose such Confidential Information and shall use it only in
 
accordance with the terms of the license agreement you entered into with VOTRE IT.
 
*******************************************************************************
 
AMENDMENT HISTORY.
 
===================
 

  2.   PROGRAMMER   : RANGA
 
       DATE         : 2016-12-06
 
       PPCR         :
 
       VERSION           : 1.0.2
 
       DESCRIPTION  : Changed The User Group drop down . removed Customer Admin creation
 
 
 
******************************************************************************
 
  ABSTRACT ( PROGRAM DESCRIPTION )
 
  ================================
 
******************************************************************************
 
*/--%>


<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind ="UserRequest.aspx.cs" Inherits="DSCMS.UserRequest" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
   NCEDCOS | User Request
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="LiteralMessage" runat="server"></asp:Literal>

    <div class="row">

        <div class="col-lg-12">
            <h3 class="page-header">
                <asp:Label ID="Label1" runat="server" class="text-danger" Style="font-size: 15px" Text="Label" Visible="false">Request Submitted Sucessfully</asp:Label>
            </h3>
        </div>
    </div>

                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>User</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-users"></i> User Creation
                            </li>
                        </ol>
                    </div>
                </div>

             <div class="row">
                  <div class="container boxshadow">
                            <div class="col-lg-12" style="font-family:Cambria;">
                                <h1 class="page-header">
                                    <small>New User Creation</small>
                                </h1>
                            </div>
                       <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
                 <div class="col-lg-11">
                     <div class="form-horizontal" role="form" style="font-family:Cambria;">
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="PersonName"> Name</label>
                            <div class="col-sm-6">
                            <asp:TextBox ID="PersonName" CssClass="form-control"  Width="500" runat="server"></asp:TextBox>
                                                                                   

                            </div>
                             <div class="col-sm-3">
                             <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="PersonName" ErrorMessage="Name is  Required."  ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        </div>
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="UserID"">Designation</label>
                            <div class="col-sm-5">
                             <asp:TextBox ID="txtDesignation" CssClass="form-control"  runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                 <asp:Label ID="Label2" runat="server" Text="Label" visible="false" ForeColor="Red">User Exist</asp:Label>
                         
                                
                        </div>
                                            
                        </div>




                          <div class="form-group">
                            <label class="control-label col-sm-2" for="UserGroup">User Group</label>
                            <div class="col-sm-5">
                            <asp:DropDownList ID="ddUserGroup" runat="server" CssClass="form-control" Width="400" AppendDataBoundItems="true">
                             <asp:ListItem Text="--Select User Group--" Value="" />
                                <asp:ListItem Text="Customer User" Value="CUSTOMER" />
                            

                            </asp:DropDownList>
                            </div>
                              <div class="col-sm-3">
                             <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="ddUserGroup" ErrorMessage="User Group is  Required."  ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="UserID"">User ID</label>
                            <div class="col-sm-5">
                             <asp:TextBox ID="UserID" CssClass="form-control" runat="server" Width="400"></asp:TextBox>
                                                        
                            </div>
                             <div class="col-sm-3">
                             <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="UserID" ErrorMessage="User ID is  Required."  ForeColor="Red"></asp:RequiredFieldValidator><br />
                                 <asp:RegularExpressionValidator  ForeColor="Red" ID="rev" runat="server" ControlToValidate="UserID"
    ErrorMessage="Spaces are not allowed!" ValidationExpression="[^\s]+" /><br />
                                  <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "UserID" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{4,}$" runat="server" ErrorMessage="Minimum 4 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>

                            <div class="col-sm-3">
                            <asp:Label ID="lblErrorUser" runat="server" Text="Label" visible="false" ForeColor="Red" align="cener">User Exist</asp:Label></div>
                            <div class="col-sm-3">
                                 
                            
                        </div>
                        </div>


                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Email</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txteEmail" enabled="true" name="address3" placeholder="For Password Changing Purposes"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                                <div class="col-sm-5">
                             <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txteEmail" ForeColor="Red" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                      </div>

                              <div class="col-sm-5">
                             <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ControlToValidate="txteEmail" ErrorMessage="Email is Required."  ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                                    
                                   </div>
                          


                         

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="Password">Password</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="Password" inputtype="password" Width="400" TextMode="Password" placeholder="Minimum 8 Characters, Numeric and special Characters are musts " Font-Size="X-Small"  height="30"  CssClass="form-control" runat="server"></asp:TextBox>
    

                            </div>
                             <div class="col-sm-3">
                                <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="Password" ErrorMessage="Password is  Required."  ForeColor="Red"></asp:RequiredFieldValidator><br>
                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegExp1" runat="server" style="width:30%"    
                                    ErrorMessage="Weak Password or Password is too Long"
                                    ControlToValidate="Password"    
                                    Tooltip="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character."
                                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,15}$"/>
                             
                        </div>
                        </div>
                           
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="ConfirmPassword">Confirm Password</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="ConfirmPassword" Font-Size="X-Small"  inputtype="password" TextMode="Password" height="30" Width="400" CssClass="form-control" runat="server"></asp:TextBox>
                               
  
  
                            </div>
                                                    <div class="col-sm-3">
                                                        <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="ConfirmPassword"  ErrorMessage="Confirm Password is  Required."  ForeColor="Red"></asp:RequiredFieldValidator></div>
                            <div class="col-sm-3">
                             <asp:CompareValidator ID="CompareValidator1" runat="server" 
  ControlToValidate="ConfirmPassword"
    CssClass="ValidationError"
    ControlToCompare="Password"
    ErrorMessage="Password Confirmation Failed" 
      ForeColor="Red"
    ToolTip="Password must be the same" />
 
                              
                        </div> 
                                            
  </div>

                        

                         
                        </div>

                       <div class="form-group">
                                <div class="col-sm-8">
                                    <div class="col-sm-4"></div>
                                    <div class="col-sm-8">
                                 <asp:Label ID="lblSuccess" runat="server" Text="Label" visible="false" ForeColor="blue">"Request Sent Successfully!!!"</asp:Label>

                           </div>
                                    </div>
                        
                        </div>

                        

                        

                        

                       

                         <div class="btn-group"></div>
 <div class="form-group">
                           <div class="col-sm-7" style="padding-bottom:20px">
                                
                               <asp:Button ID="Button2" runat="server"  Text="Cancel" CssClass="btn btn-Secondary pull-right btn-sm" Width="150px" style="display:none" OnClick="Button2_Click"  />
                            <asp:Button ID="Button1" runat="server"  Text="Submit" CssClass="btn btn-primary pull-right btn-sm" Width="150px" OnClick="Button1_Click"  />
                            
                           </div>
                        </div>

                         

                      </div> <%--End of form-horizontal--%>
                 </div><%-- End of col-lg-11--%>
            </div>  <%--End of Row--%>

</asp:Content>


