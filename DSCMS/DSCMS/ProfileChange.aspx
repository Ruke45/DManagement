<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileChange.aspx.cs" MasterPageFile="~/Master.Master" Inherits="DSCMS.ProfileChange" %>






  
<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
   User
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="LiteralMessage" runat="server"></asp:Literal>

                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>User Request</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-dashboard"></i>User Request
                            </li>
                        </ol>
                    </div>
                </div>

             <div class="row">
                            
                 <div class="container boxshadow">
                 <div class="col-lg-11">
                     
                         <div class="col-lg-12" style="font-family:Cambria;">
                                <h1 class="page-header">
                                    <small>User Request</small>
                                </h1>
                            </div>
                     <div class="form-horizontal" role="form" style="font-family:Cambria;">


                        <div class="form-group">
                            <label class="control-label col-sm-2" for="UserID"">User Name</label>
                            <div class="col-sm-8">
                             <asp:TextBox ID="UserID" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="PersonName">Old Password</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="OldPassword" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="Password">New Password</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="NewPassword" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                           <div class="form-group">

                            <label class="control-label col-sm-2" for="ConfirmPassword">Confirm Password</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="ConfirmPassword" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                       

                        

                        

                        

                        <div class="col-sm-6"></div>
                         <div class="col-sm-4">
                         <div class="btn pull-right">
 
                           
                            <asp:Button ID="Button1" runat="server" align="left"  Text="Change" CssClass="btn btn-primary" Width="200px" /></div></div>
                            
                       

                         

                      </div> <%--End of form-horizontal--%>
                 </div><%-- End of col-lg-11--%>
                </div>
             </div> <%--End of Row--%>

</asp:Content>


