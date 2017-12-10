if (top != self) top.location.href = "Default.aspx";
var url = "", Wurl = "";
function $() { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); }
function trim(s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; }
document.write("<script type=\"text/javascript\" src=\"../Scripts/ext/ext-base.js\"><\/script>");
document.write("<script type=\"text/javascript\" src=\"../Scripts/ext/ext-all.js\"><\/script>");
function jsload(_url, idm) {
    if (!$(idm)) {
        var _js = document.createElement("script");
        _js.id = idm;
        _js.setAttribute("type", "text/javascript");
        _js.setAttribute("src", _url);
        document.body.appendChild(_js);
    }
}
function Email(s) { return s.match(/^[\w]{1}[\w\.\-_]*@[\w]{1}[\w\-_\.]*\.[\w]{2,4}$/i); }
function Dwm() {
    var today = new Date();
    var day;
    var date;
    if (today.getDay() == 0) day = "星期日";
    if (today.getDay() == 1) day = "星期一";
    if (today.getDay() == 2) day = "星期二";
    if (today.getDay() == 3) day = "星期三";
    if (today.getDay() == 4) day = "星期四";
    if (today.getDay() == 5) day = "星期五";
    if (today.getDay() == 6) day = "星期六";
    date1 = (today.getFullYear()) + "年" + (today.getMonth() + 1) + "月" + today.getDate() + "日&nbsp;&nbsp;";
    date2 = day;
    document.getElementById("SDwm").innerHTML = "今天是：" + date1 + date2;
}
var btvar = 0;
function tophead(vid) {
    vid = vid ? vid : "tophead";
    var ulli = $(vid).getElementsByTagName("li");
    var Changeiframe = function (tv) {
        for (var li = 0; li <= ulli.length - 1; li++) { ulli[li].className = ''; }
        tv.className = 'lm';
        if (btvar == 1) { window.frames["btFrame"].gotleft();}
    }
    for (var tli = 0; tli <= ulli.length - 1; tli++) {
        ulli[tli].onmouseout = function () {
            var tcl = this.className;
            if (tcl.indexOf('lm') > -1)
                this.className = "lm";
            else
                this.className = "";
        }
        ulli[tli].onmouseover = function () {
            var tcl = this.className;
            if (tcl.indexOf('lm') > -1)
                this.className = "li lm";
            else
                this.className = "li";
        }
        ulli[tli].onclick = function () {
            window.open("left.aspx?mer=" + this.id, "leftall");
            Changeiframe(this);
        }
    }
}

var TBcust = 0, Pagerul = "", pageall = 0;
function Pages(Page) {
    if (Pagerul != "") {
        if (document.getElementById("VwmM") && !Vwm.hidden)
            window.VwmM.location.href = Pagerul + "&Page=" + Page;
        if (document.getElementById("BasicR") && !winlay.hidden)
            window.BasicR.location.href = Pagerul + "&Page=" + Page;
        else
            window.btFrame.comi1.location.href = Pagerul + "&Page=" + Page;
    }
}
function checkPage(evt, page) {
    evt = (evt) ? evt : ((window.btFrame.comi1.event) ? event : null);
    if (pageall <= 1) { return false; }
    var Textp = window.btFrame.comi1.document.getElementById("PageText").value;
    if (isNaN(page) && page == "") { Textp = ""; return false; }
    if (evt) {
        if (evt.keyCode == 13) {
            var pa = Number(page); if (pa <= pageall) { Pages(page); } else { return false; }
        }
    } else { return false; }
}
function changeUrl(page) { if (pageall > 1) { if (!isNaN(page) && page != "") { var pa = Number(page); if (pa <= pageall) { Pages(page); } } } }
