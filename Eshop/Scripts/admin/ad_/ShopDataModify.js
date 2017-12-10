var pWin = window.parent.parent;
if (window == top) top.location.href = "../";
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js"></script>');
var loa = {
    ci: new Array(6),
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    loadfun: function () {
        loa.ci = $("#upid").val().split('|');
        var upid = loa.$("Number").value;
        if (upid != "") loa.upidurl += "&upid=" + upid;
        var tab = loa.$("tabbtm").getElementsByTagName("p");
        for (var i = 0; i < tab.length; i++) {
            tab[i].onclick = function () {
                var tid = this.firstChild.id;
                for (var j = 1; j < (tab.length + 1) ; j++) { loa.$("divt" + j).style.display = "none"; }
                for (var m = 0; m < tab.length; m++) { tab[m].className = ""; }
                this.className = "p";
                loa.$("div" + tid).style.display = "block";
            }
        }
        var optnone = function (im, v, Cim, Cims, civ) {
            for (var m = im; m < v; m++) {
                loa.$("upid" + m).options.length = 0;
                loa.$("upid" + m).style.display = "none";
                loa.DropContact(loa.$(Cim).value, Cims, civ);
            }
        }
        for (var i = 0; i < 5; i++) {
            if (i == 0)
                eval('loa.DropContact("0", "upid' + i + '", loa.ci[' + i + ']);');
            else
                eval('loa.DropContact(loa.ci[' + (i - 1) + '], "upid' + i + '", loa.ci[' + i + ']);');
        }
        $("#upid0").change(function () { optnone(1, 5, "upid0", "upid1", loa.ci[0]); });
        $("#upid1").change(function () { optnone(2, 5, "upid1", "upid2", loa.ci[1]); });
        $("#upid2").change(function () { optnone(3, 5, "upid2", "upid3", loa.ci[2]); });
        $("#upid3").change(function () { optnone(4, 5, "upid3", "upid4", loa.ci[3]); });

        if (this.$("add")) {
            this.$("add").innerHTML = "<img src=\"" + pWin.url + "images/tab/AD01.gif\" align=\"absmiddle\" /> " + this.$("add").innerHTML;
            this.$("add").onclick = function () { loa.zOpen(loa.upidurl, '商品图片添加'); }
        }
        if (this.$("Coloradd")) {
            this.$("Coloradd").innerHTML = "<img src=\"" + pWin.url + "images/tab/AD01.gif\" align=\"absmiddle\" /> " + this.$("Coloradd").innerHTML;
            this.$("Coloradd").onclick = function () { loa.zsOpen(loa.upidurl, '商品列表颜色'); }
        }
    },
    picking: "请选择",
    Durl: pWin.url + "Apply/script/Dselect.aspx?from=ShopClass&typeID=Number&typeName=title&HTML=$&where=upid&Number=",
    DropContact: function (Numid, Dropid, Dropupid) {
        if (Numid == "" || !this.trim(Numid)) {
            this.$(Dropid).options.length = 0;
            this.$(Dropid).style.display = "none";
            return false;
        }
        $.get(this.Durl + Numid, function (data) {
            loa.$(Dropid).options.length = 0;
            var Cent = data, CentArr = Cent.split("$"), textvalue;
            if (!loa.trim(Cent) || Cent == "") {
                loa.$(Dropid).style.display = "none";
            } else {
                loa.$(Dropid).style.display = "";
                loa.$(Dropid).options.add(new Option(loa.picking, ''));
                if (Cent != "" && Cent != null) {
                    for (var i = 0, j = CentArr.length; i < j; i++) {
                        textvalue = CentArr[i].split(",");
                        loa.$(Dropid).options.add(new Option(textvalue[0], textvalue[1]));
                    }
                    for (var i = 0; i < loa.$(Dropid).options.length; i++) {
                        if (loa.$(Dropid).options[i].value == Dropupid) { loa.$(Dropid).options[i].selected = true; break; }
                    }
                }
            }
        });
    },
    ColDr: function () {
        var T = '', V = '';
        for (var i = 0; i < 5; i++) {
            var tv = $('#upid' + i + ' option:selected').text();
            var ta = $("#upid" + i).val();
            if (this.trim(tv)) { if (T != '') T += " - "; if (V != '') V += "|"; T += tv; V += ta; }
        }
        if (!this.trim(V)) { pWin.BalC("请选择商品类别！", "upid0"); return false; }
        $("#upid").val(V); $("#upidT").val(T);
        return true;
    }, winW: 380, winH: 163, upidurl: '', TitleName: "商品图片", Tableurl: "Shop/shoplistModify.aspx", Tableurls: "Shop/ColorClassModify.aspx",
    zOpen: function (objID, Title) {
        Title = pWin.btFrame.comi1.Re.widthCheck(Title, 20);
        pWin.winlist(this.winW, this.winH, Title, this.Tableurl + "?Ed=Yes" + objID);
    },
    zsOpen: function (objID, Title) {
        Title = pWin.btFrame.comi1.Re.widthCheck(Title, 20);
        pWin.winlist(this.winW, this.winH, Title, this.Tableurls + "?Ed=Yes" + objID);
    }
}
onload = function () { loa.loadfun(); }
function gotoB() {
    if (pWin.Boxif("商品标题不能为空！", "title")) return false;
    if (!loa.ColDr()) return false;
    var theForm = document.forms['form1'];
    if (!theForm) { theForm = document.form1; }
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
}