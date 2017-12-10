<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Navigation.aspx.cs" Inherits="admin_system_Navigation" StylesheetTheme="Member" %>
<%@ Register Src="~/Ascx/Order/Pageview.ascx" TagName="Pageview" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>导航分类管理</title>
<script type="text/javascript" src="../../Scripts/admin/ready.js"></script>
<script type="text/javascript">
    derF["TitleName"] = "导航分类";
    derF["FrTable"] = "e_navigation";
    derF["Tableurl"] = "system/NavigationModify.aspx";
    derF["winW"] = 400;
    derF["winH"] = 240;
    derF["Tn"] = 30;
    derF["SortT"] = "导航";
</script>
</head>
<body>
  <div class="tabT">
    <div class="tabTR"></div>
    <div class="tablText"><img src="../../images/tab/tab_09.gif" width="16" height="13" /> <span class="tab4">导航栏目配置</span></div>
    <div class="tabTAll">
      <div class="tabTok"><a id="add">新增</a></div>
    </div>
    <div class="tabTL"></div>
  </div>
<div class="tabC">
  <div class="tabCR">
    <div class="tabCL">
      <table width="100%" border="0" cellspacing="1" cellpadding="0" class="tabSP" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)" onmouseout="pWin.changeback(event)" id="tmall">
        <tr class="tabHe">
          <td width="16%"> 编号 </td>
          <td width="auto"> 标题 </td>
          <td width="23%"> 关键字 </td>
          <td width="23%"> 描述 </td>
          <td width="8%">排序</td>
          <td width="180"> 管理 </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <tr inid="<%# Eval("Number")%>">
              <td>&nbsp;<%# Eval("Number")%> </td>
              <td align="center"><span id="Name<%# Eval("Number")%>" title="<%#Eval("title") %>"><%# Eval("title")%></span></td>
              <td align="center"><%# Fun(Eval("Keywords"))%> </td>
              <td align="center"><%# Fun(Eval("Description"))%></td>
              <td align="center"><a gnid="Stat" title="点击排序">[<%# Eval("Stat")%>]</a></td>
              <td class="inpqx"><div style="width:200px;"><a gnid="sCl"><%# Eval("CloseS")%></a><a gnid="Edit">编辑</a><a gnid="Delete">删除</a><span style="display:none;" id="DeM<%# Eval("Number")%>"><%# Eval("Reded")%></span></td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
        <tr runat="server" id="NoCh" visible="false">
          <td style="padding: 20px 0px; text-align: center;" colspan="7"> 没有记录 </td>
        </tr>
      </table>
    </div>
  </div>
</div>
  <div class="tabB">
    <div class="tabBR"></div>
    <div class="tabBC"><uc1:Pageview ID="Pageview1" runat="server" /></div>
    <div class="tabBL"></div>
  </div>
</body>
</html>
