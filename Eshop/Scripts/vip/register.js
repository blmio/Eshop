var Es = {
    E: new Object(),
    error: function (message) {
        $("#content .msg-warn").css('display', 'none');
        $("#content .msg-error").css('display', 'block');
        $("#content .msg-error").html("<b></b>" + message);
    },
    warn: function (message) {
        $("#content .msg-error").css('display', 'none');
        $("#content .msg-warn").css('display', 'block');
        $("#content .msg-warn").html("<b></b>" + message);
    },
    CodeImg: function (v) {
        if (v) {
            EDE.$(v + "E_Verification1").src = Eurl + "Apply/codeImg.aspx?timestamp=" + new Date().getTime();
        } else {
            EDE.$("E_Verification1").src = Eurl + "Apply/codeImg.aspx?timestamp=" + new Date().getTime();
        }
    },
    getUrlParam: function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    },
    seTname: function (v) {
        //只能是中文，英文，数字：
        var reg = /^(\w|[\u4E00-\u9FA5])*$/;
        if (v.match(reg))
            return true;
        else
            return false;
    },
    hasChar: function (s) {
        var reg = /^[a-zA-Z0-9]*$/g;
        if (reg.test(s)) { return true; }
        return false;
    },
    getByteLen: function (val) {
        return val.replace(/[^\x00-\xff]/g, '**').length;
    },
    ckName: function (th, thui) {
        var va = $(th).val();
        var name = $(th).attr("name");
        var time = new Date().getTime();
        var url = Eurl + "Apply/xmlWrite.aspx?mod=ckName&key=Name";
        url += "&val=" + escape(va) + "&tm=" + time;
        $.get(url, function (data) {
            if (data == "1") {
                EDE.E[name] = 1;
                thui.addClass('item-error');
                Es.error('该用户名已被注册');
            }
            else {
                EDE.E[name] = 0;
                $("#content .msg-error").css('display', 'none');
                $("#content .msg-warn").css('display', 'none');
            }
        })
    },
    ckCode: function (th, thui) {
        var va = $(th).val();
        var name = $(th).attr("name");
        var time = new Date().getTime();
        var url = Eurl + "Apply/xmlWrite.aspx?mod=ckCode&val=" + escape(va) + "&tm=" + time;
        $.get(url, function (data) {
            if (data == "1") {
                EDE.E[name] = 1;
                thui.addClass('item-error');
                Es.error('验证码错误');
            }
            else {
                EDE.E[name] = 0;
                $("#content .msg-error").css('display', 'none');
                $("#content .msg-warn").css('display', 'none');
            }
        })
    },
    Signup: function () {
        EDE.$("E_Verification1").src = Eurl + 'Apply/codeImg.aspx';
        $("#o-authcode .change-code").click(function () { Es.CodeImg() });
        $("#formreg .item .itxt").focusin(function () {
            $(this).parent().addClass('item-focus');
            var name = $(this).attr("name");
            switch (name) {
                case "regname":
                    Es.warn('5-25个字符,一个汉字为两个字符');
                    break;
                case "nregpwd":
                    Es.warn('6-16个字符，请使用字母加数字或符号组合');
                    break;
                case "sregpwd":
                    Es.wran('请重复输入密码');
                    break;
                case "authcode":
                    Es.wran('请输入图形验证码');
                    break;
            }
        }).focusout(function () {
            $(this).parent().removeClass('item-focus').removeClass('item-error');
            var name = $(this).attr("name");
            var va = $(this).val();
            var count = Es.getByteLen(va);
            switch (name) {
                case "regname":
                    if (!EDE.trim(va)) {
                        Es.error('请填写用户名哦');
                        $(this).parent().addClass('item-error');
                    } else if (count < 5) {
                        Es.error('请输入5-25位字母或数字或中文');
                        $(this).parent().addClass('item-error');
                    } else if (!Es.seTname(va)) {
                        Es.error('请输入5-25位字母或数字或中文');
                        $(this).parent().addClass('item-error');
                    } else
                        Es.ckName(this, $(this).parent());
                    break;
                case "nregpwd":
                    if (!EDE.trim(va)) {
                        Es.error('请设置密码哦');
                        $(this).parent().addClass('item-error');
                    } else if (count < 6) {
                        Es.error('请输入6-16位字母、数字或符号');
                        $(this).parent().addClass('item-error');
                    }
                    else {
                        $("#content .msg-error").css('display', 'none');
                        $("#content .msg-warn").css('display', 'none');
                    }
                    break;
                case "sregpwd":
                    var npwd = $(this).parent().parent().find(".item input[name='nregpwd']");
                    if (!EDE.trim(va)) {
                        Es.error('请填写确认密码哦');
                        $(this).parent().addClass('item-error');
                    } else if (va != npwd.val()) {
                        Es.error('两次密码不一致');
                        $(this).parent().addClass('item-error');
                    } else {
                        $("#content .msg-error").css('display', 'none');
                        $("#content .msg-warn").css('display', 'none');
                    }
                    break;
                case "authcode":
                    if (!EDE.trim(va)) {
                        Es.error('请填写验证码哦');
                        $(this).parent().addClass('item-error');
                    } else 
                        Es.ckCode(this, $(this).parent());
                    break;
            }
        })
        $("#regsubmit").click(function () { Es.signSumbit(this) });
    },
    signSumbit: function (th) {
        var em = $(th).parent().parent().parent().find(".item .itxt");
        var eid = $(th).attr("id");
        var bof = true;
        em.each(function (index, element) {
            var name = $(this).attr("name");
            var va = $(this).val();
            var count = Es.getByteLen(va);
            switch (name) {
                case "regname":
                    if (!EDE.trim(va)) {
                        Es.error('请填写用户名哦');
                        $(this).parent().addClass('item-error');
                        bof = false;
                        return false;
                    } else if (count < 5) {
                        Es.error('请输入5-25位字母或数字或中文');
                        $(this).parent().addClass('item-error');
                        bof = false;
                        return false;
                    } else if (!Es.seTname(va)) {
                        Es.error('请输入5-25位字母或数字或中文');
                        $(this).parent().addClass('item-error');
                        bof = false;
                        return false;
                    } else if (EDE.E[name] == 1) {
                        Es.error('该用户名已被注册');
                        bof = false;
                        return false;
                    }
                    break;
                case "nregpwd":
                    if (!EDE.trim(va)) {
                        Es.error('请设置密码哦');
                        $(this).parent().addClass('item-error');
                        bof = false;
                        return false;
                    } else if (count < 6) {
                        Es.error('请输入6-16位字母、数字或符号');
                        $(this).parent().addClass('item-focus');
                        bof = false;
                        return false;
                    }
                    break;
                case "sregpwd":
                    var npwd = $(this).parent().parent().find(".item input[name='nregpwd']");
                    if (!EDE.trim(va)) {
                        Es.error('请填写确认密码哦');
                        $(this).parent().addClass('item-error');
                        bof = false;
                        return false;
                    } else if (va != npwd.val()) {
                        Es.error('两次密码不一致');
                        $(this).parent().addClass('item-error');
                        bof = false;
                        return false;
                    } 
                    break;
                case "authcode":
                    if (!EDE.trim(va)) {
                        Es.error('请填写验证码哦');
                        $(this).parent().addClass('item-focus');
                        bof = false;
                        return false;
                    } else if (EDE.E[name] == 1) {
                        Es.error('验证码错误');
                        $(this).parent().addClass('item-error');
                        bof = false;
                        return false;
                    }
                    break;
            }
        })

        if (!bof) { return false; }
        if ($("#readme").attr("checked") == false) {
            Es.error('请接受用户协议');
            return false;
        }

        //提交表单(ajax)
        EDE.submitForm("#formreg", "reg");
    },
    Xerror: function (message) {
        var msgArr = message.split('|');
        $("#formreg").disabled = false;
        if (msgArr[1] == '1') {
            //alert(msgArr[2]);
            EDE.URLfor();
            var url = EDE.URLParams["url"];
            if (!EDE.trim(url)) url = '../default.aspx';
            location.href = unescape(url);
            return;
        } else if (msgArr[1] == '0') {
            Es.error(msgArr[2]);
        }
    }
}

$(document).ready(function () {
    Es.Signup();
})