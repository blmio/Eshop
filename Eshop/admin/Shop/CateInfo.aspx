<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CateInfo.aspx.cs" Inherits="admin_user_CateInfo" StylesheetTheme="Member" %>
<!DOCTYPE html >
<%@ Register Src="../../Ascx/Order/Pageview.ascx" TagName="PageAdmin" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品分类管理</title>
<script type="text/javascript" src="../../Scripts/admin/ready.js"></script>
<script type="text/javascript">
    derF["TitleName"] = "产品分类";
    derF["FrTable"] = "e_goods_cate";
    derF["Tableurl"] = "Shop/CateInfoModify.aspx";
    derF["winW"] = 330;
    derF["winH"] = 205;
    derF["Tn"] = 30;
    derF["SortT"] = "分类";
</script> 
</head>
<body>
    <script type="text/javascript" language="javascript">
        derF["upid"] = "<%=upid %>"; if (derF["upid"] != "") { derF["upidurl"] = "&upid=" + derF["upid"]; derF["winH"] = 230; derF["Shgra"] = 1 }
</script>
<div class="tabT">
  <div class="tabTR"></div>
  <div class="tablText"> <img src="../../images/tab/tab_09.gif" width="16" height="13" /> <span class="tab4">产品分类</span></div>
  <div class="tabTAll"><a href="CateInfo.aspx">顶级分类</a>&nbsp;&nbsp;<a id="add">新增</a></div>
  <div class="tabTL"></div>
</div>
<div class="tabC">
  <div class="tabCR">
    <div class="tabCL">
      <table width="100%" border="0" cellspacing="1" cellpadding="0" class="tabSP" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)" onmouseout="pWin.changeback(event)" id="tmall">
       <tr class="tabHe">
            <td width="8%"><span>编号</span></td>
            <td width="15%"><span>父级分类</span></td>
            <td width="auto"><span>产品分类</span></td>
            <td width="8%"><span>排序</span></td>
            <td width="260"><span>管理</span></td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
           <tr align="center" inid="<%# Eval("Number")%>">
                <td><span><%#Eval("Number") %></span></td>
                <td><span><a href="CateInfo.aspx?upid=<%#Eval("upid") %>"><%# upber(Eval("upidT"))%></a></span></td>
                <td><span><%# Eval("title")%></span></td>
                <td align="center"><a gnid="Stat" title="点击排序">[<%# Eval("Stat")%>]</a></td>
                <td class="inpqx"><div style="width:260px;"><a gnid="Shgra" href="CateInfo.aspx?upid=<%# Eval("Number") %>"><img src="../../images/tab/level_down.gif" align="absmiddle" /> 子级分类</a><a gnid="sCl"><%# Eval("CloseS")%></a><a gnid="Edit">编辑</a><a gnid="Delete">删除</a></div></td>
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