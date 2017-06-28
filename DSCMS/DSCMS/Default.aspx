<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DSCMS.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Home
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top: 50px"></div>
        <div class="container">
        <!-- Heading Row -->
        <div class="row">
            <div class="col-md-4"  ></div>
            <div class="col-md-4"  >    <%--style="padding-top:16px;"--%>        
                <a href="http://www.nce.lk/" target="_blank"><img id="Logo" runat="server" class="img-responsive img-rounded" src="../../img/NCE_Home_logo.png" alt=""/></a>
            </div>
                <div class="col-md-4"  ></div>
            </div>
            <div class="row">
            <!-- /.col-md-8 -->
            <div class="col-md-12" style="margin-top:28px; font-size:17px;">
                <%--<h2>National Chamber of Exporters</h2>--%>
                <p id="fgh" runat="server" style="text-align:center;">The NCE is the only private sector Chamber which exclusively serves Sri Lankan 
                    Exporters and is the ‘Voice of the Exporter’. Incorporated in 1994 The Chamber has 
                    a membership of over 450 export oriented companies covering all 
                    products & most services sectors, as well as service providers to exporters.</p>
                <%--<a class="btn btn-primary btn-lg" href="http://www.nce.lk/" target="_blank">Find Out More</a>--%>
            </div>
            <!-- /.col-md-4 -->
        </div>
        <!-- /.row -->
        <div style="margin-top: 20px"></div>
        <div class="row">
            <div class="col-md-10" style="padding-top:40px;">
            	<div class="well well-sm" style="background-color:#fefcff; ">
                    <h2 style="font-size:35px; padding-left:18px;">Digitally Certified Certificates of Origin Issuance System</h2>
            	</div>
            </div>
            <div class="col-md-2">
                   <img src="../../img/CerGlobe.png" style="padding-bottom:20px;" class="img-responsive img-rounded" >
            </div>
        </div>

        <!-- Content Row -->
        <div class="row">
            <div class="col-md-12">

                <%--<h6 style="padding-left:0px; color:#2196f3;"><b>Customer Registration</b></h6>--%>
                 <img src="../../img/Line.png"  class="img-responsive img-rounded" alt="Cinque Terre">
<%--                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Saepe rem nisi accusamus error velit animi non ipsa placeat. Recusandae, suscipit, soluta quibusdam accusamus a veniam quaerat eveniet eligendi dolor consectetur.</p>
                <a class="btn btn-default" href="#">More Info</a>--%>
            </div>

        </div>
        <!-- /.row -->

                    <div class="row">
            <div class="col-md-12">
            	<div class="well well-sm" style="background-color:white">
                    <h4 style="font-size:17px;">
                    The NCE is a designated Chamber by the state authorities to issue Certificates of Origin and related documents to exporters.The service is provided to both member exporters as well as non-members of the Chamber. However, members could enjoy the service at a concessionary rate. COs are issued both manually and online depending on the requirements of exporters.
            	   </h4>
                    <h4 style="font-size:17px;">
                        The NCE has introduced a fully and semi authenticated system which will issue digitally signed country of origin documents (COs), which will speed up the process and greatly reduce the time taken to manually process COs. The new procedure will also mean that the number times that an exporter has to visit the Chamber will be only once. 
                    </h4>
                   <h4 style="font-size:17px; ">The Online service is useful to those who require a number of COs at a time without delays. The service is provided;</h4>
                   <h4 style="font-size:17px;padding-left:100px;">- On a semi-automated basis where application could be made online and processed documents collected manually.</h4>
                   <h4 style="font-size:17px;padding-left:100px;">- A customized fully automated service where both submission and issue and receive of documents is online </h4>
            	</div>
                </div>
        </div>

                               <div class="row">
            <div class="col-md-12">
            	<div class="well well-sm" style="background-color:white"><h4 style="font-size:17px;">
                   Further details could be obtained from the Manager I.C.T. - <i class="fa fa-user"></i><label runat="server" id="AuthorizedName"></label>| <i class="fa fa-mobile"></i> - <label runat="server" id="PhoneNo"></label>  |<i class="fa fa-envelope"></i> -  <label runat="server" id="email"></label> 
            	                                                         </h4></div>
                </div>
        </div>

    </div>

</asp:Content>
