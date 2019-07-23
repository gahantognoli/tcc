var functionsTransportadora = {
    Listar: function () {
        fGlobal.Ajax(gHostProjeto + "Transportadora/Listar", "GET", null, functionsTransportadora.HtmlTranspodora, null, functionsTransportadora.HideLoading, functionsTransportadora.ShowLoading);
    },
    ListarPorNome: function (nome) {
        fGlobal.Ajax(gHostProjeto + "Transportadora/PesquisarNome?nome=" + nome, "GET", null, functionsTransportadora.HtmlTranspodora, null, functionsTransportadora.HideLoading, functionsTransportadora.ShowLoading);
    },
    HtmlTranspodora: function (data) {
        var json = $.parseJSON(data.transportadora);
        if (fGlobal.IsNotEmpty(json)) {
            functionsTransportadora.CardFill(json);
        }
    },
    CardFill: function (data) {
        functionsTransportadora.CardsClear();
        var html = "";
        $.each(data, function (index, value) {
            html += '<div class="card-item d-flex justify-content-between">';
            html += '<a href="/Transportadora/Detalhes/ ' + value.TransportadoraId + '" class="link-detalhes">';
            html += '<span class="h6">' + value.Nome + '</span>';
            html += '</a>';
            html += '<div>';
            html += '<a href="/Transportadora/Alterar/' + value.TransportadoraId + '" class="btn btn-sm btn-warning mr-1">';
            html += '<i class="fas fa-pencil-alt icone-edit"></i>Alterar';
            html += '</a>';
            html += '<a href="/Transportadora/Remover/' + value.TransportadoraId + '" class="btn btn-sm btn-danger">';
            html += '<i class="fas fa-trash-alt icone-remove"></i>Excluir';
            html += '</a>';
            html += '</div>';
            html += '</div>';
        });

        $("#content-transportadoras").append(html);
        functionsTransportadora.ClearDescricao();
    },
    CardsClear: function () {
        $("#content-transportadoras").find(".card-item").remove();
    },
    HideLoading: function () {
        $('#loading-transportadora').attr('style', 'display:none;');
    },
    ShowLoading: function () {
        $('#loading-transportadora').removeAttr('style', 'display:none;');
    },
    ClearDescricao: function () {
        $('#pesquisa-transportadora').val("");
        $('#pesquisa-transportadora').focus();
    }
};


$(function () {
    functionsTransportadora.Listar();

    $("#pills-transportadora-tab").on("click", function () {
        functionsTransportadora.CardsClear();
        functionsTransportadora.Listar();
    });

    $("#pesquisa-transportadora").on("keypress", function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            var descricao = $("#pesquisa-transportadora").val();
            functionsTransportadora.ListarPorNome(descricao);
        }
    });

    $('#btnPesquisarTransportadora').on('click', function () {
        var descricao = $("#pesquisa-transportadora").val();
        functionsTransportadora.ListarPorNome(descricao);
    });
});