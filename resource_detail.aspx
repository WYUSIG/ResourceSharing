<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resource_detail.aspx.cs" Inherits="resource_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   	<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>资源详情</title>
<!--    <link rel="shortcut icon" href="favicon.ico"> -->
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
                        <div class="pull-right">
                            
                            
                            日期：<button class="btn btn-white btn-xs" type="button" runat="server" id="time1">2019/1/2</button>
                        </div>
                        <div class="text-center article-title">
                            <h1 runat="server" id="title1">
                                    自行车都智能化了，你可知道它的历史？
                            </h1>
                            
                        </div>
                        <div style="text-align: center">
							<p runat="server" id="author">
								上传者：<asp:Button  runat="server" Text="关注他" class="btn btn-primary btn" /><asp:Button  runat="server" Text="收藏资源" class="btn btn-primary btn resourcemargin20" />
<!--								<a data-toggle="tab" href="#contact-1"><img alt="image" src="img/a2.jpg" class="smallhead img-circle">袁岳</a>-->
							</p>
                        	
                        </div>

                        <p runat="server" id="resourceContent">
                            在不少旁观者的眼里，智能化几乎成了一种避之唯恐不及的“瘟疫”，开始攀附上大大小小、各式各样的工具和设备，从水杯、灯泡、体重秤这样的小物件，再到冰箱、洗衣机这些生活中的庞然大物。
                        </p>
                        <p class="text-center"><img alt="image" src="Files/icon_head.png" class="resourceImage"></p>
                        <div style="text-align: center">
							<p runat="server" id="author1">
								资源下载：
							 <div class="" runat="server">
								<div class="file">
									<a href="#">
										<span class="corner"></span>

										<div class="icon">
											<i class="fa fa-file"></i>
										</div>
										<div class="file-name">
											Document_2014.doc
											<br/>
											<small>添加时间：2014-10-13</small>
										</div>
                                        <asp:Button ID="Button1" runat="server" Text="下载" class="btn btn-primary btn-block" />
									</a>
								</div>

							</div>
<!--								<a data-toggle="tab" href="#contact-1"><img alt="image" src="img/a2.jpg" class="smallhead img-circle">袁岳</a>-->
							</p>
                        	
                        </div>
                        <hr>

                        <div class="row">
                            <div class="col-lg-12" runat="server" id="commentList">

                                <h2>收藏数：</h2>
                                

                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>

    </div>
    </form>
</body>
</html>
