﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRequestApproval.aspx.cs" Inherits="DSCMS.UserRequestApproval" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>USer Request Approval</title>
    <link href="Styles/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.8.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>   
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
            <asp:ScriptManager runat="server" ID="ScriptManager1" />
            <h3 style="text-align: center;"> User Request </h3>
           
            <!-- Placing GridView in UpdatePanel-->
            <asp:UpdatePanel ID="upCrudGrid" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server"  Width="940px" HorizontalAlign="Center"
                        OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" AllowPaging="True"
                        DataKeyNames="Code" CssClass="table table-hover table-striped" DataSourceID="LinqDataSource2">
                        <Columns>
                            <asp:BoundField DataField="UserID" HeaderText="User ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="UserGroup" HeaderText="User Group" />

                             <asp:ButtonField CommandName="detail" ControlStyle-CssClass="btn btn-info"
                                ButtonType="Button" Text="Detail" HeaderText="Detailed View">
                                <ControlStyle CssClass="btn btn-info"></ControlStyle>
                            </asp:ButtonField>
                            <asp:ButtonField CommandName="editRecord" ControlStyle-CssClass="btn btn-info"
                                ButtonType="Button" Text="Edit" HeaderText="Edit Record">
                                <ControlStyle CssClass="btn btn-info"></ControlStyle>
                            </asp:ButtonField>
                            <asp:ButtonField CommandName="deleteRecord" ControlStyle-CssClass="btn btn-info"
                                ButtonType="Button" Text="Delete" HeaderText="Delete Record">
                                <ControlStyle CssClass="btn btn-info"></ControlStyle>
                            </asp:ButtonField>
                            
                        </Columns>
                    </asp:GridView>
                   
                    <asp:Button ID="btnAdd" runat="server"  Text="Add New Record" CssClass="btn btn-info" OnClick="btnAdd_Click" />
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
            <!-- Detail Modal Starts here-->
          


                    </div>
    </form>
</body>
</html>
