<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodsListModify.aspx.cs" Inherits="admin_Shop_GoodsListModify" StylesheetTheme="Members" %>
<!DOCTYPE html/>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<script type="text/javascript">
    if (window == top) top.location.href = "../";
    var pWin = window.parent.parent;
    function gotoB() {
        if (pWin.listf("标题不能为空！", "title")) return false;
        var vtr = false;
        var FImgS = $("FImgS").value, ImgS = $("ImgS").value;
        if (pWin.trim(FImgS)) { vtr = true; }
        if (pWin.trim(ImgS)) { vtr = true; }
        if (!vtr) { pWin.Boxalert("图片不能为空！"); return vtr; }
        var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
    function $() { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); }
    function trim(s) { return s.replace(/(^\s*)|(\s*$)/g, ""); }
    function titf() {
        //if (!trim($("title").value)) $("title").value = pWin.Su$("title").value;
        $("Stat").onblur = function () { SNaNs("Stat"); }
    }
    function SNaNs(Scid) { if (isNaN($(Scid).value)) { $(Scid).value = "0"; } if ($(Scid).value == "") { $(Scid).value = "0"; } }
</script>
</head>
<body onload="titf()">
<form id="form1" runat="server">
<table width="99%" border="0" cellpadding="0" cellspacing="1" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)" onmouseout="pWin.changeback(event)">
  <tr>
    <td width="25%" height="25" align="right"><b>标题：</b></td>
    <td width="75%" align="left"><asp:TextBox ID="title" runat="server" Width="220"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right"><b>产品图片：</b></td>
    <td align="left">
<div id="div1">
    <asp:TextBox ID="ImgS" runat="server" Width="150"></asp:TextBox>
    &nbsp;<a href="javascript:pWin.Visili('div1','div2')">上传图片</a> <img src="../../images/admin/memo.gif" width="16" height="16" title="图标，可以是网络地址如：http://www.bxite.com/img/sslm_logo.gif 点击 上传图片 是本地上传  :也可以用Flash动画" />
</div>
<div id="div2" style="display:none;">
    <asp:FileUpload ID="FImgS" runat="server" Width="160" />
    &nbsp;<a href="javascript:pWin.Visili('div1','div2')">取消上传</a>
</div>
    </td>
  </tr>
  <tr>
    <td height="25" align="right"><b>开关设置：</b></td>
    <td align="left">
       <asp:CheckBox ID="CloseS" runat="server" Text="关闭" />&nbsp; &nbsp; 
       <asp:TextBox ID="Stat" runat="server" Width="50"></asp:TextBox> <label for="Stat">排序</label>
    </td>
  </tr>
</table>
<asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="upid" runat="server" Visible="false"></asp:Label>
</form>
</body>
</html>