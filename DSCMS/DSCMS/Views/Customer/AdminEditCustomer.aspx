<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminEditCustomer.aspx.cs" Inherits="DSCMS.Views.Customer.AdminEditCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Edit Customer
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-lg-12">
        <div class="row">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        <small>Customer</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li class="active">
                            <i class="fa fa-th-large"></i> Edit Customer Detail
                        </li>
                    </ol>
                </div>
            </div>
            <div class="container col-lg-12" runat="server" id="ErrorMessage1" style="font-family: Cambria;">
                <%--Error Msg goes here--%>
            </div>
            
        </div>
        
        <div class="row">
            <div class="container boxshadow">

                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Customer Details</small>
                    </h2>
                </div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Customer Id</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtCustomerId" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                           
                        </div>
                       
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Customer Name</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtCustName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCusCheck" runat="server" Text="Label" Visible="false" ForeColor="Red">The Company Exist.</asp:Label>

                                <asp:RequiredFieldValidator ID="cvCustName" runat="server" ControlToValidate="txtCustName" ErrorMessage="Customer name is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                       <%-- <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Admin Name</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtAdminName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAdminName" ErrorMessage="Admin Name is a Required." ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>--%>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address 1</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtAddress1" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="reAddress" runat="server" ControlToValidate="txtAddress1" ErrorMessage="Address1 is a Required." ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address 2</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtAddress2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="rfAddress2" runat="server" ControlToValidate="txtAddress2" ErrorMessage="Address2  is a Required." ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address 3</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtAddress3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="rfAddress3" runat="server" ControlToValidate="txtAddress3" ErrorMessage="Address2 is a Required." ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>



                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">General E-Mail</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                 <div style="width:200px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="E-mail is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div> <div style="width:200px">
                                <asp:RegularExpressionValidator ID="cvEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Address." ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                                </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">General Telephone</label>

                            <div class="col-sm-3">
                                <asp:TextBox ID="txtTelephone" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                 <div style="width:200px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTelephone" ErrorMessage="Telephone Number is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                               </div> <div style="width:200px">
                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator2" runat="server"
                                    ErrorMessage="Invalid Telephone Number"
                                    ControlToValidate="txtTelephone"
                                    ValidationExpression="^[0-9]{10}$" />
                                   </div>
                            </div>


                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">General FAX</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtFax" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                 <div style="width:200px">
                                </div> <div style="width:200px">
                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator1" runat="server"
                                    ErrorMessage="Invalid Fax Number"
                                    ControlToValidate="txtFax"
                                    ValidationExpression="^[0-9]{10}$" />
                                   </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Contact Person’s Details</small></h2>
                </div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Name</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtContactName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="RFVContactName" runat="server" ControlToValidate="txtContactName" ErrorMessage="Name is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Designation</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="RFVtxtDesignation" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Designation is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Direct Phone Number</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                 <div style="width:200px">
                                <asp:RequiredFieldValidator ID="RFVPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Number is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div> <div style="width:200px">
                                <asp:RegularExpressionValidator ForeColor="Red" ID="REVPhoneNumber" runat="server"
                                    ErrorMessage="Invalid Telephone Number"
                                    ControlToValidate="txtPhoneNumber"
                                    ValidationExpression="^[0-9]{10}$" />
                                    </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Mobile</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtContactMobile" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                 <div style="width:200px">
                                <asp:RequiredFieldValidator ID="RFVContactMobile" runat="server" ControlToValidate="txtContactMobile" ErrorMessage="Mobile No is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                               </div> <div style="width:200px">
                                <asp:RegularExpressionValidator ForeColor="Red" ID="REVContactMobile" runat="server"
                                    ErrorMessage="Invalid Telephone Number"
                                    ControlToValidate="txtContactMobile"
                                    ValidationExpression="^[0-9]{10}$" />
                                   </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">E-mail</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtContactEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                 <div style="width:200px">
                                <asp:RequiredFieldValidator ID="RFVContactEmail" runat="server" ControlToValidate="txtContactEmail" ErrorMessage="Email Address is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div> <div style="width:200px">
                                <asp:RegularExpressionValidator ID="REVConEmailValidator" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtContactEmail" ErrorMessage="Invalid Email Address." ForeColor="Red"></asp:RegularExpressionValidator>
</div>
                            </div>
                        </div>

                    </div>
                </div>


                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Product Details</small></h2>
                </div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Export Products</label>
                            <div class="col-sm-6">
                                <textarea id="txaProducts" runat="server" name="txaProducts" cols="50" rows="10" style="width: 100%" title="products must separate with ','"> </textarea>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="RFVProducts" runat="server" ControlToValidate="txaProducts" ErrorMessage="Export Products is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Export Sector </label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpExportSector"
                                    Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="--Export Sector--" Value="" />
                                     <asp:ListItem Text="Remove Export Sector" Value="none" />
                                </asp:DropDownList>
                                <asp:Label ID="lblExportSector" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:Button ID="Button1" runat="server" Text="+" CssClass="btn btn-default" OnClick="Button1_Click" />
                                <asp:RequiredFieldValidator ID="RFVExportSector" runat="server" ControlToValidate="drpExportSector" ErrorMessage="Export Sector is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                
                            </div>
                            <div id="sector1" runat="server" visible="false">
                                <br />
                                <br />
                                <label class="control-label col-sm-2" for="email"></label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="drpExportSector1"
                                        Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Export Sector--" Value="" />
                                         <asp:ListItem Text="Remove Export Sector" Value="none" />
                                    </asp:DropDownList>
                                    <asp:Label ID="lblExportSector1" Visible="false" runat="server" ></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button ID="Button2" runat="server" Text="+" CssClass="btn btn-default" OnClick="Button2_Click" />
                                </div>
                            </div>
                            <div id="sector2" runat="server" visible="false">
                                 <br />
                                <br />
                             <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpExportSector2"
                                    Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="--Export Sector--" Value="" />
                                     <asp:ListItem Text="Remove Export Sector" Value="none" />
                                </asp:DropDownList>
                                <asp:Label ID="lblExportSector2" Visible="false" runat="server"></asp:Label>
                            </div>
                                <div class="col-sm-3">
                                    <asp:Button ID="Button3" runat="server" Text="+" CssClass="btn btn-default" OnClick="Button3_Click" />
                                </div>
                                </div>
                            <div id="sector3" runat="server" visible="false">
                                 <br />
                                <br />
                             <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpExportSector3"
                                    Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="--Export Sector--" Value="" />
                                     <asp:ListItem Text="Remove Export Sector" Value="none" />
                                </asp:DropDownList>
                                <asp:Label ID="lblExportSector3" Visible="false" runat="server" ></asp:Label>
                            </div>
                                <div class="col-sm-3">
                                    <asp:Button ID="Button4" runat="server" Text="+" CssClass="btn btn-default" OnClick="Button4_Click" />
                                </div>
                                </div>
                            <div id="sector4" runat="server"  visible="false">
                                 <br />
                                <br />
                             <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpExportSector4"
                                    Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="--Export Sector--" Value="" />
                                     <asp:ListItem Text="Remove Export Sector" Value="none" />
                                </asp:DropDownList>
                                <asp:Label ID="lblExportSector4" Visible="false" runat="server" ></asp:Label>
                            </div>
                                </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">NCE Member </label>
                            <div class="col-sm-1">
                                <asp:RadioButtonList ID="RbtnMember" runat="server">
                                    <asp:ListItem Value="Yes"  runat="server"> Yes</asp:ListItem>
                                    <asp:ListItem Value="No" runat="server"> No</asp:ListItem>
                                </asp:RadioButtonList>

                            </div>
                             <label class="control-label col-sm-2" for="email">Payment Method</label>
                                <div class="col-sm-1">
                                    <asp:RadioButtonList ID="RblPaid" runat="server">
                                        <asp:ListItem Value="cash" runat="server"> Cash</asp:ListItem>
                                        <asp:ListItem Value="credit" runat="server"> Credit</asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                            </div>
                          
                               
                                
                            </div>







                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Template</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="drpTemplate"
                                        Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select Template--" Value="" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <%--<asp:RequiredFieldValidator ID="RFVExportSector" runat="server" ControlToValidate="drpExportSector" ErrorMessage="Export Sector is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                    --%>
                                </div>
                            </div>

                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Administrator Details</small></h2>
                </div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">User Name</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtuserName" Enabled="false"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                               
                                <input type="button" class="btn btn-primary" onclick="showDiv()" value="Create New Customer Admin"/>
                            </div>
                        </div>
                        </div>
                    </div>
                    <script>
                        function showDiv() {
                            document.getElementById('show').style.display = "block";
                        }
                    </script>
                <div class="col-lg-11" id="show" style="display:none">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                       
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">New User Name</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtnewUserName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <div>
                                    <asp:Label ID="lbluserName" ForeColor="red" runat="server" Visible="false" Text="The Administrator Exists."></asp:Label>
                                   
                                </div><div>
                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtnewUserName"
                                    ErrorMessage="User Name should be at least 4 character." ValidationExpression="[a-zA-Z.0-9]{4,20}" />
                               </div>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Password</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtPassword" ToolTip="Minimum length 8 characters including 1 number and special character" TextMode="Password" Height="32px" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <div>
                                <asp:Label ID="lblpasswordrequired" ForeColor="red" runat="server" Visible="false" Text="Password is Required."></asp:Label>
                                    </div>
                                <div>
                                 <asp:RegularExpressionValidator ForeColor="Red" ID="RegExp1" runat="server" Style="width: 30%"
                                    ErrorMessage="Minimum length 8 characters including 1 number and special character"
                                    ControlToValidate="txtPassword"
                                    
                                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[-_$@$!%*#?&])[A-Za-z\d$@$!%*#?&-_]{8,15}$" />
                              </div></div>
                        </div>
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Confirm Password</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtConfermpass"  TextMode="Password" Height="32px" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5">
                                <div>
                                <asp:Label ID="lblconPassword" ForeColor="red" runat="server" Visible="false" Text="Password Conformation is Required."></asp:Label></div><div>
                                  <asp:CompareValidator ID="cvpassword1" runat="server"
                                    ControlToValidate="txtConfermpass"
                                    ControlToCompare="txtPassword"
                                    ErrorMessage="Password Confirmation Failed." ForeColor="Red">
                                </asp:CompareValidator>
                            </div></div>
                        </div>
                </div>
                        </div>
                    </div>
               
                <div class="col-lg-11" id="Save" runat="server">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">

                        <div class="form-group">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-6">
                                <asp:Button ID="Submit" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="Submit_Click" />
                                 <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="btn btn-danger" Width="200px" OnClick="Cancel_Click" />
                               
                            </div>
                        </div>







                    </div>
                    <%--End of form-horizontal--%>
                </div>
                <%-- End of col-lg-11--%>
            </div>
            <%--End of Row--%>
        </div>
    </div>
            </div>
         </div>
</asp:Content>
