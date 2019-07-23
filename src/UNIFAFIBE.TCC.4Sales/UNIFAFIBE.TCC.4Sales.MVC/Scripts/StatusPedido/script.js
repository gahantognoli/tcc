var functionsStatusPedido = {
    ListarStatus: function () {
        fGlobal.Ajax(gHostProjeto + "StatusPedido/Listar", "GET", null, functionsStatusPedido.HtmlStatus, null, functionsStatusPedido.HideLoading, functionsStatusPedido.ShowLoading);
    },
    HtmlStatus: function (data) {
        var json = $.parseJSON(data.statusPedido);
        if (fGlobal.IsNotEmpty(json)) {
            functionsStatusPedido.CardFill(json);
        }
    },
    Novo: function (pDescricao) {
        fGlobal.Ajax(gHostProjeto + "StatusPedido/Novo", "POST", { descricao: pDescricao }, functionsStatusPedido.HtmlCadastroStatus, null, null, null);
    },
    HtmlCadastroStatus: function (data) {
        var json = $.parseJSON(data.statusPedido);
        if (fGlobal.IsNotEmpty(json)) {
            if (fGlobal.VerificaErrosValidacao(json.ValidationResult)) {
                fGlobal.EmitirNotificacao("Sucesso", "Status <b>" + json.Descricao + "</b> cadastrado com sucesso!", "info");
                functionsStatusPedido.ListarStatus();
            } else {
                fGlobal.ExibirNotificaoErrosValidacao(json.ValidationResult);
            }
        }
    },
    CardFill: function (data) {
        functionsStatusPedido.CardsClear();
        var html = "";
        $.each(data, function (index, value) {
            html += '<div class="card-item d-flex justify-content-between">';
            html += '<span class="h6">' + value.Descricao + '</span>';
            html += '<div>';
            html += '<a href="/StatusPedido/Alterar/' + value.StatusPedidoId + '" class="btn btn-sm btn-warning mr-1">';
            html += '<i class="fas fa-pencil-alt icone-edit"></i>Alterar';
            html += '</a>';
            html += '<a href="/StatusPedido/Remover/' + value.StatusPedidoId + '" class="btn btn-sm btn-danger">';
            html += '<i class="fas fa-trash-alt icone-remove"></i>Excluir';
            html += '</a>';
            html += '</div>';
            html += '</div>';
        });

        $("#content-status-pedido").append(html);
        functionsStatusPedido.ClearDescricao();
    },
    CardsClear: function () {
        $("#content-status-pedido").find(".card-item").remove();
    },
    HideLoading: function () {
        $('#loading-status-pedido').attr('style', 'display:none;');
    },
    ShowLoading: function () {
        $('#loading-status-pedido').removeAttr('style', 'display:none;');
    },
    ClearDescricao: function () {
        $('#descricao-status-pedido').val("");
        $('#descricao-status-pedido').focus();
    }
};

$(function () {
    $("#pills-status-tab").on("click", function () {
        functionsStatusPedido.CardsClear();
        functionsStatusPedido.ListarStatus();
    });

    $("#btnIncluirPedido").on("click", function () {
        var descricao = $("#descricao-status-pedido").val();
        functionsStatusPedido.Novo(descricao);
    });
});