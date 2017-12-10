<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" class="root">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>e商城-综合网购首选-正品低价、品质保障、货到付款、配送及时、放心服务、轻松购物！</title>
    <link href="App_Themes/index/index.css" rel="stylesheet" />
    <link href="App_Themes/public/global.css" rel="stylesheet" />
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
    <div id="nav" style="padding-left: 0px; margin-bottom: 0px;">
        <div class="wid">
            <h2>全部商品分类</h2>
            <ul id="navitems"><%=wrap_navitems() %></ul>
        </div>
    </div>
    <div class="aucSlider">
        <div class="wid clearfix">
            <!--分类-->
            <div class="aucCategorys">
                <%=wrap_cate() %>
            </div>
        </div>
        <%=wrap_flash() %>
    </div>
    <div id="oa_layout">
        <div class="hot-wrap clearfix">
            <div class="wid hot-recom-done" id="hot-recom">
                <div id="recomyou" class="m">
                    <div class="mt">
                        <h2>热品推荐</h2>
                    </div>
                    <div class="mc">
                        <ul><%=wrap_recomyou() %></ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="wid">
            <div class="floorList">
                <!--商品列表-->
                <div id="gd-pj" class="oa-floor">
                    <div class="mt">电脑配件</div>
                    <div class="mc">
                       <%=wrap_floorList("电脑配件") %>
                    </div>
                </div>
                <div id="gd-sj" class="oa-floor">
                    <div class="mt">手机配件</div>
                    <div class="mc">
                       <%=wrap_floorList("手机配件") %>
                    </div>
                </div>
                <div id="gd-sm" class="oa-floor">
                    <div class="mt">数码影音</div>
                    <div class="mc">
                       <%=wrap_floorList("数码影音") %>
                    </div>
                </div>
                <div id="gd-jd" class="oa-floor">
                    <div class="mt">家用电器</div>
                    <div class="mc">
                       <%=wrap_floorList("家用电器") %>
                    </div>
                </div>
                <div id="gd-bg" class="oa-floor">
                    <div class="mt">办公打印</div>
                    <div class="mc">
                       <%=wrap_floorList("办公打印") %>
                    </div>
                </div>
                <div id="gd-wl" class="oa-floor">
                    <div class="mt">网络产品</div>
                    <div class="mc">
                       <%=wrap_floorList("网络产品") %>
                    </div>
                </div>
                <div id="gd-ws" class="oa-floor">
                    <div class="mt">外设产品</div>
                    <div class="mc">
                       <%=wrap_floorList("外设产品") %>
                    </div>
                </div>
                <div id="gd-fw" class="oa-floor">
                    <div class="mt">服务产品</div>
                    <div class="mc">
                       <%=wrap_floorList("服务产品") %>
                    </div>
                </div>
            </div>
        </div>
        <div class="wid">
            <div id="pc-link">
                <div class="mt"></div>
                <div class="mc">
                        <ul><%=wrap_ads_flash() %></ul>
                </div>
            </div>
        </div>
    </div>
    <div class="help-link clearfix"><%=wrap_helplist() %>
    </div>
    <%=footer() %>
    <%=goTop() %>
</body>
</html>