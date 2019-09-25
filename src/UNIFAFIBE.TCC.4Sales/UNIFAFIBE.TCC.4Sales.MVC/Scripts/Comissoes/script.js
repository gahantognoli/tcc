var functionsComissoes = {
    Listar: function (mes, ano) {
        fGlobal.Ajax(gHostProjeto + "Comissao/Listar?mes=" + mes + "&ano=" + ano, "GET", null,
            functionsComissoes.HtmlComissoes, null, null, null);
    },
    HtmlComissoes: function (data) {
        var json = $.parseJSON(data.comissoes);
        console.log(json);
        if (fGlobal.IsNotEmpty(json)) {
            functionsComissoes.TableFill(json);
        }
    },
    AtualizarPagamento: function (parcelaId, paga) {
        fGlobal.Ajax(gHostProjeto + "Comissao/AtualizarPagamento?parcelaId=" + parcelaId + "&pago=" + paga,
            "GET", null, functionsComissoes.HtmlComissoes, null, null, null);
    },
    TableFill: function (data) {
        $('#tabela-comissoes tr').remove();
        var html = "";
        $.each(data, function (i, item) {
            html += "<tr>";
            html += "<input type='hidden' class='parcelaId' value=" + item.ParcelaId+">";
            html += "<td>" + item.DataPagamento + "</td>";
            html += "<td>" + item.NumeroPedido + "</td>";
            html += "<td>" + item.Vendedor + "</td>";
            html += "<td>" + item.Representada + "</td>";
            html += "<td>" + item.Cliente + "</td>";
            html += "<td>" + item.NumeroParcela + "</td>";
            html += "<td>" + Number(item.ValorComissao.toString().replace(',', '.')).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' }) + "</td>";
            html += "<td>" + item.PercComissao + "</td>";
            html += "<td>" + (item.Paga === true ? "<input type='checkbox' class='comissao' checked />" : "<input type='checkbox' class='comissao' />") + "</td>";
            html += "</tr>";
        });
        $('#tabela-comissoes').append(html);
    }
};

$(function () {
    let mes = $('#mes').val();
    let ano = $('#ano').val();
    functionsComissoes.Listar(mes, ano);

    $('#mes').on('change', function () {
        let mes = $('#mes').val();
        let ano = $('#ano').val();
        functionsComissoes.Listar(mes, ano);
    });

    $('#ano').on('change', function () {
        let mes = $('#mes').val();
        let ano = $('#ano').val();
        functionsComissoes.Listar(mes, ano);
    });

    $(document).on('change', '.comissao', function () {
        var parcelaId = $(this).closest('tr').find('.parcelaId').val();
        if ($(this).is(':checked') === true) {
            functionsComissoes.AtualizarPagamento(parcelaId, true);
        } else {
            functionsComissoes.AtualizarPagamento(parcelaId, false);
        }
    });

});