var EDE = {
    E: new Object(),
    $: function () { return document.getElementById ? document.getElementById(arguments[0]) : eval(arguments[0]); },
    trim: function (s) { if (s != "" && s != null) { return s.replace(/(^\s*)|(\s*$)/g, ""); } return null; },
    URLParams: new Object(), aParams: document.location.search.substr(1).split('&'),
    URLfor: function () {
        var aParam;
        for (i = 0; i < EDE.aParams.length; i++) {
            aParam = EDE.aParams[i].split('=');
            if (this.trim(aParam[0])) EDE.URLParams[aParam[0]] = aParam[1];
        }
    },/*退出登录*/
    local: function (key) {
        var str = "";
        switch (key) {
            case "Login":
                str = "member/login.aspx?&";
                break
            case "Exit":
                str = "Apply/xmlWrite.aspx?mod=login&&login=Logoff&";
                break
        }
        location.href = Eurl + str + "url=" + escape(location.href);
    }, /*加入收藏*/
    AddFavorite: function (sURL, sTitle) {
        sURL = encodeURI(sURL);
        try {
            window.external.addFavorite(sURL, sTitle);
        } catch (e) {
            try {
                window.sidebar.addPanel(sTitle, sURL, "");
            } catch (e) {
                alert("加入收藏失败，请使用Ctrl+D进行添加,或手动在浏览器里进行设置.");
            }
        }
    },
    submitForm: function (formid, mod) {
        /*提交表单(ajax)*/
        var path = Eurl + "Apply/xmlwrite.aspx?mod=" + mod;
        $.ajax({
            type: "POST",
            dataType: "html",
            url: path,
            data: $(formid).serialize(),
            success: function (result) {
                Es.Xerror(result);
            }
        })
    },
    include: function (file) {
        var files = typeof file == "string" ? [file] : file;
        for (var i = 0; i < files.length; i++) {
            var name = files[i].replace(/^\s|\s$/g, ""), att = name.split('.'), ext = att[att.length - 1].toLowerCase();
            var isCSS = ext == "css", tag = isCSS ? "link" : "script",
            attr = isCSS ? " type='text/css' rel='stylesheet'" : " language='javascript' type='text/javascript'",
            Uname = (name.indexOf('http://') > -1) ? name : Eurl + name,
            link = (isCSS ? "href" : "src") + "='" + Uname + "'";
            if ($(tag + "[" + link + "]").length == 0) $("<" + tag + attr + link + "></" + tag + ">").appendTo("head");
        }
    },
    search: function (word) {
        var value = $("#" + word).val();
        if (this.trim(value))
            location.href = "../search.aspx?keys=" + value;
        else
            location.reload();
    },
    goTop: function () {
        $(window).scroll(function () {
            if ($(window).scrollTop() > 100)
                $("#go-top").css('display', 'block');
            else
                $("#go-top").css('display', 'none');

        });
        //渐渐返回顶部
        $("#go-top .j-go-top").click(function () {
            $('body,html').animate({ scrollTop: 0 }, $(window).scrollTop() / 5);
            return false;
        });
    }, /*  * url 目标url   * arg 需要替换的参数名称   * arg_val 替换后的参数的值   * return url 参数替换后的url  */
    changeURLArg: function (url, arg, arg_val) {
        var pattern = arg + '=([^&]*)';
        var replaceText = arg + '=' + arg_val;
        if (url.match(pattern)) {
            var tmp = '/(' + arg + '=)([^&]*)/gi';
            tmp = url.replace(eval(tmp), replaceText);
            return tmp;
        } else {
            if (url.match('[\?]')) {
                return url + '&' + replaceText;
            } else {
                return url + '?' + replaceText;
            }
        }
        return url + '\n' + arg + '\n' + arg_val;
    },
    hoverCart: function(){
        $("#settleup").hover(function (e) {
            $(this).addClass('hover');
            e.stopPropagation();  //阻止事件冒泡
            EDE.deleteCart();
        }, function () {
            $(this).removeClass('hover');
            e.stopPropagation();
        })
    },
    deleteCart: function () {
        $("#mcart-mz .delete").click(function () {
            var url = "mod=dCart&emid=" + $(this).attr("data-id");
            $.get(Eurl + "Apply/xmlwrite.aspx?" + url, function (data) {
                var dataArr = data.split('|');
                if (dataArr[1] == "1") {
                    EDE.refrCart();
                    return;
                }
                alert(dataArr[2]);
            })
        });
    },
    refrCart: function () {
        $.get(Eurl + "Apply/xmlwrite.aspx?mod=refrCart", function (data) { $("#settleup").html(data); })
    }
}
onload = function () { EDE.goTop(); EDE.hoverCart();}