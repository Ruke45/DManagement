<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master"  CodeBehind="CustomerRequestStatus.aspx.cs" Inherits="DSCMS.CustomerRequestStatus" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
  NCEDCOS | Request Status
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Button ID="btnShow" runat="server" width="200" CssClass="btn btn-Secondary" style="display:none"  Text="Edit" />
     <asp:Button ID="btnShow2" runat="server" width="200" CssClass="btn btn-Secondary" style="display:none"  Text="Edit" />
       <style>
        .possitions {
            float:right;
        }
    </style>
 
    <script type='text/javascript'>      //<![CDATA[
        var dow = 0;
        $(window).load(function () {
            $(document).ready(function () {
              
                $('#download').click(function () {
                    dow = 1;
                   
                    html2canvas($("#gride"), {
                        onrendered: function (canvas) {
                            
                            var imgData = canvas.toDataURL('image/png');
                            $("#imgRes").attr("src", imgData);
                            var doc = new jsPDF('p', 'mm');
                            
    
                            doc.addImage(imgData, 'PNG', 10, 10);
                                
                            doc.save('StatusRequest.pdf');

                            window.location.href = "CustomerRequestStatus.aspx";
                        }

                    });

                }); 


            });


        });//]]> 
        </script>

    <%--<script type='text/javascript'>      //<![CDATA[
        var dow = 0;
       function Download(){
                    dow = 1;
                    html2canvas($("#grid"), {
                        onrendered: function (canvas) {

                            var imgData = canvas.toDataURL('image/png');
                            $("#imgRes").attr("src", imgData);
                            var doc = new jsPDF('p', 'mm');

                            doc.addImage(imgData, 'PNG', 10, 10);
                            doc.save('CusReq.pdf');

                            window.location.href = "CustomerRequestStatus.aspx";
                        }

                    }

         //]]> 
        </script>--%>


   

    <style>
        #cal1 {
        display:none;
        position:absolute;
        background-color:white;
        }
         #cal2 {
        display:none;
        position:absolute;
        background-color:white;
        }
    </style>
<script>
    function hide() {
        document.getElementById('gridShow').style.display = "none";
        document.getElementById('grid').style.display = "block";
    }
    var val1 = 0;
    var val2 = 0;
    function showcal1() {
        if (val1 == 0) {
            document.getElementById("cal1").style.display = "block";
            val1 = 1;
        }
        else {
            document.getElementById("cal1").style.display = "none";
            val1 = 0;
        }
    }
    function showcal2() {
        if (val2 == 0) {
            document.getElementById("cal2").style.display = "block";
            val2 = 1;
        }
        else {
            document.getElementById("cal2").style.display = "none";
            val2 = 0;
        }
    }
</script>
      
    <%--<div class="col-lg-12" style="min-height: 340px">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>  Request Status</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-dashboard"></i>  Request Status
                    </li>
                </ol>
            </div>
        </div>
     
        <div class="col-md-10 col-md-offset-1">
            <div class="row">
                
                <div class="col-lg-12" >
                    
                    <div class="col-md-5" >
                        
                        <label class="control-label col-md-4" for="email">From Date</label>

                        <div class="col-md-2">
                           <table><tr><td> <asp:TextBox Enabled="true" ID="txtFromDate" runat="server"></asp:TextBox></td>
                            <td><input type="button" onclick="showcal1()" value="..."/></td>
                               </tr></table>
                            <div id="cal1" style="z-index:999">
                           <asp:Calendar ID="Calendar1"  runat="server" OnSelectionChanged="Page_Load"></asp:Calendar>
                                </div>
                            
                            <div class="col-ms-3" style="width: 150px">
                                <asp:RequiredFieldValidator ID="RvFromDate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From Date is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            
                                <asp:Label ID="labstartdatevalidation" runat="server" Visible="false" ForeColor="Red" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <label class="control-label col-md-4" for="email">To Date </label>

                        <div class="col-md-2">
                            <table><tr><td>
                             <asp:TextBox ID="txtTodate" Enabled="true" runat="server"></asp:TextBox></td>
                            <td> <input type="button" onclick="showcal2()" value="..."/>
                                </td></tr></table>
                            <div id="cal2" style="z-index:999">
                             <asp:Calendar ID="Calendar2" CssClass="as"  runat="server"  OnSelectionChanged="Page_Load"></asp:Calendar>
                            </div>
                          
                            <div class="col-ms-3" style="width: 150px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTodate" ErrorMessage="From Date is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            
                                <asp:Label ID="labdatevalidation" runat="server" Visible="false" ForeColor="Red" />
                            </div>
                        </div>
                    </div>
                </div>
              <div class="row">

                <div class="col-lg-12" >
                    <div class="col-md-5" >
                    <label class="control-label col-md-4" for="email">&nbsp &nbsp &nbsp Status &nbsp &nbsp &nbsp&nbsp &nbsp </label><div class="col-ms-1" ></div>
                    <div class="col-md-3" >
                            <asp:DropDownList ID="ddStatus"   width="220" height="30"  runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="" Value="" Selected="True" ></asp:ListItem>
                                <asp:ListItem Value="All" >All</asp:ListItem>
                               <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                  <asp:ListItem Value="Reject">Rejected</asp:ListItem>
                                 <asp:ListItem Value="Pending">Pending</asp:ListItem>
      

                            </asp:DropDownList>
                           

                       
                        </div></div>

                    <div class="col-md-5" >
                    
                     <label   class="control-label col-md-4"    >Customer</label>

                     <div class="col-md-2" >
                         
                            <asp:DropDownList ID="ddCustomer"  width="200" height="30"  runat="server" AppendDataBoundItems="true">
                                <asp:ListItem  Value="" ></asp:ListItem>
                                <asp:ListItem Value="All">All</asp:ListItem>
                                 
            
      
                            </asp:DropDownList>
                           


                        </div></div>

                </div>
                  
                   <div class="col-md-2" ></div>
                  <div class="col-md-4" >
                      
                   <asp:Label ID="lblStatus" runat="server" Visible="false" ForeColor="Red" text="Select Status to Continue"/>
                      </div> <div class="col-md-1" ></div>
                  <div class="col-md-4" >
                      
                   <asp:Label ID="lblCustomer" runat="server" Visible="false" ForeColor="Red" text="Select Customer to Continue"/>
                      </div>
                    </div>
           <br/>
              
                <div class="col-lg-12" >
                    
                    <div class="col-md-5" >
                     <label class="control-label col-md-4" for="email">Request No</label>

                      <div class="col-sm-8">
                                <asp:TextBox ID="txtRequestNo" enabled="true" name="address3" CssClass="form-control" runat="server"></asp:TextBox>
    
                            </div></div>
                </div>
            </div>
                <div class="col-lg-10" >
                    <div class="col-md-8"></div>
                       
                           <div class="col-md-2">
                          <button id="download"  visible="true" title="save pdf print attendance sheet" class="btn btn-primary btn-block" target="blank">Print</button></div>
                        <asp:Button ID="Button2" runat="server" Text="Enquiry" CssClass="btn btn-primary"   OnClick="Button1_Click"></asp:Button>
                     
                               
                  

                    </div>
                    
                </div>

            </div>--%>
      <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Certificate</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-cogs"></i> Certificate Request Status
                    </li>
                </ol>
            </div>
        </div>
     <div class="col-lg-12" style="min-height: 340px">
     
   
        <div class="col-md-10 col-md-offset-1">
             <div class="form-horizontal" role="form" style="font-family: Cambria;">
            <div class="row">
                 <div class="group" >
                       
                        <label class="control-label col-md-2" for="email">From Date</label>
                       
                        <div class="col-md-2">
                          <asp:TextBox Enabled="true" ID="txtFromDate" runat="server"   CssClass="form-control"></asp:TextBox>
                           <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtFromDate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />

                            <div class="col-md-12" style="width:250px">
                                <div>
                                    <asp:RequiredFieldValidator ID="RvFromDate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From Date is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div>
                                    <asp:Label ID="labstartdatevalidation" runat="server" Visible="false" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                   
                     
                  
                       
                        <label class="control-label col-md-2"  for="email">To Date </label>
                      
                        <div class="col-md-2">
                          
                             <asp:TextBox ID="txtTodate"  Enabled="true" runat="server"  CssClass="form-control"></asp:TextBox>
                           
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtTodate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />
                          
                            <div class="col-md-12" >
                                <div>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTodate" ErrorMessage="To Date is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div><div><asp:Label ID="labdatevalidation" runat="server" Visible="false" ForeColor="Red" />
                            </div></div>
                        </div>

                          
                        
                    <label class="control-label col-md-2" for="email">Status</label>
                    <div class="col-md-2"  >
                            <asp:DropDownList ID="ddStatus"  runat="server" AppendDataBoundItems="true"  CssClass="form-control">
                                <asp:ListItem Text="" Value="" Selected="True" ></asp:ListItem>
                                <asp:ListItem Value="All" >All</asp:ListItem>
                               <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                  <asp:ListItem Value="Reject">Rejected</asp:ListItem>
                                 <asp:ListItem Value="Pending">Pending</asp:ListItem>
      

                            </asp:DropDownList>
                           
                          <div class="col-md-12" >
                              
                              <div>
                          <asp:Label ID="lblStatus" runat="server" Visible="false" ForeColor="Red" text="Select Status to Continue"/>
                              </div>
                              </div>
                        </div>
                    </div>

                 </div>


               
              <div class="row">
                   <div class="group" >
                   
                 
                       
                     <label class="control-label col-md-2" for="email">Request No</label>
                        
                      <div class="col-md-2">
                                <asp:TextBox ID="txtRequestNo"  enabled="true"  CssClass="form-control" runat="server"></asp:TextBox>
    
                            </div>
                       

                  

                         

                        <label class="control-label col-md-2" for="email">Invoice No</label>

                        <div class="col-md-2">
                            <asp:TextBox ID="txtInvoice" Enabled="true" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                    </div>
                   
                    

                        <label class="control-label col-md-2">RequestType</label>

                        <div class="col-md-2">

                            <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="All">All</asp:ListItem>
                                <asp:ListItem Value="Emailed">Emailed</asp:ListItem>
                                <asp:ListItem Value="Normal">Normal</asp:ListItem>
                                <asp:ListItem Value="Document">Document</asp:ListItem>
                                <asp:ListItem Value="Uploaded">Uploaded</asp:ListItem>



                            </asp:DropDownList>

                            <div class="col-md-12">
                                <asp:Label ID="Label2" runat="server" Visible="false" ForeColor="Red" Text="Select a Request Type" />
                            </div>

                        </div>
                
                    </div>
              


          <br />
               
            <div class="row" >
              <div class="group" >
                 
                 <label   class="control-label col-md-2">Customer</label>
                      <div class="col-md-5">
                          <asp:DropDownList ID="ddCustomer"  runat="server" AppendDataBoundItems="true"  CssClass="form-control">
                             <asp:ListItem  Value="" ></asp:ListItem>
                             <asp:ListItem Value="All">All</asp:ListItem>
                           </asp:DropDownList>
                         
                          <div class="col-ms-3" > 
                              <asp:Label ID="lblCustomer" runat="server" Visible="false" ForeColor="Red" text="Select Customer to Continue"/>
                              </div>

                        </div> 


                       <div class="col-md-5">
             
                    <div style="float:right">
                    <asp:Button ID="btnExport" runat="server" Text="Export To PDF" CssClass="btn btn-primary" Width="110" OnClick="ExportToPDF" />


                    <%--<asp:Button id="download" runat="server"  visible="true" Text="Print" title="save pdf print attendance sheet" class="btn btn-primary btn-block"  OnClick="disable" ></asp:Button></div>--%>
                    <asp:Button ID="Button2" runat="server" Text="Enquiry" CssClass="btn btn-primary" Width="110" OnClick="Button1_Click"></asp:Button>
                    <%-- <asp:Button ID="Button3"  runat="server" Text="Endfgdg" CssClass="btn btn-primary"   Width="110" OnClick="ck"></asp:Button>--%>
                    <button id="download" style="display: none" onclick="hide();" visible="true" title="save pdf print attendance sheet" class="btn btn-primary btn-block">Download</button>
                    </div>
             
                    </div>
              </div>
                 
                </div>
       <br />

             </div>
                 
               
        <div class="row"></div>
     
            <div class="panel panel-default panel-table" id="abc">
                <div class="panel-heading" id="hd" runat="server" visible="false" >
                    <div class="row">
                         <div class="col col-xs-1"></div>
                        <div class="col col-xs-5">
                            <h3 class="panel-title">&nbsp&nbsp&nbsp&nbsp&nbsp Customer Request Status</h3>

                        </div>
                       
                       

                    </div>
                </div>
                
                <div class="panel-body" >
                    <div class="col-lg-12" style="padding-left:3%">
                    <div id="gridShow">
                       
                    <asp:GridView ID="gvCusreq" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search"
                         OnSelectedIndexChanged="gvInvoice_SelectedIndexChanged" AllowPaging="True" PageSize="10"  
                       OnPageIndexChanging="grdData_PageIndexChanging" >
                        <Columns>
                            <asp:BoundField HeaderText="Request Type"  DataField="Cerated_By" SortExpression="Request_ID" > <ItemStyle Width="120px"></ItemStyle></asp:BoundField>
                            <asp:BoundField HeaderText="Request No"  DataField="Request_ID" SortExpression="Request_ID" > <ItemStyle Width="120px"></ItemStyle></asp:BoundField>
                            <asp:BoundField HeaderText="CustomerName" DataField="User_Name" SortExpression="Request_ID" ><ItemStyle Width="110px"></ItemStyle></asp:BoundField>
                            <asp:BoundField HeaderText="Customer ID" DataField="Customer_ID" SortExpression="Request_ID" ><ItemStyle Width="110px"></ItemStyle></asp:BoundField>
                            <asp:BoundField HeaderText="Invoice No" DataField="Invoice_No" SortExpression="Request_ID" ><ItemStyle Width="120px"></ItemStyle></asp:BoundField>
                              
                            <asp:BoundField HeaderText="Status" DataField="Status_" SortExpression="Request_ID" ><ItemStyle Width="90px"></ItemStyle></asp:BoundField>
                              <asp:BoundField HeaderText="Status Date" DataField="Cerated_Date" SortExpression="Request_ID" ><ItemStyle Width="190px"></ItemStyle></asp:BoundField>
                          
                            <asp:TemplateField Visible="false" >
                                      <ItemTemplate>
                                          <asp:Label ID ="lblRequest_ID" runat="server" Text='<%#Eval("Request_ID") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>
                             <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                          <asp:Label ID ="lblRejectCode" runat="server" Text='<%#Eval("Is_Send") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>



                                         <asp:TemplateField HeaderStyle-Width="10px"  >
                                   <ItemTemplate  >
                                       <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-primary"  OnClick="btnDetails_Click" OnDataBinding="btnDelete_DataBinding" >Details</asp:LinkButton>
                                       <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary"  OnClick="btnReject_Click" visible="false" >RejectReasons</asp:LinkButton>
                                        
                                       
                                   </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                         <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>
                        </div>


                         <div id="gride" style="display:none" runat="server">
                             <div    style="height:20px;margin-left:auto;margin-right:50%; padding-bottom:20px " > 
                              <asp:Label ID="Label3"  runat="server" Visible="true"  text="Status List"/>
                              </div>
                           <div>
                               <asp:Label ID="Label4"  runat="server" Visible="true" text=" .     " />
                           </div>
                      
                    <asp:GridView ID="gvDownload" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search"
                          Width="700px">
                        <Columns>
                            <asp:BoundField HeaderText="Request Type"  DataField="Cerated_By" SortExpression="Request_ID" > <ItemStyle Width="40px"></ItemStyle></asp:BoundField>
                            <asp:BoundField HeaderText="Request No"  DataField="Request_ID" SortExpression="Request_ID" > <ItemStyle Width="40px"></ItemStyle></asp:BoundField>
                            <asp:BoundField HeaderText="CustomerName" DataField="User_Name" SortExpression="Request_ID" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                            <asp:BoundField HeaderText="Customer ID" DataField="Customer_ID" SortExpression="Request_ID" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                            <asp:BoundField HeaderText="Status" DataField="Status_" SortExpression="Request_ID" ><ItemStyle Width="40px"></ItemStyle></asp:BoundField>
                            <asp:BoundField HeaderText="Invoice No" DataField="Invoice_No" SortExpression="Request_ID" ><ItemStyle Width="40px"></ItemStyle></asp:BoundField>
                            <asp:BoundField HeaderText="Status Date" DataField="Cerated_Date" SortExpression="Request_ID" ><ItemStyle Width="90px"></ItemStyle></asp:BoundField>
                       </Columns>
                    </asp:GridView>
                        </div>
                       </div>
                    <div class="col-md-12 text-center">
                        <ul class="pagination pagination-lg pager" id="myPager"></ul>
                    </div>
                </div>
            </div>
         </div>
          </div>  
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
        
               <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="Panel3" TargetControlID="btnShow"
    CancelControlID="btnCloseD" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" Width="600" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content" >
      <div class="modal-header">
           <div class="col-xs-3 text-left" >
        Reject Reason</div></div>
      
        
      
      <div class="modal-body" >
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                           

                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="Label1" Font-Size="Medium"  runat="server" Text="Are  You Sure ?"></asp:Label>
                         </div>
                    </div>
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          
          <asp:Button ID="btnCloseD" runat="server" Text="close" Width="150px" CssClass="btn btn-Secondary"  />
      </div>
    </div>
</asp:Panel>

    <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel1" TargetControlID="btnShow2"
    CancelControlID="btnclosedoc" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" Width="600" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content" >
      <div class="modal-header">
           <div class="col-xs-3 text-left" >
        Documents</div></div>
      
        
      
      <div class="modal-body" >
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                           

                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblDocName" Font-Size="Medium"  runat="server" ></asp:Label>
                         </div>
                    </div>
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          
          <asp:Button ID="btnclosedoc" runat="server" Text="close" Width="150px" CssClass="btn btn-Secondary"  />
      </div>
    </div>
</asp:Panel>


    
</asp:Content>
