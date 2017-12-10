<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodsInfo.aspx.cs" Inherits="admin_Shop_GoodsInfo"  StylesheetTheme="Member"%>
<%@ Register Src="../../Ascx/Order/Pageview.ascx" TagName="PageAdmin" TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>产品信息管理</title>
   <script type="text/javascript" src="../../Scripts/admin/ready.js"></script>
   <script type="text/javascript">
       derF["TitleName"] = "产品信息";
       derF["FrTable"] = "e_goods";
       derF["Tableurl"] = "Shop/GoodsInfoModify.aspx";
       derF["winW"] = 900;
       derF["winH"] = 360;
       derF["Tn"] = 30;
       derF["SortT"] = "产品";
       derF["ImgS"] = "ImgS";
       derF["SeW"] = 340;
       derF["SeH"] = 225;
       derF["Sealeurl"] = "Shop/GoodsSearch.aspx";
</script>
</head>
<body>
    <script type="text/javascript" language="javascript">
        derF["upid"] = "<%=upid %>";
        if (derF["upid"] != "") {
            derF["upidurl"] = "&upid=" + derF["upid"];
        }
</script>
<div class="tabT">
  <div class="tabTR"></div>
  <div class="tablText"><img src="../../images/tab/tab_09.gif" width="16" height="13" /> <span class="tab4"><%=head%>产品信息管理</span></div>
  <div class="tabTAll"><a id="Search">查询</a> <a id="add">新增</a><a id="Deleteall">删除</a></div>
  <div class="tabTL"></div>
</div>
<div class="tabC">
  <div class="tabCR">
    <div class="tabCL">
      <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabSP" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)"  onmouseout="pWin.changeback(event)" id="tmall">
        <tr class="tabHe">
            <td width="5%"><input id="ch2" type="checkbox" value="checkbox" onclick="pWin.chkalls(this)" /></td>
            <td width="18%">分类区</td>
            <td width="12%">显示图片</td>
            <td width="auto">标题</td>
            <td width="10%">价格</td>
            <td width="6%">排序</td>
            <td width="230">管理</td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <tr inid="<%# Eval("Number")%>">
              <td align="center"><input name="check" type="checkbox" value="<%# Eval("Number")%>" /></td>
              <td><span><%#toCate(Eval("upid"),Eval("upids")) %></span></td>
               <td align="center"><span class="img" simg="<%#Eval("ImgS")%>" id="m<%#mi %>"><img src="../../image/s.gif" style="background-image:url(../../Apply/avatar.aspx?Type=fixnone&size=25x20&key=<%#Eval("ImgS")%>)" /></span></td>
              <td><span><%# Eval("title") %></span></td>
              <td><span><%# MR(Eval("price")) %></span></td>
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
