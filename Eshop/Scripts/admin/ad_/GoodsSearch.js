var pWin = window.parent.parent;
if (window == top) top.location.href = "../";
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js"></script>');
var loa = {
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    loadfun: function () {
        var upids = "";
        loa.DropContact(this.$("upid").value, 'upids', upids);
        this.$("upid").onchange = function () {
            loa.DropContact(this.value, 'upids', upids);
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
    }
}
onload = function () { loa.loadfun(); }
function gotoB() {
    var str = "";
    if (pWin.trim($("emid").value)) { str += "&emid=" + $("emid").value; }
    if (pWin.trim($("title").value)) { str += "&title=" + escape($("title").value); }
    if (pWin.trim($("price").value)) {
        var price = Number($("price").value);
        if (price > 0) str += "&price=" + $("price").value;
    }
    if (pWin.trim($("upid").value)) { str += "&upid=" + escape($("upid").value); }
    if (pWin.trim($("upids").value)) { str += "&upids=" + escape($("upids").value); }
    if (str != "")
        pWin.btFrame.comi1.location.href = "Shop/GoodsInfo.aspx?kk=kk" + str;
    else
        pWin.btFrame.comi1.location.href = "Shop/GoodsInfo.aspx";
}