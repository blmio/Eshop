if (window == top) top.location.href = "../";
var pWin = window.parent.parent;
function gotoB() { BoxIc.gotoB(); }
var BoxIc = {
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
                BoxIc.$(Dropid).options.length = 0;
                var Cent = xhr.responseText, CentArr = Cent.split("$"), textvalue;
                BoxIc.$(Dropid).options.add(new Option("--- " + tstr + " ---", ''));
                if (Cent != "" && Cent != null) {
                    for (var i = 0, j = CentArr.length; i < j; i++) {
                        textvalue = CentArr[i].split(",");
                        BoxIc.$(Dropid).options.add(new Option(textvalue[0], textvalue[1]));
                    }
                    for (var m = 0; m < BoxIc.$(Dropid).options.length; m++) {
                        if (BoxIc.$(Dropid).options[m].value == Drvalue) { BoxIc.$(Dropid).options[m].selected = true; break; }
                    }
                }
                pWin.hidden(); xhr = null;
            }
        }
        xhr.send(null);
    },
    SmallCh: function (s) {
        if (s.value == "1") {
            this.$("SmallC_ID").style.display = "";
            this.DropCt(this.$("BigC_ID").value, "SmallC_ID", this.SmallC_ID, "请选择小版块");
        } else {
            this.$("SmallC_ID").style.display = "none";
            this.$("SmallC_ID").options.length = 0;
        }
    },
    resWH: 1, FromTable: 'ClinicClass', BigC_ID: '', SmallC_ID: '',
    Setresize: function (sid) {
        switch (sid.value) {
            case "002":
                pWin.win.setSize(600, 285);
                pWin.win.center();
                this.resWH = 0;
                this.FromTable = 'ClinicClass';
                this.$("Tr1").style.display = "";
                this.$("Dropbk").style.display = "";
                this.DropCt('0', "BigC_ID", this.BigC_ID, "请选择大版块");
                this.SmallCh(this.$("SmallC").value);
                break;
            default:
                if (pWin.win) {
                    pWin.win.setSize(400, 235);
                    pWin.win.center();
                }
                this.resWH = 1;
                this.$("Dropbk").style.display = "none";
                this.$("Tr1").style.display = "none";
                break;
        }
    },
    gotoB: function () {
        if (pWin.Boxif("请选择广告类别名！", "Dupid")) return false;
        if (this.resWH == 0) {
            if (pWin.Boxif("请选择大版块！", "BigC_ID")) return false;
            var Smal = this.$("SmallC").value;
            if (Smal == "1") {
                if (pWin.Boxif("请选择小版块！", "SmallC_ID")) return false;
            }
        }
        if (pWin.Boxif("请填写广告名称！", "title")) return false;
        if (pWin.Boxif("请填写广告位置！", "Etitle")) return false;
        var vtr = false;
        var FImgS = this.$("FImgS").value, ImgS = this.$("ImgS").value;
        if (pWin.trim(FImgS)) { vtr = true; }
        if (pWin.trim(ImgS)) { vtr = true; }
        if (!vtr) { pWin.Boxalert("图片不能为空！"); return vtr; }
        var theForm = document.forms['login-form'];
        if (!theForm) {
            theForm = document.login-form;
        }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
};
onload = function () {
    BoxIc.Setresize(BoxIc.$("Dupid"));
    BoxIc.$("Dupid").onchange = function () { BoxIc.Setresize(this); }
    BoxIc.$("BigC_ID").onchange = function () { BoxIc.SmallCh(BoxIc.$("SmallC")); }
    BoxIc.$("SmallC").onchange = function () {
        BoxIc.SmallCh(BoxIc.$("SmallC"));
    }
}