<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminEditUser.aspx.cs" Inherits="DSCMS.Views.Customer.AdminEditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Edit User
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <script>
       
        function Close_btn(){
            document.getElementById("divAdd").style.display = "none";
        }
        function btnAdd_click() {
            document.getElementById("divAdd").style.display = "block";
        }
    </script>
    <style>
        #divAdd {
            display:none;
        }
    </style>
   <div id="ReasonPop" runat="server" visible="false">
        <div style="width: 100%; height: 150%; background-color: rgba(0, 0, 0, 0.81); z-index: 9999; margin-left: -15px;margin-top:-60px" position: fixed">
            <div class="col-lg-8" style="margin-left: 15%; margin-right: 15%; margin-top: 10%">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Edit User</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">


                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">User Name</label>

                               
                                
                                <div class="col-sm-3">
                                     <asp:Label ID="lblUserName" runat="server" CssClass="form-control" Text="Label"></asp:Label>

                                </div>
                            </div>
                          
                                     
                               
                            
                             <div class="form-group">
                                <label class="control-label col-sm-2" >Person Name</label>


                                <div class="col-sm-3">
                                    
                                    <asp:TextBox ID="txtPersonName" runat="server" CssClass="form-control" ></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary"  OnClick="Save_btn" />
                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-danger" OnClick="Close_btn" />
                    </div>
                </div>
            </div>


        </div>

    </div>


     <div id="divRemove" runat="server" visible="false">
        <div style="width: 100%; height: 150%; background-color: rgba(0, 0, 0, 0.81); z-index: 9999; margin-left: -15px; position: fixed">
            <div class="col-lg-8" style="margin-left: 15%; margin-right: 15%; margin-top: 10%">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">De Activate User</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">


                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">User Name</label>


                                <div class="col-sm-3">
                                    
                                    <asp:Label ID="lblUserid" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Person Name</label>


                                <div class="col-sm-3">
                                    
                                    <asp:Label ID="lblPersonName" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                                </div>
                            </div>
                           

                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button1" runat="server" Text="DE Activate" CssClass="btn btn-primary"  OnClick="Confirm_btn" />
                        <asp:Button ID="Button2" runat="server" Text="Close" CssClass="btn btn-danger" OnClick="Close_btn" />
                    </div>
                </div>
            </div>


        </div>

    </div>


   
     <div id="divAdd">
        <div style="width: 100%; height: 150%; background-color: rgba(0, 0, 0, 0.81); z-index: 9999; margin-left: -15px; position: fixed">
            <div class="col-lg-8" style="margin-left: 15%; margin-right: 15%; margin-top: 10%">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Add User</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">

                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Customer Name</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtCustomer" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCustomer" ErrorMessage="Select Customer First" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Person Name</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtAdminName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdminName" ErrorMessage="Person Name is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                         <div class="form-group">
                            <label class="control-label col-sm-3" for="email">User Group</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="drpUserGroup" CssClass="form-control" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem>--Select User Group</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4">
                                <div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpUserGroup" ErrorMessage="User Name is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div>
                                <asp:Label ID="lblGroupErrormsg" runat="server"  Visible="false" ForeColor="Red">Disable Customer Admin And Try Agian</asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-3" for="email">User Name</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <div>
                                <asp:Label ID="lblUserNameCheck" runat="server"  Visible="false" ForeColor="Red">The Administrator Exists</asp:Label>
                                </div><div>
                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUserName"
                                    ErrorMessage="User Name should be at least 6 Character." ValidationExpression="[a-zA-Z.0-9]{6,20}" />
                                </div><div>
                                <asp:RequiredFieldValidator ID="cvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="User Name is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="control-label col-sm-3" for="email">Password</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtPassword" Style="height: 32px; margin-bottom: 0;" TextMode="password" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:RequiredFieldValidator ID="cvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegExp1" runat="server" Style="width: 30%"
                                    ErrorMessage="Weak Password."
                                    ControlToValidate="txtPassword"
                                    ToolTip="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character."
                                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[-_$@$!%*#?&])[A-Za-z\d$@$!%*#?&-_]{8,}$" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-3" for="email">Confirm Password</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtconfirm_password" Style="height: 32px; margin-bottom: 0;" TextMode="password" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:RequiredFieldValidator ID="cvconfirm_password" runat="server"
                                    ErrorMessage="Password Conformation is Required."
                                    ControlToValidate="txtconfirm_password" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvpassword1" runat="server"
                                    ControlToValidate="txtconfirm_password"
                                    ControlToCompare="txtPassword"
                                    ErrorMessage="Password Confirmation Failed." ForeColor="Red">
                                </asp:CompareValidator><br />

                            </div>
                        </div>
                            
                           
                            
                            
                           

                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button3" runat="server" Text="Save" CssClass="btn btn-primary"  OnClick="Add_new" />
                        <input type="button" id="Button4" value="Close" class="btn btn-danger" onclick="Close_btn()" />
                    </div>
                </div>
            </div>


        </div>

    </div>
   



     <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Edit User</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-dashboard"></i>Edit Customer's Users
                    </li>
                </ol>
            </div>
     
        </div>

        <div class="col-md-10 col-md-offset-1">

            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-7">


                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Customer Name</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpCustomer" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control">
                                        <asp:ListItem>--Select Customer Name--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                      
                        <div class="col col-xs-3 text-right" style="float: right">
                            <form action="#" method="get">
                                <div class="input-group">
                                    <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                                    <input class="form-control" id="system-search" placeholder="Search for"  />
                                    <span class="input-group-btn">
                                        <button type="submit" class="btn btn-default frm-btn"><i class="glyphicon glyphicon-search"></i></button>
                                    </span>
                                </div>
                            </form>

                        </div>
                        <div class="col col-xs-2 text-right">
                              
                        </div>

                    </div>
                    <div style="float:right">
                    <input type="button" id="btnAdd"  class="btn btn-primary"  value="Add New" onclick="btnAdd_click()" />
                        </div>
                </div>

                <div class="panel-body">
                    

                    <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search"  
                        >
                        <Columns>
                            <asp:BoundField HeaderText="User Name" DataField="UserId1" SortExpression="UserId1" />
                            <asp:BoundField HeaderText="Person Name" DataField="PersonName1" SortExpression="PersonName1" />
                            <asp:BoundField HeaderText="Created By" DataField="CreatedBy1" SortExpression="CreatedBy1" />
                            <asp:BoundField HeaderText="Created Date" DataField="CreatedDate1" SortExpression="CreatedDate1" />
                            <asp:BoundField HeaderText="Group" DataField="UserGroupName1" SortExpression="UserGroupName1" />
                             <asp:TemplateField HeaderText="Edit Option">
                                <ItemTemplate>
                                    <asp:LinkButton ID="View" runat="server" CssClass="btn btn-primary" OnClick="Edit_Click">View</asp:LinkButton>
                                    <asp:LinkButton ID="remove" runat="server" CssClass="btn btn-danger" OnClick="Remove_btn">De Activate</asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>    
                        </Columns>
                    </asp:GridView>
                    <div class="col-md-12 text-center">
                        <ul class="pagination pagination-lg pager" id="myPager"></ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
      
</asp:Content>
