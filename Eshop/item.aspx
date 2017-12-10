<%@ Page Language="C#" AutoEventWireup="true" CodeFile="item.aspx.cs" Inherits="item" %>
<!doctype html>
<html class="root">
<head>
    <meta charset="utf-8">
    <title><%=Vt[4] %>-e商城</title>
    <link href="App_Themes/index/index.css" rel="stylesheet">
    <link href="App_Themes/public/global.css" rel="stylesheet">
    <link href="App_Themes/index/item.css" rel="stylesheet">
    <script type="text/javascript" charset="utf-8" src="Apply/head.aspx"></script>
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
    <div id="root-nav">
        <div class="wid">
            <!--导航标题-->
            <div class="breadcrumb"><%=wrap_breadcrumb() %></div>
        </div>
    </div>
    <!--info box-->
    <div id="p-box">
        <div class="wid">
            <div id="product-intro" class="m-item-grid clearfix">
                <div id="preview">
                    <div id="spec-n1" class="jqzoom">
                        <img class="err-product" width="350" height="350" src="<%=Vt[7].Replace("~/","") %>" alt="<%=Vt[4] %>" />
                    </div>
                </div>
                <div class="m-item-inner">
                    <div id="itemInfo">
                        <div id="name">
                            <h1><%=Vt[4] %></h1>
                            <div id="p-ad" class="p-ad"><%=Vt[5] %></div>
                        </div>
                        <div id="summary">
                            <div id="comment-count">
                                <p class="comment">总销量</p>
                                <a class="count" href="#comment"><%=Vt[8] %></a>
                            </div>
                            <div id="summary-price">
                                <div class="dt">价&nbsp;&nbsp;格：</div>
                                <div class="dd"><strong class="p-price" id="jd-price">￥<%=MR(Vt[6]) %></strong> </div>
                            </div>
                            <div id="summary-num">
                                <div class="dt">商品信息：</div>
                                <div class="dd clearfix"><%=Vt[3] %></div>
                            </div>
                            <div id="summary-stock">
                                <div class="dt">运&nbsp;&nbsp;费：</div>
                                <div class="dd">免运费</div>
                            </div>
                            <div id="summary-service">
                                <div class="dt">服&nbsp;&nbsp;务：</div>
                                <div class="dd">由e商城负责发货，并提供售后服务</div>
                            </div>
                        </div>
                        <div id="choose" class="clearfix p-choose-wrap">
                            <div id="choose-btns" class="li">
                                <div class="choose-amount fl">
                                    <div class="wrap-input">
                                        <a class="btn-reduce" href="javascript:;">-</a> <a class="btn-add" href="javascript:;">+</a>
                                        <input class="text" id="buy-num" value="1" maxlength="5"/>
                                    </div>
                                </div>
                                <div class="btn" id="choose-btn-append"><a class="btn-append" id="add-cart" href="javascript:Es.addCart();">加入购物车</a></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--content-->
    <div class="wid">
        <div class="right">
            <div id="product-detail" class="m m1">
                <div class="mt J-detail-tab" id="pro-detail-hd">
                    <div class="mt-inner m-tab-trigger-wrap clearfix">
                        <ul class="m-tab-trigger">
                            <li id="detail-tab-intro" class="ui-switchable-item trig-item curr"><a href="javascript:;">商品介绍</a></li>
                            <li id="detail-tab-list" class="ui-switchable-item trig-item"><a href="javascript:;">包装清单</a></li>
                            <li id="detail-tab-comm" class="ui-switchable-item trig-item"><a href="javascript:;">商品评价<em class="hl_blue hide" style="display: inline;">(<%=totalAppra %>)</em></a></li>
                            <li id="detail-tab-prom" class="ui-switchable-item trig-item"><a href="javascript:;">售后保障</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="ui-switchable-panel ui-switchable-panel-selected" style="display: block">
                <div class="mc" id="product-detail-1">
                    <!--详情介绍-->
                    <%=wrap_parameter() %>
                    <!--图片介绍-->
                    <%=wrap_detail() %>
                </div>
            </div>
            <div class="ui-switchable-panel mc hide" id="product-detail-2" style="display: none;">
                <div class="item-detail"><%=Vt[10] %></div>
            </div>
            <div class="ui-switchable-panel mc hide" id="product-detail-3" style="display: none;">
                    <div id="state"> <strong>权利声明：</strong><br>
      e商城上的所有商品信息、客户评价、商品咨询、网友讨论等内容，是e商城重要的经营资源，未经许可，禁止非法转载使用。
      <p><b>注：</b>本站商品信息均来自于合作方，其真实性、准确性和合法性由信息拥有者（合作方）负责。本站不提供任何保证，并不承担任何法律责任。</p>
    </div>
    <div id="comments-list" class="m">
        <%=wrap_appra() %>
<%--      <div class="mt">
        <div class="mt-inner m-tab-trigger-wrap clearfix">
          <ul class="m-tab-trigger">
            <li class="ui-switchable-item trig-item curr" ><a href="javascript:;">全部评价<em>(380)</em></a></li>
            <li class="ui-switchable-item trig-item" ><a href="javascript:;">好评<em>(368)</em></a></li>
            <li class="ui-switchable-item trig-item" ><a href="javascript:;">中评<em>(8)</em></a></li>
            <li class="ui-switchable-item trig-item" ><a href="javascript:;">差评<em>(4)</em></a></li>
          </ul>
        </div>
      </div>
      <div id="comment-0" class="mc ui-comments-panel comments-table ui-comments-panel-selected" style="display:block">
        <div class="com-table-header"> <span class="item column1">评价心得</span> <span class="item column2">评价等级</span> <span class="item column3">购买时间</span> <span class="item column4">评论者</span> </div>
        <div class="com-table-main">
          <div class="comments-item">
            <ul class="clearfix">
              <li class="item1"> <span>质量配件全新，还送了鼠标，用了以后可以考虑添加一块显卡了。</span> <b>2015-05-21 17:34</b> </li>
              <li class="item2"> <span>好评</span> </li>
              <li class="item3"> <span>2015-05-21 17:34</span> </li>
              <li class="item4"> <span>macneil</span> </li>
            </ul>
          </div>
        </div>
      </div>
        <div id="comment-1" class="mc hide ui-comments-panel comments-table" style="display:none;" ></div>
        <div id="comment-2" class="mc hide ui-comments-panel comments-table" style="display:none;" ></div>
        <div id="comment-3" class="mc hide ui-comments-panel comments-table" style="display:none;" ></div>--%>
      </div>
            </div>
            <div class="ui-switchable-panel mc hide" id="product-detail-4" style="display: none;">
                <div class="item-detail">
                    本产品全国联保，享受三包服务，质保期为：一年质保<br>
                    您可以查询本品牌在各地售后服务中心的联系方式，<a target="_blank" href="http://www.eshop.com/">请点击这儿查询......</a><br>
                    <br>
                    品牌官方网站：<a target="_blank" href="http://www.eshop.com/">http://www.eshop.com/</a><br>
                    售后服务电话：400-887-8912<br>
                </div>
            </div>
        </div>
        <div class="left">
            <div id="sp-reco" data-rid="509001" class="m m2 m3">
                <div class="mt">
                    <h2>热门推荐</h2>
                </div>
                <div class="mc">
                    <!--热门推荐-->
                    <ul><%=wrap_reco() %></ul>
                </div>
            </div>
        </div>
        <span class="clr"></span>
    </div>
    <div style="height: 50px;"></div>
    <div class="help-link clearfix">
        <%=wrap_helplist() %>
    </div>
    <!--footer-->
    <%=footer() %>
    <%=goTop() %>
</body>
</html>
<script type="text/javascript">
    EDE.E["em-id"] = "<%=goodId %>";
    EDE.include('Scripts/shop/item.js');
</script>