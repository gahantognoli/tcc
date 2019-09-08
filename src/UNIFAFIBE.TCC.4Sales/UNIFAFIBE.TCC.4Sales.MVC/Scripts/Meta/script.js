var functionsMeta = {
    Listar: function () {
        fGlobal.Ajax(gHostProjeto + "Meta/Listar", "GET", null, functionsMeta.HtmlMeta, null, functionsMeta.HideLoading, functionsMeta.ShowLoading);
    },
    HtmlMeta: function (data) {
        var json = $.parseJSON(data.meta);
        if (fGlobal.IsNotEmpty(json)) {
            functionsMeta.CardFill(json);
        }
    },
    CardFill: function (data) {
        functionsMeta.CardsClear();
        var html = "";
        $.each(data, function (index, value) {
            html += '<div class="card-item d-flex justify-content-between">';
            html += '<a href="/Meta/Detalhes/ ' + value.MetaId + '" class="link-detalhes">';
            html += '<span class="h6">' + value.Ano + '/' + value.Mes + '</span>';
            html += '</a>';
            html += '<div>';
            html += '<a href="/Meta/Alterar/' + value.MetaId + '" class="btn btn-sm btn-warning mr-1">';
            html += '<i class="fas fa-pencil-alt icone-edit"></i>Alterar';
            html += '</a>';
            html += '<a href="/Meta/Remover/' + value.MetaId + '" class="btn btn-sm btn-danger">';
            html += '<i class="fas fa-trash-alt icone-remove"></i>Excluir';
            html += '</a>';
            html += '</div>';
            html += '</div>';
        });

        $("#content-meta").append(html);
        functionsMeta.ClearDescricao();
    },
    CardsClear: function () {
        $("#content-meta").find(".card-item").remove();
    },
    HideLoading: function () {
        $('#loading-meta').attr('style', 'display:none;');
    },
    ShowLoading: function () {
        $('#loading-meta').removeAttr('style', 'display:none;');
    },
    ClearDescricao: function () {
        $('#pesquisa-meta').val("");
        $('#pesquisa-meta').focus();
    }
};

$(function () {
    functionsMeta.Listar();

    $("#pills-meta-tab").on("click", function () {
        functionsMeta.CardsClear();
        functionsMeta.Listar();
    });

    //$("#pesquisa-transportadora").on("keypress", function (e) {
    //    if (e.keyCode === 13) {
    //        e.preventDefault();
    //        var descricao = $("#pesquisa-transportadora").val();
    //        functionsTransportadora.ListarPorNome(descricao);
    //    }
    //});

    //$('#btnPesquisarTransportadora').on('click', function () {
    //    var descricao = $("#pesquisa-transportadora").val();
    //    functionsTransportadora.ListarPorNome(descricao);
    //});
});