if (window == top) top.location.href = "../";
var pWin = window.parent.parent;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js\"></script>');
var Bx = {
    Subjsall: function () {
        var now = new Date().getTime(),
        hurl = pWin.url + 'admin/Apply/HtmlWrite.aspx?mod=Subjsall';
        Bx.loading("正在生成整站所有页");
        $.get(hurl + '&now=' + now, function (data) {
            var myhtml = $("#kkm").html();
            $("#kkm").html(myhtml + data);
            pWin.hiddenstr();
        });
    },
    Subjsindex: function () {
        var now = new Date().getTime(),
        hurl = pWin.url + 'admin/Apply/HtmlWrite.aspx?mod=Subjsindex';
        Bx.loading("正在生成首页");
        $.get(hurl + '&now=' + now, function (data) {
            var myhtml = $("#kkm").html();
            $("#kkm").html(myhtml + data);
            pWin.hiddenstr();
        });
    },
    loading: function (v) {
        var str = '<div align="center"><img src="' + pWin.url + 'images/images/loading.gif" /></div>';
        str += '<div align="center">' + v + '…</div>';
        pWin.TanCe(str)
    }
}