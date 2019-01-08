﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index_v1.aspx.cs" Inherits="index_v1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <title>资源库系统</title>

    <meta name="description" content="基于Bootstrap3最新版本开发的扁平化主题，采用了主流的左右两栏式布局，使用了Html5+CSS3等现代技术">

    <!--[if lt IE 9]>
    <meta http-equiv="refresh" content="0;ie.html" />
    <![endif]-->

    <link rel="shortcut icon" href="资源.png">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/style.min.css" rel="stylesheet">
    <link href="css/resource_zh.css" rel="stylesheet">
</head>
<body class="fixed-sidebar full-height-layout gray-bg" style="overflow:hidden">
    <div id="wrapper">
        <!--左侧导航开始-->
        <nav class="navbar-default navbar-static-side" role="navigation">
            <div class="nav-close"><i class="fa fa-times-circle"></i>
            </div>
            <div class="sidebar-collapse">
                <ul class="nav" id="side-menu">
                    <li class="nav-header">
                        <div class="dropdown profile-element">
                            
                            <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                               <span><img alt="image" class="img-circle" src="img/admin.png" /></span>
                               <span class="clear">
                               <span class="block m-t-xs"><strong class="font-bold" runat="server" id="user_name">11</strong></span>
                               <span class="text-muted text-xs block" runat="server" id="role">超级管理员</span>
                               </span>
                            </a>
                            <ul class="dropdown-menu animated fadeInRight m-t-xs">
                                
                                <li><a class="J_menuItem" href="GM_info.aspx">个人资料</a>
                                </li>
                                <li class="divider"></li>
                                <li><a href="登录.aspx">安全退出</a>
                                </li>
                            </ul>
                        </div>
                        <div class="logo-element">Debugs
                        </div>
                    </li>
                    <li>
                        <a class="J_menuItem" href="GM_info.aspx"><i class="fa fa-male"></i> <span class="nav-label">个人信息</span></a>
                    </li>
                    <li>
                        <a class="J_menuItem" href="all_res.aspx"><i class="fa fa-upload"></i> <span class="nav-label">所有资源</span></a>
                    </li>
                    <li>
                        <a class="J_menuItem" href="allPublish.aspx"><i class="fa fa-magnet"></i> <span class="nav-label">所有帖子</span></a>
                    </li>
                    <li>
                        <a class="J_menuItem" href="allUsers.aspx"><i class="fa fa-group"></i> <span class="nav-label">所有用户</span></a>
                    </li>
                    
                   

                    
                    
                    
                </ul>
            </div>
        </nav>
        <!--左侧导航结束-->
        <!--右侧部分开始-->
        <div id="page-wrapper" class="gray-bg dashbard-1">
            <div class="row border-bottom">
                <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
                    <div class="navbar-header"><a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i> </a>
                        <form role="search" class="navbar-form-custom" method="post" action="post_hot.aspx">
                            <div class="form-group">
                                <input type="text" placeholder="请输入您需要查找的内容 …" class="form-control" name="top-search" id="top-search">
                            </div>
                        </form>
                    </div>
                    <ul class="nav navbar-top-links navbar-right">
                        
                        
                    </ul>
                </nav>
            </div>
            <div class="row content-tabs">
                <button class="roll-nav roll-left J_tabLeft"><i class="fa fa-backward"></i>
                </button>
                <nav class="page-tabs J_menuTabs">
                    <div class="page-tabs-content">
                        <a href="javascript:;" class="active J_menuTab" data-id="index_v1.html">首页</a>
                    </div>
                </nav>
                <button class="roll-nav roll-right J_tabRight"><i class="fa fa-forward"></i>
                </button>
                <div class="btn-group roll-nav roll-right">
                    <button class="dropdown J_tabClose" data-toggle="dropdown">关闭操作<span class="caret"></span>

                    </button>
                    <ul role="menu" class="dropdown-menu dropdown-menu-right">
                        <li class="J_tabShowActive"><a>定位当前选项卡</a>
                        </li>
                        <li class="divider"></li>
                        <li class="J_tabCloseAll"><a>关闭全部选项卡</a>
                        </li>
                        <li class="J_tabCloseOther"><a>关闭其他选项卡</a>
                        </li>
                    </ul>
                </div>
                <a href="login.aspx" class="roll-nav roll-right J_tabExit"><i class="fa fa fa-sign-out"></i> 退出</a>
            </div>
            <div class="row J_mainContent" id="content-main">
                <iframe class="J_iframe" name="iframe0" width="100%" height="100%" src="welcome.aspx" frameborder="0" data-id="welcome.aspx" seamless></iframe>
            </div>
            <div class="footer">
                <div class="pull-right">&copy; 天长地久 <a href="../../default.htm" target="_blank">2班debugs团队</a>
                </div>
            </div>
        </div>
        <!--右侧部分结束-->
        
        <!--上传资源-->
        <div id="small-chat">
            
            <a class="open-small-chat">
                <i class="fa fa-file"></i>

            </a>
        </div>
    </div>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script src="js/plugins/layer/layer.min.js"></script>
    <script src="js/hplus.min.js"></script>
    <script type="text/javascript" src="js/contabs.min.js"></script>
    <!--<script src="js/plugins/pace/pace.min.js"></script> -->
</body>
</html>
