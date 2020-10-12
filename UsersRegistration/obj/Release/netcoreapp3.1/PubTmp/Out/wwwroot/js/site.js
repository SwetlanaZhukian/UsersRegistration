// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $("#checkall").click(function () {
        $("input[type=checkbox]").prop("checked", $(this).prop("checked"))
    })
    $("input[type=checkbox]").click(function () {
        if (!$(this).prop("checked")) {
            $("#checkall").prop("checked", false)
        }
        if ($(".checkitem:checked").length == $(".checkitem").length) {
            $("#checkall").prop("checked", true)
        }
    })

});

$('.checkitem').click(function () {
    if ($(".checkitem:checked").length >= 1) {
        $('#submitbtn').prop('disabled', false);
        $('#submitbtn1').prop('disabled', false);
        $('#submitbtn2').prop('disabled', false);

    } else {
        $('#submitbtn').prop('disabled', true);
        $('#submitbtn1').prop('disabled', true);
        $('#submitbtn2').prop('disabled', true);
    }
});

$('#checkall').click(function () {
    if ($(this).prop("checked") == true) {
        $('#submitbtn').prop('disabled', false);
        $('#submitbtn1').prop('disabled', false);
        $('#submitbtn2').prop('disabled', false);

    } else {
        $('#submitbtn').prop('disabled', true);
        $('#submitbtn1').prop('disabled', true);
        $('#submitbtn2').prop('disabled', true);
    }
});
