$(".toggle-password").click(function () {

    $(this).toggleClass("fa-eye fa-eye-slash");
    var input = $($(this).attr("toggle"));
    if (input.attr("type") == "password") {
        input.attr("type", "text");
    } else {
        input.attr("type", "password");
    }
});


$('#menu-btn').click(function () {
    if ($(this).prop("checked") == true) {
        $('.left_col').css('margin-left', '0px');
        $('.top_nav,.right_col').css({ 'margin-left': '300px', 'width': 'calc(100% - 300px)' });
        $('.hamburger-menu-icon').css({ 'position': 'relative', 'right': '0' });
        $('.hideMobile-txt').css('display', 'inline-block');
        $('.signOut-section').css({ 'left': '20px', 'right': 'auto' });
        $('.dashboard-logo').css('visibility', 'visible');
    }
    else if ($(this).prop("checked") == false) {
        $('.left_col').css('margin-left', '-250px');
        $('.top_nav,.right_col').css({ 'margin-left': '50px', 'width': 'calc(100% - 50px)' });
        $('.hamburger-menu-icon').css({ 'position': 'absolute', 'right': '0' });
        $('.signOut-section').css({ 'left': 'auto', 'right': '5px' });
        $('.hideMobile-txt').css('display', 'none');
        $('.dashboard-logo').css('visibility', 'hidden');


    }
});

$(window).resize(function () {

    if ($(window).width() <= 1024) {
        $("#menu-btn").prop("checked", false);

    }

});

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

function ShowSlackbarSucessMessage(alertMsg) {
    $("#alertPopup").append("<strong>" + alertMsg + "</strong>")
        .removeAttr("hidden")
        .fadeTo(2000, 500).slideUp(500, function () {
            $("#alertPopup").slideUp(500);
        });
}
function ShowSlackbarErrorMessage(alertMsg) {
    $("#alertErrorPopup").append("<strong>" + alertMsg + "</strong>")
        .removeAttr("hidden")
        .fadeTo(2000, 500).slideUp(500, function () {
            $("#alertErrorPopup").slideUp(500);
            $("#alertErrorPopup").text('');
        });
}