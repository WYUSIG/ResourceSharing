<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GM_info.aspx.cs" Inherits="GM_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员信息</title>
    <link rel="shortcut icon" href="favicon.ico"> 
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/style.min.css" rel="stylesheet">
    <link href="css/plugins/toastr/toastr.min.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
       <div class="col-sm-12">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                <h1>我的信息</h1>
                </div>
                <div class="ibox-content">
                <form method="get" class="form-horizontal">
                <div class="form-group" style="height:30px"> 
                 <asp:Label ID="id" runat="server" Text="ID：" style="font-size:22px"  class="col-sm-2 control-label"></asp:Label>
                </div>
                <div class="hr-line-dashed"></div>
                <div class="form-group" style="height:30px"> 
                 <asp:Label ID="name" runat="server" Text="姓名：" style="font-size:22px"  class="col-sm-2 control-label"></asp:Label>
                </div>
                <div class="hr-line-dashed"></div>
                <div class="form-group" style="height:30px"> 
                 <asp:Label ID="phone" runat="server" Text="电话：" style="font-size:22px"  class="col-sm-2 control-label"></asp:Label>
                </div>
                <div class="hr-line-dashed"></div>


                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <div class="form-group" style="height:30px"> 
                 <asp:Label ID="pw" runat="server" Text="密码：" style="font-size:22px"  class="col-sm-2 control-label"></asp:Label>
                  <asp:Button ID="Button1" runat="server" Text="显示密码" 
                        class="btn btn-primary btn-sm" style="float:right" onclick="Button1_Click"/>
                </div>

                </ContentTemplate>
                 </asp:UpdatePanel>

                <div class="hr-line-dashed"></div>
                </form>
                </div>
            </div>
       </div>
       </div>
   
    </form>
</body>
</html>
