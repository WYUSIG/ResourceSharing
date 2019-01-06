<%@ Page Language="C#" AutoEventWireup="true" CodeFile="subscribe.aspx.cs" Inherits="subscribe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>我的关注</title>
    <link rel="shortcut icon" href="favicon.ico"> <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/style.min.css" rel="stylesheet">
    <link href="css/resource_zh.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <form id="form1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row" runat="server" id="userList">
<!--
            <div class="col-sm-4">
                <div class="contact-box">
                    <a href="profile.aspx">
                        <div class="col-sm-4">
                            <div class="text-center">
                                <img alt="image" class="img-circle m-t-xs img-responsive" src="img/a2.jpg">
                                
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <h3><strong>钟显东</strong></h3>
                            
                            <div>
                            	<p><i class="fa fa-map-marker">学校：五邑大学</i></p>
                            	<p><i class="fa fa-map-marker">身份：学生</i></p>
                            	<p><i class="fa fa-map-marker">宣言：努力的黑寡妇</i></p>
                  
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </a>
                </div>
            </div>
-->
            
            
            
        </div>
    </div>
    </form>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/content.min.js"></script>
    <script>
        $(document).ready(function(){$(".contact-box").each(function(){animationHover(this,"pulse")})});
    </script>
</body>
</html>
