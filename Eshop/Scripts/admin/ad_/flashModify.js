if (window == top) top.location.href = "../";
var pWin = window.parent.parent;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js\"></script>');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery.cxcalendar.min.js\"></script>');
document.write('<link href="' + pWin.url + 'Scripts/jquery/jquery.cxcalendar.css" type="text/css" rel="stylesheet" />');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/ext/showDialog.js"></script>');
function gotoB() { Boxfl.gotoB(); }
var Boxfl = {
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    Durl: '',
    DropCt: function (Number, Dropid, Drvalue, tstr) {
        if (Number == "" || !this.trim(Number)) {
            this.$(Dropid).options.length = 0;
            this.$(Dropid).options.add(new Option("--- " + tstr + " ---", ''));
            return false;
        }
        this.Durl = pWin.url + "Apply/script/Dselect.aspx?from=" + this.FromTable + "&typeID=Number&typeName=title&HTML=$&where=upid&Number=";
        pWin.TanCen();
        var xhr = pWin.XMLHttps(); //调用创建XHR对象的封装函
        xhr.open("get", this.Durl + Number);
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 500) { alert(xhr.responseText); hidden(); return false; }
            if (xhr.readyState == 4 && xhr.status == 200) {
                Boxfl.$(Dropid).options.length = 0;
                var Cent = xhr.responseText, CentArr = Cent.split("$"), textvalue;
                Boxfl.$(Dropid).options.add(new Option("--- " + tstr + " ---", ''));
                if (Cent != "" && Cent != null) {
                    for (var i = 0, j = CentArr.length; i < j; i++) {
                        textvalue = CentArr[i].split(",");
                        Boxfl.$(Dropid).options.add(new Option(textvalue[0], textvalue[1]));
                    }
                    for (var m = 0; m < Boxfl.$(Dropid).options.length; m++) {
                        if (Boxfl.$(Dropid).options[m].value == Drvalue) { Boxfl.$(Dropid).options[m].selected = true; break; }
                    }
                }
                pWin.hidden(); xhr = null;
            }
        }
        xhr.send(null);
    },
    gotoB: function () {
        if (pWin.Boxif("请填写图片名称！", "title")) return false;
        var vtr = false;
        var FImgS = this.$("FImgS").value, ImgS = this.$("ImgS").value;
        if (pWin.trim(FImgS)) { vtr = true; }
        if (pWin.trim(ImgS)) { vtr = true; }
        if (!vtr) { pWin.Boxalert("图片不能为空！"); return vtr; }
        var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
}