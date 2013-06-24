<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUrl.aspx.cs" Inherits="Log4netUTS.TestWeb.TestUrl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtUrl" Text="http://tLog.cn100.com/HttpLogReceive.aspx" runat="server" Width="381px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="测试" onclick="Button1_Click" />
        <asp:Label ID="lbInfo" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
