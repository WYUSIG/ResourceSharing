<%@ Page Language="C#" AutoEventWireup="true" CodeFile="form_avatar.aspx.cs" Inherits="form_avatar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>修改头像</title>
    <link rel="shortcut icon" href="favicon.ico"> 
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/style.min.css" rel="stylesheet">
    <link href="css/resource_zh.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <form id="form1" runat="server">
    <div class="wrapper wrapper-content  animated fadeInRight article">
        <div class="row">
            <div class="col-lg-10 col-lg-offset-1">
                <div class="ibox">
                    <div class="ibox-content">
                    	<h4>修改头像</h4>
    					<div class="avatarDiv center">
    						<p class="text-center" runat="server" id="user_avator"></p>
    						<div class="avatarInput">
    							<input class="btn btn-primary btn-block" type="file" name="MyFileUploadInput" runat="server" id="avatar_input"/>
    						</div>
    						<div class="avatarInput">
    							<asp:Button runat="server" Text="上传头像" class="btn btn-danger btn-block dim" onclick="submit_click" ID="upload2"/>
    						</div>
    					</div>
    				</div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/content.min.js"></script>
    <script src="js/resource_z.js"></script>
    <script>
        $(document).ready(function(){$(".contact-box").each(function(){animationHover(this,"pulse")})});
    </script>
</body>
</html>
