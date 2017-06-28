<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditNCEContactPersonName.aspx.cs" Inherits="DSCMS.Views.Maintenance.EditNCEContactPersonName" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
        NCEDCOS | Contact Person Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-lg-12">
        <div class="row">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        <small>NCE Contact Person</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li class="active">
                            <i class="fa fa-th-large"></i> Certificate Verification Contact Person
                        </li>
                    </ol>
                </div>
            </div>
            <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
                <%--Error Msg goes here--%>
            </div>
            
        </div>
        <div class="row">
            <div class="container boxshadow">

                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>NCE Contact Person Details</small>
                    </h2>
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
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Web Address</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtWeb" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <div style="width:200px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWeb" ErrorMessage="Email Address is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div><div style="width:200px">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="\w+([-+.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtWeb" ErrorMessage="Invalid Email Address." ForeColor="Red"></asp:RegularExpressionValidator>
                              </div>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Fax No</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtfaxNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <div style="width:200px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfaxNo" ErrorMessage="Email Address is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div><div style="width:200px">
                                  <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator2" runat="server"
                                            ErrorMessage="Invalid Fax Number"
                                            ControlToValidate="txtfaxNo"
                                            ValidationExpression="^\+(?:[0-9].?){6,14}[0-9]$" />
                              </div>
                            </div>
                        </div>
                        <div class="form-group" style="margin-bottom: -35px;z-index: 0;">
                            <label class="control-label col-sm-2" for="email"> Phone No</label>
                            <div class="col-sm-7" style="padding-left: 0px">
                                <div class="col-sm-5" style="padding-right: 0px">
                                    <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" runat="server" ToolTip="Ex:0111234567" placeholder="0111234567"></asp:TextBox>
                                
                                <div style="width:200px">
                                    <div>
                                    <asp:RequiredFieldValidator ID="RFVPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Number is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div>
                                   <%-- <asp:RegularExpressionValidator ForeColor="Red" ID="REVPhoneNumber" runat="server"
                                        ErrorMessage="Invalid Telephone Number"
                                        ControlToValidate="txtPhoneNumber"
                                        ValidationExpression="^[0-9]{10}$" />--%>
                                </div>
                                </div>
                           </div>
                           
                                 </div>
                        </div>
                       
                      

                    </div>
                </div>


             
         
           

                <div class="col-lg-11">
                   
               
              
                    <br />
                    <br />

                        <div class="form-group">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-6">
                                <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="Button1_Click"  />
                            </div>
                        </div>

                    <br />
                    <br /><br />





                    </div>
                    <%--End of form-horizontal--%>
                </div>
                <%-- End of col-lg-11--%>
            </div>
            <%--End of Row--%>
        </div>
            </div>
    </div>
</asp:Content>
