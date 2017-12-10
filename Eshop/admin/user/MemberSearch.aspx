<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberSearch.aspx.cs" Inherits="admin_user_MemberSearch" StylesheetTheme="Members" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<script type="text/javascript">
    if (window == top) top.location.href = "../";
    function $() { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); }
    var pWin = window.parent;
    function CategF(tH) {
        var T = $("Div" + tH).innerHTML;
        var Arr = T.split('|');
        Arr[2] = Arr[2].replace("{id}", Arr[0])
        $("tit").innerHTML = "<b>" + Arr[1] + "：</b>";
        $("inp").innerHTML = Arr[2];
    }
    onload = function () { CategF(0); }
    function gotoB() {
        var Level = $("Level").value, str = "sm=pp";
        if (Level == "0") {
            if (pWin.trim($("Name").value))
                str += "&Name=" + escape($("Name").value);
            else
                pWin.Boxalert("请输入要查找的登录名");
        }
        else if (Level == "1") {
            if (pWin.trim($("RealName").value))
                str += "&RealName=" + escape($("RealName").value);
            else
                pWin.Boxalert("请选择要查找的真实姓名");
        }
        else if (Level == "2") {
            if (pWin.trim($("Email").value))
                str += "&Email=" + escape($("Email").value);
            else
                pWin.Boxalert("请选择要查找的电子邮箱");
        }
        else if (Level == "3") {
            if (pWin.trim($("Mobile").value))
                str += "&Mobile=" + escape($("Mobile").value);
            else
                pWin.Boxalert("请选择要查找的联系电话");
        }
        if (str != "&sm=pp") {
            pWin.btFrame.comi1.location.href = "user/Member.aspx?" + str;
        }
    }
</script>
</head>
<body>
<table width="98%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)" onmouseout="pWin.changeback(event)">
  <tr>
    <td height="25" align="right" width="35%"><b>按：</b></td>
    <td align="left" width="65%">
	<select name="Level" id="Level" onchange="CategF(this.value)">
      <option value="0">登录名</option>
      <option value="1">真实姓名</option>
      <option value="2">电子邮箱</option>
      <option value="3">联系电话</option>
    </select>
	</td>
  </tr>
  <tr>
    <td height="25" align="right" id="tit"><b>登录名：</b></td>
    <td align="left" id="inp"><input name="title" type="text" style="width:130px;" /></td>
  </tr>
</table>
<div style="display:none;">
<div id="Div0">Name|登录名|<input name="{id}" type="text" id="Name" style="width:130px;" /></div>
<div id="Div1">RealName|真实姓名|<input name="{id}" type="text" id="RealName" style="width:130px;" /></div>
<div id="Div2">Email|电子邮箱|<input name="{id}" type="text" id="Email" style="width:130px;" /></div>
<div id="Div3">Mobile|联系电话|<input name="{id}" type="text" id="Mobile" style="width:130px;" /></div>
</div>
</body>
</html>
