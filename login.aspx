<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
    <title></title>
    <meta name="description" content="登录页面">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/style.min.css" rel="stylesheet">
    <link href="css/login.min.css" rel="stylesheet">
    <script>
        if(window.top!==window.self){window.top.location=window.location};
    </script>
</head>
<body class="signin">
    <div class="signinpanel">
        <div class="row">
            <div class="col-sm-5">
                
            </div>
            <div class="col-sm-5">
                <form method="post" action="index.html">
                    <h4 class="no-margins">登录：</h4>
                    <p class="m-t-md">登录到资源共享平台</p>
                    <input type="text" class="form-control uname" placeholder="用户名" />
                    <input type="password" class="form-control pword m-b" placeholder="密码" />
                    <a href="default.htm">忘记密码了？</a>
                    <button class="btn btn-success btn-block">登录</button>
                </form>
            </div>
        </div>
        <div class="signup-footer">
            <div class="pull-left">
                &copy; 2019 All Rights Reserved. 资源共享平台
            </div>
        </div>
    </div>
</body>
</html>
