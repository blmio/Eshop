if (window == top) top.location.href = "../";
var pWin = window.parent.parent;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js"></script>');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/ext/showDialog.js"></script>');
function gotoB() { Me.gotoB(); }
var Me = {
    A: new Array(6),
    ci: new Array(6),
    Bot: new Object(),
    B: new Object(),
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    Durl: function (v) {
        if (this.trim(v)) v = "city";
        if (v == "Manage")
            return pWin.url + "Apply/script/Dselect.aspx?from=Manage&typeID=Number&typeName=title&HTML=$&where=upid&and=" + escape(" and [Inq]=1 and [CloseS]<>1") + "&Number=";
        else if (v == "city")
            return pWin.url + "Apply/script/Dselect.aspx?from=city&typeID=Number&typeName=title&HTML=$&where=upid&Number=";
    },
    DropContact: function (Number, Dropid, Dropupid, from) {
        if (Number == "" || !Me.trim(Number)) {
            Me.$(Dropid).options.length = 0;
            Me.$(Dropid).style.display = "none";
            return false;
        }
        var Durlm = this.Durl(from);
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
    askClass: function () {
        Me.B["askClass"] = '';
        $("#askClass input").click(function () {
            var inv = $(this).attr("ask");
            if (Me.trim(inv)) {
                if ($(this).attr("checked") == "true")
                    Me.B["ask-" + inv] = '1';
                else
                    Me.B["ask-" + inv] = '0';
            }
        });
        $("#askClass input").each(function () {
            var inv = $(this).attr("ask");
            if (Me.trim(inv)) {
                if ($(this).attr("checked") == "true")
                    Me.B["ask-" + inv] = '1';
                else
                    Me.B["ask-" + inv] = '0';
            }
        });
    },
    loadfun: function () {
        Me.askClass();
        $("#tabbtm p a").click(function () {
            var tid = $(this).attr("id");
            $(this).parent("p").addClass("p").siblings().removeClass();
            $("#div" + tid).css("display", "block").siblings("div.dili").css("display", "none");
        });
        $("#Audit").change(function () {
            var mv = $(this).val();
            if (mv == "1") { $("#Audid").css("display", ""); } else { $("#Audid").css("display", "none"); }
        });
        Me.ci = $("#Location").val().split('|');
        Me.DropContact("0", "Cit0", Me.ci[0], "city");
        Me.DropContact(Me.ci[0], "Cit1", Me.ci[1], "city");
        Me.DropContact(Me.ci[1], "Cit2", Me.ci[2], "city");
        Me.DropContact(Me.ci[2], "Cit3", Me.ci[3], "city");
        Me.DropContact(Me.ci[3], "Cit4", Me.ci[4], "city");
        var optnone = function (im, v, Cim, Cims, civ) {
            for (var m = im; m < v; m++) {
                Me.$("Cit" + m).options.length = 0;
                Me.$("Cit" + m).style.display = "none";
                Me.DropContact(Me.$(Cim).value, Cims, civ, "city");
            }
        }
        $("#Cit0").change(function () { optnone(1, 5, "Cit0", "Cit1", Me.ci[0]); });
        $("#Cit1").change(function () { optnone(2, 5, "Cit1", "Cit2", Me.ci[1]); });
        $("#Cit2").change(function () { optnone(3, 5, "Cit2", "Cit3", Me.ci[2]); });
        $("#Cit3").change(function () { optnone(4, 5, "Cit3", "Cit4", Me.ci[3]); });
        var Maid = $("#ManidTid").val(), Msid = $("#Manidsid").val();
        Me.DropContact(Maid, "Manidd1", Msid, "Manage");
        $("#Manid").change(function () {
            Me.$("Manidd1").options.length = 0;
            Me.$("Manidd1").style.display = "none";
            Me.DropContact(Me.$("Manid").value, "Manidd1", Msid, "Manage");
        });
        Me.$('AgidT').readOnly = true;
        $('#AgidT').click(function () {
            showDialog(pWin.url + "admin/Apply/boxwin/Agents.aspx?mod=ConsultantModify");
        });
        Me.$('UsidT').readOnly = true;
        $('#UsidT').click(function () {
            showDialog(pWin.url + "admin/Apply/boxwin/Member.aspx?mod=ConsultantModify");
        });
    },
    CitAr: function () {
        var D = '', T = '', val;
        for (var i = 0; i < 5; i++) {
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
            Me.Bot["City"] = 1;
            pWin.BalC("请选择目前所在地！", "Cit0", "t1");
            return false;
        }
        return true;
    },
    gotoB: function () {
        if (Me.B["ask-Tel"] == '1') {
            if (pWin.Boxif("请输入正确的咨询电话。", "Tel")) return false;
        }
        if (Me.B["ask-QQ"] == '1') {
            if (pWin.Boxif("请输入正确的咨询QQ。", "QQ")) return false;
        }
        if (Me.B["ask-Email"] == '1') {
            if (pWin.Boxif("请输入正确的咨询邮箱。", "Email")) return false;
        }
        if (Me.B["ask-weixin"] == '1') {
            if (pWin.Boxif("请输入正确的咨询微信。", "weixin")) return false;
        }
        if (pWin.Boxif("咨询姓名不能为空！", "Name")) return false;
        if (!Me.CitAr("Manid", "请选择咨询分类")) return false;
        if (!Me.CitAr()) return false;
        $("#ManidT").val($("#Manid").find("option:selected").text());
        $("#ManidsT").val($("#Manidd1").find("option:selected").text());
        var theForm = document.forms['form1'];
        if (!theForm) { theForm = document.form1; }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
}