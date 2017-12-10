<%@ Page Language="C#" AutoEventWireup="true" CodeFile="keyDataModify.aspx.cs" Inherits="admin_system_keyDataModify" StylesheetTheme="Members" %>
<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>关键词信息管理</title>
<script type="text/javascript">
    if (window == top) top.location.href = "../";
    var pWin = window.parent.parent;
    function gotoB() {
        var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
</script>
</head>
<body>
<form id="form1" runat="server">
<table width="98%" border="0" cellspacing="1" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)" onmouseout="pWin.changeback(event)">
  <tr>
    <td height="25" align="right" width="16%">关键字：</td>
    <td height="25" align="left" width="34%"><asp:TextBox ID="keywords" runat="server" Width="230"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="25" align="right">搜索次数：</td>
    <td height="25" align="left"><asp:TextBox ID="num" runat="server" Width="230"></asp:TextBox></td>
  </tr>
  <tr>
  <td height="25" align="right">开关设置：</td>
    <td align="left">
      <asp:CheckBox ID="CloseS" runat="server" Text="关闭" />
      <asp:CheckBox ID="Reded" runat="server" Text="推荐" />
      <asp:CheckBox ID="hot" runat="server" Text="热门" />
    </td>
  </tr>
</table>
<asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
</form>
</body>
</html>
