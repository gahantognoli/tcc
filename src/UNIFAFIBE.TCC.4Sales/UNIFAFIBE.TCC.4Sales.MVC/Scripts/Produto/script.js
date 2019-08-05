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

function mValor(v) {
    v = v.replace(/\D/g, "");
    v = v.replace(/(\d)(\d{8})$/, "$1.$2");
    v = v.replace(/(\d)(\d{5})$/, "$1.$2");
    v = v.replace(/(\d)(\d{2})$/, "$1,$2");
    return v;
}

$(document).on('keyup', '.mValor', function () {
    var valor = mValor($(this).val());
    var tam = $(this).attr("maxlength");
    var pontos = 0;
    $(this).val(valor);
    if (tam !== undefined) {
        if ($(this).val().length > tam) {
            valor = valor.replace(/\D/g, "");
            if (tam > 9) {
                pontos = 3;
            } else if (tam > 6) {
                pontos = 2;
            } else {
                pontos = 1;
            }
            valor = mValor(valor.substr(0, $(this).attr("maxlength") - pontos));
            $(this).val(valor);
        }
    }
});

$(document).on('blur', '.mValor', function () {
    var valor = mValor($(this).val());
    $(this).val(valor);
});
