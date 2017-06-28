<%--<!-- Version NO 12.1 -->
<!-- Request Date:2016/12/05-->
<!-- UPdate Date:2016/12/08-->
<!-- Request By:Mr.Pradeep-->
<!-- Changes:Hide 3 templateas from Customer -->
<!-- Done By:nipun Munipura-->  
    --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SelectTemplate.aspx.cs" Inherits="DSCMS.SelectTemplate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Select Tempalte
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .templateimg {
            filter: gray; /* IE6-9 */
            -webkit-filter: grayscale(1); /* Google Chrome, Safari 6+ & Opera 15+ */
            -webkit-box-shadow: 0px 2px 6px 2px rgba(0,0,0,0.75);
            -moz-box-shadow: 0px 2px 6px 2px rgba(0,0,0,0.75);
            box-shadow: 0px 2px 6px 2px rgba(0,0,0,0.75);
            margin-bottom: 20px;
        }

            .templateimg:hover {
                filter: none; /* IE6-9 */
                -webkit-filter: grayscale(0); /* Google Chrome, Safari 6+ & Opera 15+ */
            }
    </style>
    <script>
        $('a[href^="#"]').on('click', function (event) {

            var target = $(this.getAttribute('href'));

            if (target.length) {
                event.preventDefault();
                $('html, body').stop().animate({
                    scrollTop: target.offset().top
                }, 1000);
            }

        });
    </script>
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Customer</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i> Customer Template Select
                    </li>
                </ol>
            </div>
            <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
                <%--Error Msg goes here--%>
            </div>
        </div>

        <div class="col-md-10 col-md-offset-1">
            <div class="container">
             <div class="tab-content" id="detail" runat="server" >
            </div>
                </div>
            <div style="padding: 20px" class="container"></div>
            <div id="head" runat="server" style="float:left">
            </div>
             
           
            
           

        </div>
    </div>




    <div class="row">

        <div class="col-lg-12">
            <h3 class="page-header">
                <asp:Label ID="Label1" runat="server" class="text-danger" Style="font-size: 15px" Text="Label" Visible="false">Request Submitted Sucessfully</asp:Label>
            </h3>
        </div>
    </div>



</asp:Content>
