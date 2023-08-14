let endpoint = `${location.protocol}//${location.host}/getProductsHistory/`; // URL API data
var productData;

$(document).ready(function () {
  $.ajax({
    dataType: "json",
    method: "GET",
    url: endpoint,
    success: function (data) {
      productData = data;
    },
    error: function (error_data) {
      console.log("error", error_data);
    },
  });
});

console.log(productData)
