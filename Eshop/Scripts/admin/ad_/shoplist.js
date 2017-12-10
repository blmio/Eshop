if (window == top) top.location.href = "../";
var pWin = window.parent.parent, plis = window.parent.parent.btFrame;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js\"></script>');
var derF = new Object();
derF["upidurl"] = "";
derF["TitleName"] = "图片";
derF["Modify"] = "编辑";
derF["FrTable"] = "e_goods_pic";
derF["Tableurl"] = "Shop/GoodsListModify.aspx";
derF["ImgS"] = "ImgS";
derF["begin"] = "开启";
derF["barrier"] = "关闭";
derF["CloseS"] = "CloseS";
derF["upid"] = "";

var Sli = {
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    zOpen: function (objID, Title) {
        window.parent.loa.zOpen(objID, Title);
    },
    Lock: function (Curl, sv) {
        pWin.TanCen(); var now = new Date().getTime();
        $.get(pWin.url + "admin/Apply/Boxhtml.aspx?mod=Lock&" + Curl + "&now=" + now, function (data) {
            pWin.TanCenstr(data);
            pWin.hidden();
            if (sv == 1) location.reload();
        });
    },
    BoxDelet: function (DeletObj) { pWin.BoxfirmD('真的要删除该条记录吗?', DeletObj); },
    Aeach: function () {
        $("#tmall tr td a").each(function (e) {
            var gnid = $(this).attr("gnid"), NameBid = '', DeM = 0;
            var inid = $(this).parent().parent().parent().attr("inid");
            switch (gnid) {
                case "Edit":
                    $(this).html("<img src=\"" + pWin.url + "images/tab/tab_16.gif\" align=\"middle\" title=\"" + $(this).html() + "\" />");
                    $(this).click(function (e) {
                        var sinid = $(this).parent().parent().parent().attr("inid");
                        NameBid = "";
                        if (Sli.$("Name" + sinid)) { NameBid = $("#Name" + sinid).html(); }
                        Sli.zOpen("&Number=" + sinid + derF["upidurl"], NameBid + " " + derF["TitleName"] + derF["Modify"]);
                    });
                    break;
                case "Delete":
                    $(this).html("<img src=\"" + pWin.url + "images/tab/tab_15.gif\" align=\"middle\" title=\"" + $(this).html() + "\" />");
                    DeM = 0;
                    if (Sli.$("DeM" + inid)) DeM = Number($("#DeM" + inid).html());
                    if (DeM > 2) {
                        $(this).attr("disabled", "true");
                        $(this).html("<img src=\"" + pWin.url + "images/tab/Delet.gif\" align=\"middle\" title=\"" + Dehtml + "\" />");
                    } else {
                        $(this).click(function (e) {
                            var sinid = $(this).parent().parent().parent().attr("inid");
                            var strs = "from=" + derF["FrTable"] + "&id=" + sinid;
                            if (derF["ImgS"] != "") strs += "&ImgS=" + escape(derF["ImgS"]);
                            Sli.BoxDelet(strs);
                        });
                    }
                    break;
                case "sCl":
                    var Chtml = $(this).html();
                    if (Chtml == "1") { $(this).html(derF["barrier"]); } else { $(this).html(derF["begin"]); }
                    DeM = 0;
                    if (Sli.$("DeM" + inid)) DeM = Number($("#DeM" + inid).html());
                    if (DeM > 2) {
                        $(this).attr("disabled", "true");
                    } else {
                        $(this).click(function (e) {
                            var sinid = $(this).parent().parent().parent().attr("inid");
                            var clid = $(this).html(), idMEr = "0";
                            if (clid == derF["begin"]) {
                                idMEr = "1";
                                $(this).html(derF["barrier"]);
                            } else {
                                idMEr = "0";
                                $(this).html(derF["begin"]);
                            }
                            Sli.Lock("type=" + idMEr + "&from=" + derF["FrTable"] + "&Stat=" + derF["CloseS"] + "&id=" + sinid + "&aler=" + escape(derF["barrier"]));
                        });
                    }
                    break;
            }
        });
    }
}
window.onload = function () {
    $(document).ready(function () {
        Sli.Aeach();
    });
}