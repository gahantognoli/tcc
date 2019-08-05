var functionsRepresentada = {
    CriarHTMLCondicaoPagamento: function (i) {
        var html = "";
        if (i !== 0) {
            html += '<div class="condicaoPagamento" style="margin-top:50px;"> ';
            html += '<div class="d-flex justify-content-start align-items-center">';
            html += '<h3 class="mr-3">Condição Pagamento</h3>';
            html += '<button type="button" class="btn btn-danger mt-1 mb-2 btnRemoverCondicaoPagamento"><i class="fas fa-trash-alt"></i></button> ';
            html += '</div>';
        } else {
            html += '<div class="condicaoPagamento">';
            
        }
        html += '<div class="form-group">';
        html += '<div class="col-md-2">';
        html += '<label class="control-label" for="">Descrição</label> <span class="span-obrigatorio">*</span>';
        html += '</div>';
        html += '<div class="col-md-3">';
        html += '<input type="text" class="form-control descricao" name="CondicoesPagamento[' + i + '].Descricao" id="CondicoesPagamento[' + i +'].Descricao">';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Descricao" data-valmsg-replace="true"></span>';
        html += '</div>';
        html += '</div>';
        html += '<div class="form-group">';
        html += '<div class="col-md-2">';
        html += '<label class="control-label" for="">Valor Mínimo</label>';
        html += '</div>';
        html += '<div class="col-md-3">';
        html += '<input type="text" class="form-control cepPJ" name="CondicoesPagamento[' + i + '].ValorMinimo" id="CondicoesPagamento.ValorMinimo[' + i +']">';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="ValorMinimo" data-valmsg-replace="true"></span>';
        html += '</div>';
        html += '</div>';
        html += '</div>';

        $('#condicoesPagamento').append(html);
    },
    CriarHTMLContatos: function (i) {
        var html = "";
        if (i !== 0)
        {
            html += '<div class="contato" style="margin-top:50px;"> ';
            html += '<div class="d-flex justify-content-start align-items-center">';
            html += '<h3 class="mr-3">Contato</h3>';
            html += '<button type="button" class="btn btn-danger mt-1 mb-2 btnRemoverContatos"><i class="fas fa-trash-alt"></i></button> ';
            html += '</div>';
        } else
        {
            html += '<div class="contato">';
        }
        
        html += '<div class="form-group">';
        html += '<div class="col-md-8">';
        html += '<label class="control-label" for="">Nome</label> <span class="span-obrigatorio">*</span>';
        html += '</div>';
        html += '<div class="col-md-8">';
        html += '<input type="text" class="form-control nome" name="ContatosRepresentada[' + i + '].Nome" id="ContatosRepresentada[' + i +'].Nome">';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Nome" data-valmsg-replace="true"></span>';
        html += '</div>';
        html += '</div>';
        html += '<div class="form-group">';
        html += '<div class="col-md-2">';
        html += '<label class="control-label" for="">Cargo</label> <span class="span-obrigatorio">*</span>';
        html += '</div>';
        html += '<div class="col-md-4">';
        html += '<input type="text" class="form-control" name="ContatosRepresentada[' + i +'].Cargo" id="ContatosRepresentada[' + i +'].Cargo">';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Cargo" data-valmsg-replace="true"></span>';
        html += '</div>';
        html += '</div>';
        html += '<div class="form-group">';
        html += '<div class="col-md-2">';
        html += '<label class="control-label" for="">Telefone</label> <span class="span-obrigatorio">*</span>';
        html += '</div>';
        html += '<div class="col-md-3">';
        html += '<input type="text" class="form-control" name="ContatosRepresentada[' + i + '].Telefone" id="ContatosRepresentada[' + i +'].Telefone">';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Telefone" data-valmsg-replace="true"></span>';
        html += '</div>';
        html += '</div>';
        html += '<div class="form-group">';
        html += '<div class="col-md-2">';
        html += '<label class="control-label" for="">E-mail</label> <span class="span-obrigatorio">*</span>';
        html += '</div>';
        html += '<div class="col-md-6">';
        html += '<input type="text" class="form-control" name="ContatosRepresentada[' + i +'].Email" id="ContatosRepresentada[' + i +'].Email">';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Email" data-valmsg-replace="true"></span>';
        html += '</div>';
        html += '</div>';
        html += '</div>';

        $('#contatos').append(html);
    }
};

$(function () {
    $('#CNPJ').mask("99.999.999/9999-99");

    $('#parametro').on('change', function () {
        if ($(this).val() === "cnpj")
            $("#busca").mask("99.999.999/9999-99");
        else
            $("#busca").unmask();
    });

    if ($('.condicaoPagamento').length <= 0) {
        functionsRepresentada.CriarHTMLCondicaoPagamento(0);
    }

    if ($('.contato').length <= 0) {
        functionsRepresentada.CriarHTMLContatos(0);
    }
});

$("#btnCriarCondicaoPagamento").on('click', function () {
    var i = Number($('#condicoesPagamento').find('.condicaoPagamento').last().find('.descricao').attr('id').split('[')[1].substring(0, 1)) + 1;
    functionsRepresentada.CriarHTMLCondicaoPagamento(i);
});

$(document).on('click', '.btnRemoverCondicaoPagamento', function () {
    var linhaAtual = Number($(this).parent().parent().remove().find('.descricao').attr('id').split('[')[1].substring(0, 1));
    var qtdLinhas = $('#condicoesPagamento').find('.condicaoPagamento').length;
    for (var i = linhaAtual + 1; i <= qtdLinhas; i++) {
        document.getElementById('CondicoesPagamento[' + i + '].Descricao').name =
            "CondicoesPagamento[" + (i - 1).toString() + "].Descricao";
        document.getElementById('CondicoesPagamento[' + i + '].Descricao').id =
            "CondicoesPagamento[" + (i - 1).toString() + "].Descricao";
        document.getElementById('CondicoesPagamento[' + i + '].ValorMinimo').name =
            "CondicoesPagamento[" + (i - 1).toString() + "].ValorMinimo";
        document.getElementById('CondicoesPagamento[' + i + '].ValorMinimo').id =
            "CondicoesPagamento[" + (i - 1).toString() + "].ValorMinimo";
    }
    $(this).parent().parent().remove();
});

$("#btnCriarContatos").on('click', function () {
    var i = Number($('#contatos').find('.contato').last().find('.nome').attr('id').split('[')[1].substring(0, 1)) + 1;
    functionsRepresentada.CriarHTMLContatos(i);
});

$(document).on('click', '.btnRemoverContatos', function () {
    var linhaAtual = Number($(this).parent().parent().remove().find('.nome').attr('id').split('[')[1].substring(0, 1));
    var qtdLinhas = $('#contatos').find('.contato').length;
    for (var i = linhaAtual + 1; i <= qtdLinhas; i++) {
        document.getElementById('ContatosRepresentada[' + i + '].Nome').name =
            "ContatosRepresentada[" + (i - 1).toString() + "].Nome";
        document.getElementById('ContatosRepresentada[' + i + '].Nome').id =
            "ContatosRepresentada[" + (i - 1).toString() + "].Nome";
        document.getElementById('ContatosRepresentada[' + i + '].Cargo').name =
            "ContatosRepresentada[" + (i - 1).toString() + "].Cargo";
        document.getElementById('ContatosRepresentada[' + i + '].Cargo').id =
            "ContatosRepresentada[" + (i - 1).toString() + "].Cargo";
        document.getElementById('ContatosRepresentada[' + i + '].Telefone').name =
            "ContatosRepresentada[" + (i - 1).toString() + "].Telefone";
        document.getElementById('ContatosRepresentada[' + i + '].Telefone').id =
            "ContatosRepresentada[" + (i - 1).toString() + "].Telefone";
        document.getElementById('ContatosRepresentada[' + i + '].Email').name =
            "ContatosRepresentada[" + (i - 1).toString() + "].Email";
        document.getElementById('ContatosRepresentada[' + i + '].Email').id =
            "ContatosRepresentada[" + (i - 1).toString() + "].Email";
    }
    $(this).parent().parent().remove();
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

