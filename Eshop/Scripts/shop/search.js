var Es = {
    E: new Object(),
    /* 获取url中的参数 */
    getUrlParam: function(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
        var r = window.location.search.substr(1).match(reg);  //匹配目标参数
        if (r != null) return unescape(r[2]); return null; //返回参数值
    },
    showCate: function () {
        $("#refilter .mc div h3").click(function () {
            if ($(this).parent().hasClass("hover"))
                $(this).parent().removeClass("hover");
            else
                $(this).parent().addClass("hover");
        });
    },
    /* 排序 */
    sort: function (num) {
        var str = "";
        switch (num) {
            case '':
                str = "";
                break;
            case '3':
                str = "3";
                break;
            case '1':
                if (this.getUrlParam('psort') == "1")
                    str = "2";
                else
                    str = "1";
                break;
            case '4':
                str = "4";
                break;
        }
        if (this.getUrlParam('bz') != null)
            location.href = EDE.changeURLArg(location.href, "psort", str);
        else
            location.href += "&bz=1&click=&psort=" + str;
    },
    chgColor: function (n) {
        $(".order dd").each(function (index, element) {
            $(this).removeClass();
        })
        /* 获取参数psort的值 */
        var urlParam = window.location.search;
        var loc = urlParam.substring(urlParam.lastIndexOf('=') + 1, urlParam.length);
        switch (loc) {
            case '':
                $(".order dd").eq(0).addClass("curr");
                break;
            case '3':
                $(".order dd").eq(1).addClass("curr down");
                break;
            case '2':
                $(".order dd").eq(2).addClass("price curr down");
                break;
            case '1':
                $(".order dd").eq(2).addClass("price curr up");
                break;
            case '4':
                $(".order dd").eq(3).addClass("curr");
                break;
            default:
                $(".order dd").eq(0).addClass("curr");
                break;
        }
    },
    addCart: function (emid) {
        var url = "mod=cart&&count=1&emid=" + emid;
        $.get(Eurl + "Apply/xmlwrite.aspx?" + url, function (data) {
            var dataArr = data.split('|');
            if (dataArr[1] == "1") {
                EDE.refrCart();
                return;
            }
            alert(dataArr[2]);
        })
    }
}
$(document).ready(function () {
    /*分类显示切换*/
    Es.showCate();
    /*颜色切换*/
    Es.chgColor();
})