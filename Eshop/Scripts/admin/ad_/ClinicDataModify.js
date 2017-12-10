if (window == top) top.location.href = "../";
var pWin = window.parent.parent, Author;
document.write("<script type=\"text/javascript\" src=\"../../Scripts/admin/showdiv.js\"></script>");
function $() { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); }
function trim(s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; }
var ci = new Array(6);
picking = "请选择";
Durl = pWin.url + "Apply/script/Dselect.aspx?from=ClinicClass&typeID=Number&typeName=title&HTML=$&where=upid&Number=";
//二级联动下拉
function DropContact(Number, Dropid, Dropupid) {
    if (Number == "" || !trim(Number)) {
        $(Dropid).options.length = 0;
        $(Dropid).style.display = "none";
        return false;
    }
    var xhr = pWin.XMLHttps(); //调用创建XHR对象的封装函
    xhr.open("get", Durl + Number);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 500) { alert(xhr.responseText); hidden(); return false; }
        if (xhr.readyState == 4 && xhr.status == 200) {
            $(Dropid).options.length = 0;
            var Cent = xhr.responseText, CentArr = Cent.split("$"), textvalue;
            if (!trim(Cent) || Cent == "") {
                $(Dropid).style.display = "none";
            } else {
                $(Dropid).style.display = "";
                $(Dropid).options.add(new Option(picking, ''));
                if (Cent != "" && Cent != null) {
                    for (var i = 0, j = CentArr.length; i < j; i++) { textvalue = CentArr[i].split(","); $(Dropid).options.add(new Option(textvalue[0], textvalue[1])); }
                    for (var i = 0; i < $(Dropid).options.length; i++) { if ($(Dropid).options[i].value == Dropupid) { $(Dropid).options[i].selected = true; break; } }
                }
            }
            xhr = null;
        }
    }
    xhr.send(null);
}
function loadfun() {
    DropContact("0", "upid", ci[0]);
    DropContact(ci[0], "upid1", ci[1]);
    DropContact(ci[1], "upid2", ci[2]);
    DropContact(ci[2], "upid3", ci[3]);
    DropContact(ci[3], "upid4", ci[4]);
    $("upid").onchange = function () {
        $("upid1").options.length = 0;
        $("upid1").style.display = "none";
        $("upid2").options.length = 0;
        $("upid2").style.display = "none";
        $("upid3").options.length = 0;
        $("upid3").style.display = "none";
        $("upid4").options.length = 0;
        $("upid4").style.display = "none";
        DropContact($("upid").value, 'upid1', ci[0]);
    }
    $("upid1").onchange = function () {
        $("upid2").options.length = 0;
        $("upid2").style.display = "none";
        $("upid3").options.length = 0;
        $("upid3").style.display = "none";
        $("upid4").options.length = 0;
        $("upid4").style.display = "none";
        DropContact($("upid1").value, 'upid2', ci[1]);
    }
    $("upid2").onchange = function () {
        $("upid3").options.length = 0;
        $("upid3").style.display = "none";
        $("upid4").options.length = 0;
        $("upid4").style.display = "none";
        DropContact($("upid2").value, 'upid3', ci[2]);
    }
    $("upid3").onchange = function () {
        $("upid4").options.length = 0;
        $("upid4").style.display = "none";
        DropContact($("upid3").value, 'upid4', ci[3]);
    }
    $("Author").onclick = function () { showdiv(this.id, Author); }
}

function gotoB() {
    if (pWin.Boxif("请选择科室疾病类别！", "upid")) return false;
    if (pWin.Boxif("标题名称不能为空！", "title")) return false;
    var theForm = document.forms['login-form'];
    if (!theForm) {
        theForm = document.login-form;
    }
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
}
