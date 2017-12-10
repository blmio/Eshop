if (window == top) top.location.href = "../";
var URLParams = new Object();
var aParams = document.location.search.substr(1).split('&');
for (i = 0; i < aParams.length; i++) {
    var aParam = aParams[i].split('=');
    URLParams[aParam[0]] = aParam[1];
}
var pWin = window.parent.parent, mtm = 0;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js\"></script>');
var Bx = {
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    Submitlist: function () {
        if ($("#chec2").attr("checked") == true) { Bx.Submitall(); return; }
        var emed = $("input[name='Check']:checked");
        var leng = emed.length, mn = 0, lem = 0;
        if (leng == 0) pWin.Boxalert("请选择要删除的页面！");
        emed.each(function () { if ($(this).attr("evm") != 1) { lem++; } });
        leng = lem;
        emed.each(function () {
            if ($(this).attr("evm") != 1) {
                mn++;
                var val = $(this).val(), now = new Date().getTime(), thtml = $(this).parent().find("i").html();
                if (mn == 1)
                    Bx.loading("正在删除" + thtml + "页");
                else
                    Bx.TanCstr("正在删除" + thtml + "页");
                var Vrr = val.split("|$|");
                var hurl = pWin.url + 'admin/Apply/HtmlWrite.aspx?mod=Delethtml&D=' + escape(Vrr[0]);
                if (Vrr.length > 0) hurl += "&Number=" + escape(Vrr[1]);
                if (Vrr.length > 1) hurl += "&url=" + escape(Vrr[2]);
                if (Vrr.length > 2) hurl += "&up1=" + escape(Vrr[3]);
                if (Vrr.length > 3) hurl += "&up2=" + escape(Vrr[4]);
                hurl += "&title=" + escape(thtml);
                $.get(hurl + '&now=' + now, function (data) {
                    if (leng == mn) pWin.hiddenstr();
                    var myhtml = $("#kkm").html();
                    $("#kkm").html(myhtml + data);
                });
            }
        });
    },
    loading: function (v) {
        var str = '<div align="center"><img src="' + pWin.url + 'images/images/loading.gif" /></div>';
        str += '<div align="center">' + v + '…</div>';
        pWin.TanCe(str)
    },
    TanCstr: function (v) {
        var str = '<div align="center"><img src="' + pWin.url + 'images/images/loading.gif" /></div>';
        str += '<div align="center">' + v + '…</div>';
        pWin.TanCstr(str)
    },
    Check: function () {
        var enc = $("input[name='Check']");
        enc.click(function () {
            $(this).attr("evm", "0");
            var val = $(this).val(), eid = $(this).attr("eid");
            if (eid == "ClinicData") Bx.ClinicData(this, enc);
            if ($(this).attr("checked") == true) {
                enc.each(function () {
                    if ($(this).attr("eid") == val) { $(this).attr("evm", "1"); $(this).attr("checked", true); }
                });
            } else {
                enc.each(function () {
                    if ($(this).attr("eid") == val) { $(this).attr("evm", "0"); $(this).attr("checked", false); }
                    if (eid == $(this).val()) { $(this).attr("evm", "0"); $(this).attr("checked", false); }
                    var vm = $(this).attr("vm");
                    if (Bx.ArrK(vm, val)) { $(this).attr("evm", "0"); $(this).attr("checked", false); }
                });
            }
        });
    },
    ClinicData: function (tis, enc) {
        var vm = $(tis).attr("vm");
        if (Bx.trim(vm)) {
            if ($(tis).attr("checked") == true) {
                enc.each(function () {
                    var val = $(this).val(), eid = $(this).attr("eid");
                    if (eid == "ClinicData") {
                        if (Bx.ArrK(vm, val)) { $(this).attr("evm", "1"); $(this).attr("checked", true); }
                    }
                });
            } else {
                enc.each(function () {
                    var val = $(this).val(), eid = $(this).attr("eid");
                    if (eid == "ClinicData") {
                        if (Bx.ArrK(vm, val)) { $(this).attr("evm", "0"); $(this).attr("checked", false); }
                    }
                });
            }
        }
    },
    ArrK: function (vm, val) {
        var Arr = val.split("|$|");
        for (var i = 0, len = Arr.length; i < len; i++) {
            if (vm == Arr[i]) return true;
        }
        return false;
    },
    Submitall: function () {
        var enc = $("input[name='Check']");
        var leng = enc.length, mn = 0, lem = 0;
        enc.each(function () { if ($(this).attr("box") == 1) { lem++; } });
        leng = lem;
        enc.each(function () {
            var box = $(this).attr("box");
            if (box == "1") {
                mn++;
                var val = $(this).val(), now = new Date().getTime(), thtml = $(this).parent().find("i").html();
                if (mn == 1)
                    Bx.loading("正在删除" + thtml + "页");
                else
                    Bx.TanCstr("正在删除" + thtml + "页");
                var Vrr = val.split("|$|");
                var hurl = pWin.url + 'admin/Apply/HtmlWrite.aspx?mod=Delethtml&D=' + escape(Vrr[0]);
                if (Vrr.length > 0) hurl += "&Number=" + escape(Vrr[1]);
                if (Vrr.length > 1) hurl += "&url=" + escape(Vrr[2]);
                if (Vrr.length > 2) hurl += "&up1=" + escape(Vrr[3]);
                if (Vrr.length > 3) hurl += "&up2=" + escape(Vrr[4]);
                hurl += "&title=" + escape(thtml);
                $.get(hurl + '&now=' + now, function (data) {
                    if (leng == mn) pWin.hiddenstr();
                    var myhtml = $("#kkm").html();
                    $("#kkm").html(myhtml + data);
                });
            }
        });
    }
}