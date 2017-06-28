<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserRequestApproval.aspx.cs" Inherits="DSCMS.UserRequestApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | User Approval
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .hid {
            display: none;
        }
    </style>
      <div id="ReasonPop" runat="server" visible="false">
        <div style="width: 100%; height: 150%; background-color: rgba(0, 0, 0, 0.81); z-index: 9999; margin-left: -15px;margin-top:-60px; position: fixed">
            <div class="col-lg-8" style="margin-left: 15%; margin-right: 15%; margin-top: 10%">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Reject Reason</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">
                          
                            <asp:TextBox ID="txtUserId" runat="server" CssClass="hid"></asp:TextBox>
                            <asp:TextBox ID="txtCustomerId" runat="server" CssClass="hid"></asp:TextBox>
                            <div class="form-group">
                                
                                <label class="control-label col-sm-2" for="email">Reject Reason</label>


                                <div class="col-sm-1">
                                    <asp:DropDownList ID="ddRejectReason" Width="400" Height="30" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select Reason--" Value="" />
                                    </asp:DropDownList>

                                </div>
                            </div>

                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="Reject_btn" />
                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" OnClick="Close_btn" />
                    </div>
                </div>
            </div>


        </div>

    </div>
    <style>
        .Displaynone {
            display: none;
        }
    </style>
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>User</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-users"></i> User Request Approval
                    </li>
                </ol>
            </div>
            <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
            <%--Error Msg goes here--%>
        </div>
            <div class="container col-lg-12" runat="server" visible="false"  id="divSendMailQue" style="font-family: Cambria;">
                
            <div  style="height:66px">
               
                
                <div style="float:right">
                <asp:Button ID="Sendmail" runat="server" Text="Send Confirmation" CssClass="btn btn-primary" OnClick="Sendmail_Click" />
                    <br /><lable>Confirmation Pending: </lable>
                    <asp:Label ID="lblEmailCount" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-10 col-md-offset-1">
            
            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">

                        <div class="col col-xs-7">
                            

                        </div>
                        <div class="col col-xs-3 text-right" style="float: right">
                            <form action="#" method="get">
                                <div class="input-group">
                                    <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                                    <input class="form-control" id="system-search" placeholder="Search for" />
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
                    <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search"
                        AllowPaging="True" PageSize="10" OnPageIndexChanging="grdData_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Request Id" DataField="UserRequestId1" SortExpression="UserRequestId1" />
                            <asp:BoundField HeaderText="User Id" DataField="UserId1" SortExpression="UserId1" />
                            <asp:BoundField HeaderText="User Name" DataField="PersonName1" SortExpression="PersonName1" />
                            <asp:BoundField HeaderText="Group" DataField="UserGroupName1" SortExpression="UserGroupName1" />
                            <asp:BoundField HeaderText="Group Id" DataField="UserGroupID1" SortExpression="UserGroupID1" />
                            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName1" SortExpression="CustomerName1" />
                            <asp:BoundField HeaderText="Customer Id" DataField="CustomerId1" SortExpression="CustomerId1" />
                            <asp:TemplateField HeaderText="Edit Option">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Approve" runat="server" CssClass="btn btn-primary" OnClick="Approve_Click">Approve</asp:LinkButton>
                                    <asp:LinkButton ID="Reject" runat="server" CssClass="btn btn-danger" OnClick="Reject_Click">Reject</asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>
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
</div>
   
</asp:Content>
