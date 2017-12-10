<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="member_register" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>用户注册</title>
<link href="../App_Themes/public/global.css" rel="stylesheet" />
<link href="../App_Themes/vip/register.css" rel="stylesheet" />
<script type="text/javascript" charset="utf-8" src="../Apply/head.aspx"></script>
<script type="text/javascript" charset="utf-8" src="../Scripts/vip/register.js"></script>
</head>
<body>
<div class="wid">
  <div id="logo"> <a href="../default.aspx"> <img src="../image/logo-b.png" width="170" height="60" alt="" /> </a> <b></b> </div>
</div>
<div id="content">
  <div class="reg-wrap">
    <div class="wid">
      <div class="reg-form">
        <div class="reg-box">
          <div class="mt clearfix">
            <h1>免费注册</h1>
            <div class="extra-r">
              <span>已有账户，<a href="login.aspx" style="color: #005AA0;">立即登录</a></span>
            </div>
          </div>
          <div class="msg-wrap">
            <div class="msg-warn" style="display:none;"></div>
            <div class="msg-error" style="display:none;"></div>
          </div>
          <div class="mc">
            <div class="form">
              <form id="formreg" method="post" onsubmit="return false;">
                <div class="item item-fore1">
                  <label for="regname" class="reg-label name-label"></label>
                  <input id="regname" type="text" class="itxt" name="regname" autocomplete="off" placeholder="用户名" maxlength="25" >
                </div>
                <div id="entry" class="item item-fore2">
                  <label class="reg-label pwd-label" for="nregpwd"></label>
                  <input type="password" id="nregpwd" name="nregpwd" class="itxt itxt-error" autocomplete="off" placeholder="密码" maxlength="16" > 
                </div>
                <div id="esure" class="item item-fore3">
                  <label class="reg-label pwd-label" for="sregpwd"></label>
                  <input type="password" id="sregpwd" name="sregpwd" class="itxt itxt-error" autocomplete="off" placeholder="确认密码" maxlength="16" >
                </div>
                <div id="o-authcode" class="item item-vcode item-fore4">
                  <input id="authcode" type="text" class="itxt itxt02" name="authcode" maxlength="4" >
                  <img id="E_Verification1" class="verify-code" src="../image/s.gif" width="100" height="33" /> <a href="javascript:void(0);" class="change-code" >看不清楚换一张</a> </div>
                <div class="item item-fore5">
                  <div class="safe"> <span>
                    <input id="readme" type="checkbox" class="checkbox" checked="checked" >
                    <label for="">我已阅读并同意<a href="#" class="blue" id="protocol">《e商城用户注册协议》</a></label>
                    </span> </div>
                </div>
                <div class="item item-fore6">
                  <div class="reg-btn"> <a href="javascript:;" class="btn-img btn-entry" id="regsubmit" >立即注册</a> </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="reg-banner" style="background-color: #5e8f36">
      <div class="wid">
        <div id="banner-bg" class="i-inner" style="background: url(../image/5538abcbNd9d7a62e.jpg) 0px 0px no-repeat;background-color: #5e8f36"></div>
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
