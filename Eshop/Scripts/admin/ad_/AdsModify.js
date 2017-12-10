if (window == top) top.location.href = "../";
var pWin = window.parent.parent;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js"></script>');

var Me = {
    Bot: new Object(),
    $: function () {
        return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]);
    },
    trim: function (s) {
        if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null;
    },
    loadfun: function () {
        this.Setresize("#Dupid");
        $("#Dupid").change(function () { Me.Setresize(this); });
    },
    Setresize: function (sid) {
        switch ($(sid).val()) {
            case "I02":
                break;
            default:
                $("#Tr1").css("display", "none");
                $("#Tr2").css("display", "none");
                pWin.win.setSize(460, 325);
                pWin.win.center();
                break;
        }
    },
    gotoB: function () {
        if (pWin.Boxif("请选择广告类别名！", "Dupid")) return false;
        if (pWin.Boxif("请填写广告名称！", "title")) return false;
        var theForm = document.forms['form1'];
        if (!theForm) { theForm = document.form1; }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
}
function gotoB() { Me.gotoB(); }