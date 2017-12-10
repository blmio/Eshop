if (window == top) top.location.href = "../";
var pWin = window.parent.parent;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js"></script>');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery.cxcalendar.min.js\"></script>');
document.write('<link href="' + pWin.url + 'Scripts/jquery/jquery.cxcalendar.css" type="text/css" rel="stylesheet" />');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/ext/showDialog.js"></script>');
var Me = {
    ci: new Array(6),
    Bot: new Object(),
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    SubMobil: function (val) {
        var reg = /^(((13[0-9]{1})|(14[0-9]{1})|(15[0-9]{1})|(18[0-9]{1})|(17[0-9]{1})|(16[0-9]{1}))+\d{8})$/;
        if (val.match(reg)) { return true; } return false;
    },
    SubEmail: function (val) {
        var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
        if (reg.test(val)) { return true; } return false;
    },
    Durl: pWin.url + "Apply/script/Dselect.aspx?from=city&typeID=Number&typeName=title&HTML=$&where=upid&Number=",
    loadfun: function () {
        $("#tabbtm p a").click(function () {
            var tid = $(this).attr("id");
            $(this).parent("p").addClass("p").siblings().removeClass();
            $("#div" + tid).css("display", "block").siblings("div.dili").css("display", "none");
        });

        $("#Name").focusout(function () { Me.focusoutCh(this, "会员名", 1); });
        $("#Email").focusout(function () { Me.focusoutCh(this, "联系邮箱", 0); });
        $("#Mobile").focusout(function () { Me.focusoutCh(this, "联系手机", 0); });
        $("#Lotimes").focusout(function () { Me.NisN0(this, "登录次数"); });
    },
    focusoutCh: function (obj, T, vs) {
        var na = $(obj).attr("name");
        var va = $(obj).val();
        if (!Me.trim(va) && vs == 1) {
            Me.Bot["errt-" + na] = T + "是必填项!";
            pWin.BalC(Me.Bot["errt-" + na], na, "t1");
            Me.Bot[na] = 1;
        } else if (va != Me.Bot["Vr-" + na]) {
            var tm = new Date().getTime();
            var geturl = pWin.url + "Apply/xmlWrite.aspx?mod=ckName&key=" + na;
            geturl += "&val=" + escape(va) + "&tm=" + tm;
            $.get(geturl, function (data) {
                if (data == "1") {
                    Me.Bot[na] = 1;
                    Me.Bot["errt-" + na] = va + "已存在,请填写其它" + T;
                    pWin.BalC(Me.Bot["errt-" + na], na, "t1");
                } else {
                    Me.Bot["errt-" + na] = '';
                    Me.Bot[na] = 0;
                }
            });
        }
    },
    NisN0: function (v, T, tv) {
        var val = $(v);
        if (isNaN(val.val())) {
            pWin.BalC(T + "必须是数字类型!", val.attr("id"), tv);
            val.val('0');
            return false;
        }
        return true;
    },
    gotoB: function () {
        if (pWin.Boxif("会员名不能为空！", "Name")) return false;
        if (Me.Bot['Name'] == 1) {
            pWin.BalC(Me.Bot["errt-Name"], "Name");
            return false;
        }
        var pwd = $("#pwd").val();
        if (!Me.trim(pwd) && !Me.trim($("#Password").val())) {
            pWin.BalC("登录密码不能为空！", "Password");
            return false;
        }
        var Emav = $("#Email").val();
        if (Me.trim(Emav)) {
            if (!Me.SubEmail(Emav)) {
                pWin.BalC("电子邮箱格式不正确！", "Email");
                return false;
            } else if (Me.Bot['Email'] == 1) {
                pWin.BalC(Me.Bot["errt-Email"], "Email");
                return false;
            }
        }
        var Mobiv = $("#Mobile").val();
        if (Me.trim(Mobiv)) {
            if (!Me.SubMobil(Mobiv)) {
                pWin.BalC("手机号码格式错误！", "Mobile");
                return false;
            } else if (Me.Bot['Mobile'] == 1) {
                pWin.BalC(Me.Bot["errt-Mobile"], "Mobile");
                return false;
            }
        }
        var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    },
    tabbtm: function (v) {
        if (Me.trim(v)) {
            $("#" + v).parent("p").addClass("p").siblings().removeClass();
            $("#div" + v).css("display", "block").siblings("div.dili").css("display", "none");
        }
    }
}
function gotoB() { Me.gotoB(); }
function tabbtm(v) { Me.tabbtm(v); }