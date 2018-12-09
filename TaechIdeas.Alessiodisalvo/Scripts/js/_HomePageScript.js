var index = 1;
var t;

$('.content > div > .grid').infinitescroll({
    debug: false,
    loading: {
        finished: function(opts) {},
        start: startAjax,
    },
    navSelector: "#infinitescroll",
    nextSelector: "#infinitescroll",
    itemSelector: "figure",
    dataType: 'html',
    maxPage: 4,
    path: function(index) {
        var count = parseInt(index) - 1;
        return "ajax/content-" + count + ".html";
    },
});

function startAjax(opts) {
    $.infinitescroll.prototype.options = opts;
    $.infinitescroll.prototype.beginAjax(opts);
}