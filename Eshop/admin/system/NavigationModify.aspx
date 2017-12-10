<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NavigationModify.aspx.cs" Inherits="admin_system_NavigationModify" StylesheetTheme="Members" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>导航栏目配置</title>
<script type="text/javascript">
    if (window == top) top.location.href = "../";
    var pWin = window.parent.parent;
    function gotoB() {
        if (!pWin.trim($("title").value)) { pWin.Boxalert("导航名称不能为空！"); return false; }
        $("url").value = $("url").value.replace(" ", "-");
        //$('AgidT').readOnly = false;
        var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
    function $() { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); }
</script>
<script type="text/javascript" src="../../Scripts/ext/showDialog.js"></script>
</head>
<body>
<form id="form1" runat="server">
<table width="98%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)">
  <tr>
    <td width="25%"  height="25" align="right">导航名称：</td>
    <td width="75%" height="25" align="left"><asp:TextBox ID="title" runat="server" Width="260"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="25" align="right">SEO 标 题：</td>
    <td height="25" align="left"><asp:TextBox ID="sitetitle" runat="server" Width="260" /></td>
  </tr>
  <tr>
    <td height="25" align="right">SEO关键字：</td>
    <td height="25" align="left"><asp:TextBox ID="Keywords" runat="server" Width="260" /></td>
  </tr>
  <tr>
    <td height="25" align="right">SEO 描 述：</td>
    <td height="25" align="left"><asp:TextBox ID="Description" runat="server" Width="260" /></td>
  </tr>
  <tr id="adls">
    <td height="25" align="right">页面路径：</td>
    <td height="25" align="left"><asp:TextBox ID="url" runat="server" Width="260" /></td>
  </tr>
</table>
<asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
</form>
</body>
</html>