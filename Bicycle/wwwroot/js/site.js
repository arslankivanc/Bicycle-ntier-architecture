// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".customlink").mouseover(function () {
    $(this).css("cursor", "pointer");
});
$(".customlink").mouseleave(function () {
    $(this).css("cursor", "default");
});