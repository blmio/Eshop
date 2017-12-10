<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="admin_default" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>网站管理系统</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="../App_Themes/ext/index.css" type="text/css" rel="stylesheet" />
<link rel="icon" href="../favicon.ico" type="image/x-icon" />
<link href="../App_Themes/ext/ext-all.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="../Scripts/admin/Default.js"></script>
</head>
<body style="overflow:hidden;">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr >
    <td height="63" class="headtop">
	  <div class="mah1"><img src="../images/Member/main_01.gif" width="104" height="11"></div>
	  <div class="mah2">
		 <div class="t_le1"></div>
		 <div class="t_le2"></div>
	  </div>
      <div class="mah3">
         <ul id="tophead">
           <li id="par1" class="lm"><p>综合设置</p></li>
           <li id="par2"><p>产品管理</p></li>
           <li id="par3"><p>会员管理</p></li>
           <li id="par4"><p>留言评论</p></li>
         </ul>
      </div>
      <div class="mah4">
        <span><em>欢迎您，<%=uesrname %></em></span>
	    <span><img src="../images/Member/home.gif" width="12" height="13"></span>
	    <span><a href="../" target="_blank">回首页</a></span>
	    <span><img src="../images/Member/quit.gif" width="16" height="16"></span>
	    <span><a href="Default.aspx?login=login">退出系统</a></span>
	  </div>
	</td>
  </tr>
  <tr>
    <td><iframe name="btFrame" id="btFrame" height="100%" width="100%" src="center.aspx" border="0" frameborder="0" scrolling="no"></iframe></td>
  </tr>
  <tr>
    <td height="23" class="headbot">
	  <div class="botall">
        <div class="STms" onClick="sAlert('it.html');">如有疑问请与技术人员联系</div>
        <div class="SDwm" id="SDwm">今天是：2014年02月21日 星期五</div>
	  </div>
	</td>
  </tr>
</table>
</body>
</html>
<script type="text/javascript">
    url = "<%=url %>";
    Ext.onReady(function () {
        jsload("../Scripts/admin/TanCen.js", "TanCen");
        jsload("../Scripts/admin/Window.js", "Window");
        Dwm();
        tophead();
    });
</script>