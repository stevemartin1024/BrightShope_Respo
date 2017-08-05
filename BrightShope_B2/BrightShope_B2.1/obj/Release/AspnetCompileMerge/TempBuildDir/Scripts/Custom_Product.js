$(document).ready(function ()
{
 
    _GetProductList();

});


//Get list of product from server
function _GetProductList()
{
    var tbody = $('#tbody_ProductList');
    var content;
    $.ajax({

        url: "/Admin_Product/GetListOfProduct",
        type: "GET",
        success: function(data)
        {
            
            $.each(data, function (i, item) {

               

                content += "<tr id='tr_" + item.ProductCode + "'><td>" + item.ProductCode + "</td>" +
                           "<td>" + item.ProdName + "</td>" +
                           "<td>" + item.ProductBrand + "</td>" +
                           "<td>" + item.Category + "</td>" +
                           "<td>" + "₱ " + addZeroes(item.ProdPrice) + "</td>" +
                           "<td>" + "₱ " + addZeroes(item.ProdSellingPrice) + "</td>" +
                           "<td>" + item.Supplier + "</td>" +
                           "<td><a href='#' id='" + item.ProductCode + "' ><span class='glyphicon glyphicon-pencil' ></span></a></td>" +
                           "<td><a href='#' id='" + item.ProductCode + "' ><span class='glyphicon glyphicon-trash'  style='color:red'></span></a></td></tr>";
            });
            tbody.append(content);
        }
    });
}

var addZeroes = function (num) {
    var numberAsString = num.toString();

    if (numberAsString.indexOf('.') === -1) {
        num = num.toFixed(2);
        numberAsString = num.toString();
    } else if (numberAsString.split(".")[1].length < 3) {
        num = num.toFixed(2);
        numberAsString = num.toString();
    }

    return numberAsString
};

