
<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Approval.aspx.cs" Inherits="DSCMS.Approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Approval
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="col-lg-12">
                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>Request Approval</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-dashboard"></i> Request Approval
                            </li>
                        </ol>
                    </div>
                </div>
    
        <div class="col-md-10 col-md-offset-1">

            <div class="panel panel-default panel-table">
              <div class="panel-heading">
                <div class="row">
                  <div class="col col-xs-7">
                    <h3 class="panel-title">Panel Heading</h3>
                
                  </div>
                    <div class="col col-xs-3 text-right">       
                      <form action="#" method="get">
                        <div class="input-group">
                            <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                            <input class="form-control" id="system-search" name="q" placeholder="Search for" required>
                            <span class="input-group-btn">
                                <button type="submit" class="btn btn-default frm-btn"><i class="glyphicon glyphicon-search"></i></button>
                            </span>
                        </div>
                      </form>
                
                  </div>
                  <div class="col col-xs-2 text-right">
                   
                  </div>

                </div>
              </div>
   
 <div class="panel-body">
                 <table class="table table-list-search" id="apporval">
                    <thead>
                        <tr>
                            <th>Expoter Name</th>
                            <th>Title</th>
                            <th>Email</th>
                            <th>Admin Name</th>
                            <th></th>
                           
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td>
                        </tr>
                        <tr>
                            <td>kamal</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button2" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td>
                        </tr>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button3" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td>
                        </tr>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button4" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td>
                        </tr>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button5" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td>
                        </tr>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button6" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td>
                        </tr>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button7" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td>
                            </tr>
                            <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button8" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td>
                                </tr>
                                <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button9" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td></tr>
                                    <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button10" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td>
                        </tr>
                                    <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td>OK</td>
                           <td>
                            <asp:Button ID="Button11" runat="server" Text="View" CssClass="btn btn-primary" Width="80px" />
                           </td>
                        </tr>
                        
                        </tr>
                        </tr>
                        
                        
                    </tbody>
                </table>
      <div class="col-md-12 text-center">
      <ul class="pagination pagination-lg pager" id="myPager"></ul>
      </div>
     </div>
  </div>
            </div>
     </div>
    
</asp:Content>
