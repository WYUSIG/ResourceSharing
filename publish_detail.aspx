<%@ Page Language="C#" AutoEventWireup="true" CodeFile="publish_detail.aspx.cs" Inherits="publish_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <title>帖子详情</title>

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
                            
                            <button class="btn btn-primary btn-xs" type="button" runat="server" id="lable1">乐视超级自行车</button>
                            <button class="btn btn-white btn-xs" type="button" runat="server" id="time1">2019/1/2</button>
                        </div>
                        <div class="text-center article-title">
                            <h1 runat="server" id="title1">
                                    自行车都智能化了，你可知道它的历史？
                            </h1>
                            
                        </div>
                        <div style="text-align: center">
							<p runat="server" id="author">
								作者：
<!--								<a data-toggle="tab" href="#contact-1"><img alt="image" src="img/a2.jpg" class="smallhead img-circle">袁岳</a>-->
							</p>
                        	
                        </div>

                        <p runat="server" id="publishContent">
                            在不少旁观者的眼里，智能化几乎成了一种避之唯恐不及的“瘟疫”，开始攀附上大大小小、各式各样的工具和设备，从水杯、灯泡、体重秤这样的小物件，再到冰箱、洗衣机这些生活中的庞然大物。
                        </p>
                        
                        <hr>

                        <div class="row">
                            <div class="col-lg-12" runat="server" id="commentList">

                                <h2>评论：</h2>
                                
<!--
                                <div class="social-feed-box">
                                    <div class="social-avatar">
                                        <a href="#" class="pull-left">
                                            <img alt="image" src="img/a1.jpg">
                                        </a>
                                        <div class="media-body">
                                            <a href="#">
                                              逆光狂胜蔡舞娘
                                            </a>
                                            <i></i><i></i>
                                            <button class="btn btn-info btn-xs" type="button">老师</button>&nbsp;<button class="btn btn-danger btn-xs" type="button">优</button>
                                            <small class="text-muted">17 小时前</small>
                                            <asp:Button ID="Button1" runat="server" Text="评论置优" class="btn btn-success btn pull-right"/>
                                        </div>
                                    </div>
                                    <div class="social-body">
                                        <p>
                                            好东西，我朝淘宝准备跟进，1折开卖
                                        </p>
                                        
                                    </div>
                                </div>
                                
-->
								<div class="social-feed-box">
                                    <div class="input-group">
										<textarea type="text" placeholder="输入评论内容" class="input form-control" runat="server" id="comment_content"></textarea>
										<span class="input-group-btn">
                                            <asp:Button  class="btn btn-lg btn-primary" runat="server" Text="评论" onclick="comment_click"/>
											
										</span>
									</div>
									
<!--								
                                    <div class="media-body">
                                        <textarea class="form-control long" placeholder="填写评论..."></textarea>
                                        <button class="form-control btn btn-primary btn-block" type="button">确定</button>
                                    </div>
-->
                                </div>
								<div runat="server" id="createComment"></div>
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
</body>
</html>
