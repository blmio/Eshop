<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sort.aspx.cs" Inherits="admin_Apply_Sort" StylesheetTheme="Members" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>排序</title>
    <script type="text/javascript">
        if (window == top)top.location.href = "../";
function gotoB()
{
    var theForm = document.forms['form1'];
    if (!theForm) {
        theForm = document.form1;
    }
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {if(checkcart()){theForm.submit();/*提交表单*/}}
}
        var pWin = window.parent.parent;
        function $(id){return document.getElementById(id);}
        function checkcart()
        {
            if($("txtSort").value!="")
	         {
		         var reg=/^\d{0,15}$/;
		         if(!reg.test($("txtSort").value))
		         {
			         pWin.Boxalert("排序必须是数字 \n");
			         $("txtSort").focus();
			         $("txtSort").select();
			         return false;
		         }
	         }
	         else
	         {
	            pWin.Boxalert("号码不可为空 \n");
	            return false;
	         }
	         return true;
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
  <table width="96%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)">
    <tr>
      <td align="center" height="105"> 序号：<asp:TextBox ID="txtSort" runat="server" CssClass="inptset" Width="100"></asp:TextBox></td>
    </tr>
  </table>
</form>
</body>
</html>
