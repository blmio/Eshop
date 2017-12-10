var Es = {
    E: new Object(),
    error: function (message) {
        $("#content .msg-warn").css('display', 'none');
        $("#content .msg-error").css('display', 'block');
        $("#content .msg-error").html("<b></b>" + message);
    },
    getUrlParam: function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    },
    Iaffact: function () {
        //输入框效果切换
        $("#loginname,#nloginpwd").focusin(function () {
            $("#formlogin .item").each(function (index, element) {
                $(this).removeClass('item-focus');
            })
            $(this).parent().addClass('item-focus');
        }).focusout(function () {
            $("#formlogin .item").each(function (index, element) {
                $(this).removeClass('item-focus');
            })
        })

        //自动登录提示
        $("#autoLogin").click(function () {
            if ($(this).attr("checked") == true) {
                $("#content .msg-error").css('display', 'none');
                $("#content .msg-warn").css('display', 'block');
            }
            else
                $("#content .msg-warn").css('display', 'none');
        });

        $("#loginsubmit").click(function () { Es.Login(); });
        $("#loginname").keydown(function (event) { if (event.keyCode == 13) { Es.Login(); } });
        $("#nloginpwd").keydown(function (event) { if (event.keyCode == 13) { Es.Login(); } });
        if (EDE.E["autoLogin"] == "on") { Es.Login(); }
    },
    Login: function () {
        var name = $("#loginname"), pwd = $("#nloginpwd");
        if (!EDE.trim(name.val()) && !EDE.trim(pwd.val())) {
            Es.error('请输入账户名和密码');
            $(".item-fore1").addClass('item-error');
            $(".item-fore2").addClass('item-error');
            return false;
        }
        else if (!EDE.trim(name.val()) || !EDE.trim(pwd.val())) {
            if (!EDE.trim(name.val())) {
                Es.error('请输入账户名');
                $(".item-fore1").addClass('item-error');
                $(".item-fore2").removeClass('item-error');
                return false;
            }
            else {
                Es.error('请输入密码');
                $(".item-fore1").removeClass('item-error');
                $(".item-fore2").addClass('item-error');
                return false;
            }
        }
        $(".item-fore1").removeClass('item-error');
        $(".item-fore2").removeClass('item-error');
        
        //提交表单
        $("#loginsubmit").html('正在登录...');
        EDE.submitForm("#formlogin", "login");
    },
    Xerror: function (message) {
        var msgArr = message.split('|');
        $("#formlogin").disabled = false;
        if (msgArr[1] == '1') {
            //alert(msgArr[2]);
            EDE.URLfor();
            var url = EDE.URLParams["url"];
            if (!EDE.trim(url)) url = Eurl + 'default.aspx';
            location.href = unescape(url);
            return;
        }
        //登录错误
        $("#loginsubmit").html('登&nbsp;&nbsp;&nbsp;&nbsp;录');
        Es.error(msgArr[2]);
        if (msgArr[1] == '2')
            $(".item-fore1").addClass('item-error');
        else
            $(".item-fore2").addClass('item-error');
    },
    cooperLogin: function () {
        /*合作登录接口*/
        $(".weibo-login").click(function () {
            var url = $(this).attr('url');
            var header = "https://api.weibo.com/oauth2/authorize?response_type=code&client_id=";
            window.open(header + url);
        });
        $(".qq-login").click(function () {
            var url = $(this).attr('url');
            var header = "http://openapi.qzone.qq.com/oauth/show?which=ConfirmPage&display=pc&response_type=code&client_id=";
            window.open(header + url);
        });
    }
}

$(document).ready(function () {
    Es.Iaffact();
    Es.cooperLogin();
})