<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="member_login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户登录</title>
    <link href="../App_Themes/public/global.css" rel="stylesheet" />
    <link href="../App_Themes/vip/login.css" rel="stylesheet" />
    <script type="text/javascript" charset="utf-8" src="../Apply/head.aspx"></script>
    <script type="text/javascript" charset="utf-8" src="../Scripts/vip/login.js"></script>
</head>
<body>
    <div class="wid">
        <div id="logo">
            <a href="../default.aspx">
                <img src="../image/logo-b.png" width="170" height="60" alt="" />
            </a><b></b>
        </div>
    </div>
    <div id="content">
        <div class="login-wrap">
            <div class="wid">
                <div class="login-form">
                    <div class="login-box">
                        <div class="mt clearfix">
                            <h1>e商城会员</h1>
                            <div class="extra-r">
                                <div class="regist-link"><a href="register.aspx"><b></b>立即注册</a></div>
                            </div>
                        </div>
                        <div class="msg-wrap">
                            <div class="msg-warn" style="display: block;"><b></b>公共场所不建议自动登录，以防账号丢失</div>
                            <div class="msg-error" style="display: none;"></div>
                        </div>
                        <div class="mc">
                            <div class="form">
                                <form id="formlogin" method="post">
                                    <div class="item item-fore1">
                                        <label for="loginname" class="login-label name-label"></label>
                                        <input id="loginname" type="text" class="itxt" name="loginname" autocomplete="off" placeholder="邮箱/用户名/已验证手机" value="<%=Rv[0] %>" maxlength="25"/>
                                    </div>
                                    <div id="entry" class="item item-fore2">
                                        <label class="login-label pwd-label" for="nloginpwd"></label>
                                        <input type="password" id="nloginpwd" name="nloginpwd" class="itxt itxt-error" autocomplete="off" placeholder="密码" value="<%=Rv[1] %>" maxlength="16"/>
                                    </div>
                                    <div class="item item-fore3">
                                        <div class="safe">
                                            <span>
                                                <input id="autoLogin" name="chkRememberMe" type="checkbox" class="checkbox" checked="checked" value="on"/>
                                                <label for="">自动登录</label>
                                                <script type="text/javascript">
                                                    EDE.E["autoLogin"] = "<%=Rv[2] %>";
                                                </script>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="item item-fore4">
                                        <div class="login-btn"><a href="javascript:;" class="btn-img btn-entry" id="loginsubmit">登&nbsp;&nbsp;&nbsp;&nbsp;录</a> </div>
                                    </div>
                                </form>
                            </div>
                            <div class="coagent">
                                <h5>使用合作网站账号登录：</h5>
                                <ul>
                                    <li><a href="javascript:;" class="weibo-login" url="<%=sinaKey %>&redirect_uri=<%=scallbackUrl %>&state=<%=sinaSecret %>">新浪微博</a> <span class="line">|</span> </li>
                                    <li><a href="javascript:;" class="qq-login" url= "<%=qqKey %>&redirect_uri=<%=qcallbackUrl %>&scope=<%=scope %>&state=<%=qqSecret %>">QQ</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="login-banner" style="background-color: #97eff9">
                <div class="wid">
                    <div id="banner-bg" class="i-inner" style="background: url(../image/553f2c2dNf7da5639.jpg) 0px 0px no-repeat; background-color: #97eff9"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="foot">
        <ul>
            <li><a target="_blank" href="#" rel="nofollow">关于我们</a> | <a target="_blank" href="#" rel="nofollow">联系我们</a> | <a href="#" target="_blank">网站地图</a> | <a rel="nofollow" href="#">监督投诉</a> | <a href="#" rel="nofollow" target="_blank">企业服务</a> | <a href="#" target="_blank">友情链接</a> </li>
        </ul>
        <ul>
            <li>Copyright © 2015 ESHOP.COM All Rights Reserved.</li>
        </ul>
    </div>
</body>
</html>