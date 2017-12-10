if (window == top) top.location.href = "../";
var pWin = window.parent.parent, Author;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js\"></script>');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery.cxcalendar.min.js\"></script>');
document.write('<link href="' + pWin.url + 'Scripts/jquery/jquery.cxcalendar.css" type="text/css" rel="stylesheet" />');
var Box = {
    Bot: new Object(),
    ci: new Array(6),
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    Durl: pWin.url + "Apply/script/Dselect.aspx?from=city&typeID=Number&typeName=title&HTML=$&where=upid&Number=",
    DropContact: function (Number, Dropid, Dropupid) {
        if (Number == "" || !Box.trim(Number)) {
            Box.$(Dropid).options.length = 0;
            Box.$(Dropid).style.display = "none";
            return false;
        }
        var Durlm = this.Durl;
        $.get(Durlm + Number, function (data) {
            Box.$(Dropid).options.length = 0;
            var Cent = data, CentArr = Cent.split("$"), textvalue;
            if (!Box.trim(Cent) || Cent == "") {
                Box.$(Dropid).style.display = "none";
            } else {
                Box.$(Dropid).style.display = "";
                Box.$(Dropid).options.add(new Option("请选择...", ''));
                for (var i = 0; i < CentArr.length; i++) {
                    textvalue = CentArr[i].split(",");
                    Box.$(Dropid).options.add(new Option(textvalue[0], textvalue[1]));
                }
                for (var j = 0; j < CentArr.length; j++) {
                    if (Box.$(Dropid).options[j].value == Dropupid) { Box.$(Dropid).options[j].selected = true; break; }
                }
            }
        });
    },
    Rboot: new Object(),
    loadfun: function () {
        var tab = Box.$("tabbtm").getElementsByTagName("p");
        $("#tabbtm p").click(function () {
            $(this).addClass("p").siblings().removeClass("p");
            for (var j = 1; j < (tab.length + 1); j++) { $("#divt" + j).css("display", "none"); }
            $("#div" + $(this).children("a").attr("eid")).css("display", "block");
        });

        if (Box.Bot["loAgid"] == Box.Bot["Numbid"]) {
            $("#City0").attr("disabled", "disabled");
            $("#City1").attr("disabled", "disabled");
            $("#City2").attr("disabled", "disabled");
            $("#City3").attr("disabled", "disabled");
        } else {
            Box.Bot["City"];
            var Cirr = Box.Bot["City"].split('|');
            if (!Box.trim(Box.ci[0])) Box.ci = Cirr;
            if (Box.trim(Cirr[0]) && Cirr[0] == Box.ci[0]) { $("#City0").attr("disabled", "disabled"); }
            if (Box.trim(Cirr[1]) && Cirr[1] == Box.ci[1]) { $("#City1").attr("disabled", "disabled"); }
            if (Box.trim(Cirr[2]) && Cirr[2] == Box.ci[2]) { $("#City2").attr("disabled", "disabled"); }
            if (Box.trim(Cirr[3]) && Cirr[3] == Box.ci[3]) { $("#City3").attr("disabled", "disabled"); }
        }

        Box.DropContact("0", "City0", Box.ci[0]);
        Box.DropContact(Box.ci[0], "City1", Box.ci[1]);
        Box.DropContact(Box.ci[1], "City2", Box.ci[2]);
        Box.DropContact(Box.ci[2], "City3", Box.ci[3]);
        Box.DropContact(Box.ci[3], "City4", Box.ci[4]);
        var optnone = function (im, Cim, civ) {
            for (var m = im; m < 5; m++) {
                Box.$(Cim + m).options.length = 0;
                Box.$(Cim + m).style.display = "none";
                Box.DropContact(Box.$(Cim + (im - 1)).value, Cim + im, civ);
            }
        }
        $("#City0").change(function () { optnone(1, "City", Box.ci[0]); });
        $("#City1").change(function () { optnone(2, "City", Box.ci[1]); });
        $("#City2").change(function () { optnone(3, "City", Box.ci[2]); });
        $("#City3").change(function () { optnone(4, "City", Box.ci[3]); });

        $("#Aname").blur(function () { Box.Anameblur(this); });
        Box.Rboot["boT"] = '请输入注册用户名！';
        $('#ExpDate').cxCalendar();
        $('#Birthday').cxCalendar();
        Box.$('Birthday').readOnly = true;
        Box.$('ExpDate').readOnly = true;
    },
    Anameblur: function (ev) {
        if (!Box.trim(ev.value)) {
            Box.Rboot["boT"] = "请输入注册用户名！";
            pWin.BalC(Box.Rboot["boT"], ev.id);
            Box.Rboot["boot"] = true;
            return false;
        } else {
            var count = ev.value.length;
            if (count < 2 || count > 40) {
                Box.Rboot["boT"] = "用户名太短，最少 2 个字符，最大 30 个字符之间！";
                pWin.BalC(Box.Rboot["boT"], ev.id);
                Box.Rboot["boot"] = true;
                return false;
            } else if (ev.value != Box.Bot["Vr-Aname"]) {
                var now = new Date().getTime();
                $.get(pWin.url + 'Apply/xmlWrite.aspx?mod=AgentsChang&Mname=' + escape(ev.value) + '&km=' + now, function (data) {
                    if (data == "1") {
                        Box.Rboot["boT"] = "用户名已存在！";
                        pWin.BalC(Box.Rboot["boT"], ev.id);
                        ev.value = "";
                        Box.Rboot["boot"] = true;
                    } else {
                        Box.Rboot["boot"] = false;
                    }
                });
            }
        }
    },
    CitAr: function (vt, message, tms) {
        var D = '', T = '', val, locus = '';
        for (var i = 0; i < 5; i++) {
            val = $("#" + vt + i).val();
            if (Box.trim(val)) {
                locus = val;
                if (D != '') D += "|";
                D += val;
                if (T != '') T += " - ";
                T += $("#" + vt + i).find("option:selected").text();
            }
        }
        if (D == '') {
            Box.Bot[vt] = 1;
            if (tms != 1) pWin.BalC("请选择" + message + "！", vt + "0");
            return false;
        }
        $("#" + vt).val(D);
        $("#" + vt + "V").val(T);
        $("#locus").val(locus);
        return true;
    },
    gotoB: function () {
        Box.$('Birthday').readOnly = false;
        Box.$('ExpDate').readOnly = false;
        if (pWin.Boxif("登录名不能为空！", "Aname")) return false;
        if (Box.Rboot["boot"]) {
            pWin.BalC(Box.Rboot["boT"], "Aname");
            return false;
        }
        var pwd = $("#pwd").val();
        if (!Box.trim(pwd) && !Box.trim($("#Apasswoid").val())) {
            pWin.BalC("登录密码不能为空！", "Apasswoid");
            return false;
        }
        if (!Box.CitAr("City", "所负责区")) return false;
        var theForm = document.forms['form1'];
        if (!theForm) { theForm = document.form1; }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
}
function gotoB() { Box.gotoB(); }