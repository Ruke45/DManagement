<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SelectTemplate.aspx.cs" Inherits="DSCMS.SelectTemplate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Select Tempalte
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        img {
     filter: gray; /* IE6-9 */
    -webkit-filter: grayscale(1); /* Google Chrome, Safari 6+ & Opera 15+ */
    -webkit-box-shadow: 0px 2px 6px 2px rgba(0,0,0,0.75);
    -moz-box-shadow: 0px 2px 6px 2px rgba(0,0,0,0.75);
     box-shadow: 0px 2px 6px 2px rgba(0,0,0,0.75);
     margin-bottom:20px;
     }

   img:hover {
    filter: none; /* IE6-9 */
    -webkit-filter: grayscale(0); /* Google Chrome, Safari 6+ & Opera 15+ */
    }
    </style>
 <div class="col-lg-12">
                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>Select Tempalte</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-dashboard"></i> Select Tempalte
                            </li>
                        </ol>
                    </div>
                </div>
    
     <div class="container boxshadow">
        <div class="col-md-10 col-md-offset-1" style="padding-top:20px; padding-bottom: 50px">
            <div class="row">
               <div class="col-md-4 col-sm-4 col-xs-6"><a  type="button" class="active" data-toggle="tab"  data-parent="#accordion" href="#temp1"><img src="img/300.png"  class="img-responsive" alt="Cinque Terre" width="304" ></a></div>
                <div class="col-md-4 col-sm-4 col-xs-6"> <a type="button" class="" data-toggle="tab" data-parent="#accordion" href="#temp2"><img src="img/300.png"  class="img-responsive" alt="Cinque Terre" width="304" height="236"></a></div>
                <div class="col-md-4 col-sm-4 col-xs-6"><a type="button" class="" data-toggle="tab" data-parent="#accordion" href="#temp3"><img src="img/300.png"  class="img-responsive" alt="Cinque Terre" width="304" height="236"></a></div>
                <div class="col-md-4 col-sm-4 col-xs-6"><a type="button" class="" data-toggle="tab" data-parent="#accordion" href="#temp3"><img src="img/300.png"  class="img-responsive" alt="Cinque Terre" width="304" height="236"></a></div>
                <div class="col-md-4 col-sm-4 col-xs-6"><a type="button" class="" data-toggle="tab" data-parent="#accordion" href="#temp3"><img src="img/300.png"  class="img-responsive" alt="Cinque Terre" width="304" height="236"></a></div>
                <div class="col-md-4 col-sm-4 col-xs-6"><a type="button" class="" data-toggle="tab" data-parent="#accordion" href="#temp3"><img src="img/300.png"  class="img-responsive" alt="Cinque Terre" width="304" height="236"></a></div>
            </div>
  <div class="tab-content">         
    <div id="temp1" class="tab-pane fade">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit,
        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
        quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
    </div>
    <div id="temp2" class="tab-pane fade">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit,
        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
        quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
    </div>
    <div id="temp3" class="tab-pane fade">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit,
        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
        quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
    </div>
   </div>      
 </div>
</div>
 </div>   

</asp:Content>
