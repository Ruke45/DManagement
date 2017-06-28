<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupportingDocumentDownload.aspx.cs" MasterPageFile="~/Master.Master" Inherits="DSCMS.Views.Maintenance.SupportingDocumentDownload" %>





<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">NCEDCOS | Download Supporting Document
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="diviframe" runat="server"   style="width:100%;margin:auto;height:90%;padding-top:5%;display:none">
         </div>
       <asp:Button ID="Btnsd" runat="server" width="200" CssClass="btn btn-Secondary" style="display:none" Text="Download" />
 <style>
        .possitions {
            float:right;
        }
    </style>

     <script>
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
      


     <script type='text/javascript'>      //<![CDATA[
         var dow = 0;
         $(window).load(function () {
             $(document).ready(function () {
                 $('#Btnsd').click(function () {
                     dow = 1;
                     html2canvas($("#a"), {
                         onrendered: function (canvas) {

                             var imgData = canvas.toDataURL('image/png');
                             $("#imgRes").attr("src", imgData);
                             var doc = new jsPDF('p', 'mm');
                             doc.addImage(imgData, 'PNG', 10, 10);
                             doc.save('TaxInvoice.pdf');

                             window.location.href = "CertifcateDownload.aspx";
                         }

                     });

                 });

             });


         });//]]> 

    </script>
     <script type='text/javascript'>
         function printTrigger() {
             //document.getElementById("diviframe").style.display="none";
             var PDF = document.getElementById("iFramePdf");
             PDF.focus();
             PDF.contentWindow.print();

         }

         function LoadOnce() {

             window.location.reload();


         }


         function setFormSubmitToFalse() {
             setTimeout(function () { _spFormOnSubmitCalled = false; }, 3000);
             window.location.reload();
             return true;
         }
</script>
   

    
        
        <div class="col-lg-12">
                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>Supporting Document</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-th-large"></i> Approved Supporting Document Download
                            </li>
                        </ol>
                    </div>
                </div>
    
        <div id="a" class="col-md-10 col-md-offset-1 ">
             <div class="form-horizontal" role="form" style="font-family: Cambria;">  

                   <div class="row">
                    <div class="group">
                    <label class="control-label col-md-2" for="email">From Date</label>

                    <div class="col-md-3">
                       
                                 <table><tr><td> <asp:TextBox Enabled="false" ID="txtFromDate" runat="server" Width="100px"  CssClass="form-control"></asp:TextBox></td>
                            <td><input type="button" onclick="showcal1()" value="..." class="form-control" /></td>
                               </tr></table>
                            <div id="cal1" style="z-index:999;display:none;position:absolute">
                           <asp:Calendar ID="Calendar2"  runat="server" OnSelectionChanged="Page_Load" Format="MM/dd/yyyy"></asp:Calendar>
                                </div>
                      
                        <div class="col-ms-3" style="width: 150px">
                              <asp:RequiredFieldValidator ID="RvFromDate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From Date is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            
                                <asp:Label ID="labstartdatevalidation" runat="server" Visible="false" ForeColor="Red" />
                        </div>
                    </div>

                          
                    <label class="control-label col-md-1" for="email">To Date </label>

                    <div class="col-md-2">
                       
                                     <table><tr><td>
                             <asp:TextBox ID="txtTodate" Width="100px" Enabled="false" runat="server"  CssClass="form-control"></asp:TextBox></td>
                            <td> <input type="button" onclick="showcal2()" value="..." class="form-control"/>
                                </td></tr></table>
                            <div id="cal2" style="z-index:999;display:none;position:absolute">
                             <asp:Calendar ID="Calendar3"   runat="server"  OnSelectionChanged="Page_Load" Format="MM/dd/yyyy"></asp:Calendar>
                            </div>
                          
                      
                      
                        <div class="col-ms-3" style="width: 100px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTodate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>

                             <asp:Label ID="labdatevalidation" runat="server" Visible="false" ForeColor="Red" />
                        </div>
                    </div>
                       
                   
               
                        </div>
</div>




             <div class="row" id="div3">
                    <div class="group">
                       
                    <label class="control-label col-md-2" for="email">Request ID</label>
                          
                    <div class="col-md-2">
                        <asp:TextBox ID="txtCertificateNo"   enabled="true"  CssClass="form-control" runat="server"></asp:TextBox>
    
                                
                      

                  
                    </div>

                      
                   <label class="control-label col-md-2" runat="server" id="lblcusid" for="email" text="">Customer Name</label>

                    <div class="col-md-5" runat="server" id="divhid">
                       <div >
                                    <asp:DropDownList ID="ddUserID"  CssClass="form-control"   runat="server" AppendDataBoundItems="true"><asp:ListItem Text="All" Value="" /></asp:DropDownList>

                           </div>
                               
                      </div>
                         <div class="col-md-1">
                         <asp:Button ID="Button4" CssClass="btn btn-primary"  runat="server"  Text="Search" OnClick="CertificateID_Click" />
                       
                    </div>
                   
               
                        </div>
</div></div>
            <br/>
             <br/> <br/>




            <div   class="panel panel-default panel-table boxshadow">
              <div class="panel-heading">
                <div class="row">
                                      <div class="col col-xs-4"> <h5>Document Download</h5>
                                           <asp:Label ID="Label1" ForeColor="Red" runat="server" Visible="false" Text="Your Download Date Expired"></asp:Label>
                
                  </div>
                     <div class="col col-xs-4 ">
                            <form action="#" method="get">
                                <div class="input-group">
                                    <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                                   
                                   
                                </div>
                            </form>

                        </div>
                    <div class="col col-xs-4 text-right">       
                     
                        <div class="input-group">
                            <asp:CheckBox id="CheckB1" 
                                  AutoPostBack="true"
                                  text="Select All"
  Enabled="true"
    Checked="false"
     TextAlign="Right"
     OnCheckedChanged="chkStatus_OnCheckedChanged"
 
     runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="btn-group">
                           
                                   <asp:Button ID="Button6" runat="server"   CssClass="btn btn-primary" Width="100"  Text="View" OnClick="View"  />
                                  <asp:Button ID="Button5" runat="server"   CssClass="btn btn-primary" Width="100"  Text="Print" OnClick="print"  />
                                  <asp:Button ID="Button1" runat="server"   CssClass="btn btn-primary" Width="100"  Text="Download" OnClick="down"  />
                                 <asp:Button ID="Button2" runat="server"   CssClass="btn btn-primary" Width="100" style="display:none"   Text="Select All  " OnClick="select"  />
                                 <asp:Button ID="Button3" runat="server"   CssClass="btn btn-primary" Width="100" style="display:none"  Text="Unselect All" OnClick="unselect"  />
                            
                           </div>
                        </div>
                  
                
                  </div>
                  

                </div>
              </div>
              <div class="panel-body">
                          <asp:GridView ID="GridView1" BorderStyle="NotSet" runat="server"    AllowPaging="true" PageSize="50"
                              CssClass="table  table-bordered  table-hover table-list-search"  OnPageIndexChanging="grdData_PageIndexChanging" DataKeyNames="Request_ID"
                              AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
 >
                              <Columns>
                                    <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                          <asp:Label ID ="lblDownload_Path" runat="server" Text='<%#Eval("Download_Path") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>

                                   
                                  <asp:BoundField HeaderText="Request Date" DataField="Request_Date" SortExpression="Request_Date" />
                                   <asp:BoundField HeaderText="Requested By" DataField="Request_By" SortExpression="Request_Date" />
                                  <asp:BoundField HeaderText="Request ID" DataField="Request_ID" SortExpression="Request_Date" />
                                
                                 <asp:BoundField HeaderText="Certificate Request Id" DataField="Certificate_RequestId" SortExpression="Request_Date" />
                                   <asp:BoundField HeaderText="Approved By" DataField="Approved_BY" SortExpression="Request_Date" />
                                   <asp:BoundField HeaderText="Date of Approved" DataField="Approved_Date" SortExpression="Request_Date" />

                                   
                                  <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                          <asp:Label ID ="lblDownload_RqID" runat="server" Text='<%#Eval("Request_ID") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>

                                   <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                          <asp:Label ID ="lblisdownloaded" runat="server" Text='<%#Eval("Is_Downloaded") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>

                                   <asp:BoundField HeaderText="Consignor" DataField="Consignor_" SortExpression="Request_Date" />
                                   <asp:BoundField HeaderText="Consignee" DataField="Consignee_" SortExpression="Request_Date" />
                                  <asp:BoundField HeaderText="InvoiceNo" DataField="User_Id" SortExpression="Request_Date" />




                                   <asp:TemplateField ><ItemStyle Width="100px"></ItemStyle>
                                   <ItemTemplate>
                                  <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" ClientIDMode="AutoID" OnClick="LinkButton1_Click"   >Download</asp:LinkButton>
                                    </ItemTemplate>
                                       </asp:TemplateField>
                                 <asp:TemplateField ><ItemStyle Width="100px"></ItemStyle>
                                   <ItemTemplate>
                                       &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                      <asp:CheckBox id="CheckBox1" 
  
    Checked="false"
     TextAlign="Right"

 
     runat="server"/>
                                       
                                   </ItemTemplate>
                                </asp:TemplateField>
                              </Columns>
                               <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                          </asp:GridView>

                   <div class="panel-footer">
               
              </div>
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
   



  

        

   
        

        






</asp:Content>





