
<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TaxRegistration.aspx.cs" Inherits="DSCMS.TaxRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Tax Registration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="col-lg-12">
                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>Registration</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-dashboard"></i> Tax Registration
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
                            <th>NAI Name</th>
                            <th>Discription</th>
                            <th>Persentage</th>
                            <th>Check</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                           <td>
                            <asp:CheckBox  runat="server" Width="30" class="checkbox-primary" />
                           </td>
                        </tr>
                        <tr>
                            <td>kamal</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td><asp:CheckBox ID="CheckBox1"  runat="server" Width="30" class="checkbox-primary" /></td>
                           
                        </tr>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td><asp:CheckBox ID="CheckBox2"  runat="server" Width="30" class="checkbox-primary" /></td>
                           
                        </tr>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td><asp:CheckBox ID="CheckBox3"  runat="server" Width="30" class="checkbox-primary" /></td>
                          
                        </tr>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td><asp:CheckBox ID="CheckBox4"  runat="server" Width="30" class="checkbox-primary" /></td>
                           
                        </tr>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td><asp:CheckBox ID="CheckBox5"  runat="server" Width="30" class="checkbox-primary" /></td>
                           
                        </tr>
                        <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td><asp:CheckBox ID="CheckBox6"  runat="server" Width="30" class="checkbox-primary" /></td>
                         </tr>
                            <tr>
                            <td>Sample</td>
                            <td>Filter</td>
                            <td>12-11-2011 11:11</td>
                            <td><asp:CheckBox ID="CheckBox7"  runat="server" Width="30" class="checkbox-primary" /></td>
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