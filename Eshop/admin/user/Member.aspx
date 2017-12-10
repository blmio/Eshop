<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="admin_user_Member" StylesheetTheme="Member" %>
<%@ Register Src="../../Ascx/Order/Pageview.ascx" TagName="PageAdmin" TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员管理</title>
<script type="text/javascript" src="../../Scripts/admin/ready.js"></script>
<script type="text/javascript">
    derF["TitleName"] = "会员";
    derF["FrTable"] = "e_member";
    CloseS = "CloseS";
    derF["Tableurl"] = "user/MemberModify.aspx";
    derF["winW"] = 900;
    derF["winH"] = 310;
    derF["Tn"] = 30;
    derF["SortT"] = "信息";
    derF["SeW"] = 250;
    derF["SeH"] = 130;
    derF["Sealeurl"] = "user/MemberSearch.aspx";
</script> 
</head>
<body>
<script type="text/javascript" language="javascript">
    var upid = "<%=upid %>", admin = "<%=admin %>";
    if (upid != "") derF["upidurl"] += "&upid=" + upid;
    if (admin == "admin") { Re.Search(derF["TitleName"] + "搜索"); }
</script>
<div class="tabT">
  <div class="tabTR"> </div>
  <div class="tablText"> <img src="../../images/tab/tab_09.gif" width="16" height="13" /> <span class="tab4">会员管理</span></div>
  <div class="tabTAll">
    <a id="Search">查询</a>&nbsp;
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
          <td width="10%"><span>登录名</span></td>
          <td width="10%"><span>密码</span></td>
          <td width="auto"><span>会员名</span></td>
          <td width="15%"><span>登陆次数</span></td>
          <td width="10%"><span>注册时间</span></td>
          <td width="280"><span>管理</span></td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <tr inid="<%# Eval("Number")%>">
              <td align="center"><input name="check" type="checkbox" value="<%# Eval("Number")%>" /></td>
              <td><span><%#miT(mi++)%></span></td>
              <td><span><%#Eval("Name") %></span></td>
              <td><span><%#Decrypt(Eval("Password")) %></span></td>
              <td><span><%#Eval("NickName") %></span></td>
              <td><span><%#Eval("Lotimes") %></span></td>
              <td align="center"><span><%# ET(Eval("Atime", "{0:d}"))%></span></td>
              <td class="inpqx"><div style="width:280px;"><a gnid="sCl"><%# Eval("CloseS")%></a><a gnid="Edit">编辑</a><a gnid="Delete">删除</a></div></td>
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
  <div class="tabBR"> </div>
  <div class="tabBC">
    <uc1:PageAdmin ID="PageAd1" runat="server" />
  </div>
  <div class="tabBL"> </div>
</div>
</body>
</html>
