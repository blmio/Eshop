if (window == top) top.location.href = "../";
var pWin = window.parent.parent;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js\"></script>');
function $p() { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); }
function trim(s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; }
var derF = new Object();

//#####################################
// Toolbar Items
//#####################################

//数据表的参数
derF["FrTable"]         = "";             //当前处理的表名
derF["Sonfrom"]         = "";             //要处理的二级表名
derF["SMfrom"]          = "";             //要处理的三级表名
derF["ImgS"]            = "";             //是不有要处理的图片{如果有把图片的表字段写在这：ImgS　多个：ImgS|ImgS2|ImgS3}
derF["CloseS"]          = "CloseS";       //是否关闭表的字段名
derF["Reded"]           = "Reded";        //是否推荐表的字段名
derF["Enable"]          = "Enable";       //是否设立表的字段名
derF["inSe"]            = "top";          //是否设立表的字段名
derF["upid"]            = "";             //分类字段

//窗口参数
derF["TitleName"]       = "";             //要用的窗口名
derF["winW"]            = 400;            //要用的窗口宽　默认是　400px
derF["winH"]            = 400;            //要用的窗口高　默认是　400px
derF["Tableurl"]        = "";             //要用的窗口路径
derF["TitleName2"]      = "";             //要用的窗口名
derF["winW2"]           = 400;            //要用的窗口宽　默认是　400px
derF["winH2"]           = 400;            //要用的窗口高　默认是　400px
derF["Tableurl2"]       = "";             //要用的窗口路径
derF["SeW"]             = 400;            //要用的窗口宽　默认是　400px
derF["SeH"]             = 400;            //要用的窗口高　默认是　400px
derF["Sealeurl"]        = "";             //要用的窗口路径
derF["upidurl"]         = "";             //要用的窗口参数路径
derF["TiOrder"]         = "";             //要用的窗口名
derF["wOrderW"]         = 400;            //要用的窗口宽　默认是　400px
derF["wOrderH"]         = 400;            //要用的窗口高　默认是　400px
derF["Orderurl"]        = "";             //要用的窗口路径
derF["SortT"]           = "";             //要用的排序窗口名

//当前数据参数
derF["begin"]           = "开启";
derF["barrier"]         = "关闭";
derF["Redhtml"]         = "推荐";
derF["Redgin"]          = "已推荐";
derF["Redrri"]          = "未推荐";
derF["Modify"]          = "编辑";
derF["beEnable"]        = "已设立";
derF["baEnable"]        = "未设立";
derF["beinSe"]          = "是";
derF["bainSe"]          = "否";
derF["inSehtml"]        = "设置";
derF["LockCloseS"]      = "提交订单";
derF["CloS"]            = "0";            //
derF["avahref"]         = "href";         //当前图片显示的节点值
derF["Tn"]              = 60; //窗口标题字符串文字的长度
derF["Son"]             = "0";
derF["bannerT"]         = "";
derF["mtm"]             = 0;
derF["Shgra"]           = 0;

window.onload = function () {
    $(document).ready(function () {
        Re.spanimg();
        Re.tabtopclick();
        Re.Aeach();
    });
}

var Re = {
    zOpen: function (objID, Title) {
        Title = this.widthCheck(Title, derF["Tn"]);
        pWin.winShow(derF["winW"], derF["winH"], Title, derF["Tableurl"] + "?Ed=Yes" + objID);
    },
    zOpen2: function (objID, Title) {
        Title = this.widthCheck(Title, derF["Tn"]);
        pWin.winShow(derF["winW2"], derF["winH2"], Title, derF["Tableurl2"] + "?Ed=Yes" + objID);
    },
    Search: function (Title) {
        Title = this.widthCheck(Title, derF["Tn"]);
        pWin.winShow(derF["SeW"], derF["SeH"], Title, derF["Sealeurl"]);
    },
    Lock: function (Curl, sv) {
        pWin.TanCen(); var now = new Date().getTime();
        $.get(pWin.url + "admin/Apply/Boxhtml.aspx?mod=Lock&" + Curl + "&now=" + now, function (data) {
            pWin.TanCenstr(data);
            pWin.hidden();
            if (sv == 1) location.reload();
        });
    },
    Lockall: function (strM) {
        var str = "";
        var i = 0;
        var objForm = document.getElementsByTagName("input");
        var objLen = objForm.length;
        for (var iCount = 0; iCount < objLen; iCount++) {
            if (objForm[iCount].type == "checkbox") {
                if (objForm[iCount].name == "check" && objForm[iCount].checked == true) {
                    if (i == 0) { str += objForm[iCount].value; } else { str += "|" + objForm[iCount].value; }
                    i++;
                }
            }
        }
        if (str != "") {
            Re.Lock(strM + "&id=" + str, 1);
        }
        else {
            alert("请选取后再提交！");
        }
    },
    BoxDelet: function (DeletObj) { pWin.BoxfirmD('真的要删除该条记录吗?', DeletObj); },
    widthCheck: function (categoryName, maxLength) {
        if (!maxLength) { maxLength = 20; }
        if (categoryName == null || categoryName.length < 1) { return ""; }
        if (categoryName.length < maxLength) { return categoryName; }
        return categoryName.substring(0, maxLength - 3) + "...";
    },
    tofloat: function (f, dec) {
        var fstr = f.toString().substring(0, 1);
        if (fstr == "-") f = Number(f.toString().replace("-", "")); else fstr = "";
        if (f == "") f = 0; if (isNaN(f)) f = 0; if (dec < 0) return "Error:dec < 0! ";
        result = parseInt(f) + (dec == 0 ? "" : "."); f -= parseInt(f);
        if (f == 0) for (i = 0; i < dec; i++) result += '0'; else {
            for (i = 0; i < dec; i++) f *= 10;
            result += parseInt(Math.round(f));
        }
        return fstr + result.toString();
    },
    tabtopclick: function () {
        if ($p("add")) {
            $("#add").html("<img src=\"" + pWin.url + "images/tab/AD01.gif\" align=\"absmiddle\" /> " + $("#add").html());
            $("#add").click(function () { Re.zOpen(derF["upidurl"], "新增" + derF["TitleName"]); });
        }
        if ($p("Deleteall")) {
            $("#Deleteall").html("<img src=\"" + pWin.url + "images/tab/D767.gif\" align=\"absmiddle\" /> " + $("#Deleteall").html());
            $("#Deleteall").click(function () {
                var strs = "from=" + derF["FrTable"] + derF["upidurl"];
                if (derF["SMfrom"] != "") strs += "&SMfrom=" + derF["SMfrom"];
                if (derF["Sonfrom"] != "") strs += "&Sonfrom=" + derF["Sonfrom"];
                if (derF["ImgS"] != "") strs += "&ImgS=" + escape(derF["ImgS"]);
                pWin.chkDelet(strs);
            });
        }
        if ($p("CloseS1")) {
            $("#CloseS1").html("<img src=\"" + pWin.url + "images/tab/script.gif\" align=\"absmiddle\" /> " + $("#CloseS1").html());
            $("#CloseS1").click(function () { Re.Lockall("type=0&from=" + derF["FrTable"] + "&Stat=" + derF["CloseS"] + "&types=alllll&aler=" + escape(derF["begin"])); });
        }
        if ($p("CloseS0")) {
            $("#CloseS0").html("<img src=\"" + pWin.url + "images/tab/scripts.gif\" align=\"absmiddle\" /> " + $("#CloseS0").html());
            $("#CloseS0").click(function () { Re.Lockall("type=1&from=" + derF["FrTable"] + "&Stat=" + derF["CloseS"] + "&types=alllll&aler=" + escape(derF["begin"])); });
        }
        if ($p("Search")) {
            $("#Search").html("<img src=\"" + pWin.url + "images/tab/See.gif\" align=\"absmiddle\" /> " + $("#Search").html());
            $("#Search").click(function () { Re.Search(derF["TitleName"] + "搜索"); });
        }
    },
    spanimg: function () {
        var x = 10, y = 20;
        $("#tmall tr td span.img").mouseover(function (e) {
            var img = $(this).attr("simg");
            if (!trim(img)) return;
            var id = $(this).attr("id");
            var alt = "预览图";
            if (trim($(this).attr("alt"))) alt = $(this).attr("alt");
            if (trim($(this).attr("title"))) alt = $(this).attr("title");
            var Toolhtml = '<div id="tooltip' + id + '" class="tooltip"><img src="' + pWin.url + 'Apply/admin.aspx?mod=avatar&img=' + escape(img) + '" alt="' + alt + '" /><\/div>'; //创建 div 元素
            $("body").append(Toolhtml);
            var Ttip = $("#tooltip" + id);
            var bodH = $(document).height();
            if (bodH > (e.pageY + Ttip.height()))
                Ttip.css({ "top": (e.pageY + y) + "px", "left": (e.pageX + x) + "px" }).show("fast");
            else
                Ttip.css({ "bottom": (e.pageY + y) + "px", "left": (e.pageX + x) + "px" }).show("fast");
            var Timg = $("#tooltip" + id + " img");
            if (Timg.width() > 300) W = Timg.width(300);
            if (Timg.height() > 200) W = Timg.height(200);
        }).mouseout(function () {
            var id = $(this).attr("id");
            $("#tooltip" + id).remove();  /*/移除 */
        }).mousemove(function (e) {
            var id = $(this).attr("id");
            var Ttip = $("#tooltip" + id);
            var bodH = $(document).height();
            if (bodH > (e.pageY + Ttip.height()))
                Ttip.css({ "top": (e.pageY + y) + "px", "left": (e.pageX + x) + "px" }).show("fast");
            else
                Ttip.css({ "bottom": (e.pageY + y) + "px", "left": (e.pageX + x) + "px" }).show("fast");
        });
    },
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
                        if ($p("Name" + sinid)) { NameBid = $("#Name" + sinid).html(); }
                        Re.zOpen("&Number=" + sinid + derF["upidurl"], NameBid + " " + derF["TitleName"] + derF["Modify"]);
                    });
                    break;
                case "Delete":
                    var Dehtml = $(this).html();
                    $(this).html("<img src=\"" + pWin.url + "images/tab/tab_15.gif\" align=\"middle\" title=\"" + Dehtml + "\" />");
                    DeM = 0;
                    if ($p("DeM" + inid)) DeM = Number($("#DeM" + inid).html());
                    if (DeM > 2) {
                        $(this).attr("disabled", "true");
                        $(this).html("<img src=\"" + pWin.url + "images/tab/Delet.gif\" align=\"middle\" title=\"" + Dehtml + "\" />");
                    } else {
                        $(this).click(function (e) {
                            var sinid = $(this).parent().parent().parent().attr("inid");
                            var strs = "from=" + derF["FrTable"] + "&id=" + sinid;
                            if (derF["SMfrom"] != "") strs += "&SMfrom=" + derF["SMfrom"];
                            if (derF["Sonfrom"] != "") strs += "&Sonfrom=" + derF["Sonfrom"];
                            if (derF["ImgS"] != "") strs += "&ImgS=" + escape(derF["ImgS"]);
                            Re.BoxDelet(strs);
                        });
                    }
                    break;
                case "sCl":
                    var Chtml = $(this).html();
                    if (Chtml == "1") { $(this).html(derF["barrier"]); } else { $(this).html(derF["begin"]); }
                    DeM = 0;
                    if ($p("DeM" + inid)) DeM = Number($("#DeM" + inid).html());
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
                            Re.Lock("type=" + idMEr + "&from=" + derF["FrTable"] + "&Stat=" + derF["CloseS"] + "&id=" + sinid + "&aler=" + escape(derF["barrier"]));
                        });
                    }
                    break;
                case "Red":
                    var Rhtml = $(this).html();
                    if (Rhtml == "1") { $(this).html(derF["Redgin"]); } else { $(this).html(derF["Redrri"]); }
                    $(this).click(function (e) {
                        var sinid = $(this).parent().parent().parent().attr("inid");
                        var clid = $(this).html(), idMEr = "0";
                        if (clid == derF["Redrri"]) {
                            idMEr = "1";
                            $(this).html(derF["Redgin"]);
                        } else {
                            idMEr = "0"
                            $(this).html(derF["Redrri"]);
                        }
                        Re.Lock("type=" + idMEr + "&from=" + derF["FrTable"] + "&Stat=" + derF["Reded"] + "&id=" + sinid + "&aler=" + escape(derF["Redhtml"]));
                    });
                    break;
                case "inSe":
                    var Shtml = $(this).html();
                    if (Shtml == "1") { $(this).html(derF["beinSe"]); } else { $(this).html(derF["bainSe"]); }
                    $(this).click(function (e) {
                        var sinid = $(this).parent().parent().parent().attr("inid");
                        var clid = $(this).html(), idMEr = "0";
                        if (clid == derF["bainSe"]) {
                            idMEr = "1";
                            $(this).html(derF["beinSe"]);
                        } else {
                            idMEr = "0"
                            $(this).html(derF["bainSe"]);
                        }
                        var evd = $(this).attr("evd");
                        if (!trim(evd)) evd = derF["inSe"];
                        Re.Lock("type=" + idMEr + "&from=" + derF["FrTable"] + "&Stat=" + evd + "&id=" + sinid + "&aler=" + escape(derF["inSehtml"]));
                    });
                    break;
                case "Stat":
                    $(this).click(function (e) {
                        var sinid = $(this).parent().parent().attr("inid");
                        pWin.SortOpen(sinid + '&from=' + derF["FrTable"] + '&isSort=Stat', derF["SortT"]);
                    });
                    break;
                case "Son":
                    if (derF["Son"] == "1") {
                        if (trim(derF["upid"])) {
                            $(this).attr("href", "javascript:void(0);");
                            $(this).attr("disabled", "true");
                        }
                    }
                    break;
                case "Banner":
                    $(this).click(function (e) {
                        var sinid = $(this).parent().parent().parent().attr("inid");
                        var NameBid = "";
                        if ($p("Name" + sinid)) { NameBid = $("#Name" + sinid).html(); }
                        derF["bannerT"] = NameBid;
                        sinid += "&from=" + derF["FrTable"];
                        Re.winbanner("&upid=" + sinid, NameBid + " banner配置");
                    });
                    break;
                case "Shgra":
                    if (derF["Shgra"] == 1) {
                        $(this).attr("disabled", "true");
                        $(this).attr("href", "javascript:void(0);");
                        $(this).addClass("gra");
                        $(this).find("img").attr("src", pWin.url + "images/tab/level_downs.gif");
                    }
                    break;
                    break;
            }
        });
    },
    winbanner: function (objID, Title) {
        Title = this.widthCheck(Title, 20);
        if (derF["mtm"] == 0) {
            var now = new Date().getTime();
            pWin.winShow(300, 135, Title, pWin.url + "admin/system/bannerEdit.aspx?Ed=" + now + objID);
        }
    }
}