<%@ Page Language="C#" AutoEventWireup="true"MasterPageFile="~/Master.Master" CodeBehind="UserCategory.aspx.cs" Inherits="DSCMS.UserCategory" %>





  
<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
   NCEDCOS | User
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
                                <i class="fa fa-users"></i> User Category
                            </li>
                        </ol>
                    </div>
                </div>

             <div class="row">
                            
                 <div class="container boxshadow">
                 <div class="col-lg-11">
                     <div class="col-lg-12" style="font-family:Cambria;">
                                <h1 class="page-header">
                                    <small>User Category</small>
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
                            <label class="control-label col-sm-2" for="UserGroup">User Group</label>
                            <div class="col-sm-5">
                            <asp:DropDownList ID="ddUserGroup" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        

                        

                        

                       <div class="col-lg-10">
                         <div class="form-group">
                         <div class="btn pull-right">
        
                           
                            <asp:Button ID="Button1" runat="server"  align="right" Text="submit" CssClass="btn btn-primary" Width="150px" OnClick="Button1_Click"   /> 
                            <asp:Button ID="Button2" runat="server"  Text="Cancel" CssClass="btn btn-Secondary" Width="150px" OnClick="Button2_Click" />  
                            
                        </div></div></div>

                         

                      </div> <%--End of form-horizontal--%>
                 </div><%-- End of col-lg-11--%>
             </div> <%--End of Row--%>
    </div>

</asp:Content>


