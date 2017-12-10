<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="admin_left" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>系统菜单</title>
<link href="../App_Themes/ext/index.css" type="text/css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="text/javascript" src="../Scripts/admin/left.js"></script>
<style type="text/css" charset="utf-8">
  body,html{background:url(../images/Member/main_16.gif) repeat-y 0px 0px; }
</style>
</head>
<body>
<div id="fixL">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" style="table-layout:fixed;">
  <tr>
    <td valign="top" class="matop" id="matop"><div class="load"></div></td>
  </tr>
</table>
</div>
</body>
</html>
<script type="text/javascript" charset="utf-8">
    Le.mer = "<%=mer %>";
    $(document).ready(function () {
        Le.leftall();
    });
</script>