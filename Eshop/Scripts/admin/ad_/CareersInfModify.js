if (window == top) top.location.href = "../";
var pWin = window.parent.parent;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js"></script>');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/ext/showDialog.js"></script>');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery.cxcalendar.min.js\"></script>');
document.write('<link href="' + pWin.url + 'Scripts/jquery/jquery.cxcalendar.css" type="text/css" rel="stylesheet" />');
var Me = {
    A: new Array(6),
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
    DropContact: function (Number, Dropid, Dropupid) {
        if (Number == "" || !Me.trim(Number)) {
            Me.$(Dropid).options.length = 0;
            Me.$(Dropid).style.display = "none";
            return false;
        }
        var Durlm = this.Durl;
        $.get(Durlm + Number, function (data) {

            Me.$(Dropid).options.length = 0;
            var Cent = data, CentArr = Cent.split("$"), textvalue;
            if (!Me.trim(Cent) || Cent == "") {
                Me.$(Dropid).style.display = "none";
            } else {
                Me.$(Dropid).style.display = "";
                Me.$(Dropid).options.add(new Option("请选择...", ''));
                for (var i = 0; i < CentArr.length; i++) {
                    textvalue = CentArr[i].split(",");
                    Me.$(Dropid).options.add(new Option(textvalue[0], textvalue[1]));
                }
                for (var j = 0; j <= CentArr.length; j++) {
                    if (Me.$(Dropid).options[j].value == Dropupid) { Me.$(Dropid).options[j].selected = true; break; }
                }
            }
        });
    },
    loadfun: function () {
        Me.ci = $("#Location").val().split("|");
        $("#tabbtm p a").click(function () {
            var tid = $(this).attr("id");
            $(this).parent("p").addClass("p").siblings().removeClass();
            $("#div" + tid).css("display", "block").siblings("div.dili").css("display", "none");
        });
        Me.$('AgidT').readOnly = true;
        $('#AgidT').click(function () {
            showDialog(pWin.url + "admin/Apply/boxwin/Agents.aspx?mod=CareersInfModify");
        });
        Me.$('UsidT').readOnly = true;
        $('#UsidT').click(function () {
            showDialog(pWin.url + "admin/Apply/boxwin/Member.aspx?mod=CareersInfModify");
        });
        Me.$('welfareT').readOnly = true;
        $('#welfareT').click(function () {
            showDialog(pWin.url + "admin/Apply/boxwin/welfare.aspx?mod=CareersInfModify");
        });
        Me.$('PositionT').readOnly = true;
        $('#PositionT').click(function () {
            showDialog(pWin.url + "admin/Apply/boxwin/Position.aspx?mod=CareersInfModify");
        });
        Me.DropContact("0", "Cit0", Me.ci[0]);
        Me.DropContact(Me.ci[0], "Cit1", Me.ci[1]);
        var optnone = function (im, v, Cim, Cims, civ) {
            for (var m = im; m < v; m++) {
                Me.$("Cit" + m).options.length = 0;
                Me.$("Cit" + m).style.display = "none";
                Me.DropContact(Me.$(Cim).value, Cims, civ);
            }
        }
        $("#Cit0").change(function () { optnone(1, 2, "Cit0", "Cit1", Me.ci[0]); });
        var Age = $("#Age").val().split("-");
        var Agefun = function (obj, v) {
            Me.$(obj).options.add(new Option("不限", ''));
            var selObj = $("#" + obj);
            selObj.append("<option value=''>不限</option>");
            for (var i = 16; i < 81; i++) {
                if (v == i)
                    selObj.append("<option value='" + i + "' selected>" + i + "</option>");
                else
                    selObj.append("<option value='" + i + "'>" + i + "</option>");
            }
        }
        Agefun("Age1", Age[0]);
        Agefun("Age2", Age[1]);
        $('#ValidDay').cxCalendar();
        Me.$('ValidDay').readOnly = true;
    },
    CitAr: function () {
        var D = '', T = '', val;
        for (var i = 0; i < 2; i++) {
            val = $("#Cit" + i).val();
            if (Me.trim(val)) {
                if (D != '') D += "|";
                D += val;
                if (T != '') T += " - ";
                T += $("#Cit" + i).find("option:selected").text();
            }
        }
        $("#Location").val(D);
        $("#LocationT").val(T);
        if (D == '') {
            Me.Bot["Location"] = 1;
            pWin.BalC("请选择所在地区！", "Cit0", "t1");
            return false;
        }
        return true;
    },
    gotoB: function () {
        var htex = $("#Manid").find("option:selected").text();
        $("#ManidT").val(htex);
        htex = $("#Manidd1").find("option:selected").text();
        $("#ManidsT").val(htex);
        // if($("#Age1").val()>$("#Age2").val())
        //pWin.BalC("最大年龄不能小于最小年龄！", "Age");
        $("#Age").val($("#Age1").val() + "-" + $("#Age2").val());
        var Emav = $("#Email").val();
        if (Me.trim(Emav)) {
            if (!Me.SubEmail(Emav)) {
                pWin.BalC("电子邮箱格式不正确！", "Email");
                return false;
            }
        }
        var Mobiv = $("#Mobile").val();
        if (Me.trim(Mobiv)) {
            if (!Me.SubMobil(Mobiv)) {
                pWin.BalC("手机号码格式错误！", "Mobile");
                return false;
            }
        }
        if (!Me.CitAr()) return false;
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