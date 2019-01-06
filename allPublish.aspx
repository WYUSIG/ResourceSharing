<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allPublish.aspx.cs" Inherits="allPublish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看所有帖子</title>
     <link rel="shortcut icon" href="favicon.ico"> <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/style.min.css" rel="stylesheet">

</head>
<body class="gray-bg">  
    <form id="form1" runat="server">
    <div runat="server" id="publish_list" class="wrapper wrapper-content  animated fadeInRight blog">
        <div style="margin:20px auto;width:70%;height:30px" >                          
            <asp:TextBox ID="TextBox1" runat="server" style = " width:80%; height:44px;text-align: center;font-size:20px;"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="搜 索" 
                class="btn btn-lg btn-primary" onclick="Button1_Click"/>                         
        </div>




    </div>

    </form>
</body>
</html>
