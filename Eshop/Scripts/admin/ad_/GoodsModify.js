var pWin = window.parent.parent;
if (window == top) top.location.href = "../";
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js"></script>');
var loa = {
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    loadfun: function () {
        var upid = loa.$("VEtitle").value;
        if (upid != "") loa.upidurl += "&upid=" + upid;
        var upids = loa.$("Vupids").value;
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
        loa.DropContact(this.$("upid").value, 'upids', upids);
        this.$("upid").onchange = function () {
            loa.DropContact(this.value, 'upids', upids);
        }

        if (this.$("Goodsadd")) {
            this.$("Goodsadd").innerHTML = "<img src=\"" + pWin.url + "images/tab/AD01.gif\" align=\"middle\" style=\"vertical-align: text-top\" /> " + this.$("Goodsadd").innerHTML;
            this.$("Goodsadd").onclick = function () { loa.zOpen(loa.upidurl, '图片添加'); }
        }
    },
    picking: "== 请选择商品类别 ==",
    Durl: pWin.url + "Apply/Dselect.aspx?from=e_goods_cate&typeID=Number&typeName=title&HTML=$&where=upid&Number=",
    DropContact: function (Numid, Dropid, Dropupid) {
        if (Numid == "" || !this.trim(Numid)) {
            this.$(Dropid).options.add(new Option(loa.picking, ''));
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
    }, winW: 380, winH: 163, upidurl: '', TitleName: "商品图片", Tableurl: "Shop/GoodsListModify.aspx",
zOpen: function (objID, Title) {
    Title = pWin.btFrame.comi1.Re.widthCheck(Title, 20);
    pWin.winlist(this.winW, this.winH, Title, this.Tableurl + "?Ed=Yes" + objID);
}
}
onload = function () { loa.loadfun(); }
function gotoB() {
    if (pWin.Boxif("产品标题不能为空！", "title")) return false;
    if (pWin.Boxif("请选择产品类别！", "upid")) return false;
    if (pWin.Boxif("请选择推荐类别！", "upids")) return false;
    var theForm = document.forms['form1'];
    if (!theForm) { theForm = document.form1; }
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
}