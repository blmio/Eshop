<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="member_default" %>
<!doctype html>
<html class="root">
<head>
    <meta charset="utf-8">
    <title>我的e商城</title>
    <link href="../App_Themes/index/index.css" rel="stylesheet">
    <link href="../App_Themes/public/global.css" rel="stylesheet">
    <link href="../App_Themes/vip/index.css" rel="stylesheet">
    <script type="text/javascript" charset="utf-8" src="../Apply/head.aspx"></script>
</head>
<body>
    <%=top() %>
    <div class="wid">
        <div id="logo-image"><a href="../default.aspx" class="logo"></a></div>
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
    <div class="wid" style="margin-bottom: 60px;">
        <div class="crumb">首页&nbsp;&gt;&nbsp;<strong>个人中心</strong></div>
        <div class="left">
            <div class="mc-menu-area">
                <div class="h"><a href="default.aspx" class="button-go-mc" title="个人中心"><%=wrap_portrait() %></a></div>
                <div class="b">
                    <ul>
                        <li>
                            <h3><span>个人资料</span> </h3>
                            <ol>
                                <li id="li-zl"><a href="javascript:;" title="基本资料"><span>基本资料</span></a></li>
                                <li id="li-tx"><a href="javascript:;" title="头像修改"><span>头像修改</span></a></li>
                                <li id="li-mm"><a href="javascript:;" title="修改密码"><span>修改密码</span></a></li>
                            </ol>
                        </li>
                        <li>
                            <h3><span>订单中心</span> </h3>
                            <ol>
                                <li id="li-cart"><a href="javascript:;" title="我的购物车"><span>我的购物车</span></a></li>
                                 <li id="li-dd"><a href="javascript:;" title="我的订单"><span>我的订单</span></a></li>
                                <li id="li-addr"><a href="javascript:;" title="收货地址管理"><span>收货地址管理</span></a></li>
                            </ol>
                        </li>
                        <li>
                            <h3><span>社区中心</span> </h3>
                            <ol>
                                <li id="li-appra"><a href="javascript:;" title="我的评价"><span>我的评价</span></a></li>
                            </ol>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="right"></div>
        <span class="clr"></span>
    </div>
    <div class="help-link clearfix">
        <%=wrap_helplist() %>
    </div>
    <!--footer-->
    <%=footer() %>
    <!--toTop-->
    <%=goTop() %>
</body>
</html>
<script type="text/javascript">
    EDE.E["number"]= "<%=number %>";
    EDE.include('Scripts/vip/index.js');
</script>
