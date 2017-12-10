<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodsSearch.aspx.cs" Inherits="admin_Shop_GoodsSearch" StylesheetTheme="Members" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../Scripts/admin/ad_/GoodsSearch.js"></script>
</head>
<body>
<table width="98%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)">
  <tr>
    <td width="28%" height="25" align="right">产品编号：</td>
    <td width="72%" align="left"><input name="emid" type="text" id="emid" /></td>
  </tr>
  <tr>
    <td height="25" align="right">产品名：</td>
    <td align="left"><input name="title" type="text" id="title" /></td>
  </tr>
  <tr>
    <td height="25" align="right">产品单价：</td>
    <td align="left"><input name="price" type="text" id="price" /></td>
  </tr>
  <tr>
    <td height="25" align="right">一级类别：</td>
    <td align="left"><select name="upid" id="upid"><option value="">== 请选择商品类别 ==</option><%=select()%></select></td>
  </tr>
  <tr>
    <td height="25" align="right">指定类别：</td>
    <td align="left"><select name="upids" id="upids"><option value="">== 请选择商品类别 ==</option></select></td>
  </tr>
</table>
</body>
</html>