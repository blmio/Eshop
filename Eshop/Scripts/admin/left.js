if (window == top) top.location.href = "Default.aspx";
var pWin = window.parent.parent;
document.write('<script type="text/javascript" src="' + pWin.url + 'Scripts/jquery/jquery-min.js\"></script>');
var Le = {
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    mer: null,
    load: function () {
        $("#matop").html('<div class="load"></div>');
    },
    leftall: function () {
        this.load();
        var met = this.mer ? this.mer : 'par1';
        var tm = new Date().getTime();
        $.get('Apply/Boxhtml.aspx?mod=left&mer=' + met + "&tm=" + tm, function (data) {
            $("#matop").html(data);
            Le.centerhov();
        });
    },
    centerhov: function () {
        $("#matop .center div.T").hover(function () {
            $(this).removeClass().addClass("Ts");
        }, function () {
            $(this).removeClass().addClass("T");
        }).click(function () {
            var em = $(this).find("em").eq(0).attr('class');
            if (em == "e") {
                $(this).find("em").removeClass('e');
            } else {
                $(this).find("em").addClass('e');
            }
            $(this).next("div.C").slideToggle("slow");
            //Le.fixL();
        }).each(function () {
            var em = $(this).find("em").eq(0).attr('class');
            if (em == "e")
                $(this).next("div.C").css("display", "none");
            else
                $(this).next("div.C").css("display", "block");

            var esi = $(this).attr('esi');
            if (esi != Le.mer) {
                $(this).next("div.C").css("display", "none");
                $(this).find("em").eq(0).addClass('e');
            }
            else {
                $(this).next("div.C").css("display", "block");
                $(this).find("em").eq(0).removeClass('e');
            }
            //Le.fixL();
        });
        $("#matop .center p").click(function () {
            $("#matop .center p").removeClass("a");
            $(this).addClass("a");
        });
    },
    fixL: function () {
        var h = 20;
        $("#matop .center div.T em.e").each(function () {
            var pel = $(this).parent().next("div.C").find("p");
            pel.each(function () {
                h = h + 18;
            });
        });
        $("#matop .center div.T").each(function () { h = h + 25; });
        $("#fixL").css({ "height": h + "px", "display": "block" });
        alert(h);
    }
}
