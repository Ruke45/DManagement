<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="DSCMS.Views.Report.Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Transaction History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <style>
        #cal1 {
            display: none;
            position: absolute;
            background-color: white;
        }

        #cal2 {
            display: none;
            position: absolute;
            background-color: white;
        }
      
    </style>
    
    <script>
        function hid() {
            document.getElementById("divheader").style.display="block";
            window.print();
            document.getElementById("divheader").style.display = "none";
        }
   
       
    </script>
     <script type=application/javascript>document.links[0].href = "data:text/html;charset=utf-8," + encodeURIComponent('<!doctype html>' + document.documentElement.outerHTML)</script>
    <style>
          @media print {
         body * {
            visibility:hidden;
         }
          #divheader, #divheader * {
            visibility:visible;
         }
            #divheader {
                position: absolute;
                margin-top:-500px;
               
            }
         #dvContents, #dvContents * {
            visibility:visible;
         }
        
         #dvContents {
             position:absolute;
           width:740px;
           margin-top:-50px;
            top:0px;
         }
          
              
            }
         
         @page {
    size: auto;   /* auto is the initial value */
    margin: 0;  /* this affects the margin in the printer settings */
}
     }
}
html {
  background-color: #FFFFFF;
  margin: 0px; /* this affects the margin on the HTML before sending to printer */
}

    </style>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12" id="div4">
                <h1 class="page-header">
                    <small>Certificate</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i>Transaction History
                    </li>
                </ol>
            </div>
            <div class="col-md-10 col-md-offset-1">
               
                
                </div>
           
            <div class="col-md-10 col-md-offset-1">
                  <div class="form-horizontal" role="form" style="font-family: Cambria;">  
              <div class="row" id="div3">
                    <div class="group">
                    <label class="control-label col-md-2" for="email">From Date</label>

                    <div class="col-md-3">
                       
                                    <asp:TextBox  CssClass="form-control" ID="txtFromDate" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtFromDate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />
                      

                        <div class="col-ms-3" style="width: 150px">
                            <asp:RequiredFieldValidator ID="RvFromDate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>

                            <asp:Label ID="labstartdatevalidation" runat="server" Visible="false" ForeColor="Red" />
                        </div>
                    </div>

                          
                    <label class="control-label col-md-2" for="email">To Date </label>

                    <div class="col-md-3">
                       
                                    <asp:TextBox ID="txtTodate" CssClass="form-control" runat="server"></asp:TextBox>
                               
                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtTodate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />
                        <div class="col-ms-3" style="width: 150px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTodate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>


                        </div>
                    </div>
                   
               
                        </div>
</div>
                <div>

                </div>
                <div class="row" style="padding-bottom:10px" id="div2">
                     <div class="group" >
                               <label class="control-label col-md-2" runat="server" id="lblcusid" for="email" text="">Customer Name</label>
                      <div class="col-md-3">
                       
                          <div>
                                <asp:DropDownList ID="drpCustomer" CssClass="form-control" AppendDataBoundItems="true" runat="server" >
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    
                                </asp:DropDownList>
                              </div>
                          </div>

                         <div class="col-md-2"></div>
                          <div class="col-md-3" >
                              <div style="float:right">
                        <asp:Button ID="Find" runat="server"  Text="Find" CssClass="btn btn-primary" OnClick="Find_Click"  />
                             </div></div>
                      </div>
                </div>
                      </div>
              
                   
                    
          
                <div class="panel panel-default panel-table" id="div5">
                    <div class="panel-heading" id="div1">
                         <lable >Customer Sort</lable>
                            <asp:CheckBox ID="cbSorting" runat="server" AutoPostBack="true" OnCheckedChanged="Find_Click" />
                        <div class="row">
                           
                            <div class="col col-xs-3 text-right" style="float: right">
                              
                                    <div class="input-group">
                                        <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                                       <%-- <input class="form-control" id="system-search" placeholder="Search for" />
                                       --%> <span class="input-group-btn">
                                          <%--  <button type="submit" class="btn btn-default frm-btn"><i class="glyphicon glyphicon-search"></i></button>
                                       --%> </span>
                                    </div>
                             
                            </div>
                            <div class="col col-xs-2 text-right">
                            </div>

                        </div>
                    </div>

                    <div class="panel-body" >
                        <div style="padding:5px">
                      <input type="button" value="Print" id="btn1" class="btn btn-primary" style="float:right;" onclick="hid()" />
                            </div>
                        <br />
                        <div runat="server" id="content">
                           <div class="form-horizontal" role="form" style="font-family: Cambria;display:none" id="divheader">
                               <div class="row">
                                   <h3 style="flex-align:center">Certificate Issue History</h3>
                                   <div class="form-group">
                                       <table>
                                           <tr>
                                               <td style="padding: 10px">
                                                   <label>From</label></td>
                                               <td>
                                                   <asp:Label ID="lblFrom" runat="server" Text=""></asp:Label></td>
                                               <td style="padding: 10px">
                                                   <label>To</label></td>
                                               <td>
                                                   <asp:Label ID="lblTo" runat="server" Text=""></asp:Label></td>
                                               <td></td>
                                               <td style="padding: 10px">
                                                   <label>Customer</label></td>
                                               <td>
                                                   <asp:Label ID="lblcusname" runat="server" Text="Label"></asp:Label></td>
                                               </tr>
                                           </table>
                                   </div>
                               </div>
                            </div>
                        <table class="table table-bordered boxshadow" id="dvContents"  >
                            <thead>
                            <tr>
                                <th>Ref No</th>
                                 <th>NCE Member</th>
                               <%--  <th>Port Of Discharge</th>--%>
                                 <th>Invoice No</th>
                              <%--  <th>Consignee</th>--%>
                                 <th>Approved By</th>
                                <%-- <th>Paid Type</th>--%>
                                 <th>Total Value</th>
                                 <th>Customer Name</th>
                                <th>Requested Date</th>
                                 <th>Issued Date</th>
                                 <th>Supporting Document</th>
                              <%--  <th>Items</th>--%>
                               
                                 
                            </tr>
                                </thead>
                            <tbody>
                            <tr>
                                <div runat="server" id="head"></div>
                            </tr>
                                </tbody>
                        </table>
                       
                       </div>
    
                        <div class="col-md-12 text-center">
                            <%--<ul class="pagination pagination-lg pager" id="myPager"></ul>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
 </div>
</asp:Content>
