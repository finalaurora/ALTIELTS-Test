// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var rate = 0;

$(document).ready(function () {
    $(".rating-star-block .star").mouseleave(function () {
        var hoverVal = $(this).attr('rating');
        $(this).nextUntil().addClass("outline");
        $(this).nextUntil().removeClass("filled");
    });
    $(".rating-star-block .star").mouseenter(function () {
        var hoverVal = $(this).attr('rating');
        $(this).prevUntil().addClass("filled");
        $(this).addClass("filled");
        $("#RAT").html(hoverVal);
    });

    $(".rating-star-block .star").click(function () {
        var v = $(this).attr('rating');
        rate = v;
    });
});

function setNewScore(container, data) {
    $(container).html(data);
    $("#myElem").show('1000').delay(2000).queue(function (n) {
        $(this).hide(); n();
    });
}