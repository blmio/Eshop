<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>e商城-后台登录系统</title>
<link href="login/global.css" rel="stylesheet"/>
<link href="login/login.css" rel="stylesheet"/>
<script src="../Scripts/jquery/jquery-min.js" type="text/javascript"></script>
<script src="login/login.js" type="text/javascript"></script>
<%--    <script type="text/javascript">
        var path = "Apply/xmlWrite.aspx?mod=addCate";
        $.get(path, function (data) {
            alert(data);
        })
    </script>--%>
</head>
<body>
<div id="content">
  <div class="msg-wrap">
    <div class="msg-error" style="display:none;"></div>
  </div>
  <form id="adform" class="form" method="post" >
    <div class="item"> <span class="u_logo"></span>
      <input name="adname" class="itxt" type="text" placeholder="手机号/邮箱/用户名" autocomplete="off" value="<%=Rv[0] %>" maxlength="25" />
    </div>
    <div class="item"> <span class="p_logo"></span>
      <input name="adpassword" class="itxt" type="password" placeholder="密码 (6~32 个字符)" autocomplete="off" value="<%=Rv[1] %>" maxlength="16" />
    </div>
    <div class="item">
      <div class="login-wrap">
        <div class="safe fl">
          <input name="chkRememberMe" type="checkbox" class="checkbox" checked="checked" value="on" />
          <span>记住我</span> 
        </div>
        <div class="login-btn fr"> <a href="javascript:;" class="btn-img" id="loginsumbit">登录</a> </div>
      </div>
    </div>
  </form>
</div>
     <script type="text/javascript">
         Es.E["reme"] = "<%=Rv[2] %>";
     </script>
</body>
</html>
