/// <reference path="jquery-1.4.1-vsdoc.js" />

$(function () {
    $("a[href=#]").click(function (e) {
        e.preventDefault();
    });

    $.ajaxSetup({
        beforeSend: function (xhr) {
            showLoading(true);
        },
        complete: function (xhr, textStatus) {
            showLoading(false);
        },
        error: function (xhr, textStatus, errorThrown) {
            //alert($("<div>").html(xhr.responseText).html());
            //showError($("h2 i", $(xhr.responseText)).text());
        }
    });

});

function showLoading(show) {
    if (show) {
        $("#loading span").css({
            top: ($("#loading").height() / 2 - $("#loading span").height() / 2) + "px",
            left: ($("#loading").width() / 2 - $("#loading span").width() / 2) + "px"
        });;

        $("#loading").fadeIn();
    }
    else {
        $("#loading").fadeOut();
    }
}

function rnd() {
    rnd.seed = (rnd.seed * 9301 + 49297) % 233280;
    return rnd.seed / (233280.0);
};

rnd.today = new Date();
rnd.seed = rnd.today.getTime();

function rand(number) {
    return Math.ceil(rnd() * number);
};
