<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sub_allres.aspx.cs" Inherits="sub_allres" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>关注人的资源</title>
    <meta charset="utf-8">
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="shortcut icon" href="favicon.ico"> 
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/style.min.css" rel="stylesheet">
    <link href="css/plugins/toastr/toastr.min.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <form id="form1" runat="server">
    <div style="width:100%;height:48px;background-color:#ffffff;margin-bottom:20px">
       <a href="sub_allres.aspx">
       <div style="float:left;width:10%;height:100%;background-color:#1AB394;color:#ffffff;font-size:17px; text-align: center;">
       <div style="height:10px">&nbsp</div>
           <asp:Label ID="Label1" runat="server" Text="关注人的资源" style="background-color:#1AB394;color:#ffffff;"></asp:Label>
       </div>
       </a>
        <div style="float:right;margin-top:11px">
            <asp:TextBox ID="TextBox1" runat="server" style="height:28px;width:300px;font-size:15px;"></asp:TextBox>
            <asp:Button ID="Button1"  runat="server" Text="搜 索" 
                class="btn btn-sm btn-primary" onclick="Button1_Click" />
        </div>
    </div>
    <div class="row" style="margin-left:10px">
	    <div class="col-sm-13" id="fileList" runat="server" >
        
        </div>
    </div>
    </form>

   <script src="js/jquery.min.js"></script>        
    <script src="js/content.min.js"></script>
    <script src="js/plugins/toastr/toastr.min.js"></script>
    <script src="js/resource_z.js"></script>
    <script>
        $(document).ready(function () { $(".file-box").each(function () { animationHover(this, "pulse") }) });
    </script>
</body>
</html>
