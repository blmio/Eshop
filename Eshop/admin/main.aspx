<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="admin_main" StylesheetTheme="Member" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<script type="text/javascript" src="../Scripts/admin/html/JSmain.js"></script>
</head>
<body>
<div class="tabT">
  <div class="tabTR"></div>
  <div class="tablText"><img src="../images/tab/tab_09.gif" width="16" height="13" /> <span class="tab4">欢迎您“<%= Vt[0] %>”管理e商城后台</span></div>
  <div class="tabTL"></div>
</div>
<div class="tabC">
  <div class="tabCR">
    <div class="tabCL">
      <table width="100%"  border="0" cellspacing="0" cellpadding="0" class="tabSP2" id="tmall">
        <tr class="tabHe">
          <td width="15%">栏目</td>
          <td width="85%">信息</td>
        </tr>
        <tr>
          <td align="right">当前管理员：</td>
          <td><%= Vt[0] %></td>
        </tr>
        <tr>
          <td align="right">本次登录时间：</td>
          <td><%= Vt[1] %></td>
        </tr>
        <tr>
          <td align="right">登录次数：</td>
          <td><%= Vt[2] %> 次</td>
        </tr>
      </table>
    </div>
  </div>
</div>
<div class="tabB">
  <div class="tabBR"></div>
  <div class="tabBC"></div>
  <div class="tabBL"></div>
</div>
</body>
</html>
<script type="text/javascript">
    $(document).ready(function () {
        $("#tmall").mouseover(function () { pWin.changeto(event.srcElement ? event.srcElement : event.target) }).mouseout(function () { pWin.changeback(event); });
    });
</script>