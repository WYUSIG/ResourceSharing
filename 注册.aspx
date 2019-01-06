<%@ Page Language="C#" AutoEventWireup="true" CodeFile="注册.aspx.cs" Inherits="注册" %>

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
            height: 568px;
        }
        .style2
        {
            width: 284px;
        }
        .style3
        {
            width: 284px;
            font-size: medium;
            color: #FFFFFF;
            text-align: right;
        }
        .style4
        {
            width: 284px;
            font-size: large;
            color: #FFFFFF;
            text-align: right;
        }
        .style5
        {
            width: 284px;
            color: #FFFFFF;
        }
        .style6
        {
            color: #FFFFFF;
            font-size: large;
        }
        .style7
        {
            width: 284px;
            text-align: right;
        }
        .style8
        {
            color: #FFFFFF;
        }
        .style9
        {
            color: #FF0000;
        }
        .style10
        {
            color: #FF0000;
            font-size: large;
        }
    </style>
</head>
<body style = "background-image:url('img/zc.jpg');">
    <form id="form1" runat="server">
    <table align="center" class="style1">
        <tr>
            <td class="style3">
                <strong style="font-size: large"><span class="style9">*</span>呢称：</strong></td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Font-Size="Large"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                     ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox1" 
                     ForeColor="Red">*账号不能为空</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <strong><span class="style9">*</span>密码：</strong></td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Size="Large"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                     ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox2" 
                     ForeColor="Red">*密码不能为空</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <strong><span class="style9">*</span>性别：</strong></td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Size="Large" 
                    ForeColor="White">
                    <asp:ListItem>男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                     ErrorMessage="RequiredFieldValidator" ControlToValidate="RadioButtonList1" 
                     ForeColor="Red">*请选择您的性别</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style7">
                <strong>
                <span class="style10">*</span><span class="style6">联系电话</span></strong><span class="style8">：</span></td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Font-Size="Large"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                     ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox4" 
                     ForeColor="Red">*联系电话不能为空</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <strong>头像：</strong></td>
            <td>
                <input id="UP_FILE" runat="server" accept="image/*" name="UP_FILE" 
                    style="Width:320" type="file" /></td>
        </tr>
        <tr>
            <td class="style4">
                <strong><span class="style9">*</span>身份：</strong></td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" 
                    Font-Size="Large" ForeColor="White" 
                    onselectedindexchanged="RadioButtonList2_SelectedIndexChanged">
                    <asp:ListItem>教师</asp:ListItem>
                    <asp:ListItem Selected="True">学生</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                     ErrorMessage="RequiredFieldValidator" ControlToValidate="RadioButtonList2" 
                     ForeColor="Red">*请选择您的身份</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style5">
               <asp:Label ID="Label1" runat="server" Font-Size="Large" 
                    style="text-align: right" Text="班级： "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Font-Size="Large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" BorderColor="Black" Font-Size="Large" 
                    style="text-align: right; color: #FFFFFF" Text="任课老师："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" Font-Size="Large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <strong>生日：</strong></td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server" Font-Size="Large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <strong>个性签名：</strong></td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server" Font-Size="Large" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                学校：</td>
            <td>
                <asp:TextBox ID="TextBox10" runat="server" Font-Size="Large"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Height="39px" onclick="Button1_Click" 
        style="margin-left: 742px" Text="注册" Width="124px" />
    </form>
</body>
</html>
