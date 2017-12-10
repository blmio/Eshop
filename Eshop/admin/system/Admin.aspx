<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="admin_system_Admin" StylesheetTheme="Member" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript" src="../../Scripts/admin/ready.js"></script>
<script type="text/javascript">
    derF["TitleName"] = "操作员";
    derF["FrTable"] = "e_admin";
    derF["Tableurl"] = "system/AdminModify.aspx";
    derF["winW"] = 310;
    derF["winH"] = 210;
    derF["Tn"] = 20;
    derF["SortT"] = "操作员";
</script>
</head>
<body>
<%=admin %>
<div class="tabT">
  <div class="tabTR"></div>
  <div class="tablText"><img src="../../images/tab/tab_09.gif" width="16" height="13" /> <span class="tab4">操作员管理</span></div>
  <div class="tabTAll">
    <a id="add">新增</a>
  </div>
  <div class="tabTL"></div>
</div>
<div class="tabC">
  <div class="tabCR">
    <div class="tabCL">
      <table width="100%" border="0" cellspacing="1" cellpadding="0" class="tabSP" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)" onmouseout="pWin.changeback(event)" id="tmall">
        <tr class="tabHe">
          <td width="20%">操作员等级</td>
          <td width="20%">操作员用户名</td>
          <td width="20%">操作员姓名</td>
          <td width="20%">建立时间</td>
          <td>管理</td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
        <tr inid="<%# Eval("Number")%>">
          <td><%# Rank(Eval("upid"), Eval("Rank"))%></td>
          <td><%# Eval("Aname")%></td>
          <td><%# Eval("RealityName")%></td>
          <td><%# Eval("Atime")%></td>
          <td class="inpqx"><div style="width: 210px;"><a gnid="sCl"><%# Eval("CloseS")%></a><a gnid="Edit">编辑</a><a gnid="Delete">删除</a><span style="display:none;" id="DeM<%# Eval("Number")%>"><%# RepBound(Eval("Number"))%></span></div></td>
        </tr>
          </ItemTemplate>
        </asp:Repeater>
      </table>
    </div>
  </div>
</div>
  <div class="tabB">
    <div class="tabBR"></div>
    <div class="tabBC"></div>
    <div class="tabBL"></div>
  </div>
</body>
</html>
