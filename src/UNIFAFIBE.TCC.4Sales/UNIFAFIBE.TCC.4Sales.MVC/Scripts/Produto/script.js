var functionsProdutos = {

};

$(function () {
    $('#Codigo').on('keyup', function () {
        $(this).val($(this).val().toUpperCase());
    });
    $('#UnidadeMedida').on('keyup', function () {
        $(this).val($(this).val().toUpperCase());
    });
});