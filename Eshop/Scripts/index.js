var Es = {
    E: new Object(),
    autoFlash: function () {
        //图片轮播效果
        var wrap = $("#auc_slider .auc_wrap li");
        var trigger = $("#auc_slider .auc_trigger a");
        var len = wrap.length;
        var num = 0;
        var pick = function () {
            EDE.E["focus"] = setInterval(function () {
                wrap.eq(num).css('z-index', '0');
                wrap.eq(num).css('opacity', '0');
                wrap.eq(num).removeClass("panel-selected");
                trigger.eq(num).removeClass("curr");

                num++;
                wrap.eq(num % len).css('z-index', '1');
                wrap.eq(num % len).animate({ opacity: "1" }, 500);
                wrap.eq(num % len).addClass("panel-selected");
                trigger.eq(num % len).addClass("curr");

                if (num > len - 1) num = 0;
            }, 5000);
        }
        wrap.parent().hover(function () { clearInterval(EDE.E["focus"]); }, function () { pick(); });
        trigger.hover(function () {
            var index = $(this).index();
            trigger.each(function (index, element) {
                $(this).removeClass("curr");
            });
            $(this).addClass("curr");

            wrap.each(function (index, element) {
                $(this).css('z-index', '0');
                $(this).css('opacity', '0');
                $(this).removeClass("panel-selected");
            });
            wrap.eq(index).css('z-index', '1');
            wrap.eq(index).animate({ opacity: "1" }, 500);
            wrap.eq(index).addClass("panel-selected");

            EDE.E["focus"] = window.clearInterval(EDE.E["focus"]);
        }, function () { pick(); });
        pick();
    },
    showCateItem: function () {
        // 分类显示效果
        var cateItem = $(".aucCategorys .item");
        cateItem.hover(function () {
            $(this).addClass("current");
            $(this).find(".sub_item ").show();
        }, function () {
            $(this).removeClass("current");
            $(this).find(".sub_item ").hide();
        });
    }
}

$(document).ready(function () {
    /* 图片自动播放 */
    Es.autoFlash();
    /* 显示所有分类 */
    Es.showCateItem();
});