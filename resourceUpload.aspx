<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resourceUpload.aspx.cs" Inherits="resourceUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <title>资源上传</title>
    <link rel="shortcut icon" href="favicon.ico"> 
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/style.min.css" rel="stylesheet">
    <link href="css/plugins/toastr/toastr.min.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <form id="form1" runat="server">
    <div>
    	<div class="wrapper wrapper-content">
			<div class="row">
				<div class="col-sm-3">
					<div class="ibox float-e-margins">
						<div class="ibox-content">
							<div class="file-manager">
								<input type="text" placeholder="请输入资源名称" class="form-control m-b" runat="server" id="resourceName">
								<h5>资源的标签：</h5>
                                
								<input type="text" placeholder="未选择标签" class="form-control m-b" runat="server" id="lable">
                                <br><br>
								<textarea placeholder="请输入资源描述" class="form-control input-lg m-b" rows="10" runat="server" id="descn1"></textarea>
								<h5>运行效果：</h5><input class="btn btn-primary btn-block" type="file" name="MyFileUploadInput[]" runat="server" id="Image"/><br><br>
								<h5>资源文件：</h5><input class="btn btn-primary btn-block" type="file" name="MyFileUploadInput[]" runat="server" id="resource"/><br><br>
								<asp:Button runat="server" Text="上传资源" class="btn btn-primary btn-block" onclick="upload_click" ID="upload"/>

								<div class="hr-line-dashed"></div>
								<h5 class="tag-title">请选择标签</h5>
								<ul class="tag-list" style="padding: 0" id="lable_ul" runat="server">
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
				<div class="col-sm-9 animated fadeInRight">
				   <h5>我上传过的资源：</h5>
					<div class="row">
						<div class="col-sm-12" id="fileList" runat="server">
<!--
							<div class="file-box" runat="server">
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
-->
<!--
							<div class="file-box" runat="server" onclick="downloadFile1">
								<div class="file">
									<a href="#">
										<span class="corner"></span>

										<div class="image">
											<img alt="image" class="img-responsive" src="img/p1.jpg">
										</div>
										<div class="file-name">
											Italy street.jpg
											<br/>
											<small>添加时间：2014-10-13</small>
										</div>
									</a>

								</div>
							</div>
-->


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
    <script>
        $(document).ready(function(){$(".file-box").each(function(){animationHover(this,"pulse")})});
    </script>
    
</body>
</html>
