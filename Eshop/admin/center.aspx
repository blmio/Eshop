<%@ Page Language="C#" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title>中间部分</title>
  <link href="../App_Themes/ext/index.css" type="text/css" rel="stylesheet" />
</head>
<body style="margin:0px;overflow:hidden;">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" style="table-layout:fixed;">
  <tr>
    <td width="177" id="frmTitle" name="fmTitle" align="center" valign="top" height="100%"><iframe name="leftall" id="leftall" height="100%" width="180" src="left.aspx" border="0" frameborder="0" scrolling="auto">浏览器不支持嵌入式框架，或被配置为不显示嵌入式框架。</iframe></td>
    <td width="8" valign="middle" background="../images/Member/main_12.gif" onClick="switchSysBar()"><span class="navPoint"><img src="../images/Member/main_18.gif" name="img1" width=8 height=52 id=img1></span></td>
    <td align="center" valign="top" height="100%"><iframe name="comi1" id="comi1" height="100%" width="100%" border="0" frameborder="0" src="main.aspx"> 浏览器不支持嵌入式框架，或被配置为不显示嵌入式框架。</iframe></td>
    <td width="4" align="center" valign="top" background="../images/Member/main_20.gif"></td>
  </tr>
</table></body>
</html>
<script type="text/javascript" language="javascript">
    if (window == top) top.location.href = ".";
    var pWin = window.parent;
    function $() { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); }
    var MTM = 0;
    function switchSysBar() {
        if (MTM == 0) {
            $("img1").src = "../images/Member/main_18_1.gif";
            $("frmTitle").style.display = "none";
            MTM = 1;
        }
        else {
            $("img1").src = "../images/Member/main_18.gif";
            $("frmTitle").style.display = "";
            MTM = 0;
        }
        pWin.btvar = MTM;
    }
    function gotleft() {
        $("img1").src = "../images/Member/main_18.gif";
        $("frmTitle").style.display = "";
        MTM = 0;
    }
</script>