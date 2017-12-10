if (window == top) top.location.href = "../";
var pWin = window.parent.parent;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js\"></script>');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/ext/showDialog.js"></script>');
function gotoB() { Box.gotoB(); }
var Box = {
    B: new Object(),
    A: new Array(6),
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    Durl: pWin.url + "Apply/script/Dselect.aspx?from=NewsClass&typeID=Number&typeName=title&HTML=$&where=upid&Number=",
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
                for (var j = 0; j <= CentArr.length; j++) {
                    if (Box.$(Dropid).options[j].value == Dropupid) { Box.$(Dropid).options[j].selected = true; break; }
                }
            }
        });
    },
    loadfun: function () {
        Box.DropContact("0", "upid0", Box.A[0]);
        Box.DropContact(Box.A[0], "upid1", Box.A[1]);
        Box.DropContact(Box.A[1], "upid2", Box.A[2]);
        var optnone = function (im, Cim, civ) {
            for (var m = im; m < 3; m++) {
                Box.$(Cim + m).options.length = 0;
                Box.$(Cim + m).style.display = "none";
                Box.DropContact(Box.$(Cim + (im - 1)).value, Cim + im, civ);
            }
        }
        var setVideo = function (v) {
            if (v != "C0000001") {
                $("#setVideo").css("display", "none");
                $("#I1F").height(311);
            } else {
                $("#setVideo").css("display", "");
                $("#I1F").height(285);
            }
        }
        setVideo(Box.A[0]);
        $("#upid0").change(function () { optnone(1, "upid", Box.A[0]); setVideo($(this).val()); });
        $("#upid1").change(function () { optnone(2, "upid", Box.A[1]); });
        $("#upid1").change(function () { optnone(3, "upid", Box.A[2]); });
        Box.$('AgidT').readOnly = true;
        $('#AgidT').click(function () {
            showDialog(pWin.url + "admin/Apply/boxwin/Agents.aspx?mod=NewsDataModify");
        });
        Box.$('UsidT').readOnly = true;
        $('#UsidT').click(function () {
            showDialog(pWin.url + "admin/Apply/boxwin/Member.aspx?mod=NewsDataModify");
        });
        $("#Audit").change(function () {
            var mv = $(this).val();
            if (mv == "1") { $("#Audid").css("display", ""); } else { $("#Audid").css("display", "none"); }
        });
    },
    CitAr: function (vt, message, tms) {
        var D = '', T = '', val;
        for (var i = 0; i < 3; i++) {
            val = $("#" + vt + i).val();
            if (Box.trim(val)) {
                if (D != '') D += "|";
                D += val;
                if (T != '') T += " - ";
                T += $("#" + vt + i).find("option:selected").text();
            }
        }
        if (D == '') {
            Box.B[vt] = 1;
            if (tms != 1) pWin.BalC("请选择" + message + "！", vt + "0");
            return false;
        }
        $("#" + vt).val(D);
        $("#" + vt + "T").val(T);
        return true;
    },
    gotoB: function () {
        if (pWin.Boxif("新闻标题不能为空！", "title")) return false;
        if (!Box.CitAr("upid", "新闻分类")) return false;
        if ($("#upid0").val() == "C0000008") {
            var vtr = false;
            var FImgS = this.$("FImgS").value, ImgS = this.$("ImgS").value;
            if (pWin.trim(FImgS)) { vtr = true; }
            if (pWin.trim(ImgS)) { vtr = true; }
            if (!vtr) { pWin.Boxalert("图片不能为空！"); return vtr; }
        }
        var theForm = document.forms['form1'];
        if (!theForm) { theForm = document.form1; }
        if (Box.B["upid"] == "1") { return false; }
        Box.B["upid"] = "1";
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
}
onload = function () {
    Box.B["upid"] = "0";
    Box.A = $("#upid").val().split('|');
    Box.loadfun();
}