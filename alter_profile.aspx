<%@ Page Language="C#" AutoEventWireup="true" CodeFile="alter_profile.aspx.cs" Inherits="alter_profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>修改个人资料</title>
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
    <div class="wrapper wrapper-content  animated fadeInRight article">
        <div class="row">
            <div class="col-lg-10 col-lg-offset-1">
                <div class="ibox">
                    <div class="ibox-content">
                    	<div class="text-center"><h3>修改个人信息</h3></div>
    					<div class="avatarDiv center">
    						<h4>修改头像</h4>
    						<p class="text-center" runat="server" id="avator_p"></p>
    						<div class="avatarInput">
    							<input class="btn btn-primary btn-block" type="file" name="MyFileUploadInput" runat="server" id="avatar_input"/>
    						</div>
    						
    					</div>
    					<div>
    						<h4>其他信息</h4>
    						
    						<p class="text-center avatarInput1">姓名：<input type="text" runat="server" id="name"/></p>
    						
    						<p class="text-center avatarInput1">性别：
    							<label class="radio-inline">
								  <input type="radio" checked="" value="option1" id="optionsRadios1" name="optionsRadios" runat="server" />
								  男</label>
								<label class="radio-inline">
								  <input type="radio" value="option2" id="optionsRadios2" name="optionsRadios" runat="server"/>
								  女</label>
    						</p>
    						
    						
    						<p class="text-center avatarInput1">电话：<input type="text" runat="server" id="phone"/></p>
    						<p class="text-center avatarInput1">密码：<input type="text" runat="server" id="user_password"/></p>
    						<p class="text-center avatarInput1">学校：<input type="text" runat="server" id="school"/></p>
    						<div runat="server" id="studentList"></div>
    						<p class="text-center avatarInput1" runat="server" id="class_flag">班级：<input type="text" runat="server" id="user_class"/></p>
    						<p class="text-center avatarInput1" runat="server" id="teacher_flag">老师：<input type="text" runat="server" id="teacher"/></p>
    						
    						<p class="text-center marginTop30">生日：<input class="laydate-icon form-control layer-date" runat="server" id="birthday"/></p>
    						<textarea placeholder="请输入宣言" rows="5" runat="server" class="avatarInput" runat="server" id="sig"></textarea>
    						
                            <div class="avatarInput">
    							<asp:Button runat="server" Text="修改个人信息" class="btn btn-danger btn-block dim" onclick="submit_click" ID="upload"/>
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
    <script src="js/plugins/layer/laydate/laydate.js"></script>
    <script src="js/resource_z.js"></script>
    <script>
        laydate({elem:"#birthday",event:"focus"});var start={elem:"#start",format:"YYYY/MM/DD hh:mm:ss",min:laydate.now(),max:"2099-06-16 23:59:59",istime:true,istoday:false,choose:function(datas){end.min=datas;end.start=datas}};var end={elem:"#end",format:"YYYY/MM/DD hh:mm:ss",min:laydate.now(),max:"2099-06-16 23:59:59",istime:true,istoday:false,choose:function(datas){start.max=datas}};laydate(start);laydate(end);
    </script>

</body>
</html>
