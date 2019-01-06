<%@ Page Language="C#" AutoEventWireup="true" CodeFile="posting.aspx.cs" Inherits="posting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>发布帖子</title>
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
                    	<div class="text-center"><h3>发布帖子</h3></div>
                    	
    					<div class="center">
    							<input type="text" placeholder="请输入帖子标题" class="form-control m-b long" runat="server" id="publish_title">
								<h5>帖子的标签：</h5>
                                
								<input type="text" placeholder="请输入帖子标签" class="form-control m-b long" runat="server" id="publish_lable">
                                <br><br>
								<textarea placeholder="请输入帖子内容" class="form-control input-lg m-b long" rows="20" runat="server" id="publish_content"></textarea>
								
								<asp:Button runat="server" Text="发布帖子" class="btn btn-primary btn-block" onclick="submit_click" ID="upload"/>

								<div class="hr-line-dashed"></div>
								
<!--
									<li><a class="lables" href="#">html</a>
									</li>
									<li><a class="lables" href="#">css</a>
									</li>
									<li><a class="lables" href="#">js</a>
									</li>
									<li><a class="lables" href="#">asp.net</a>
									</li>
-->

								</ul>
								<div class="clearfix"></div>
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
