var fileTemplate = "<div>";
fileTemplate += "<div class=\"progressbar\"></div>";
fileTemplate += "<div class=\"preview\"><img src=\"\"/></div>";
fileTemplate += "</div>";

/**
* 提问
* @param	{String}	提问内容
* @param	{Function}	回调函数. 接收参数：输入值
* @param	{String}	默认值
*/
artDialog.prompt = function (content, yes, value) {
    value = value || '';
    var input;

    return artDialog({
        id: 'Prompt',
        icon: 'question',
        fixed: true,
        lock: true,
        opacity: .1,
        content: [
            '<div style="margin-bottom:5px;font-size:12px">',
                content,
            '</div>',
            '<div>',
                '<input value="',
                    value,
                '" style="width:18em;padding:6px 4px" />',
            '</div>'
            ].join(''),
        init: function () {
            input = this.DOM.content.find('input')[0];
            input.select();
            input.focus();
        },
        ok: function (here) {
            return yes && yes.call(this, input.value, here);
        },
        cancel: true
    });
};
var Uploader = function (options) {
    this.initialize(options);
};

Uploader.prototype = {
    defaults: {
        name: "upfile"
    },
    initialize: function (options) {
        var containers = this.container = $(options.container);
        var defaults = this.defaults;
        containers.each(function () {
            var opts = this.options = $.extend({}, defaults, options);
            var container = $(this);
            var target = $(container.attr("target"));
            var mode = container.attr("mode");
            opts.postUrl = container.attr("url");
            if (mode) {
                opts.postUrl += "&mode=" + mode;
            }
            container.html("").append(fileTemplate);
            if (target.val()) {
                var url = target.val();
                if (mode)
                    url = "/static/media/" + url;
                container.find("img").attr("src", url);
            }
            $.extend(opts, {
                onClientLoadStart: function (e, file) {
                    if (container.is(":hidden")) {
                        container.show();
                    }
                },
                onClientLoad: function (e, file) {
                    container.find('img').attr("src", e.target.result);
                },
                onServerLoadStart: function (e, file) {
                    container.find(".progressbar").html("0%");
                },
                onServerProgress: function (e, file) {
                    if (e.lengthComputable) {
                        var percentComplete = (e.loaded / e.total) * 100;
                        container.find(".progressbar").html("" + percentComplete);
                    }
                },
                onServerLoad: function (e, file) {
                    container.find(".progressbar").html("100%")
                },
                onSuccess: function (e, file, resp) {
                    var data = eval("(" + resp + ")");
                    target.val(data.url);
                    url = data.url;
                    if (mode)
                        url = "/static/media/" + url;

                    container.find('img').attr("src", url);
                }
            });
            container.dblclick(function () {
                art.dialog.prompt('请输入图片网址', function (val) {
                    target.val(val);
                    if (mode)
                        container.find('img').attr("src", "/static/media/" + val);
                    else
                        container.find('img').attr("src", val);
                }, target.val());
            });
            container.html5Uploader(opts);
        });
    }
};


function slugify(text) {
    text = text.replace(/[^-a-zA-Z0-9,&\s]+/ig, '');
    text = text.replace(/-/gi, "_");
    text = text.replace(/\s/gi, "-");
    return text;
}
