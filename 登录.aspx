<%@ Page Language="C#" AutoEventWireup="true" CodeFile="登录.aspx.cs" Inherits="登录" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 50%;
            height: 336px;
        }
        .style2
        {
            width: 488px;
        }
        .style4
        {
            color: #FFFFFF;
            text-align: right;
        }
        .style5
        {
            color: #FFFFFF;
            text-align: right;
            font-size: large;
        }
        .style6
        {
            color: #FFFFFF;
            font-weight: 700;
            font-size: x-large;
        }
        .style8
        {
            text-align: center;
        }
        .style9
        {
            color: #FFFFFF;
            font-size: large;
        }
        .style10
        {
            text-align: center;
            color: #FFFFFF;
            font-size: xx-large;
            font-family: 华文新魏;
        }
    </style>
</head>
<body style = "background-image:url('img/dl.jpg');">
    <form id="form1" runat="server">
    <div class="style10">
    
        <strong><em>欢迎您的到来</em></strong></div>
    <table align="center" class="style1">
        <tr>
            <td class="style5">
                <strong style="font-family: 隶书; font-size: x-large">账号：</strong></td>
            <td class="style2">
                <asp:TextBox ID="account" runat="server" Font-Size="Larger" Height="30px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                     ErrorMessage="RequiredFieldValidator" ControlToValidate="account" 
                     ForeColor="Red">*账号不能为空</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <strong style="font-family: 隶书; font-size: x-large">密码：</strong></td>
            <td class="style2">
                <asp:TextBox ID="PW" runat="server" TextMode="Password" Font-Size="Larger" 
                    Height="30px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                     ErrorMessage="RequiredFieldValidator" ControlToValidate="PW" 
                     ForeColor="Red">*密码不能为空</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <strong style="font-size: x-large; font-family: 隶书">身份：</strong></td>
            <td class="style2">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" Font-Size="Larger" Height="39px">
                    <asp:ListItem>管理员</asp:ListItem>
                    <asp:ListItem>教师</asp:ListItem>
                    <asp:ListItem>学生</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                     ErrorMessage="RequiredFieldValidator" ControlToValidate="RadioButtonList1" 
                     ForeColor="Red">*请选择您的身份</asp:RequiredFieldValidator>
            </td>
        </tr>
        </table>
    <div class="style8">
        <span class="style9"><strong>
        <br />
        </strong></span>
        <br />
        <asp:Button ID="Button1" runat="server" Height="40px" 
        style="text-align: center; margin-left: 48px" Text="登录" Width="163px" 
        onclick="Button1_Click" />
&nbsp;&nbsp;&nbsp; <span class="style6"><a href="注册.aspx" style="color: #FFFFFF">点击此处注册</a></span></div>
    </form>
    </body>
</html>
