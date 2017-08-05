
        $(document).ready(function ()
        {

            a = { PassExist: 0 }
            b = { InvalidPass: 0}
            var staticData = $.extend({}, a,b);
            $('#imageBrowes').change(function () {

                var File = this.files;

                if (File && File[0]) {
                    ReadImage(File[0]);
                }

            });

        });
        
        $('#btn_Submit_NewEditProduct').click(function()
        {
            if (!$('#_CreateUpdateProd_Form').valid())
            {
                return false;
            }
            else if (a.PassExist == 1)
            {

                return false;
            }

            $('#myModal_del').modal('toggle');
            $('#myModal_del').modal('show');
  
        });
        
        var ReadImage = function (file) {
            var reader = new FileReader;
            var image = new Image;

            reader.readAsDataURL(file);
            reader.onload = function (_file) {
                image.src = _file.target.result;
                image.onload = function () {
                    var height = this.height;
                    var width = this.width;
                    var type = file.type;
                    var size = ~~(file.size / 1024) + "kb";

                    $("#targetImg").attr('src', _file.target.result);
                    $("#description").text('size:' + size + ',' + height + 'x' + width + '');
                    $('#imgPreview').show();

                };
            };
        };
        
        var clearPreview = function () {
            $("#imageBrowes").val('');
            $("#description").val('');
            $('#imgPreview').hide();
        };
        
        $('#txtProd_Code').keyup(function () {

                var d = {"_productCode" : $('#txtProd_Code').val()}
                $.ajax({

                    url: "/Admin_Product/CheckProdCodeExist",
                    type: "POST",
                    data: d,
                    success: function(data)
                    {
                        if (data == 1) {
                            $("#_ProdExist").css("display", "block");
                            a = { PassExist: 1 };
                            $.extend({}, a);
                        }
                        else
                        {
                            $("#_ProdExist").hide();
                            a = { PassExist: 0 };
                            $.extend({}, a);
                        };
                    }
                });
        });
        
        $('#txtDelSupplier').focusout(function()
        {

            if($('#txtDelSupplier').val() == '')
            {
                $('#InvalidPass span').html('password required');
                $('#InvalidPass').css("display", "block");
                return false;
               
            }
            else
            {
                $('#InvalidPass').css("display", "none");
                
            }
        })
        
        $('#txtDelSupplier').focusin(function () {

      
                $('#InvalidPass').css("display", "none");
             
            
        })
        
        $('#txtDelSupplier').bind("keyup change", function () {
         
                var userPassword = { "_userPassword": $('#txtDelSupplier').val() };

                $.ajax({

                    url: "/Admin/ConfirmPassword",
                    type: "POST",
                    data: userPassword,
                    success: function (data) {

                        if (data == 1) {
                            $('#InvalidPass').css("display", "none");
                            b = { InvalidPass: 1 }
                            $.extend({}, a, b);
                            return true;
                        }
                        else {
                            $('#InvalidPass span').html('Invalid Password');
                            $('#InvalidPass').css("display", "block");
                            b = { InvalidPass: 0 }
                            $.extend({}, a, b);
                            return false;

                            }

                    }
                })
            
        });
        
        $('#btn_cancel').click(function () {

            $('#txtDelSupplier').val('');
            $('#InvalidPass').css("display", "none");

        });
        
        $('#btn_AddConfirm').click(function () {


            if ($('#txtDelSupplier').val() == '') {
                $('#InvalidPass span').html('password required');
                $('#InvalidPass').css("display", "block");
                return false;

            }
            else if (b.InvalidPass == 0)
            {

                return false;

            }
            else
            {
            
            _SendNewProduct();
            

            }

        });
                
        function _SendNewProduct()
        {
            var _newProdForm = $('#_CreateUpdateProd_Form');
            var data = new FormData;

            if ($('#imageBrowes').length > 0)
            {
                var image = $('#imageBrowes').get(0).files;
                data.append("Image", image[0]);
            }
           
            
            $.each(_newProdForm.serializeArray(), function (key, input) {
                data.append(input.name, input.value);
            });

          
            $.ajax({

                type: "POST",
                url: "/Admin_Product/createNewProduct",
                data: data,
                contentType: false,
                processData: false,
                success: function (data) {
                    _clearForm();
                        
                    //if (data == 0 || data == "0")
                    //{
                    //    $('#uploadedImage').prepend('<img id="theImg" src="/Images/no-image620.png" class="img-responsive thumbnail"/>');
                    //}
                    //else
                    //{
                    //    $('#uploadedImage').append('<img src="/Admin_Product/imageRetrieve?_prodCode=' + data + '"class="img-responsive thumbnail"/>');
                    //}
                       
                
                    
                   
                }
            });
        }
        
        function _clearForm()
        {
            $('#txtProd_Code').val('');
            $('#txtProd_Name').val('');
            $('#txtProd_Brand').val('');
            $('#txtProd_Description').val('');
            $('#ddlProd_Category').val('');
            $('#ddlProd_Supplier').val(''); 
            $('#txtProd_SellPrice').val('');
            $('#txtProd_Weight').val('');
            $('#txtProd_SuppPrice').val('');
            clearPreview();
        }