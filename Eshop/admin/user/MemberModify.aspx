<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberModify.aspx.cs" Inherits="admin_user_MemberModify" StylesheetTheme="Members" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员编辑</title>
<script type="text/javascript" src="../../Scripts/admin/ad_/MemberModify.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<div class="tabbtm" id="tabbtm">
  <p class="p"><a id="t1">基本信息</a></p>
  <p><a id="t2">会员介绍</a></p>
</div>
<div id="divt1" class="dili">
<table width="98%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)">
  <tr>
    <td width="11%" align="right">会员名：</td>
    <td width="39%"><asp:TextBox ID="Name" runat="server" Width="280"></asp:TextBox></td>
    <td width="11%" align="right">登录密码：</td>
    <td width="39%"><asp:TextBox ID="Password" runat="server" Width="280" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right">昵称：</td>
    <td><asp:TextBox ID="NickName" runat="server" Width="280"></asp:TextBox></td>
    <td align="right">真实姓名：</td>
    <td><asp:TextBox ID="RealName" runat="server" Width="280"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right">联系邮箱：</td>
    <td><asp:TextBox ID="Email" runat="server" Width="280"></asp:TextBox></td>
    <td align="right">联系手机：</td>
    <td><asp:TextBox ID="Mobile" runat="server" Width="280"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right">出生年月：</td>
    <td><asp:TextBox ID="Birth" runat="server" Width="280"></asp:TextBox></td>
    <td align="right">性别：</td>
    <td><%=Sexra() %></td>
  </tr>
  <tr>
    <td align="right">头像：</td>
    <td >
    <div id="div1">
        <asp:TextBox ID="ImgS" runat="server" Width="140"></asp:TextBox>
        &nbsp;<a href="javascript:pWin.Visible('div1','div2')">上传图片</a> 
        <img src="../../images/admin/memo.gif" width="16" height="16" title="图标，可以是网络地址如：http://www.bxite.com/img/sslm_logo.gif 点击 上传图片 是本地上传 " />
    </div>
    <div id="div2" style="display:none;">
        <asp:FileUpload ID="FImgS" runat="server" Width="150" />&nbsp;<a href="javascript:pWin.Visible('div1','div2')">取消上传</a>
    </div>
    <td rowspan="2" align="right">通讯地址：</td>
    <td rowspan="2"><asp:TextBox ID="Address" runat="server" Width="280" Height="40" TextMode="MultiLine"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right">登录次数：</td>
    <td><asp:TextBox ID="Lotimes" runat="server" Width="140"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="right">开关设置：</td>
    <td colspan="3">
      <asp:CheckBox ID="CloseS" runat="server" Text="关闭" />
    </td>
  </tr>
</table>
</div>
<div id="divt2" style="display:none;" class="dili">
<table width="98%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)">
  <tr>
    <td align="right" width="15%">会员介绍：</td>
    <td align="left" width="85%"><asp:TextBox ID="Content" runat="server" Width="210" TextMode="MultiLine" style="display:none"></asp:TextBox><iframe id="I1" frameborder="0" height="370" name="I1" scrolling="No" src="../../eWebEditor/ewebeditor.htm?id=Content&style=expand650&skin=flat9&Page=yes" width="100%"></iframe></td>
  </tr>
</table>
</div>
<asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
<input type="hidden" name="pwd" id="pwd" value="<%=Vr[2] %>" />
</form>
<script type="text/javascript">
    $(document).ready(function () {
        Me.Bot["Vr-Name"] = "<%=Vr[1] %>";
        Me.Bot["Vr-Email"] = "<%=Vr[9] %>";
        Me.Bot["Vr-Mobile"] = "<%=Vr[6] %>";
        Me.loadfun();
    });
</script>
</body>
</html>