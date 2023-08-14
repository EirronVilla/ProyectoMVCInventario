// Call the dataTables jQuery plugin
$(document).ready(function() {
  $('#dataTable').DataTable();
});

$(document).ready(function() {
  var table = $('#dataTable').DataTable();
   
  $('#dataTable tbody').on('click', 'tr', function () {
      // var data = table.row( this ).data();
      // $(location).attr('href', _href + '?' + 
      window.document.location = $(this).attr("data-id") + "/";
})});

$(document).ready(function() {
  var table = $('#dataTable').DataTable();
   
  $('.warning-table tbody').on('click', 'tr', function () {
      window.location.href = location.protocol + "//" + location.host + "/primes/" + $(this).attr("data-id");
})});