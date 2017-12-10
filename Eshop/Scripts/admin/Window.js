var win, surl, frid = "Suiframe";
function winShow(W, H, T, url) {
    if (surl != url) {
        if (win) winCle();
        surl = url;
        win = false;
    }
    if (!win) {
        frid = "Feid" + new Date().getTime();
        win = new Ext.Window({
            title: T,
            layout: 'fit',
            width: W,
            height: H,
            closeAction: 'hide',
            plain: true,
            //maximizable:true,
            //loadMask:"正在加载",
            //modal:false,
            //border: false,
            buttonAlign: 'center',
            html: '<iframe src="' + url + '" width="100%" height="100%" frameborder="0" style="border:none;" id="' + frid + '" name="' + frid + '"></iframe>',
            buttons: [{ text: '确定', handler: function () { ifrsubmit(); } }, { text: '取消', handler: function () { win.hide(); } }]
        });
    }
    win.show();
    //alert(win.el.dom.innerHTML);
}

function winView(W, H, T, url) {
    if (surl != url) {
        if (win) winCle();
        surl = url;
        win = false;
    }
    if (!win) {
        frid = "Feid" + new Date().getTime();
        win = new Ext.Window({
            title: T,
            layout: 'fit',
            width: W,
            height: H,
            closeAction: 'hide',
            plain: true,
            html: '<iframe src="' + url + '" width="100%" height="100%" frameborder="0" style="border:none;" id="' + frid + '" name="' + frid + '"></iframe>'
        });
    }
    win.show();
    //alert(winS.el.dom.innerHTML);
}

function winClose(ifrmname) {
    win.hide();
    win = false;
    window.btFrame.comi1.location.href = ifrmname + "&news=" + new Date().getTime();
}

function winCle() {
    win.hide();
    win = false;
}
function winCleload() {
    win.hide();
    win = false;
    if (document.getElementById("BasicR") && !winlay.hidden)
        window.BasicR.location.reload();
    else if (document.getElementById("VwmM") && !Vwm.hidden)
        window.VwmM.location.reload();
    else
        window.btFrame.comi1.location.reload();
}

function VwmCleload() {
    win.hide();
    win = false;
    if (document.getElementById("VwmM") && !Vwm.hidden)
        window.VwmM.location.reload();
    else if (document.getElementById("BasicR") && !winlay.hidden)
        window.BasicR.location.reload();
    else
        window.btFrame.comi1.location.reload();
}

function ifrsubmit(v) {
    if (!v) v = frid;
    var iframeTest = window.frames[v];
    iframeTest.gotoB();
}

function Boxfirm(str, url) {
    Ext.MessageBox.confirm(
		'Confirm',
		str,
		function (btn) {
		    if (btn == "yes") {
		        window.btFrame.comi1.location.href = url + "&news=" + new Date().getTime();
		    }
		}
	);
}
function BoxfirmD(str, DeletObj, v) {
    Ext.MessageBox.confirm(
		'Confirm',
		str,
		function (btn) {
		    if (btn == "yes") BoxDelet(DeletObj, v);
		}
	);
}

function BoxDelet(DeletObj, v) {
    TanCen(); var now = new Date().getTime();
    var xhr = XMLHttps(); //调用创建XHR对象的封装函
    xhr.open("get", "Apply/Boxhtml.aspx?mod=BoxDelet&" + DeletObj + "&now=" + now);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 500) { alert(xhr.responseText); return false; }
        if (xhr.readyState == 4 && xhr.status == 200) {
            var Centt = xhr.responseText;
            TanCenstr(Centt);
            hidden();
            if (document.getElementById("VwmM") && !Vwm.hidden)
                window.VwmM.location.reload();
            else if (document.getElementById("BasicR") && !winlay.hidden)
                window.BasicR.location.reload();
            else if (v == '1')
                eval("indow." + frid + ".shoplist.location.reload();");
            else
                window.btFrame.comi1.location.reload();
            xhr = null;
        }
    }
    xhr.send(null);
}

function Boxicons(str) {
    Ext.MessageBox.show({
        title: 'Icon Support',
        msg: 'Here is a message with an icon!',
        buttons: Ext.MessageBox.OK,
        //fn: showResult,
        icon: "warning"
    });
}
//弹出操作提示
function Boxalert(str) {
    Ext.MessageBox.alert('操作提示！', str);
}

function BoxfirmLo(str, Curl) {
    Ext.MessageBox.confirm(
		'Confirm',
		str,
		function (btn) {
		    if (btn == "yes") Lockrel(Curl);
		}
	);
}

function Lockrel(Curl) {
    TanCen(); var now = new Date().getTime();
    var xhr = XMLHttps(); //调用创建XHR对象的封装函
    xhr.open("get", "Apply/Boxhtml.aspx?mod=Lock&" + Curl + "&now=" + now);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 500) { alert(xhr.responseText); return false; }
        if (xhr.readyState == 4 && xhr.status == 200) {
            var Centt = xhr.responseText;
            TanCenstr(Centt); hidden();
            if (document.getElementById("VwmM") && !Vwm.hidden)
                window.VwmM.location.reload();
            else if (document.getElementById("BasicR") && !winlay.hidden)
                window.BasicR.location.reload();
            else
                window.btFrame.comi1.location.reload();
            xhr = null;
        }
    }
    xhr.send(null);
}


function SortOpen(objID, Title) {
    winShow(200, 105, Title + "排序", "Apply/Sort.aspx?id=" + objID);
}
function Reloade() { top.location.href("../../login.aspx"); }

//弹出操作提示
function BalC(str, Contl) {
    Ext.MessageBox.alert('操作提示！', str, function () { focT(Contl); })
}
function focT(Contl) {
    var iframeTest = window.frames[frid];
    iframeTest.document.getElementById(Contl).focus();
}
function Su$() {
    var iframeTest = window.frames[frid];
    return iframeTest.document.getElementById ? iframeTest.document.getElementById(arguments[0]) : eval(arguments[0]);
}
function bannerT() {
    var v = window.btFrame.comi1.derF["bannerT"];
    if (trim(v)) return v;
    return "";
}
function Boxif(str, Contl) {
    if (!trim(Su$(Contl).value)) {
        Ext.MessageBox.alert('操作提示！', str, function () {
            var iframeTest = window.frames[frid];
            iframeTest.document.getElementById(Contl).focus();
        });
        return true;
    }
    return false;
}
var list, lurl;
function winlist(W, H, T, url) {
    if (lurl != url) {
        if (list) listCle();
        lurl = url;
        list = false;
    }
    if (!list) {
        list = new Ext.Window({
            title: T,
            //layout:'fit',
            width: W,
            height: H,
            closeAction: 'hide',
            plain: true,
            maximizable: true,
            loadMask: "正在加载",
            modal: false,
            //border: false,
            buttonAlign: 'center',
            html: '<iframe src="' + url + '" width="100%" height="100%" frameborder="0" style="border:none;" id="listframe" name="listframe"></iframe>',
            buttons: [{ text: '确定', handler: function () { ifrsubmit('listframe'); } }, { text: '取消', handler: function () { list.hide(); } }]
        });
    }
    list.show();
    //alert(list.el.dom.innerHTML);
}
function listCle() {
    list.hide();
    list = false;
}
function listCleload(listid) {
    if (!listid) listid = "shoplist";
    if (listid == "" || listid == null) listid = "shoplist";
    list.hide();
    list = false;
    if (document.getElementById(listid) && !winlay.hidden) {
        eval("window." + listid + ".location.reload();");
    } else if (document.getElementById("VwmM") && !Vwm.hidden)
        window.VwmM.location.reload();
    else
        eval("window." + frid + "." + listid + ".location.reload();");
}
//弹出操作提示
function lisC(str, Contl) {
    Ext.MessageBox.alert('操作提示！', str, function () { focT(Contl); })
}
function lisT(Contl) {
    var iframeTest = window.frames["listframe"];
    iframeTest.document.getElementById(Contl).focus();
}
function Sust() {
    var iframeTest = window.frames["listframe"];
    return iframeTest.document.getElementById ? iframeTest.document.getElementById(arguments[0]) : eval(arguments[0]);
}
function listf(str, Contl) {
    if (!trim(Sust(Contl).value)) {
        Ext.MessageBox.alert('操作提示！', str, function () {
            var iframeTest = window.frames["listframe"];
            iframeTest.document.getElementById(Contl).focus();
        });
        return true;
    }
    return false;
}