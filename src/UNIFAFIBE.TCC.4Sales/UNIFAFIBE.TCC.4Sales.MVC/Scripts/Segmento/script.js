var functionsSegmento = {   
    Listar: function () {
        fGlobal.Ajax(gHostProjeto + "Segmento/Listar", "GET", null, functionsSegmento.HtmlSegmento, null, functionsSegmento.HideLoading, functionsSegmento.ShowLoading);
    },
    HtmlSegmento: function (data) {
        var json = $.parseJSON(data.segmento);
        if (fGlobal.IsNotEmpty(json)) {
            functionsSegmento.CardFill(json);
        }
    },
    Novo: function (pDescricao) {
        fGlobal.Ajax(gHostProjeto + "Segmento/Novo", "POST", { descricao: pDescricao }, functionsSegmento.HtmlCadastroSegmento, null, null, null);
    },
    HtmlCadastroSegmento: function (data) {
        var json = $.parseJSON(data.segmento);
        if (fGlobal.IsNotEmpty(json)) {
            if (fGlobal.VerificaErrosValidacao(json.ValidationResult)) {
                fGlobal.EmitirNotificacao("Sucesso", "Segmento <b>" + json.Descricao + "</b> cadastrado com sucesso!", "info");
                functionsSegmento.Listar();
            } else {
                fGlobal.ExibirNotificaoErrosValidacao(json.ValidationResult);
            }
        }
    },
    CardFill: function (data) {
        functionsSegmento.CardsClear();
        var html = "";
        $.each(data, function (index, value) {
            html += '<div class="card-item d-flex justify-content-between">';
            html += '<span class="h6">' + value.Descricao + '</span>';
            html += '<div>';
            html += '<a href="/Segmento/Alterar/' + value.SegmentoId + '" class="btn btn-sm btn-warning mr-1">';
            html += '<i class="fas fa-pencil-alt icone-edit"></i>Alterar';
            html += '</a>';
            html += '<a href="/Segmento/Remover/' + value.SegmentoId + '" class="btn btn-sm btn-danger">';
            html += '<i class="fas fa-trash-alt icone-remove"></i>Excluir';
            html += '</a>';
            html += '</div>';
            html += '</div>';
        });

        $("#content-segmento").append(html);
        functionsSegmento.ClearDescricao();
    },
    CardsClear: function () {
        $("#content-segmento").find(".card-item").remove();
    },
    HideLoading: function () {
        $('#loading-segmento').attr('style', 'display:none;');
    },
    ShowLoading: function () {
        $('#loading-segmento').removeAttr('style', 'display:none;');
    },
    ClearDescricao: function () {
        $('#descricao-segmento').val("");
        $('#descricao-segmento').focus();
    }
};

$(function () {
    functionsSegmento.Listar();
    $("#segmento-tab").on("click", function () {
        functionsSegmento.CardsClear();
        functionsSegmento.Listar();
    });

    $("#btnIncluirSegmento").on("click", function () {
        var descricao = $("#descricao-segmento").val();
        functionsSegmento.Novo(descricao);
    });
});