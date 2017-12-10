<%@ Page Language="C#" AutoEventWireup="true" CodeFile="keyData.aspx.cs" Inherits="admin_system_keyData" StylesheetTheme="Member" %>
<%@ Register src="../../Ascx/Order/Pageview.ascx" tagname="PageAdmin" tagprefix="uc1" %>
<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>关键词信息管理</title>
<script type="text/javascript" src="../../Scripts/admin/ready.js"></script>
<script type="text/javascript">
    derF["TitleName"] = "关键词信息";
    derF["FrTable"] = "e_keydata";
    derF["Tableurl"] = "system/keyDataModify.aspx";
    derF["winW"] = 380;
    derF["winH"] = 160;
    derF["Tn"] = 30;
    derF["SortT"] = "信息";
</script> 
</head>
<body>
<script type="text/javascript" language="javascript">
    derF["upid"] = "<%=upid %>";
    if (derF["upid"] != "") derF["upidurl"] += "&upid=" + derF["upid"];
    derF["TitleName"] = "<%=str%>";
</script>
<div class="tabT">
  <div class="tabTR"> </div>
  <div class="tablText"> <img src="../../images/tab/tab_09.gif" width="16" height="13" /> <span class="tab4">关键词信息管理</span></div>
  <div class="tabTAll">
    <a id="add">新增</a>&nbsp;
    <a id="Deleteall">删除</a>
  </div>
  <div class="tabTL"></div>
</div>
<div class="tabC">
  <div class="tabCR">
    <div class="tabCL">
      <table width="100%" border="0" cellspacing="1" cellpadding="0" class="tabSP" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)" onmouseout="pWin.changeback(event)" id="tmall">
        <tr class="tabHe">
          <td width="5%"><input id="ch2" type="checkbox" value="checkbox" onclick="pWin.chkalls(this)" /></td>
          <td width="10%"><span>编号</span></td>
          <td width="auto"><span>关键字</span></td>
          <td width="10%"><span>搜索次数</span></td>
          <td width="20%"><span>客户端的 IP</span></td>
          <td width="8%"><span>排序</span></td>
          <td width="200"><span>管理</span></td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <tr inid="<%# Eval("Number")%>">
              <td align="center"><input name="check" type="checkbox" value="<%# Eval("Number")%>" /></td>
              <td align="center"><%#miT(mi++) %></td>
              <td><span id="Name<%# Eval("Number") %>" title="<%#Eval("keywords") %>"><%# Eval("keywords")%></span></td>
              <td align="center"><%# Eval("num")%></td>
              <td><span id="IP"<%# Eval("Number") %>" title="<%#Eval("UserHostAddress") %>"><%# Eval("UserHostAddress")%></span></td>
              <td align="center"><a gnid="Stat" title="点击排序">[<%# Eval("Stat")%>]</a></td>
              <td class="inpqx"><div style="width:200px;"><a gnid="Red"><%# Eval("Reded")%></a><a gnid="sCl"><%# Eval("CloseS")%></a><a gnid="Edit">编辑</a><a gnid="Delete">删除</a></div></td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
        <tr runat="server" id="NoCh" visible="false">
          <td style="padding: 20px 0px; text-align: center;" colspan="5"> 没有记录 </td>
        </tr>
      </table>
    </div>
  </div>
</div>
<div class="tabB">
  <div class="tabBR"> </div>
  <div class="tabBC">
    <uc1:PageAdmin ID="PageAd1" runat="server" />
  </div>
  <div class="tabBL"> </div>
</div>
</body>
</html>
