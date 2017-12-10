var Es = {
    E: new Object(),
    switchTab: function()
    {
        //商品分栏
        $("#pro-detail-hd .m-tab-trigger li").click(function () {
            $(this).parent().find("li").each(function () {
                $(this).removeClass("curr");
            });
            $(this).addClass("curr");

            var panel = $(".right .ui-switchable-panel");
            panel.each(function () {
                $(this).removeClass("ui-switchable-panel-selected");
                $(this).addClass("hide");
                $(this).hide();
            });
            panel.eq($(this).index()).addClass("ui-switchable-panel-selected");
            panel.eq($(this).index()).removeClass("hide");
            panel.eq($(this).index()).show();
        })
        //评价分栏
        $("#product-detail-3 .m-tab-trigger li").click(function () {
            $(this).parent().find("li").each(function () {
                $(this).removeClass("curr");
            });
            $(this).addClass("curr");

            var panel = $(".right .ui-comments-panel");
            panel.each(function () {
                $(this).removeClass("ui-comments-panel-selected");
                $(this).addClass("hide");
                $(this).hide();
            });
            panel.eq($(this).index()).addClass("ui-comments-panel-selected");
            panel.eq($(this).index()).removeClass("hide");
            panel.eq($(this).index()).show();
        })
    },
    buyNum: function (id) {
        var mid = $("#buy-num");
        //匹配数字
        var reg = new RegExp("^[0-9]*$");
        mid.keyup(function () {
            if ($(this).val() < 1 || $(this).val() > 199 || !reg.test($(this).val()))
                $(this).val(1);
        });
        //增加和减少
        $(".btn-reduce").click(function () {
            mid.val(parseInt(mid.val()) - 1);
            if (mid.val() < 1 || mid.val() > 199) mid.val(1);
        });
        $(".btn-add").click(function () {
            mid.val(parseInt(mid.val()) + 1);
            if (mid.val() < 1 || mid.val() > 199) mid.val(199);
        });
    },
    addCart: function () {
        var url = "mod=cart&emid=" + EDE.E["em-id"];
        url += "&count=" + $("#buy-num").val();
        $.get(Eurl + "Apply/xmlwrite.aspx?" + url, function (data) {
            var dataArr =data.split('|');
            if(dataArr[1] == "1") {
                EDE.refrCart();
                return;
            }
            alert(dataArr[2]);
        })
    }
}

$(document).ready(function () {
    Es.switchTab();
    Es.buyNum();
})