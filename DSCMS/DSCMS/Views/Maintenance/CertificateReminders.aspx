<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master"  AutoEventWireup="true" CodeBehind="CertificateReminders.aspx.cs" Inherits="DSCMS.Views.Maintenance.CertificateReminders" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Certificate Status
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
                                <i class="fa fa-cogs"></i> Certificate Status
                            </li>
                        </ol>
                    </div>
                </div>
    
        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
              <div class="panel-heading">
                <div class="row">
                  <div class="col col-xs-9"> <h5>Certificate Status List</h5>
                
                  </div>
                    <div class="col col-xs-3 text-right">       
                      <form action="#" method="get">
                        <div class="input-group">
                             <div class="col-sm-5">
                            <asp:Button ID="btnShow" CssClass="btn btn-Secondary" Width="200" runat="server" style="display:none"  Text="Edit" />
            <asp:Button ID="btnShow2" CssClass="btn btn-primary" runat="server"  Width="200" Text="Add New " />
                                  <asp:Button ID="btnTdelete" runat="server" Width="200" CssClass="btn btn-Secondary" Text="Edit" style="display:none" visible="false"/>
                            </div >
                          
                        </div>
                      </form>
                
                  </div>
                  

                </div>
              </div>
              <div class="panel-body">
                          <asp:GridView ID="GridView1" BorderStyle="NotSet" runat="server" AllowPaging="True" PageSize="10"
                              CssClass="table  table-bordered  table-hover table-list-search" OnPageIndexChanging="grdData_PageIndexChanging"
                              AutoGenerateColumns="False" 
 >
                              <Columns>
                                 <asp:BoundField HeaderText="Certificate No" DataField="Template_Id" SortExpression="Template_Id" />
                                  <asp:BoundField HeaderText="Customer Name" DataField="User_Id" SortExpression="Template_Id" />
                                  <asp:BoundField HeaderText="Issued Date" DataField="Level_Id" SortExpression="Template_Id" />
                                  
                                 <asp:TemplateField HeaderText = "Edit Option">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-primary" >View</asp:LinkButton>
                                       <asp:LinkButton ID="btnDelete" runat="server"  CssClass="btn btn-danger" >Continue Form</asp:LinkButton>
                                       
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
        <h4 class="modal-title">Edit Certificate Status</h4>
      </div>
      <div class="modal-body">
                     
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px"  />
          <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" />
      </div>
    </div>
</asp:Panel>
<!-- ModalPopupExtender -->
             <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="Panel3" TargetControlID="btnTdelete"
    CancelControlID="btnCloseD" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" Width="600" align="center"  style = "display:none">
    <!-- Modal content-->
    <div class="modal-content" >
      <div class="modal-header">
           <div class="col-xs-3 text-left" >
       Ask for Certificate Status</div>
        
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
          <asp:Button ID="Button1" runat="server" Text="Yes" CssClass="btn btn-primary" Width="150px"  />
          <asp:Button ID="btnCloseD" runat="server" Width="150px" Text="No"  CssClass="btn btn-Secondary" />
      </div>
    </div>
</asp:Panel>


<!-- Modal -->
            <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="btnShow2"
    CancelControlID="Button2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                        <asp:Panel ID="Panel2" runat="server" Width="1200" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Complete Certificate Details</h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                           <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Certificate No</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox1" ReadOnly="true" BackColor="White" CssClass="form-control" Enabled="false" runat="server" Text="CE3-Cert"></asp:TextBox>
                        </div>
                        <label class="control-label col-sm-2" for="email">CustomerName</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox2" ReadOnly="true" BackColor="White" CssClass="form-control" Enabled="false" runat="server" Text="W.D.Wanigasekara" ></asp:TextBox>
                        </div>
                    </div>
                      
                        
                          
                                                      <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroradddn" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                      <div class="container boxshadow">
            <div class="col-lg-11">
                				
                <div class="form-horizontal" role="form" style="font-family: Cambria;">

                    <div class="col-lg-12" style="font-family: Cambria;">
                        <h1 class="page-header">
                           <%-- <small>Certificate Details (Certificate Request ID : <asp:Label ID="lblRequestID" runat="server" Text=""></asp:Label>)</small>--%>
                        </h1>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Consignor / Exporter</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtExporter" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Consignee</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtConsignee" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Invoice No</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoNo" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <label class="control-label col-sm-2" for="email">Invoice Date</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoDate" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Country Of Origin</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtCountryOfOrigin" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <label class="control-label col-sm-2" for="email">Vessel</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtVessel" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Port of Loading</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPortLoading" ReadOnly="true" BackColor="White"  CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Port of Discharge</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPortDischrg" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Place of Delivery</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPlcofDelivry" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <h1 class="page-header">
                            <small>Certificate Items</small>
                        </h1>
                    </div>
                    <div class="container">
                        <div class="col-lg-11">

                            <div class="panel panel-default panel-table boxshadow">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col col-xs-7">
                                            <h3 class="panel-title">Items</h3>

                                        </div>

                                    </div>
                                </div>
                              
                                <div class="panel-footer">
                                    <div class="row">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Total Quantity</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtTotQunatity" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                  <%--  </div>
                    <div class="form-group">--%>
                        <label class="control-label col-sm-2" for="email">Total Invoice Value</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoVal" ReadOnly="true" BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    


                    
                </div>
            </div>
            <%--End of form-horizontal--%>
        </div>


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="btnSubmitA" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px"  />
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


