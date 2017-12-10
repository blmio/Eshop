<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HelpModify.aspx.cs" Inherits="admin_system_HelpModify"  StylesheetTheme="Members"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>添加、修改</title>
<script type="text/javascript">
    if (window == top) top.location.href = "../";
    var pWin = window.parent.parent;
    function gotoB() {
        if (pWin.Boxif("分类标题不能为空！", "title")) return false;
        var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
    function $() { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); }
</script>
</head>
<body>
<form id="form1" runat="server">
  <table width="98%" border="0" cellspacing="1" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)">
  <tr>
    <td height="25" align="right" width="25%"><b>信息分类：</b></td>
    <td height="25" align="left" width="75%"><asp:TextBox ID="title" runat="server" Width="180"></asp:TextBox></td>
  </tr>
  <tr id="div3">
    <td height="25" align="right"><b>父级分类：</b></td>
    <td align="left"><asp:DropDownList ID="DropDupid" runat="server"></asp:DropDownList></td>
  </tr>
  <tr>
    <td height="25" align="right"><b>开关设置：</b></td>
    <td align="left">
      <asp:CheckBox ID="CloseS" runat="server" Text="关闭" />
    </td>
  </tr>
</table>
<asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="LGrade" runat="server" Text="0" Visible="false"></asp:Label>
</form>
</body>
</html>
<script type="text/javascript">
    var adminD = <%=adminD %>;
    if(adminD==1){
        $("div3").style.display = "none";
    }  
</script>