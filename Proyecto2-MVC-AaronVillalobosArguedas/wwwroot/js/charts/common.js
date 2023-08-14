$(document).ready(function () {
  $('[data-toggle="tooltip"]').tooltip();
});

$(function() {
    $('#dataTypeAdd').change(function(){
        $('.addSelection').hide();
        $('#' + $(this).val()).show();
    });
});

$(function() {
    $('#dataTypeRem').change(function(){
        $('.remSelection').hide();
        $('#' + $(this).val()).show();
    });
});

function logout() {
    window.location.href = location.protocol + "//" + location.host + "/logout/";
}