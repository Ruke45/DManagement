<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DSCMS.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Register
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>Registration</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-dashboard"></i> Registration
                            </li>
                        </ol>
                    </div>
                </div>

             <div class="row">
                           
                 <div class="container boxshadow">
                 <div class="col-lg-11">
                     <div class="form-horizontal" role="form" style="font-family:Cambria;">

                          <div class="col-lg-12" style="font-family:Cambria;">
                                <h1 class="page-header">
                                    <small>Genaral Details of the Customer</small>
                                </h1>
                            </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Customer Name</label>
                            <div class="col-sm-8">
                             <asp:TextBox ID="TextBox1" name="cus_name" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Short Name</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="TextBox2" name="short_name" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Customer Type</label>
                            <div class="col-sm-5">
                            <asp:DropDownList ID="DropDownList1" name="cus_type" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address Line 1</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="TextBox3" name="address1" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address Line 2</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="TextBox4" name="address2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address Line 3</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="TextBox5" name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Country</label>
                            <div class="col-sm-5">
                            <asp:DropDownList ID="DropDownList2" name="countery"  runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">State</label>
                            <div class="col-sm-5">
                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">City</label>
                            <div class="col-sm-5">
                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">PO Box</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Contact Person</label>
                            <div class="col-sm-1">
                            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control" Width="80px">
                                <asp:ListItem>Mr</asp:ListItem>
                                <asp:ListItem>Ms</asp:ListItem>
                                <asp:ListItem>Dr</asp:ListItem>
                                <asp:ListItem>Rev</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             <div class="col-sm-7">
                                <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">E-Mail</label>
                            <div class="col-sm-3">
                            <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                             <label class="control-label col-sm-2" for="email">Web Address</label>
                            <div class="col-sm-3">
                            <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Telephone</label>
                            <div class="col-sm-1">
                            <asp:TextBox ID="TextBox10" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-sm-2">
                            <asp:TextBox ID="TextBox12" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                             <label class="control-label col-sm-2" for="email">FAX</label>
                            <div class="col-sm-2">
                            <asp:TextBox ID="TextBox11" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">VAT Reg No</label>
                            <div class="col-sm-3">
                            <asp:TextBox ID="TextBox13" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">SVAT Reg No</label>
                            <div class="col-sm-3">
                            <asp:TextBox ID="TextBox14" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                             <label class="control-label col-sm-1" style="color: #808080;" for="email">(Optional)</label>
                        </div>


                         <div class="col-lg-12">
                                <h1 class="page-header">
                                    <small>Customer Login Details</small>
                                </h1>
                            </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">User Name</label>
                            <div class="col-sm-3">
                            <asp:TextBox ID="TextBox15" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Password</label>
                            <div class="col-sm-3">
                            <asp:TextBox ID="TextBox16" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Confirm Password</label>
                            <div class="col-sm-3">
                            <asp:TextBox ID="TextBox17" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Register</label>
                            <div class="col-sm-6">
                            <asp:Button ID="Button1" runat="server" Text="Register" CssClass="btn btn-primary" Width="200px" />
                            </div>
                        </div>

                         

                      </div> <%--End of form-horizontal--%>
                 </div><%-- End of col-lg-11--%>
                     </div>
             </div> <%--End of Row--%>

</asp:Content>
