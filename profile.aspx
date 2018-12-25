<%@ Page Language="C#" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>个人资料</title>
    <meta name="description" content="个人资料页面">
    <link rel="shortcut icon" href="资源.png"> <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/style.min.css" rel="stylesheet">
    <link href="css/resourceSharing.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content">
        <div class="row animated fadeInRight">
            <div class="col-sm-4">
                <div class="ibox float-e-margins">
                    <div class="ibox-title feed-element">
                        <a href="#" class="pull-left"><img alt="image" class="img-circle" src="img/a1.jpg"></a><h5 class="profille">个人资料</h5>
                    </div>
                    <div>
                        <div class="ibox-content profile-content text-center">
                           	<img alt="image" class="img-circle" src="img/a1.jpg"><br><br>
                            <h4>姓名：<strong>Beaut-zihan</strong></h4><br><br>
                            <h4>地点：<strong>五邑大学</strong></h4><br><br>
                            <h4>个性签名：<strong>这人很懒，什么也没有留下...</strong></h4>
                            
                            <div class="row m-t-lg">
                                <div class="col-sm-4">
                                    <span class="bar">5,3,9,6,5,9,7,3,5,2</span>
                                    <h5><strong>169</strong> 上传的资源</h5>
                                </div>
                                <div class="col-sm-4">
                                    <span class="line">5,3,9,6,5,9,7,3,5,2</span>
                                    <h5><strong>28</strong> 关注的用户</h5>
                                </div>
                                <div class="col-sm-4">
                                    <span class="bar">5,3,2,-1,-3,-2,2,3,5,2</span>
                                    <h5><strong>240</strong> 粉丝</h5>
                                </div>
                            </div>
                            <br><br>
                            <div class="user-button">
                                <div class="row">
                                    <div class="col-sm-6 col-lg-12">
                                        <button type="button" class="btn btn-primary btn-sm btn-block"><i class="fa fa-heart-o"></i> 关注他</button>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-8">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>用户动态</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                <i class="fa fa-wrench"></i>
                            </a>
                            <ul class="dropdown-menu dropdown-user">
                                <li><a href="#">为空</a>
                                </li>
                               
                            </ul>
                            <a class="close-link">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">

                        <div>
                            <div class="feed-activity-list">

                                <div class="feed-element">
                                    <a href="#" class="pull-left">
                                        <img alt="image" class="img-circle" src="img/a1.jpg">
                                    </a>
                                    <div class="media-body ">
                                        <small class="pull-right text-navy">1天前</small>
                                        <strong>SIG</strong> 上传了 <strong>资源名</strong>
                                      <br>
                                        <div class="file-box">
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
												</a>
											</div>
										</div>
                                       
                                       
                                        
                                    </div>
                                    <div class="pull-left">
                                           	&nbsp;&nbsp;&nbsp;&nbsp;
                                            <a class="btn btn-xs btn-white"><i class="fa fa-thumbs-up"></i> 赞 </a>
                                            <a class="btn btn-xs btn-white"><i class="fa fa-heart"></i> 收藏</a>
                                            <a class="btn btn-xs btn-primary"><i class="fa fa-pencil"></i> 评论</a>
                                    </div>
                                </div>

                                <div class="feed-element">
                                    <a href="#" class="pull-left">
                                        <img alt="image" class="img-circle" src="img/a1.jpg">
                                    </a>
                                    <div class="media-body ">
                                        <small class="pull-right">5分钟前</small>
                                        <strong>SIG</strong> 发了一个 <strong>问题帖子</strong>.
                                        <br>
                                        <div class="well">
                                            1+1为什么等于2？
                                        </div>
                                        

                                    </div>
                                    <div class="pull-left">
                                           	&nbsp;&nbsp;&nbsp;&nbsp;
                                            <a class="btn btn-xs btn-white"><i class="fa fa-thumbs-up"></i> 赞 </a>
                                            <a class="btn btn-xs btn-white"><i class="fa fa-heart"></i> 收藏</a>
                                            <a class="btn btn-xs btn-primary"><i class="fa fa-pencil"></i> 评论</a>
                                    </div>
                                </div>
                            <button class="btn btn-primary btn-block m"><i class="fa fa-arrow-down"></i> 显示更多</button>

                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/content.min.js"></script>
    <script src="js/plugins/peity/jquery.peity.min.js"></script>
    <script src="js/demo/peity-demo.min.js"></script>
    

</body>
</html>
