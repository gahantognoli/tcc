var index = 1;
var error = 0;
var valorCampo = "";

var functionsFaturamento = {
    CriaLinhasTabela: function () {
        var html = "";
        html = '<tr id="linha_' + index + '" value="' + index + '">';
        html += '<td class="input-small">';
        html += '<span class="parcela" id="parcela_' + index + '"> ' + index + '.</span>';
        html += '</td>';
        html += '<td class="input-small">';
        html += '<div class="input-group">';
        html += '<input type="text" class="form-control comissao mValor required" id="comissao_' + index + '" />';
        html += '<div class="input-group-append">';
        html += '<span class="input-group-text">R$</span>';
        html += '</div>';
        html += '</div>';
        html += '</td>';
        html += '<td class="input-small">';
        html += '<input type="date" class="form-control data required" id="data_' + index + '" />';
        html += '</td>';
        html += '<td style="width: 100px;">';
        html += '<button type="button" class="btn btn-sm btn-danger btn-remover">';
        html += '<i class="fas fa-minus mr-1"></i>Remover';
        html += '</button>';
        html += '</td>';
        html += '</tr>';

        $('#corpo-tabela').append(html);

        $('#totalItens').text(parseInt($('#totalItens').text()) + 1);

        index++;
    },
    GeraRequisicao: function () {
        $('#corpo-tabela tr').each(function (i, item) {
            var parcelas = [];

            $('#corpo-tabela tr').each(function (i, item) {
                i++;
                var parcela = {
                    NumeroParcela: $('#parcela_' + i).text().split('.')[0].trim(),
                    ValorParcela: $('#comissao_' + i).val(),
                    DataPagamento: $('#data_' + i).val()
                };
                parcelas.push(parcela);

            });

            var faturamento = {
                PedidoId: $("#pedidoId").val(),
                Valor: $("#valorFaturamento").val(),
                InformacoesAdicionais: $("#informacoesAdicionais").val(),
                Parcelas: parcelas
            };

            functionsFaturamento.GerarFaturamento(JSON.stringify(faturamento));
        });
    },
    GerarFaturamento: function (pFaturamento) {
        fGlobal.Ajax(gHostProjeto + 'Pedido/Faturar', "POST", { faturamento: pFaturamento }, functionsFaturamento.HtmlFaturamento,
            null, functionsFaturamento.EsconderModal, functionsFaturamento.MostrarModal);
    },
    HtmlFaturamento: function (data) {
        if (data.IsValid === true) {
            window.location = gHostProjeto + 'Pedido/Index';
        } else {
            fGlobal.ExibirNotificaoErrosValidacao(data);
        }
    },
    RemoveLinhaTabela: function (campo) {
        var tr = $(campo).closest('tr');
        var valorLinha = parseInt(tr.attr("value"));
        var count = (index - 1);

        for (var a = valorLinha; a <= count; a++) {
            if ($("#linha_" + (a + 1)) !== "") {
                $("#linha_" + (a + 1)).attr({
                    "id": "linha_" + a,
                    "value": a
                });

                $("#parcela_" + (a + 1)).text(a + ".");
                $("#parcela_" + (a + 1)).attr("id", "parcela_" + a);
                $("#comissao_" + (a + 1)).attr("id", "comissao_" + a);
                $("#data_" + (a + 1)).attr("id", "data_" + a);
                tr.attr("value", a);
            }
        }

        tr.remove();
        index--;
    },
    VerificaValorFaturamento: function (valor) {
        if (Number(functionsFaturamento.FormatarDecimalCalculo(valor)) > Number(functionsFaturamento.FormatarDecimalCalculo($('#totalPedido').val()))) {
            fGlobal.EmitirNotificacao('Validação', 'Valor do faturamento excede o valor do Pedido.', 'danger');
            $('#valorFaturamento').val('');
            $('#valorFaturamento').focus();
        }
    },
    MostrarModal: function () {
        fGlobal.MostrarModal('#modal-faturamento');
    },
    EsconderModal: function () {
        fGlobal.EsconderModal('#modal-faturamento');
    },
    ValidaObrigatorio: function () {
        error = 0;
        $('.required').each(function () {
            if (($(this).val() === "" || $(this).val() === null)) {
                $(this).css("border", "1px solid red");
                error++;
            } else {
                $(this).css("border", "1px solid #CCC");
            }
        });
        if (error > 0) {
            alert("Favor preencher os campos em vermelho!");
        }
    },
    CalcularComissaoParcelas: function () {
        var qtdParcelas = Number($('#corpo-tabela tr').length);
        var percentualComissao = functionsFaturamento.FormatarDecimalCalculo($('#percentualComissao').val());
        var valorFaturamento = functionsFaturamento.FormatarDecimalCalculo($('#valorFaturamento').val());

        var comissao = parseFloat(((valorFaturamento * percentualComissao) / qtdParcelas) / 100).toFixed(2).replace('.', ',');

        $('#corpo-tabela tr').find('.comissao').each(function (i, item) {
            $(item).val(comissao);
        });

    },
    AjusteComissaoParcelas: function (valorComissao, indice) {
        if (Number($('#corpo-tabela tr').length) !== indice) {
            var qtdParcelas = Number($('#corpo-tabela tr').length) - indice;
            var percentualComissao = functionsFaturamento.FormatarDecimalCalculo($('#percentualComissao').val());
            var valorFaturamento = functionsFaturamento.FormatarDecimalCalculo($('#valorFaturamento').val());
            var comissaoTotal = Number(valorFaturamento * (percentualComissao / 100));

            var comissao = parseFloat(((comissaoTotal - valorComissao) / qtdParcelas)).toFixed(2).replace('.', ',');

            if (Number(functionsFaturamento.FormatarDecimalCalculo(comissao)) <= 0) {
                comissao = '';
            }

            $('#corpo-tabela tr').find('.comissao').each(function (i, item) {
                if (i + 1 > indice) {
                    $(item).val(comissao);
                }
            });
        }
    },
    CalcularComissaoTotal: function () {
        var percentualComissao = functionsFaturamento.FormatarDecimalCalculo($('#percentualComissao').val());
        var valorFaturamento = functionsFaturamento.FormatarDecimalCalculo($('#valorFaturamento').val());

        var comissaoTotal = parseFloat((valorFaturamento * (percentualComissao / 100))).toFixed(2).replace('.', ',');
        $('#totalComissao').text(comissaoTotal);
    },
    FormatarDecimalCalculo: function (valor) {
        return valor.replace('.', '').replace(',', '.');
    }
};

$(function () {
    $('#valorFaturamento').
        val(parseFloat(functionsFaturamento.FormatarDecimalCalculo($('#totalPedido').val()) -
            functionsFaturamento.FormatarDecimalCalculo($('#valorJaFaturado').val())).toFixed(2)
            .replace('.', ','));

    functionsFaturamento.CalcularComissaoTotal();

    $('#totalPedido').trigger('blur');

    $('#valorFaturamento').on('blur', function () {
        functionsFaturamento.VerificaValorFaturamento($(this).val());
        functionsFaturamento.CalcularComissaoTotal();
        functionsFaturamento.CalcularComissaoParcelas();
    });

    $('#valorFaturamento').trigger('blur');
    $('#valorJaFaturado').trigger('blur');

    $('#btn-criar').on('click', function () {
        functionsFaturamento.CriaLinhasTabela();
        functionsFaturamento.CalcularComissaoParcelas();
    });

    $(document).on('click', '#btnFaturar', function () {
        functionsFaturamento.ValidaObrigatorio();
        if (error === 0) {
            functionsFaturamento.GeraRequisicao();
        }
        
    });

    $(document).on('click', '.btn-remover', function () {
        functionsFaturamento.RemoveLinhaTabela(this);
        functionsFaturamento.CalcularComissaoParcelas();
    });

    $(document).on('focus', '.comissao', function () {
        valorCampo = $(this).val();
    });

    $(document).on('blur', '.comissao', function (e) {
        if (valorCampo !== $(this).val()) {
            var indice = Number($(this).attr('id').split('_')[1]);
            var valorComissao = 0;

            $('#corpo-tabela tr').find('.comissao').each(function (i, item) {
                if (i + 1 <= indice) {
                    valorComissao += Number(functionsFaturamento.FormatarDecimalCalculo($(item).val()));
                }
            });

            functionsFaturamento.AjusteComissaoParcelas(valorComissao, indice);
            valorComissao = "";
        }
    });
});