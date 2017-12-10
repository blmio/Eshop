<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FlashPic.aspx.cs" Inherits="admin_system_FlashPic" StylesheetTheme="Member" %>
<%@ Register Src="../../Ascx/Order/Pageview.ascx" TagName="PageAdmin" TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>轮播图片管理</title>
   <script type="text/javascript" src="../../Scripts/admin/ready.js"></script>
   <script type="text/javascript">
    derF["TitleName"] = "轮播图片";
    derF["FrTable"] = "e_flash";
    derF["Tableurl"] = "system/FlashPicModify.aspx";
    derF["winW"] = 400;
    derF["winH"] = 260;
    derF["Tn"] = 30;
    derF["SortT"] = "图片";
    derF["ImgS"] = "ImgS";
</script>
</head>
<body>
<div class="tabT">
  <div class="tabTR"></div>
  <div class="tablText"><img src="../../images/tab/tab_09.gif" width="16" height="13" /> <span class="tab4">轮播图片管理</span></div>
  <div class="tabTAll"><a id="add">新增</a></div>
  <div class="tabTL"></div>
</div>
<div class="tabC">
  <div class="tabCR">
    <div class="tabCL">
      <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabSP" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)" id="tmall">
        <tr class="tabHe">
          <td width="8%">编号</td>
          <td width="15%">图片</td>
          <td width="28%">图片名称</td>
          <td width="auto">图片描述</td>
          <td width="8%">排序</td>
          <td width="200">管理</td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <tr inid="<%# Eval("Number")%>">
              <td align="center"><%#miT(mi++) %></td>
              <td align="center"><span class="img" simg="<%#Eval("ImgS")%>" id="m<%#mi %>"><img src="../../image/s.gif" style="background-image:url(../../Apply/avatar.aspx?Type=fixnone&size=25x20&key=<%#Eval("ImgS")%>)" /></span></td>
              <td><span title="<%# Eval("title") %>" id="Name<%# Eval("Number")%>"><%#Eval("title") %></span></td>
              <td><span><%# Eval("Description") %></span></td>
              <td align="center"><a gnid="Stat" title="点击排序">[<%# Eval("Stat")%>]</a></td>
              <td class="inpqx"><div style="width:200px;"><a gnid="sCl"><%# Eval("CloseS")%></a><a gnid="Edit">编辑</a><a gnid="Delete">删除</a></div></td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
        <tr runat="server" id="NoCh" visible="false">
          <td style="padding:20px 0px; text-align:center;" colspan="7">没有记录</td>
        </tr>
      </table>
    </div>
  </div>
</div>
<div class="tabB">
  <div class="tabBR"></div>
  <div class="tabBC">
    <uc1:PageAdmin ID="PageAd1" runat="server" />
  </div>
  <div class="tabBL"></div>
</div>
</body>
</html>
