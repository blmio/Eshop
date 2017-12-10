var Es = {
    E: new Object(),
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    getUrlParam: function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    },
    error: function (message) {
        $("#content .msg-error").css('display', 'block');
        $("#content .msg-error").html(message);
    },
    before: function () {
        if (Es.E["reme"] != "on")
            $("input[name='chkRememberMe']").attr("checked", false);

        $("#loginsumbit").click(function () { Es.Login(); });
        $("input[name='adname']").keydown(function (event) { if (event.keyCode == 13) { Es.Login(); } });
        $("input[name='adpassword']").keydown(function (event) { if (event.keyCode == 13) { Es.Login(); } });
    },
    Login: function () {
        var name = $("input[name='adname']"), pwd = $("input[name='adpassword']");
        if (!this.trim(name.val()) && !this.trim(pwd.val())) {
            Es.error('请输入账户名和密码');
            return false;
        }
        else if (!this.trim(name.val()) || !this.trim(pwd.val())) {
            if (!this.trim(name.val())) {
                Es.error('请输入账户名');
                return false;
            }
            else {
                Es.error('请输入密码');
                return false;
            }
        }

        this.submitForm("#adform", "login");
    },
    submitForm: function (formid, mod) {
        //提交表单(ajax)
        var path = "../admin/Apply/xmlWrite.aspx?mod=" + mod;
        $.ajax({
            type: "POST",
            dataType: "html",
            url: path,
            data: $(formid).serialize(),
            success: function (result) {
                Es.Xerror(result);
            }
        })
    },
    Xerror: function (message) {
        var msgArr = message.split('|');
        $("#adform").disabled = false;
        if (msgArr[1] == '1') {
            var url = this.getUrlParam('url');
            if (!this.trim(url)) url = 'default.aspx';
            location.href = unescape(url);
            return;
        }
        Es.error(msgArr[2]);
    }
}

$(document).ready(function () {
    Es.before();
})