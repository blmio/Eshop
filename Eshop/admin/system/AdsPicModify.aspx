<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdsPicModify.aspx.cs" Inherits="admin_system_AdsPicModify" StylesheetTheme="Members" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>图片修改、添加</title>
<script type="text/javascript" src="../../Scripts/admin/ad_/flashModify.js"></script>
<style type="text/css">
table td{line-height:30px;height:30px;}
</style>
</head>
<body>
<form id="form1" runat="server">
<table width="98%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)">
  <tr>
    <td height="30" align="right">图片名称：</td>
    <td height="30" align="left">
        <asp:TextBox ID="title" runat="server" Width="230"></asp:TextBox>
    </td>
  </tr>
      <tr>
    <td height="30" align="right">图片描述：</td>
    <td height="30" align="left">
        <asp:TextBox ID="Description" runat="server" Width="230"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td height="30" align="right">切换图片：</td>
    <td height="30" align="left">
    <div id="div1">
        <asp:TextBox ID="ImgS" runat="server" Width="140"></asp:TextBox>
        &nbsp;<a href="javascript:pWin.Visible('div1','div2')">上传图片</a> 
        <img src="../../images/admin/memo.gif" width="16" height="16" title="图标，可以是网络地址如：http://www.bxite.com/img/sslm_logo.gif 点击 上传图片 是本地上传 " />
    </div>
    <div id="div2" style="display:none;">
        <asp:FileUpload ID="FImgS" runat="server" Width="150" />&nbsp;<a href="javascript:pWin.Visible('div1','div2')">取消上传</a>
    </div>
    </td>
  </tr>
  <tr>
    <td height="30" align="right">链接地址：</td>
    <td height="30" align="left">
        <asp:TextBox ID="url" runat="server" Width="230" />
    </td>
  </tr>
  <tr>
    <td height="30" align="right">开关设置：</td>
    <td height="30" align="left">
        <asp:CheckBox ID="CloseS" runat="server" Text=" 关闭" />
        <asp:CheckBox ID="Reded" runat="server" Text=" 推荐" />
    </td>
  </tr>
</table>
<asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
</form>
</body>
</html>