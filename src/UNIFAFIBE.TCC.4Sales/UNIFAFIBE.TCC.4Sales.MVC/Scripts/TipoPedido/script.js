var functionsTipoPedido = {
    ListarTipos: function () {
        fGlobal.Ajax(gHostProjeto + "TipoPedido/Listar", "GET", null, functionsTipoPedido.HtmlTipo, null, functionsTipoPedido.HideLoading, functionsTipoPedido.ShowLoading);
    },
    HtmlTipo: function (data) {
        var json = $.parseJSON(data.tipoPedido);
        if (fGlobal.IsNotEmpty(json)) {
            functionsTipoPedido.CardFill(json);
        }
    },
    Novo: function (pDescricao) {
        fGlobal.Ajax(gHostProjeto + "TipoPedido/Novo", "POST", { descricao: pDescricao }, functionsTipoPedido.HtmlCadastroTipo, null, null, null);
    },
    HtmlCadastroTipo: function (data) {
        var json = $.parseJSON(data.tipoPedido);
        if (fGlobal.IsNotEmpty(json)) {
            if (fGlobal.VerificaErrosValidacao(json.ValidationResult)) {
                fGlobal.EmitirNotificacao("Sucesso", "Tipo <b>" + json.Descricao + "</b> cadastrado com sucesso!", "info");
                functionsTipoPedido.ListarTipos();
            } else {
                fGlobal.ExibirNotificaoErrosValidacao(json.ValidationResult);
            }
        }
    },
    CardFill: function (data) {
        functionsTipoPedido.CardsClear();
        var html = "";
        $.each(data, function (index, value) {
            html += '<div class="card-item d-flex justify-content-between">';
            html += '<span class="h6">' + value.Descricao + '</span>';
            html += '<div>';
            if (value.Padrao === false) {
                html += '<a href="/TipoPedido/Alterar/' + value.TipoPedidoId + '" class="btn btn-sm btn-warning mr-1">';
                html += '<i class="fas fa-pencil-alt icone-edit"></i>Alterar';
                html += '</a>';
            }

            if (value.Padrao === false) {
                html += '<a href="/TipoPedido/Remover/' + value.TipoPedidoId + '" class="btn btn-sm btn-danger">';
                html += '<i class="fas fa-trash-alt icone-remove"></i>Excluir';
                html += '</a>';
            }
            
            html += '</div>';
            html += '</div>';
        });

        $("#content-tipo-pedido").append(html);
        functionsTipoPedido.ClearDescricao();
    },
    CardsClear: function () {
        $("#content-tipo-pedido").find(".card-item").remove();
    },
    HideLoading: function () {
        $('#loading-tipo-pedido').attr('style', 'display:none;');
    },
    ShowLoading: function () {
        $('#loading-tipo-pedido').removeAttr('style', 'display:none;');
    },
    ClearDescricao: function () {
        $('#descricao-tipo-pedido').val("");
        $('descricao-tipo-pedido').focus();
    }
};

$(function () {
    $("#pills-tipo-tab").on("click", function () {
        functionsTipoPedido.CardsClear();
        functionsTipoPedido.ListarTipos();
    });

    $("#btnIncluirTipoPedido").on("click", function () {
        var descricao = $("#descricao-tipo-pedido").val();
        functionsTipoPedido.Novo(descricao);
    });
});