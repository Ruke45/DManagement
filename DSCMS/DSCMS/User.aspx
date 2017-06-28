<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master"  CodeBehind="User.aspx.cs" Inherits="DSCMS.User" %>





  
<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
   User
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
                                <i class="fa fa-dashboard"></i>User
                            </li>
                        </ol>
                    </div>
                </div>

             <div class="row">
                 <div class="container boxshadow">
                 <div class="col-lg-11">
                      <div class="col-lg-12" style="font-family:Cambria;">
                                <h1 class="page-header">
                                    <small>User Information</small>
                                </h1>
                            </div>
                     <div class="form-horizontal" role="form" style="font-family:Cambria;">


                        <div class="form-group">
                            <label class="control-label col-sm-2" for="UserID"">User ID</label>
                            <div class="col-sm-8">
                             <asp:TextBox ID="UserID" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="UserGroupID">User Group ID</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="UserGroupID" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                     
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="PersonName">Person Name</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="PersonName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="Password">Password</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="Password" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="ConfirmPassword">Confirm Password</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="ConfirmPassword" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        

                        

                        

                        

                       

                         <div class="form-group">
                           <div class="col-sm-6"></div>
                            <div class="col-sm-6">
                            <asp:Button ID="Button1" runat="server" Text="save" CssClass="btn btn-primary" Width="200px" OnClick="Button1_Click1" />
                            </div>
                        </div>

                         

                      </div> <%--End of form-horizontal--%>
                 </div><%-- End of col-lg-11--%>
             </div> <%--End of Row--%>
    </div>

</asp:Content>

