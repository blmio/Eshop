<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodsList.aspx.cs" Inherits="admin_Shop_GoodsList" StylesheetTheme="Members" %>
<!DOCTYPE html/>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<script type="text/javascript" src="../../Scripts/admin/ad_/shoplist.js"></script>
<style type="text/css">
table{margin-top: 0px;}
</style>
</head>
<body>
<script type="text/javascript">
    derF["FrTable"] = "e_goods_pic";
    derF["upid"] = "<%=upid %>";
    if (derF["upid"] != "") {
        derF["upidurl"] = "&upid=" + derF["upid"];
    }
</script>
<table width="98%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)" id="tmall" class="tabSP">
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
  <tr inid="<%# Eval("Number")%>">
    <td align="center" width="16%"><%#miT(mi++) %></td>
    <td width="auto" align="center"><span id="Name<%# Eval("Number")%>"><%# Eval("title")%></span></td>
    <td width="17%" align="center"><%#ImgID(Eval("ImgS"), Eval("Number"))%></td>
    <td align="center" width="6%">[<%# Eval("Stat")%>]</td>
    <td class="inpqx" width="150"><div style="width:150px;"><a gnid="sCl"><%# Eval("CloseS")%></a><a gnid="Edit">编辑</a><a gnid="Delete">删除</a></div></td>
  </tr>
</ItemTemplate>
</asp:Repeater>
  <tr runat="server" id="NoCh" visible="false">
   <td style="padding:20px 0px; text-align:center;" colspan="4"><a href="javascript:Sli.zOpen(derF['upidurl'],'列表图片添加')">添加列表图片</a></td>
  </tr>
</table>
</body>
</html>
