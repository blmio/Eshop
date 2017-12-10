(function ($) {
    jQuery.fn.extend({
        uploadPreview: function (opts) {
            opts = jQuery.extend({
                width: 0,
                height: 0,
                imgPreview: null,
                imgType: ["gif", "jpeg", "jpg", "bmp", "png"],
                callback: function () { return false; }
            }, opts || {});

            var _self = this;
            var _this = $(this);
            var imgPreview = $(opts.imgPreview);
            /*设置样式*/
            autoScaling = function () {
                imgPreview.css({ "margin-left": 0, "margin-top": 0, "width": opts.width, "height": opts.height });
                imgPreview.show();
            };
            /*file按钮出发事件*/
            _this.change(function () {
                if (this.value) {
                    if (!RegExp("\.(" + opts.imgType.join("|") + ")$", "i").test(this.value.toLowerCase())) {
                        alert("图片类型必须是" + opts.imgType.join("，") + "中的一种");
                        this.value = "";
                        return false;
                    };
                    if ($.browser.msie) {/*判断ie*/
                        var path = $(this).val();
                        if (/"\w\W"/.test(path)) {
                            path = path.slice(1, -1);
                        }
                        imgPreview.attr("src", path);
                        imgPreview.css({ "margin-left": 0, "margin-top": 0, "width": opts.width, "height": opts.height });
                        setTimeout("autoScaling()", 100);
                    } else {
                        if ($.browser.version < 7) {
                            imgPreview.attr('src', this.files.item(0).getAsDataURL());
                        } else {
                            var oFReader = new FileReader(),
                            rFilter = /^(?:image\/bmp|image\/cis\-cod|image\/gif|image\/ief|image\/jpeg|image\/jpeg|image\/jpeg|image\/pipeg|image\/png|image\/svg\+xml|image\/tiff|image\/x\-cmu\-raster|image\/x\-cmx|image\/x\-icon|image\/x\-portable\-anymap|image\/x\-portable\-bitmap|image\/x\-portable\-graymap|image\/x\-portable\-pixmap|image\/x\-rgb|image\/x\-xbitmap|image\/x\-xpixmap|image\/x\-xwindowdump)$/i;
                            oFReader.onload = function (oFREvent) {
                                imgPreview.attr('src', oFREvent.target.result);
                            };
                            var oFile = this.files[0];
                            oFReader.readAsDataURL(oFile);
                        };
                        imgPreview.css({ "margin-left": 0, "margin-top": 0, "width": opts.width, "height": opts.height });
                        setTimeout("autoScaling()", 100);
                    }
                };
                opts.callback();
            });
        }
    });
})(jQuery);