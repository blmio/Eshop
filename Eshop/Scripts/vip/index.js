var vip = {
    v: new Object(),
    selected: function () {
        $(".b ol li a").click(function () {
            $(".b ol li").each(function () {
                $(this).removeClass();
            });
            $(this).parent().addClass("current");
            vip.getRight($(this));
        });
    },
    getRight: function (object) {
        var mod = "";
        var id = object.parent().attr("id");
        mod =  id + "&m=" + EDE.E["number"];
        //ajax请求
        $.get(Eurl + "vip/Apply/xmlWrite.aspx?mod=" + mod, function (data) {
            $(".right").html(data);

            //注册事件
            vip.post();
            vip.cartSelected();
            vip.showAppra();
        });
    },
    post: function () {
        $("#form1 .btns").click(function () {
            EDE.E["btnId"] = $(this).attr('id');
            vip.submitForm("#form1", EDE.E["btnId"]);
        });
    },
    submitForm: function (formid, mod) {
        /*提交表单(ajax)*/
        var path = Eurl + "vip/Apply/xmlWrite.aspx?mod=" + mod + "&m=" + EDE.E["number"];
        $.ajax({
            type: "POST",
            dataType: "html",
            url: path,
            data: $(formid).serialize(),
            success: function (result) {
                vip.Xerror(result);
            }
        })
    },
    Xerror: function (message) {
        //返回信息处理
        var msgArr = message.split('|');
        $("#form1 .btns").disabled = false;
        alert(msgArr[2]);
    },/* 购物车操作 */
    cartSelected: function () {
        var checkItem = $("ul.item .item-checkbox");
        checkItem.click(function () {
            if ($(this).attr("checked")) {
                var Value = parseFloat($(this).parent().parent().siblings(".total-price").text()) + parseFloat($(".price em").attr("data-bind"));
                var Count = parseInt($(this).parent().parent().siblings(".item-count").text()) + parseInt($(".amount-sum em").text());
                $(".amount-sum em").text(Count);
                var Value = Value.toFixed(2); //保留两位小数
                $(".price em").attr("data-bind", Value);
                $(".price em").text("￥" + Value);
            }
            else {
                var Value = parseFloat($(".price em").attr("data-bind")) - parseFloat($(this).parent().parent().siblings(".total-price").text());
                var Count = parseInt($(".amount-sum em").text()) - parseInt($(this).parent().parent().siblings(".item-count").text());
                $(".amount-sum em").text(Count);
                var Value = Value.toFixed(2); //保留两位小数
                $(".price em").attr("data-bind", Value);
                $(".price em").text("￥" + Value);
                //去掉全选
                $("#toggle-checkboxes_down").attr("checked", "");
            }
        });
        //删除操作
        var deleteItem = $("ul.item .delete");
        deleteItem.click(function () {
            var path = $(this).attr("data-id") + "&m=" + EDE.E["number"];
            $.get(Eurl + "vip/Apply/xmlWrite.aspx?mod=deleteCart&gdid=" + path, function (result) {
                vip.Xerror(result);
                vip.getRight($("#li-cart a"));
            })
        });
        $("#form1 .remove-batch").click(function () {
            var gdid = "";
            checkItem.each(function (index, element) {
                if ($(this).attr("checked")) {
                    if (gdid == "")
                        gdid = $(this).siblings("#item-gdid").val();
                    else
                        gdid += "|" + $(this).siblings("#item-gdid").val();
                }
            })

            var path = Eurl + "vip/Apply/xmlWrite.aspx?mod=deleteCart&gdid=" + gdid + "&m=" + EDE.E["number"];
            $.get(path, function (result) {
                vip.Xerror(result);
                vip.getRight($("#li-cart a"));
            })
        });

        //自动计算价格
        $("#toggle-checkboxes_down").click(function () {
                if ($(this).attr("checked")) {
                    checkItem.each(function (index, element) {
                        $(this).attr("checked", "true");
                        var Value = parseFloat($(this).parent().parent().siblings(".total-price").text()) + parseFloat($(".price em").attr("data-bind"));
                        var Count = parseInt($(this).parent().parent().siblings(".item-count").text()) + parseInt($(".amount-sum em").text());
                        $(".amount-sum em").text(Count);
                        var Value = Value.toFixed(2); //保留两位小数
                        $(".price em").attr("data-bind", Value);
                        $(".price em").text("￥" + Value);
                    })
                }    
                else {
                    checkItem.each(function (index, element) {
                        $(this).attr("checked", "");
                        $(".amount-sum em").text("0");
                        $(".price em").attr("data-bind", "0.00");
                        $(".price em").text("￥0.00");
                    })
                }
        });
        //提交表单
        $("#form1 .submit-btn").click(function () {
            var gdid = "";
            checkItem.each(function (index, element) {
                if ($(this).attr("checked"))
                {
                    if (gdid == "")
                        gdid = $(this).siblings("#item-gdid").val();
                    else
                        gdid += "|" + $(this).siblings("#item-gdid").val();
                }
            })

            var path = Eurl + "vip/Apply/xmlWrite.aspx?mod=btn_cart&gdid=" + gdid + "&m=" + EDE.E["number"];
            $.get(path, function (result) {
                vip.Xerror(result);
                vip.getRight($("#li-cart a"));
            })
        });
    },
    showAppra: function () {
        $("ul.item .confirm").click(function () {
            var data = $("ul.item .text span").text();
            alert(data);
        })
    }
}

$(document).ready(function () {
    /* 选中效果 */
    vip.selected();
    /* 初始化 */
    vip.getRight($("#li-zl a"));
    $("#li-zl").addClass('current');
})