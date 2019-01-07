<%@ Page Language="C#" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>个人资料</title>
    <meta name="description" content="个人资料页面">
    <link rel="shortcut icon" href="资源.png"> 
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/style.min.css" rel="stylesheet">
    <link href="css/resourceSharing.css" rel="stylesheet">
    <link href="css/resource_zh.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <form id="form1" runat="server">
    <div>
    	<div class="wrapper wrapper-content">
			<div class="row animated fadeInRight">
				<div class="col-sm-4">
					<div class="ibox float-e-margins">
						<div class="ibox-title feed-element">
							<a href="#" class="pull-left" runat="server" id="smallavatar"></a><h5 class="profille">个人资料</h5>
						</div>
						<div>
							<div class="ibox-content profile-content text-center" >
                                
                                <div runat="server" id="div111"></div>
								<br><br> 
								<h4>姓名：<strong runat="server" id="name"></strong></h4><br><br>
								<h4>性别：<strong runat="server" id="sex"></strong></h4><br><br>
								<h4>电话：<strong runat="server" id="phone"></strong></h4><br><br>
                                <h4>学校：<strong runat="server" id="school"></strong></h4><br><br>
								<h4>班级：<strong runat="server" id="student_class"></strong></h4><br><br>
                                <h4>生日：<strong runat="server" id="birthday"></strong></h4><br><br>
								<h4>个性签名：<strong runat="server" id="sig">这人很懒，什么也没有留下...</strong></h4>

								<div class="row m-t-lg">
									<div class="col-sm-4">
<!--										<span class="bar">5,3,9,6,5,9,7,3,5,2</span>-->
										<i class="fa fa-file fa-2x"></i>
										<h5><strong runat="server" id="resourceCount"></strong> 上传的资源</h5>
									</div>
									<div class="col-sm-4">
<!--										<span class="line">5,3,9,6,5,9,7,3,5,2</span>-->
										<i class="fa fa-heart fa-2x"></i>
										<h5><strong runat="server" id="concernCount"></strong> 关注的用户</h5>
									</div>
									<div class="col-sm-4">
<!--										<span class="bar">5,3,2,-1,-3,-2,2,3,5,2</span>-->
										<i class="fa fa-tree fa-2x"></i>
										<h5><strong runat="server" id="concernedCount"></strong> 粉丝</h5>
									</div>
								</div>
								<br><br>
								<div class="user-button">
									<div class="row">
										<div class="col-sm-6 col-lg-12" runat="server" id="buttonList">
                                            
											
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
								<div class="feed-activity-list" runat="server" id="publish_list">
									
<!--
									<div class="ibox">
										<div class="ibox-content">
											<a href="#" class="pull-left">
												<img alt="image" class="img-circle smallhead" src="img/a1.jpg">
											</a>
											<a href="article.html" class="btn-link">
												<h2>
													21世纪数学难题
												</h2>
											</a>
											<div class="small m-b-xs">
												<strong>钟显东</strong> <span class="text-muted"><i class="fa fa-clock-o"></i> 3 小时前</span>
											</div>
											<p>
												1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?1+1为什么等于2?
											</p>
											<div class="row">
												<div class="col-md-6">
													<h5>标签：</h5>
													<button class="btn btn-primary btn-xs" type="button">数学</button>
													
												</div>
												<div class="col-md-6">
													<div class="small text-right">
														<h5>状态：</h5>
														<div> <i class="fa fa-comments-o"> </i> 56 评论 </div>
														<div> <i class="fa fa-paw"> </i> 144 回复</div>
													</div>
												</div>
											</div>
										</div>
									</div>
-->
									
									
									
<!--								<button class="btn btn-primary btn-block m"><i class="fa fa-arrow-down"></i> 显示更多</button>-->

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
    <script src="js/plugins/peity/jquery.peity.min.js"></script>
    <script src="js/demo/peity-demo.min.js"></script>
    

</body>
</html>
