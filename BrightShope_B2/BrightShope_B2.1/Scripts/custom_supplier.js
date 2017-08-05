


//DocumentReady
$(document).ready(function () {
    a = { x: 0}
    b = { method: "InsertNewSupplier" }
    c = { _delSuppId: ""}
    var staticData = $.extend({}, a, b, c);

    _LoadListOfSupplier();

    //Open Add Supplier Form and generate Supplier id
    $('#btnNewSuplier').click(function () {
        $('#modal_title').html("New Supplier");
        var gentext = $('#genSuppID');
        $.ajax({

            url: '/Admin/GenerateSupplierID',
            type: 'GET',
            success: function (data) {
                gentext.val(data);
                gentext.attr('readonly', 'true');
                b = { method: "InsertNewSupplier" }
                $.extend({},a,b);
            }
        });
    });
 
    //Load All Supplier from database method
    function _LoadListOfSupplier() {
        var tbody = $('#tbody_supplierData');
        var content;

        $.ajax({
            url: "/Admin/GetSuppliersData",
            type: "GET",
            success: function (data) {
                $.each(data, function (i, item) {

                    content += "<tr id='tr_" + item.SupplierID + "'><td>" + item.SupplierID + "</td>" +
                               "<td class='ellipsis'>" + item.SuppName + "</td>" +
                               "<td>" + item.SuppContact_ + "</td>" +
                               "<td class='ellipsis'>" + item.SuppEmail + "</td>" +
                               "<td><a href='#' id='"+ item.SupplierID + "' onclick='sayHelloWord(this.id)' data-toggle='modal' data-target='#myModal'><span class='glyphicon glyphicon-pencil' ></span></a></td>" +
                               "<td><a href='#' id='" + item.SupplierID + "' onclick='DeleteThis(this.id)' data-toggle='modal' data-target='#myModal_del' ><span class='glyphicon glyphicon-trash'  style='color:red'></span></a></td></tr>";
                });
                tbody.append(content);
            }
        });
    }

    //Insert Supplier method
    function _InsertNewSupplier() {
        var tbody = $('#tbody_supplierData');
        var newSupplierData = $('#_newSupplierForm').serialize();
        var content;

        $.ajax({

            type: 'POST',
            data: newSupplierData,
            url: '/Admin/InsertNewSupplier',
            success: function (data) {

                content += "<tr id='tr_" + data.SupplierID + "'><td>" + data.SupplierID + "</td>" +
                              "<td class='ellipsis'>" + data.SuppName + "</td>" +
                              "<td>" + data.SuppContact_ + "</td>" +
                              "<td class='ellipsis'>" + data.SuppEmail + "</td>" +
                               "<td><a href='#' id='" + data.SupplierID + "' onclick='sayHelloWord(this.id)' data-toggle='modal' data-target='#myModal'><span class='glyphicon glyphicon-pencil' ></span></a></td>" +
                               "<td><a href='#' id='" + data.SupplierID + "' onclick='DeleteThis(this.id)' data-toggle='modal' data-target='#myModal_del' ><span class='glyphicon glyphicon-trash'  style='color:red'></span></a></td></tr>";


                tbody.append(content);
                clearForm();
            }
        });
    }

    //Update Supplier method
    function _UpdateSupplier() {
        var tbody = $('#tbody_supplierData');
        var newSupplierData = $('#_newSupplierForm').serialize();
        var content;

        $.ajax({

            type: 'POST',
            data: newSupplierData,
            url: '/Admin/UpdateSupplier',
            success: function (data) {

                content += "<td>" + data.SupplierID + "</td>" +
                              "<td class='ellipsis'>" + data.SuppName + "</td>" +
                              "<td>" + data.SuppContact_ + "</td>" +
                              "<td class='ellipsis'>" + data.SuppEmail + "</td>" +
                              "<td><a href='#' id='" + data.SupplierID + "' onclick='sayHelloWord(this.id)' data-toggle='modal' data-target='#myModal'><span class='glyphicon glyphicon-pencil' ></span></a></td>" +
                              "<td><a href='#' id='" + data.SupplierID + "' onclick='DeleteThis(this.id)' data-toggle='modal'href='#' data-target='#myModal_del' ><span class='glyphicon glyphicon-trash'  style='color:red'></span></a></td>";
                                

                $('#tr_' + data.SupplierID).html(content);
                
            }
        });
    }

    //Add/Update Supplier Event
    $('#btn_submitNewSupplier').click(function () {

          
      $.extend({}.a, b, c);
         
      if ((!$('#_newSupplierForm').valid()))
            {
         
                return false;
            }
            else if($('#txtPassword').val() == "")
            {
                $('#lblErrorPassword').html('Password Required');
                $('#lblErrorPassword').removeClass();
                $('#lblErrorPassword').show();

                a = { x: 0 };
                $.extend({}.a, b);
                return false;
            }
            else if (a.x == 0)
            {
       
                return false;
            }
            else 
            {
            

                if (b.method == "InsertNewSupplier")
                {
                    _InsertNewSupplier();
                    a = { x: 0 };
                    $.extend({}.a, b, c);
                    clearForm();
                }
                else
                {
                    _UpdateSupplier();
                    a = { x: 0 };
                    $.extend({}.a, b, c);
                    clearForm()
                }
                   
            }

    });

    $('#btn_deleteSupplier').click(function () {

        staticData = $.extend({}, a, b, c);

        if ($('#txtDelSupplier').val() == "") {
            $('#lblErrorPassword_Del').html('Password Required');
            $('#lblErrorPassword_Del').removeClass();
            $('#lblErrorPassword_Del').show();

            a = { x: 0 };
            $.extend({}.a, b, c);
            return false;
        }
        else if (a.x == 0) {
          
            return false;
        }
        else {
           
            _delSupplierMethod(c._delSuppId)
        }

    });

});
//DocumentReady end



    //Open Update Supplier form and get Supplier Details
    function sayHelloWord(id) {


    $('#modal_title').html("Update Supplier");
    var gentext = $('#genSuppID');
    var suppID = { "supplierID": id }
    $.ajax({
        url: "/Admin/GetSupplierDetails",
        type: "POST",
        data: suppID,
        success: function (data) {
            gentext.val(id);
            gentext.attr('readonly', 'true');
            $('#txtSuppName').val(data.SuppName);
            $('#txtSuppAddress').val(data.SuppAddress);
            $('#txtSuppCity_Prov').val(data.SuppCity_Prov);
            $('#txtContact').val(data.SuppContact_);
            $('#txtEmail').val(data.SuppEmail);

            b = { method: "UpdateSupplier" }
            $.extend({}.a, b, c);
        }
    });
}
    
    //Checked if the password is correct while typing
    $('#txtPassword').bind("keyup change", function () {

        var userPassword = { "_userPassword": $('#txtPassword').val() };

        $.ajax({

            url: "/Admin/ConfirmPassword",
            type: "POST",
            data: userPassword,
            success: function (data) {
                if (data == 1) {
                    $('#lblErrorPassword').removeClass();
                    $('#lblErrorPassword').hide();
                    a = { x: 1 };
                    $.extend({}.a, b);

                }
                else {
                    $('#lblErrorPassword').html('Invalid Password');
                    $('#lblErrorPassword').removeClass();
                    $('#lblErrorPassword').show();
                    a = { x: 0 };
                    $.extend({}.a, b);
                    return false;

                }
            }
        })

    });
    
    //Close the add and update form
    $('#btn_submitNewClose').click(function () {

        clearForm();
    });
    
    //Clear input data in add and update supplier form
    function clearForm() {
        $('#_newSupplierForm input').val('');
        $('#lblErrorPassword').removeClass();
        $('#lblErrorPassword').hide();
        $('#txtPassword').val('');

        a = { x: 0 };
        $.extend({}.a, b);
    }
    
    // Get SupplierID for deletion method
    function DeleteThis(id)
    {   
        $('#textSupplierID').html('<b>' + id + '</b>');
        c = { _delSuppId: id }
        var staticData = $.extend({}, a, b, c);
    }

    //checked password while typing if correct - for deletion confirmation
    $('#txtDelSupplier').bind("keyup change", function () {

        var userPassword = { "_userPassword": $('#txtDelSupplier').val() };

        $.ajax({

            url: "/Admin/ConfirmPassword",
            type: "POST",
            data: userPassword,
            success: function (data) {
                if (data == 1) {
                    $('#lblErrorPassword_Del').removeClass();
                    $('#lblErrorPassword_Del').hide();
                    a = { x: 1 };
                    $.extend({}.a, b, c);

                }
                else {
                    $('#lblErrorPassword_Del').html('Invalid Password');
                    $('#lblErrorPassword_Del').removeClass();
                    $('#lblErrorPassword_Del').show();
                    a = { x: 0 };
                    $.extend({}.a, b, c);
                    return false;

                }
            }
        })

    });

    //Supplier deletion method
    function _delSupplierMethod(id)
    {
        var SuppID = { "supplierID": id };

        $.ajax({

            url: "/Admin/MarkDeleteSupplier",
            type: "POST",
            data: SuppID,
            success: function(data)
            {
                if(data == 1)
                {
                    $('#tr_' + id).fadeTo("slow",0.7, function(){
                        $(this).remove()
                    });

                    c._delSuppId = "";
                    a.x = 0;
                    $.extend({}.a, b, c);
                    $('#txtDelSupplier').val('');
                }
                else
                {
                    alert("deletion failed");
                }
            }
        });
    }
  