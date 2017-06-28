<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="PackageType.aspx.cs" MasterPageFile="~/Master.Master" Inherits="DSCMS.PackageType" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Package Type
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
                                <i class="fa fa-cogs"></i> Package Type
                            </li>
                        </ol>
                    </div>
                </div>
    
        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
              <div class="panel-heading">
                <div class="row">
                                      <div class="col col-xs-8"><h5>Package Type List </h5>
                
                  </div>
                    <div class="col col-xs-4 text-right">       
                      <form action="#" method="get">
                        <div >
                            <div class="col-sm-5" style="float:right">
                            <asp:Button ID="btnShow" runat="server" Width="200" CssClass="btn btn-Secondary" Text="Edit" style="display:none" visible="false"/>
                                <asp:Button ID="btnTdelete" runat="server" Width="200" CssClass="btn btn-Secondary" Text="Edit" style="display:none" visible="false"/>
            <asp:Button ID="btnShow2" CssClass="btn btn-primary"  runat="server" Text="Add New" />
                            
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
                                 <asp:BoundField HeaderText="Package Type" DataField="Package_Type" SortExpression="Package_Type" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                  <asp:BoundField HeaderText="Package Description" DataField="Package_Description" SortExpression="Package_Type" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                   
                                 <asp:TemplateField HeaderText = "Edit Option"><ItemStyle Width="100px"></ItemStyle>
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary"  OnClick="LinkButton1_Click">Edit</asp:LinkButton>
                                        <asp:LinkButton ID="LinkDelete" runat="server" CssClass="btn btn-danger"  OnClick="Delete_Click">Delete</asp:LinkButton>
                                       
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
 <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>


<!-- ModalPopupExtender -->

<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Edit Package Type</h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Package Type</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="txtPackageID"  name="address3" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                        </div>




                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Description</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="txtPackageDescription"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
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
          <asp:Button ID="btnClose" runat="server" Text="Close"  CssClass="btn btn-Secondary" OnClick="btnClose_Click" />
      </div>
    </div>
</asp:Panel>
            <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="Panel3" TargetControlID="btnTdelete"
    CancelControlID="btnCloseD" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" Width="600" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content" >
      <div class="modal-header">
           <div class="col-xs-3 text-left" >
        Delete Package</div></div>
      
        
      
      <div class="modal-body" >
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                           

                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="Label1" Font-Size="Medium"  runat="server" Text="Are  You Sure ,You Want to Delete this Record?"></asp:Label>
                         </div>
                    </div>
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="Button1" runat="server" Text="Yes" CssClass="btn btn-primary" Width="150px" OnClick="btnDelete_Click" />
          <asp:Button ID="btnCloseD" runat="server" Text="No" Width="150px" CssClass="btn btn-Secondary" OnClick="btnClose_Click" />
      </div>
    </div>
</asp:Panel>

<!-- ModalPopupExtender -->

<!-- Modal -->
            <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="btnShow2"
    CancelControlID="Button2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Add Package Type</h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                                                                                <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroradddid" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Description</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="txtPackageDescriptionAdd"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                                                      <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroradddn" ForeColor="Red" runat="server" Text=""></asp:Label>
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


