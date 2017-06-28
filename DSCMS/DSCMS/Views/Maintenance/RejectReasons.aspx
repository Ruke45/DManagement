<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master"  CodeBehind="RejectReasons.aspx.cs" Inherits="DSCMS.Reject_Reasons" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Reject Reasons
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="col-lg-12">
                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>Maintenance</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-cogs"></i> Reject Reasons
                            </li>
                        </ol>
                    </div>
                </div>
    
        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
              <div class="panel-heading">
                <div class="row">
                  <div class="col col-xs-8"> <h5>Reject Reasons List</h5>
                
                  </div>
                    <div class="col col-xs-4 text-right">       
                      <form action="#" method="get">
                        <div >
                            <div class="col-sm-5" style="float:right">
                                <asp:Button ID="btnShow" runat="server" width="200" CssClass="btn btn-Secondary" style="display:none"  Text="Edit" />
            <asp:Button ID="btnShow2" runat="server"  CssClass="btn btn-primary" Text="Add New " />
                                <asp:Button ID="btnTdelete" runat="server" Width="200" CssClass="btn btn-Secondary" Text="Edit" style="display:none" visible="false"/>
                            
                            </div>
                        </div>
                      </form>
                
                  </div>
                  

                </div>
              </div>
              <div class="panel-body">
                          <asp:GridView ID="GridView1" BorderStyle="NotSet" runat="server" AllowPaging="True" PageSize="10" 
                              CssClass="table  table-bordered  table-hover table-list-search" OnPageIndexChanging="grdData_PageIndexChanging"
                              AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
 >
                              <Columns>
                                   <asp:BoundField HeaderText="Reject Code" DataField="Reject_Code" SortExpression="Reject_Code" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                  <asp:BoundField HeaderText="Reason Name" DataField="Reason_Name" SortExpression="Reject_Code" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                   <asp:BoundField HeaderText="Category" DataField="Category_" SortExpression="Reject_Code" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                 <asp:TemplateField HeaderText = "Edit Option"><ItemStyle Width="20%"></ItemStyle>
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1"  CssClass="btn btn-primary" runat="server" OnClick="LinkButton1_Click">Edit</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2"  CssClass="btn btn-danger" runat="server" OnClick="Delete_Click">Delete</asp:LinkButton>
                                       
                                   </ItemTemplate>
                                </asp:TemplateField>
                              </Columns>
                               <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                          </asp:GridView>

              
            </div>

</div>

	<div class="row">
        <div class="col-md-3">

        </div>
		<div class="col-md-9">
    	   
		</div>
	</div>

</div>
            </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


<!-- ModalPopupExtender -->
<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Edit Reasons</h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         <div class="form-group">
                            <label class="control-label col-sm-3" for="email">Reject Code</label>
                            <div class="col-sm-7">
                            <asp:TextBox ID="txtRejectCode" Enabled="false"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                           <div class="form-group">
                            <label class="control-label col-sm-3" for="email">Reason  Name</label>
                            <div class="col-sm-7">
                            <asp:TextBox ID="txtReasonName"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                           

                          <div class="form-group">
                            <label class="control-label col-sm-3" for="email"> Reason  Category</label>
                            <div class="col-sm-1">
                                <asp:DropDownList ID="ddeCategory" runat="server" Height="30" Width="200" AppendDataBoundItems="true"/>
                            
                            </div>
                        </div>
                         



                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="btnSubmit_Click" />
          <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" />
      </div>
    </div>
</asp:Panel>
<!-- ModalPopupExtender -->
                    <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="Panel3" TargetControlID="btnTdelete"
    CancelControlID="btnCloseD" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" Width="600" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content" >
      <div class="modal-header">
            <div class="col-xs-3 text-left" >
        Delete Reason</div>
        
      </div>
      <div class="modal-body" >
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                           

                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="Label1" Font-Size="Medium"  runat="server" Text="Are  You Sure,You Want to Delete this Record?"></asp:Label>
                         </div>
                    </div>
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="Button1" runat="server" Text="Yes" CssClass="btn btn-primary" Width="150px" OnClick="btnDelete_Click" />
          <asp:Button ID="btnCloseD" runat="server" Text="No" Width="150px" CssClass="btn btn-Secondary" />
      </div>
    </div>
</asp:Panel>


<!-- Modal --> <%-- <cc1:FilteredTextBoxExtender ID="TextBox1_FilteredTextBoxExtender" runat="server"
Enabled="True" TargetControlID="txtRejectCodeadd" FilterType="Numbers">
</cc1:FilteredTextBoxExtender>--%>

            <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="btnShow2"
    CancelControlID="Button2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Add Reject Reasons</h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                                                                                <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroradddRejectCode" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                           <div class="form-group">
                            <label class="control-label col-sm-3" for="email">ReasonName</label>
                            <div class="col-sm-7">
                            <asp:TextBox ID="txtReasonNameadd"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                                                      <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroraddReasonName" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                           
                           <div class="form-group">
                            <label class="control-label col-sm-3" for="email"> Reason  Category</label>
                            <div class="col-sm-1">
                                <asp:DropDownList ID="ddCategory" runat="server" Height="30" Width="200" AppendDataBoundItems="true"><asp:ListItem Text="--Select category--" Value="" /></asp:DropDownList>
                            
                            </div>
                        </div>
                                                    <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerrorreasoncategory" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="btnSubmitA" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="btnSubmitA_Click" />
          <asp:Button ID="Button2" runat="server" Text="Close" CssClass="btn btn-default" />
      </div>
    </div>
</asp:Panel>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
        </Triggers>

        



</asp:UpdatePanel>




</asp:Content>



