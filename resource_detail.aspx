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
                            
                            <button class="btn btn-success btn-xs" type="button" runat="server" >高级资源</button>
                            <button class="btn btn-white btn-xs" type="button" runat="server" id="time1">2019/1/2</button>
                        </div>
                        <div class="text-center article-title">
                            <h1 runat="server" id="title1">
                                    自行车都智能化了，你可知道它的历史？
                            </h1>
                            
                        </div>
                        <div style="text-align: center">
							<p runat="server" id="author">
								上传者：<asp:Button  runat="server" Text="关注他" class="btn btn-primary btn" onclick="fllow_click"/><asp:Button  runat="server" Text="收藏资源" class="btn btn-primary btn resourcemargin20" onclick="collect_click"/>
<!--								<a data-toggle="tab" href="#contact-1"><img alt="image" src="img/a2.jpg" class="smallhead img-circle">袁岳</a>-->
							</p>
                        	
                        </div>

                        <p runat="server" id="resourceContent">
                            在不少旁观者的眼里，智能化几乎成了一种避之唯恐不及的“瘟疫”，开始攀附上大大小小、各式各样的工具和设备，从水杯、灯泡、体重秤这样的小物件，再到冰箱、洗衣机这些生活中的庞然大物。
                        </p>
                        <p class="text-center" runat="server" id="resourceImage"><img alt="image" src="Files/icon_head.png" class="resourceImage"></p>
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
                                <div class="clearfix"></div>
                                <div class="clearfix"></div>
                                <div runat="server" id="admint">
                                <h4>管理员选项：</h4>
                                <div class="col-sm-6">
                                	<h5 class="tag-title">修改标签</h5>
                                	<input type="text" placeholder="未选择标签" class="form-control m-b" runat="server" id="lable">
									<ul class="tag-list" style="padding: 0" id="lable_ul" runat="server">
	
										<li><a class="lables" href="#">html</a>
										</li>
										<li><a class="lables" href="#">css</a>
										</li>
										<li><a class="lables" href="#">js</a>
										</li>
										<li><a class="lables" href="#">asp.net</a>
										</li>
	

									</ul>
                             		<div class="clearfix"></div>
                              		<asp:Button  runat="server" Text="确定修改" class="btn btn-danger btn-block" onclick="alter_click"/>
                               		<div class="clearfix"></div>
                                </div>
                                <div class="col-sm-6">
                                	<h5 class="tag-title">修改资源等级</h5>
                                	<input type="text"  class="form-control m-b" runat="server">
                                	<h5 class="tag-title">删除资源</h5>
                                	<asp:Button ID="Button2" runat="server" Text="删除资源" class="btn btn-danger btn-block" onclick="delete_click"/>
                                	<div class="clearfix"></div>
                                </div>
								
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
    <script src="js/plugins/toastr/toastr.min.js"></script>
    <script src="js/resource_z.js"></script>
</body>
</html>
