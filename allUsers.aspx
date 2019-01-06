<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allUsers.aspx.cs" Inherits="allUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/allUsers.css" rel="stylesheet" type="text/css" />
    <title>查看所有用户</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class = "panle">
        <div class="searchdiv">
        <asp:TextBox ID="TextBox1" runat="server" class = "searchbox"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="搜 索" class = "searchbtn" placeholder="ID/姓名/"
                onclick="Button1_Click"/>
        </div>
        <div style="width:95%;margin:0 auto;">
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" DataSourceID="SqlDataSource1" style="width:100%;" 
                AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" PageSize="5">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                        ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="sex" HeaderText="sex" SortExpression="sex" />
                    <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                    <asp:BoundField DataField="password" HeaderText="password" 
                        SortExpression="password" />
                    <asp:BoundField DataField="class" HeaderText="class" SortExpression="class" />
                    <asp:BoundField DataField="taecher" HeaderText="taecher" 
                        SortExpression="taecher" />
                    <asp:BoundField DataField="flag" HeaderText="flag" SortExpression="flag" />
                    <asp:BoundField DataField="school" HeaderText="school" 
                        SortExpression="school" />
                    <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                </Columns>
                <EditRowStyle BackColor="#3CB371" />
                <FooterStyle BackColor="#2E8B57" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#008B45" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            
            每页显示&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="border-radius:3px;">
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            </asp:DropDownList>
            条记录&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                DeleteCommand="DELETE FROM [user] WHERE [id] = ?" 
                InsertCommand="INSERT INTO [user] ([id], [name], [sex], [phone], [password], [class], [taecher], [flag], [school]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                SelectCommand="SELECT [id], [name], [sex], [phone], [password], [class], [taecher], [flag], [school] FROM [user]" 
                
                UpdateCommand="UPDATE [user] SET [name] = ?, [sex] = ?, [phone] = ?, [password] = ?, [class] = ?, [taecher] = ?, [flag] = ?, [school] = ? WHERE [id] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="sex" Type="String" />
                    <asp:Parameter Name="phone" Type="String" />
                    <asp:Parameter Name="password" Type="String" />
                    <asp:Parameter Name="class" Type="String" />
                    <asp:Parameter Name="taecher" Type="String" />
                    <asp:Parameter Name="flag" Type="String" />
                    <asp:Parameter Name="school" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="sex" Type="String" />
                    <asp:Parameter Name="phone" Type="String" />
                    <asp:Parameter Name="password" Type="String" />
                    <asp:Parameter Name="class" Type="String" />
                    <asp:Parameter Name="taecher" Type="String" />
                    <asp:Parameter Name="flag" Type="String" />
                    <asp:Parameter Name="school" Type="String" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    </form>
</body>
</html>
