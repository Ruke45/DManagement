<%--
<!-- Version NO 12.1 -->
<!-- Request Date:2016/12/05-->
<!-- Update Date:2016/12/08-->
<!-- Request By:Mr.Pradeep-->
<!-- Changes:remove Administrator Name when Create Administrator--> 
<!-- Done By:nipun Munipura-->    
    --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="DSCMS.CustomerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Customer Register
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
      .radioButtonList { list-style:none; margin: 0; padding: 0;}
    .radioButtonList.horizontal li { display: inline;}

        .radioButtonList label {
            display: inline;
        }
        #exsectorDiv1 {
            display:none;
        }
        #exsectorDiv2 {
            display:none;
        }
        #exsectorDiv3 {
            display:none;
        }
        #exsectorDiv4 {
            display:none;
        }
    </style>
    <script>
        var btnvalue1 = 0;
        var btnvalue2 = 0;
        var btnvalue3 = 0;
        var btnvalue4 = 0;
        function ShowExsector1() {
       
            if (btnvalue1 == 0) {
                document.getElementById("exsectorDiv1").style.display = "block";
                btnvalue1 = 1;
            }
            else if (btnvalue1 == 1) {
                document.getElementById("exsectorDiv2").style.display = "block";
                btnvalue1 = 2;
            }
            else if (btnvalue1 == 2) {
                document.getElementById("exsectorDiv3").style.display = "block";
                btnvalue1 = 3;
            }
            else if (btnvalue1 == 3) {
                document.getElementById("exsectorDiv4").style.display = "block";
                btnvalue1 = 4;
            }
            else if (btnvalue1 == 4) {
               // document.getElementById("exsectorDiv4").style.display = "none";
                btnvalue1 = 5;
            }
            else if (btnvalue1 == 5) {
               // document.getElementById("exsectorDiv3").style.display = "none";
                btnvalue1 = 6;
            }
            else if (btnvalue1 == 6) {
               // document.getElementById("exsectorDiv2").style.display = "none";
                btnvalue1 = 7;
            }
            
            else {
                //document.getElementById("exsectorDiv1").style.display = "none";
                btnvalue1 = 0;
            }
        
        
        }
        
    </script>
    <div class="col-lg-12">
        <div class="row">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        <small>Customer</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li class="active">
                            <i class="fa fa-th-large"></i> Customer Registration
                        </li>
                    </ol>
                </div>
            </div>
            <div class="container col-lg-12" runat="server" id="ErrorMessage1" style="font-family: Cambria;">
                <%--Error Msg goes here--%>
            </div>
            <div class="container col-lg-12" runat="server" id="ErrorMessage2" style="font-family: Cambria;">
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
                            <label class="control-label col-sm-2" for="email">Company Name</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="CustName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCusCheck" runat="server" Text="Label" Visible="false" ForeColor="Red">The Company Exist.</asp:Label>

                                <asp:RequiredFieldValidator ID="cvCustName" runat="server" ControlToValidate="CustName" ErrorMessage="Customer name is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address Line 1</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="Address1" CssClass="form-control" runat="server" EnableViewState="False"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="reAddress" runat="server" ControlToValidate="Address1" ErrorMessage="Address1 is Required." ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address Line 2</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="Address2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <%--<asp:RequiredFieldValidator ID="rfAddress2" runat="server" ControlToValidate="Address2" ErrorMessage="Address2  is Required." ForeColor="Red"></asp:RequiredFieldValidator>--%>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">City</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="Address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="rfAddress3" runat="server" ControlToValidate="Address3" ErrorMessage="City is Required." ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>



                        <div class="form-group" >
                            <label class="control-label col-sm-2" for="email">General E-Mail</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="Email" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <div style="width:200px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Email" ErrorMessage="E-mail is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div style="width:200px">
                                <asp:RegularExpressionValidator ID="cvEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email" ErrorMessage="Invalid Email Address." ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            </div>
                        </div>

                        <div class="form-group" style="margin-bottom: -35px;z-index: 0;">
                            
                            <label class="control-label col-sm-2" for="email" > Telephone</label>
                           <div class="col-sm-7" style="padding-left:0px">
                            <div class="col-sm-5">
                                <asp:TextBox ID="Telephone" CssClass="form-control" runat="server" ToolTip="Ex:0111234567" placeholder="0111234567"></asp:TextBox>
                                <div style="width:200px">
                                    <div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Telephone" ErrorMessage="Telephone Number is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div><div style="width:200px">
                                        <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator2" runat="server"
                                            ErrorMessage="Invalid Telephone Number"
                                            ControlToValidate="Telephone"
                                            ValidationExpression="^[0-9]{10}$" />
                                    </div>
                            </div>
                            </div>
                            <label class="control-label col-sm-2" for="email" style="padding-left:0px">General FAX</label>
                            <div class="col-sm-5" style="padding-right:0px">
                                <asp:TextBox ID="Fax" CssClass="form-control" runat="server" ToolTip="Ex:0111234567" placeholder="0111234567"></asp:TextBox>
                                 <div class="col-sm-3">
                                    <%-- <div style="width:200px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Fax" ErrorMessage="Fax Number is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>--%>
                                 <div style="width:200px">
                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator1" runat="server"
                                    ErrorMessage="Invalid Fax Number"
                                    ControlToValidate="Fax"
                                    ValidationExpression="^[0-9]{10}$" />
                                    </div>
                            </div>
                            </div>
                               </div>

                        </div>
                        
                        <br />
                        <br />
                          <div class="form-group" >
                            <label class="control-label col-sm-2" for="email">Copy Of Business Registration</label>
                            <div class="col-sm-7">
                                 <asp:FileUpload ID="btnRegistration" runat="server" />
                            </div>
                            <div class="col-sm-3">
                               <div>
                                   <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </div>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.pdf)$"
                                        ControlToValidate="btnRegistration" runat="server" ForeColor="Red" ErrorMessage="Please select a valid PDF File file."
                                        Display="Dynamic" />

                                </div>
                           
                        </div>


                          <div class="form-group" >
                            <label class="control-label col-sm-2" for="email">Request Letter</label>
                            <div class="col-sm-7">
                                 <asp:FileUpload ID="btnRequest" runat="server" />
                            </div>
                            <div class="col-sm-3">
                                <div>
                                   <asp:Label ID="Label2" runat="server" Text=""></asp:Label></div>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.pdf)$"
                                        ControlToValidate="btnRequest" runat="server" ForeColor="Red" ErrorMessage="Please select a valid PDF File file."
                                        Display="Dynamic" />

                                </div>
                        </div>

                       

                        <br />
                    </div>
                </div>
               <br />
                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Contact Person’s Details</small></h2>
                </div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Contact Person Name</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtContactName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="RFVContactName" runat="server" ControlToValidate="txtContactName" ErrorMessage="Name is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Designation</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="RFVtxtDesignation" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Designation is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">E-mail</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtContactEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <div style="width:200px">
                                <asp:RequiredFieldValidator ID="RFVContactEmail" runat="server" ControlToValidate="txtContactEmail" ErrorMessage="Email Address is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div><div style="width:200px">
                                <asp:RegularExpressionValidator ID="REVConEmailValidator" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtContactEmail" ErrorMessage="Invalid Email Address." ForeColor="Red"></asp:RegularExpressionValidator>
                              </div>
                            </div>
                        </div>


                        <div class="form-group" style="margin-bottom: -35px;z-index: 0;">
                            <label class="control-label col-sm-2" for="email">Direct Phone No</label>
                            <div class="col-sm-7" style="padding-left: 0px">
                                <div class="col-sm-5" style="padding-right: 0px">
                                    <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" runat="server" ToolTip="Ex:0111234567" placeholder="0111234567"></asp:TextBox>
                                
                                <div style="width:200px">
                                    <div>
                                    <asp:RequiredFieldValidator ID="RFVPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Number is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div>
                                    <asp:RegularExpressionValidator ForeColor="Red" ID="REVPhoneNumber" runat="server"
                                        ErrorMessage="Invalid Telephone Number"
                                        ControlToValidate="txtPhoneNumber"
                                        ValidationExpression="^[0-9]{10}$" />
                                </div>
                                </div>
                           </div>
                            <label class="control-label col-sm-2" for="email">Mobile No</label>
                            <div class="col-sm-5" style="padding-right: 0px">
                                <asp:TextBox ID="txtContactMobile" CssClass="form-control" runat="server" ToolTip="Ex:0771234567" placeholder="0771234567"></asp:TextBox>
                           
                            <div style="width:200px">
                                 <div>
                                <asp:RequiredFieldValidator ID="RFVContactMobile" runat="server" ControlToValidate="txtContactMobile" ErrorMessage="Mobile No is Required." ForeColor="Red" ></asp:RequiredFieldValidator>
                                </div> <div>
                                <asp:RegularExpressionValidator ForeColor="Red" ID="REVContactMobile" runat="server"
                                    ErrorMessage="Invalid Telephone Number"
                                    ControlToValidate="txtContactMobile"
                                    ValidationExpression="^[0-9]{10}$" />
                                     </div>
                            </div>
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
                                <textarea id="txaProducts" runat="server" name="txaProducts" cols="50" rows="5" style="width: 100%" title="products must separate with ','"> </textarea>
                            </div>
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="RFVProducts" runat="server" ControlToValidate="txaProducts" ErrorMessage="Export Products is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Export Sector </label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpExportSector1"
                                    Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="--Export Sector--" Value="" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                 <input type="button" class="btn btn-default" value="+" id="exSector1" onclick="ShowExsector1()" />
                                <asp:RequiredFieldValidator ID="RFVExportSector" runat="server" ControlToValidate="drpExportSector1" ErrorMessage="Export Sector is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                
                            </div>
                            <div id="exsectorDiv1">
                                <br />
                                <br />

                                <label class="control-label col-sm-2" for="email"></label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="drpExportSector2"
                                        Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Export Sector--" Value="" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                  <%--  <input type="button" class="btn btn-default" value="+" id="exSector2" onclick="ShowExsector2()" />
                              --%>  </div>
                            </div>

                            <div id="exsectorDiv2">
                                <br />
                                <br />
                                <label class="control-label col-sm-2" for="email"></label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="drpExportSector3"
                                        Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Export Sector--" Value="" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                   <%-- <input type="button" class="btn btn-default" value="+" id="exSector4" onclick="ShowExsector3()" />
                                --%></div>
                            </div>
                            <div id="exsectorDiv3">
                                <br />
                                <br />
                                <label class="control-label col-sm-2" for="email"></label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="drpExportSector4"
                                        Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Export Sector--" Value="" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                  <%--   <input type="button" class="btn btn-default" value="+" id="Button2" onclick="ShowExsector4()" />
                              --%>  </div>
                                <div id="exsectorDiv4">
                                    <br />
                                    <br />
                                    <label class="control-label col-sm-2" for="email"></label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="drpExportSector5"
                                            Width="100%" Height="30" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Text="--Export Sector--" Value="" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3">
                                    </div>
                                </div>
                             </div>
                        </div>
                        <div class="form-group" style="margin-bottom: -25px;z-index: 0;">
                            <label class="control-label col-sm-2" for="email">NCE Member </label>
                            <div class="col-sm-1">
                                <asp:RadioButtonList ID="RbtnMember" RepeatDirection="Horizontal" TextAlign="Right" CssClass="radioButtonList" runat="server">
                                    <asp:ListItem Value="Yes"> Yes</asp:ListItem>
                                    <asp:ListItem Value="No"> No</asp:ListItem>
                                </asp:RadioButtonList>
                                  <br />
                             

                            </div>
                          
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="RFVRbtnMember" runat="server" ControlToValidate="RbtnMember" ErrorMessage="NCE Member is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                </div>
                 <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Tax Details</small></h2>
                </div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Tax Details</label>
                            <div class="col-sm-1">
                                <asp:RadioButtonList  OnSelectedIndexChanged="RbtnMember_SelectedIndexChanged" AutoPostBack="true" ID="rdtax" RepeatDirection="Vertical" TextAlign="Right" CssClass="radioButtonList" runat="server">
                                    <asp:ListItem Value="Yes">SVAT</asp:ListItem>
                                    <asp:ListItem Value="No">VAT</asp:ListItem>
                                </asp:RadioButtonList>
                                   
                                  <br />
                            </div>
                          
                            <div class="col-sm-3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdtax" ErrorMessage="Tax Details is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            </div>
                         <asp:GridView ID="gvTaxRegistration" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search" >
                                <Columns>
                                    <%-- <asp:BoundField HeaderText="Tax ID" DataField="TaxId1" SortExpression="TaxId1" />--%>
                                    <asp:BoundField HeaderText="Tax Code" DataField="TaxCode1" SortExpression="TaxCode1" />
                                    <asp:BoundField HeaderText="Tax Name" DataField="TaxName1" SortExpression="TaxName1" />
                                    <asp:BoundField HeaderText="Tax Percentage" DataField="TaxPercentage1" SortExpression="TaxPercentage1" />
                                     <asp:TemplateField HeaderText="Tax Registration No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="RegistrationNo" runat="server" Enabled="true" ClientIDMode="Static"></asp:TextBox>
                                           
                                        </ItemTemplate>

                                    </asp:TemplateField>


                                </Columns>
                                 <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                            </asp:GridView>
                        </div>
                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Customer Administrator Details</small></h2>
                </div>
                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">

                          <%--<div class="form-group">
                            <label class="control-label col-sm-2" for="email"> Name</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtAdminName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdminName" ErrorMessage="Person Name is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                 <div>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAdminName" ErrorMessage="." ForeColor="white"></asp:RequiredFieldValidator>
                               
                                </div>
                            </div>
                        </div>--%>



                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">User Name</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="UserName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <div>
                                <asp:Label ID="lblUserNameCheck" runat="server" Text="Label" Visible="false" ForeColor="Red">The Administrator Exists</asp:Label>
                                </div><div>
                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator3" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="User Name should be at least 4 character." ValidationExpression="[a-zA-Z.0-9]{4,20}" />
                                </div><div>
                                <asp:RequiredFieldValidator ID="cvUserName" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Password</label>
                            <div class="col-sm-3">
                                <asp:TextBox  ID="Password" Style="height: 32px; margin-bottom: 0;" TextMode="password" CssClass="form-control" runat="server" ToolTip="Minimum length 8 characters including 1 number and special character"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <div>
                                <asp:RequiredFieldValidator ID="cvPassword" runat="server" ControlToValidate="Password" ErrorMessage="Password is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                               </div><div>
                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegExp1" runat="server" Style="width: 30%"
                                    ErrorMessage="Minimum length 8 characters including 1 number and special character"
                                    ControlToValidate="Password"
                                    
                                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[-_$@$!%*#?&])[A-Za-z\d$@$!%*#?&-_]{8,15}$" />
                            </div>
                               </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Confirm Password</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="confirm_password" Style="height: 32px; margin-bottom: 0;" TextMode="password" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <div>
                                <asp:RequiredFieldValidator ID="cvconfirm_password" runat="server"
                                    ErrorMessage="Password Conformation is Required."
                                    ControlToValidate="confirm_password" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                    </div>
                                <div>
                                <asp:CompareValidator ID="cvpassword1" runat="server"
                                    ControlToValidate="confirm_password"
                                    ControlToCompare="Password"
                                    ErrorMessage="Password Confirmation Failed." ForeColor="Red">
                                </asp:CompareValidator><br />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-6">
                                <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="Button1_Click" />
                            </div>
                        </div>







                    </div>
                    <%--End of form-horizontal--%>
                </div>
                <%-- End of col-lg-11--%>
            </div>
            <%--End of Row--%>
        </div>
            
</div></div>
</asp:Content>
