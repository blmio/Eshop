<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminModify.aspx.cs" Inherits="admin_system_AdminModify" StylesheetTheme="Members" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        if (window == top) top.location.href = "../";
        function gotoB() {
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
        }
        var pWin = window.parent.parent;
    </script>
</head>
<body>
    <form id="form1" runat="server">
<table width="98%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)">
  <tr>
    <td width="35%" height="25" align="right">操作员用户名：</td>
    <td width="65%" align="left">
        <asp:TextBox ID="TAname" runat="server"></asp:TextBox>
    </td>
  </tr>
  <tr id="adl">
    <td height="25" align="right">旧 &nbsp;密&nbsp;码：</td>
    <td align="left">
    <asp:TextBox ID="TApasswoid" runat="server" TextMode="Password"></asp:TextBox>
  </td>
  <tr>
    <td height="25" align="right"><span id="adn">新 &nbsp;密&nbsp;码：</span></td>
    <td align="left">
    <asp:TextBox ID="TApasswoid1" runat="server" TextMode="Password"></asp:TextBox>
  </td>
  <tr>
    <td height="25" align="right">确&nbsp;认&nbsp;密&nbsp;码：</td>
    <td align="left">
    <asp:TextBox ID="TApasswoid2" runat="server" TextMode="Password"></asp:TextBox>
  </td>
  </tr>
  <tr>
    <td height="25" align="right">操作员姓名：</td>
    <td align="left">
        <asp:TextBox ID="TRealityName" runat="server"></asp:TextBox>
        <asp:Label ID="LApasswoid" runat="server" Visible="false"></asp:Label>
    </td>
  </tr>
</table><asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
<script type="text/javascript">
    function $(id){return document.getElementById(id);}
    var adminD = <%=adminD %>;
    function zOpen1()
    {
        if(adminD==1)
        {
            $("adl").style.display = "none";
            $("adn").innerHTML = "设&nbsp;置&nbsp;密&nbsp;码：";
            pWin.win.setSize(310, 185);
        }
    }
    zOpen1();
</script>
    </form>
</body>
</html>
