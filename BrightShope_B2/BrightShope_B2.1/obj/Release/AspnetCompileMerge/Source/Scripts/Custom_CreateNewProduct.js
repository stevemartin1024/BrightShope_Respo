
$(document).ready(function () {


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


var clearPreview = function()
{

    $("#imageBrowes").val('');
    $("#description").val('');
    $('#imgPreview').hide();

}