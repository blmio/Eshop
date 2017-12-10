<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<%@ Register Src="~/Ascx/Order/PageNum.ascx" TagName="PageNum" TagPrefix="uc4" %>
<!doctype html>
<html class="root">
<head>
    <meta charset="utf-8">
    <title><%=name %>-商品搜索-e商城</title>
    <link href="App_Themes/index/index.css" rel="stylesheet">
    <link href="App_Themes/public/global.css" rel="stylesheet">
    <link href="App_Themes/index/search.css" rel="stylesheet">
    <script type="text/javascript" charset="utf-8" src="Apply/head.aspx"></script>
    <script type="text/javascript" charset="utf-8" src="Scripts/shop/search.js"></script>
</head>
<body>
    <%=top() %>
    <div class="wid">
        <div id="logo-image"><a href="default.aspx" class="logo"></a></div>
        <div id="search">
            <ul id="helper" class="hide" style="display: none;">
            </ul>
            <div class="form">
                <input class="text" id="key" type="text" autocomplete="off" value="<%=name %>" onkeydown="javascript:if(event.keyCode==13) EDE.search('key');" style="color: rgb(153, 153, 153);" />
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
    <div class="wid main">
        <div class="crumb">全部结果&nbsp;&gt;&nbsp;<strong><%=name %></strong></div>
        <div class="left">
            <div class="m" id="refilter">
                <div class="mt">
                    <h2>所有类目</h2>
                </div>
                <div class="mc">
                    <%=wrap_leftCate() %>
                </div>
            </div>
            <div id="ad_left" class="m m0 hide" style="display: block;">
                <div class="mt">
                    <h2>同类推广</h2>
                </div>
                <div class="mc">
                    <ul><%=wrap_reco() %></ul>
                </div>
            </div>
        </div>
        <div class="right-extra">
            <div id="filter">
                <div class="fore1">
                    <dl class="order">
                        <dt>排序：</dt>
                        <dd class="curr"><a href="javascript:;" onclick="Es.sort('')">综合排序</a><b></b></dd>
                        <dd class=""><a href="javascript:;" onclick="Es.sort('3')">销量</a><b></b></dd>
                        <dd class=""><a href="javascript:;" onclick="Es.sort('1')">价格</a><b></b></dd>
                        <dd class=""><a href="javascript:;" onclick="Es.sort('4')">浏览量</a><b></b></dd>
                    </dl>
                    <span class="clr"></span>
                </div>
            </div>
            <div class="m gl-type-6 prebuy plist-n7" id="plist">
                <ul class="list-h clearfix">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="lh-wrap">
                                    <div class="p-img">
                                        <a target="_blank" href="item.aspx?id=<%#Eval("emid") %>" title="<%#Eval("subtitle") %>">
                                            <img width="220" height="220" data-img="1" src="<%#showImg(Eval("ImgS")) %>" class="err-product">
                                        </a>
                                        <div></div>
                                    </div>
                                    <div class="p-name"><a target="_blank" href="item.aspx?id=<%#Eval("emid") %>" title="<%#Eval("subtitle") %>"><%#showTitle(Eval("title")) %><font class="adwords"><%#Eval("subtitle") %></font> </a></div>
                                    <div class="p-price"><em></em><strong>￥<%#MR(Eval("price")) %></strong> </div>
                                    <div class="extra"><span>总销量<%#Eval("BuyT") %>件</span></div>
                                    <div class="btns"><a href="javascript:Es.addCart(<%#Eval("emid") %>);" class="btn-buy" stock="<%#Eval("emid") %>">加入购物车</a></div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul runat="server" id="NoCh" visible="false" class="list-h clearfix">
                    <li style="width: 98%">
                        <p class="NoCh" style="text-align: center;">
                            没有找到该商品，试试别的吧！
                        </p>
                    </li>
                </ul>
            </div>
            <div class="m clearfix" id="bottom_pager">
                <div class="page fr">
                    <uc4:PageNum ID="PageNum1" runat="server" />
                </div>
            </div>
            <div id="re-search" class="m">
                <dl>
                    <dt>重新搜索</dt>
                    <dd>
                        <input type="text" class="text" id="key-re-search" onkeydown="javascript:if(event.keyCode==13){EDE.search('key-re-search');return false;}" value="">
                        <input type="button" class="button" onclick="EDE.search('key-re-search')" id="btn-re-search" value="搜&nbsp;索">
                    </dd>
                </dl>
            </div>
        </div>
        <span class="clr"></span>
    </div>
    <div class="help-link clearfix">
        <%=wrap_helplist() %>
    </div>
    <!--footer-->
    <%=footer() %>
    <%=goTop() %>
</body>
</html>
