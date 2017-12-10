<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" class="root">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>e商城-综合网购首选-正品低价、品质保障、货到付款、配送及时、放心服务、轻松购物！</title>
    <link href="App_Themes/index/index.css" rel="stylesheet" />
    <link href="App_Themes/public/global.css" rel="stylesheet" />
    <link href="App_Themes/index/error.css" rel="stylesheet" />
    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <script type="text/javascript" charset="utf-8" src="Apply/head.aspx"></script>
    <script type="text/javascript" charset="utf-8" src="Scripts/index.js"></script>
</head>
<body>
    <%=top() %>
    <div class="wid">
        <div id="logo-image"><a href="default.aspx" class="logo"></a></div>
        <div id="search">
            <ul id="helper" class="hide" style="display: none;">
            </ul>
            <div class="form">
                <input class="text" id="key" type="text" autocomplete="off" onkeydown="javascript:if(event.keyCode==13) EDE.search('key');" style="color: rgb(153, 153, 153);" />
                <button class="button cw-icon" onclick="EDE.search('key');return false;"><i></i>搜索</button>
            </div>
        </div>
        <div id="settleup" class="dorpdown"><%=refrCart() %></div>
        <div id="hotwords"><strong>热门搜索：</strong><%=wrap_hotwords() %></div>
        <span class="clr"></span>
    </div>
    <div id="nav" class="sub" style="padding-left: 0px; margin-bottom: 0px;">
        <div class="wid">
            <h2>全部商品分类</h2>
            <ul id="navitems"><%=wrap_navitems() %></ul>
        </div>
    </div>
    <div class="wid">
        <div class="notice-search">
            <div class="ns-wrap clearfix info">
                <span class="ns-icon"></span>
                <div class="ns-content"><span><%=tip_info %></span> </div>
            </div>
        </div>
    </div>
    <div class="help-link clearfix">
        <%=wrap_helplist() %>
    </div>
    <%=footer() %>
    <%=goTop() %>
</body>
</html>
