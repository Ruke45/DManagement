<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MessageList.aspx.cs" Inherits="DSCMS.Views.Contact.MassageList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Message
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div id="popup" runat="server" visible="false">
      
        <div style="width: 100%; height: 150%; background-color: rgba(0, 0, 0, 0.81); z-index: 9999; margin-left: -15px;margin-top:-60px; position: fixed">
            <div class="col-lg-8" style="margin-left: 15%; margin-right: 15%; margin-top: 6%">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Message</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">


                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email" >Name</label>


                                <div class="col-sm-7"> 
                                    <asp:TextBox ID="txtName" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>

                                </div>
                               
                            </div>

                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Email Address</label>


                                <div class="col-sm-7">
                                   <asp:TextBox ID="txtEmail" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>

                                </div>
                                
                            </div>

                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Phone Number</label>


                                <div class="col-sm-7">
                                   
                                    <asp:TextBox ID="txtPhone" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                
                            </div>

                            

                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Details</label>


                                <div class="col-sm-7">
                                    <textarea id="TextArea1" disabled class="form-control col-md-6" runat="server"  cols="20" rows="10"></textarea>

                                </div>
                                
                            </div>

                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" />
                   </div>
                </div>
            </div>


        </div>

   

   </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      
    <div class="col-lg-12" style="min-height: 500px">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Message</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i>Certificate Verification Message
                    </li>
                </ol>
            </div>
            
        </div>
     
        <div class="col-md-10 col-md-offset-1">
          
    <div class="row">
                    <div class="group">
                    <label class="control-label col-md-2" for="email">From Date</label>

                    <div class="col-md-3">
                       
                                    <asp:TextBox  CssClass="form-control" ID="txtFromDate" runat="server"></asp:TextBox>
                                     <cc1:CalendarExtender ID="CalendarExtender3" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy"
                                PopupButtonID="Image1" />
                      
                        <div class="col-ms-3" style="width: 150px">
                            <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div><div>
                             <asp:Label ID="labstartdatevalidation" runat="server" Visible="false" ForeColor="Red" Font-Size="Small" />
                                    </div>
                        </div>
                    </div>

                          
                    <label class="control-label col-md-2" for="email">To Date </label>

                    <div class="col-md-3">
                       
                                    <asp:TextBox ID="txtTodate"  CssClass="form-control" runat="server"></asp:TextBox>
                                  <cc1:CalendarExtender ID="CalendarExtender4" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtTodate"
                                Format="dd/MM/yyyy"
                                PopupButtonID="Image1" />
                      
                      
                        <div class="col-ms-3" style="width: 150px">
                            <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTodate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>
                                <div>
                                <asp:Label ID="labdatevalidation" runat="server" Visible="false" Font-Size="Small" ForeColor="Red" />
                                    </div>

                        </div>
                     
                    </div>
                   <div class="col-md-20">
                        
                
                   </div>
                      
                        </div>

        </div>

              <div class="row">
                     <div class="group" >
                                <label class="control-label col-md-2" for="email">Status</label>
                      <div class="col-md-3">
                               <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                             <asp:ListItem Text="All" Value="All" />
                            <asp:ListItem Text="New" Value="N" />
                            <asp:ListItem Text="Old" Value="Y" />
                        </asp:DropDownList>
                          </div>
                        
                       
                          <div class="col-md-5" >
                              <div style="float:right">
                        <asp:Button ID="Find" runat="server" Text="Find" CssClass="btn btn-primary" OnClick="Find_Click"  />
                             </div></div>
                      </div>
                </div>
            
              
                
            <div style="height: 20px"></div>
            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-7">
                            <h3 class="panel-title"></h3>

                        </div>
                        <div class="col col-xs-5 text-right" style="float: right">
                         
                        </div>
                       
                    
                </div>
</div>
                <div class="panel-body" id="grid">
                    <asp:GridView ID="gvmassage" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search" OnSelectedIndexChanged="gvmassage_SelectedIndexChanged"
                        AllowPaging="True" PageSize="10"  OnPageIndexChanging="grdData_PageIndexChanging" >
                        <Columns>
                            
                            <asp:BoundField HeaderText="Name" DataField="Name1" SortExpression="Name1" />
                            <asp:BoundField HeaderText="Email Address" DataField="Email1" SortExpression="Email1" />
                             <asp:BoundField HeaderText="Contact No" DataField="Phone1" SortExpression="Phone1" />
                              <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                          <asp:Label ID ="detail" runat="server" Visible="false" Text='<%#Eval("Detail1") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                          <asp:Label ID ="Seq" runat="server" Visible="false" Text='<%#Eval("SeqId1") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>
                            <asp:BoundField HeaderText="Date" DataField="CreatedDate1" SortExpression="CreatedDate1" />
                             <asp:BoundField HeaderText="Status" DataField="Status1" SortExpression="Status1" />
                            <asp:ButtonField CommandName="select" ControlStyle-CssClass="btn btn-info btn-sm" HeaderText="View Details" Text="View"></asp:ButtonField>
                        </Columns>
                         <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>
                    <div class="col-md-12 text-center">
                        <ul class="pagination pagination-lg pager" id="myPager"></ul>
                    </div>
                </div>
            </div>
        </div>
    
      </div>
</asp:Content>
