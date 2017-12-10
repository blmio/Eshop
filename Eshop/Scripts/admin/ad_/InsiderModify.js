if (window == top) top.location.href = "../";
var pWin = window.parent.parent;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js"></script>');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/ext/showDialog.js"></script>');
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery.cxcalendar.min.js\"></script>');
document.write('<link href="' + pWin.url + 'Scripts/jquery/jquery.cxcalendar.css" type="text/css" rel="stylesheet" />');
var Me = {
    A: new Array(6),
    ci: new Array(6),
    Bot: new Object(),
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    loadfun: function () {
        Me.$('AgidT').readOnly = true;
        $('#AgidT').click(function () {
            showDialog(pWin.url + "admin/Apply/boxwin/Agents.aspx?mod=InsiderModify");
        });
        Me.$('UsidT').readOnly = true;
        $('#UsidT').click(function () {
            showDialog(pWin.url + "admin/Apply/boxwin/Member.aspx?mod=InsiderModify");
        });
        $('#Age').cxCalendar();
        Me.$('Age').readOnly = true;
        $("#Audit").change(function () {
            var mv = $(this).val();
            if (mv == "1") { $("#Audid").css("display", ""); } else { $("#Audid").css("display", "none"); }
        });
    },
    gotoB: function () {
        var htex = $("#Manid").find("option:selected").text();
        $("#ManidT").val(htex);
        htex = $("#Manidd1").find("option:selected").text();
        $("#ManidsT").val(htex);
        var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) { theForm.submit(); /*提交表单*/ }
    }
}
function gotoB() { Me.gotoB(); }