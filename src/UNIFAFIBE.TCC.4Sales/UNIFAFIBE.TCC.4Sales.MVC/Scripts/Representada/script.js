var functionsRepresentada = {
    
};

$(function () {
    $('#parametro').on('change', function () {
        if ($(this).val() === "cnpj")
            $("#busca").mask("99.999.999/9999-99");
        else
            $("#busca").unmask();
    });
});
