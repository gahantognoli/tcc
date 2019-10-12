var index;
var error = 0;
var functionsPedido = {
    GerarOrcamento: function (pedido) {
        fGlobal.Ajax(gHostProjeto + 'Pedido/GerarOrcamento', "POST", { pedido: pedido }, functionsPedido.HtmlOrcamento,
            null, functionsPedido.EsconderModal, functionsPedido.MostrarModal);
    },
    SalvarOrcamento: function (orcamento) {
        fGlobal.Ajax(gHostProjeto + 'Pedido/SalvarOrcamento', "POST", { orcamento: orcamento }, functionsPedido.HtmlOrcamento,
            null, functionsPedido.EsconderModal, functionsPedido.MostrarModal);
    },
    HtmlOrcamento: function (data) {
        var validationResult = data;
        if (validationResult.IsValid === false) {
            fGlobal.ExibirNotificaoErrosValidacao(validationResult);
            setTimeout(function () { functionsPedido.EsconderModal(); }, 30);
        } else {
            window.location = gHostProjeto + 'Pedido/Index';
        }

    },
    GerarPedido: function (pedido) {
        fGlobal.Ajax(gHostProjeto + 'Pedido/GerarPedido', "POST", { pedido: pedido }, functionsPedido.HtmlPedido,
            null, functionsPedido.EsconderModal, functionsPedido.MostrarModal);
    },
    HtmlPedido: function (data) {
        var validationResult = data;
        if (validationResult.IsValid === false) {
            fGlobal.ExibirNotificaoErrosValidacao(validationResult);
            setTimeout(function () { functionsPedido.EsconderModal(); }, 30);
        } else {
            window.location = gHostProjeto + 'Pedido/Index';
        }

    },
    AlterarStatus: function (statusId, pedidoId) {
        fGlobal.Ajax(gHostProjeto + 'Pedido/AlterarStatus', "POST", { statusId: statusId, pedidoId: pedidoId },
            functionsPedido.HtmlAlterarStatus, null, functionsPedido.EsconderModal, functionsPedido.MostrarModal);
    },
    HtmlAlterarStatus: function (data) {
        window.location = gHostProjeto + 'Pedido/Index';
    },
    Remover: function (pedidoId) {
        fGlobal.Ajax(gHostProjeto + 'Pedido/Remover', "POST", { pedidoId: pedidoId }, functionsPedido.HtmlRemover,
            null, functionsPedido.EsconderModal, functionsPedido.MostrarModal);
    },
    HtmlRemover: function (data) {
        window.location = gHostProjeto + 'Pedido/Index';
    },
    MostrarModal: function () {
        fGlobal.MostrarModal('#modal-pedido');
    },
    EsconderModal: function () {
        fGlobal.EsconderModal('#modal-pedido');
    },
    GerarRequisicao: function (tipo) {
        var itensPedido = [];

        $('#corpo-tabela tr').each(function (i, item) {
            i++;
            var produto = {
                ItemPedidoId: $('#itemPedidoId_' + i).val(),
                PedidoId: $('#pedidoId').val(),
                Quantidade: $('#quantidade_' + i).val(),
                Desconto: $('#desconto_' + i).val(),
                Subtotal: $('#subtotal_' + i).val(),
                ProdutoId: $('#produtoId_' + i).val()
            };
            itensPedido.push(produto);
        });

        console.log(itensPedido);

        var pedido = {
            PedidoId: $('#pedidoId').val(),
            NumeroPedido: $('#numeroPedido').val(),
            EnderecoEntrega: $('#enderecoEntrega').val(),
            Contato: $('#contato').val(),
            QuantidadeTotalItens: $('#totalItens').text().trim(),
            ValorTotal: $('#subtotal').text().trim(),
            RepresentadaId: $('#representadaId').val(),
            ClienteId: $('#clienteId').val(),
            CondicaoPagamentoId: $('#condicoesPagamento').val(),
            TransportadoraId: $('#TransportadoraId').val(),
            TipoPedidoId: $('#TipoPedidoId').val(),
            UsuarioId: $('#UsuarioId').val(),
            StatusPedidoId: $('#StatusId').val(),
            ItensPedido: itensPedido
        };

        if (tipo === "pedido") {
            functionsPedido.GerarPedido(JSON.stringify(pedido));
        } else if (tipo === "Salvar Orçamento") {
            functionsPedido.SalvarOrcamento(JSON.stringify(pedido));
        } else {
            functionsPedido.GerarOrcamento(JSON.stringify(pedido));
        }
    },
    GetEnderecos: function (id) {
        fGlobal.Ajax(gHostProjeto + 'Pedido/GetEnderecosCliente/' + id, "GET", null, functionsPedido.HtmlEnderecos,
            null, null, null);
    },
    HtmlEnderecos: function (data) {
        functionsPedido.PreencherSelectEnderecos(data);
    },
    PreencherSelectEnderecos: function (data) {
        functionsPedido.ClearSelect('#enderecoEntrega');
        var html = '';
        $.each(data.json, function (i, item) {
            html += '<option value=' + item.EnderecoClienteId + '>' + item.Endereco + ', ' + item.Numero + '</option>';
        });
        $('#enderecoEntrega').append(html);
    },
    GetContatos: function (id) {
        fGlobal.Ajax(gHostProjeto + 'Pedido/GetContatosCliente/' + id, "GET", null, functionsPedido.HtmlContatos,
            null, null, null);
    },
    HtmlContatos: function (data) {
        functionsPedido.ClearSelect('#contato');
        var html = '';
        $.each(data.json, function (i, item) {
            html += '<option value=' + item.ContatoClienteId + '>' + item.Nome + '</option>';
        });
        $('#contato').append(html);
    },
    GetCondicoesPagamento: function (id) {
        fGlobal.Ajax(gHostProjeto + 'Pedido/GetCondicoesPagamentoRepresentada/' + id, 'GET', null, functionsPedido.HtmlCondicoesPagamentos, null,
            null, null);
    },
    HtmlCondicoesPagamentos: function (data) {
        functionsPedido.ClearSelect('#condicoesPagamento');
        var html = '';
        $.each(data.json, function (i, item) {
            html += '<option value=' + item.CondicaoPagamentoId + '>' + item.Descricao + '</option>';
        });
        $('#condicoesPagamento').append(html);
    },
    ClearSelect: function (id) {
        $(id).find('option').remove();
    },
    CriaLinhasTabela: function () {
        if ($('#corpo-tabela').find('tr').length > 0) {
            index = Number($('.produto').last().attr('id').split('_')[1]) + 1;
        } else {
            index = 1;
        }
        var html = "";
        html = '<tr id="linha_' + index + '" value="' + index + '">';
        html += '<input type="hidden" id="produtoId_' + index + '" />';
        html += '<td class="input-large">';
        html += '<div class="input-group">';
        html += '<input type="text" class="form-control produto required" id="produto_' + index + '" placeholder="Informe a descrição do produto" />';
        html += '<div class="input-group-append">';
        html += '<span class="input-group-text"><i class="fas fa-search"></i></span>';
        html += '<button type="button" class="btn btn-sm btn-criar btn-trocarProduto" id="btnTrocarProduto_' + index + '" disabled="disabled"><i class="fas fa-pencil-alt"></i></button>';
        html += '</div>';
        html += '</div>';
        html += '</td>';
        html += '<td class="input-small">';
        html += '<input type="text" class="form-control preco required" id="preco_' + index + '" readonly="readonly" />';
        html += '</td>';
        html += '<td class="input-small">';
        html += '<input type="number" class="form-control quantidade required" id="quantidade_' + index + '" min="1" value="1" />';
        html += '</td>';
        html += '<td class="input-small">';
        html += '<div class="input-group">';
        html += '<input type="text" class="form-control mValor desconto required" id="desconto_' + index + '" value="0" />';
        html += '<div class="input-group-append">';
        html += '<span class="input-group-text">R$</span>';
        html += '</div>';
        html += '</div>';
        html += '</td>';
        html += '<td class="input-small">';
        html += '<input type="text" class="form-control subtotal required" id="subtotal_' + index + '" readonly="readonly" />';
        html += '</td>';
        html += '<td style="width: 100px;">';
        html += '<button type="button" class="btn btn-sm btn-danger btn-remover">';
        html += '<i class="fas fa-minus mr-1"></i>Remover';
        html += '</button>';
        html += '</td>';
        html += '</tr>';

        $('#corpo-tabela').append(html);

        $('#totalItens').text(parseInt($('#totalItens').text()) + 1);
    },
    RemoveLinhaTabela: function (campo) {
        var tr = $(campo).closest('tr');

        tr.fadeOut(400, function () {

            var valorLinha = parseInt(tr.attr("value"));
            var count = (index - 1);

            for (var a = valorLinha; a <= count; a++) {

                if ($("#linha_" + (a + 1)) !== "") {
                    $("#linha_" + (a + 1)).attr({
                        "id": "linha_" + a,
                        "value": a
                    });

                    $("#produtoId_" + (a + 1)).attr("id", "produtoId_" + a);
                    $("#itemPedidoId_" + (a + 1)).attr("id", "itemPedidoId_" + a);
                    $("#produto_" + (a + 1)).attr("id", "produto_" + a);
                    $("#preco_" + (a + 1)).attr("id", "preco_" + a);
                    $("#quantidade_" + (a + 1)).attr("id", "quantidade_" + a);
                    $("#desconto_" + (a + 1)).attr("id", "desconto_" + a);
                    $("#subtotal_" + (a + 1)).attr("id", "subtotal_" + a);
                    $("#btnTrocarProduto_" + (a + 1)).attr("id", "btnTrocarProduto_" + a);
                    tr.attr("value", a);
                }
            }

            tr.remove();
            index--;
            $('#totalItens').text(parseInt($('#totalItens').text()) - 1);
            functionsPedido.CalculaTotal();
            return false;
        });
    },
    CalculaTotal: function () {
        var total = 0;
        if ($('#corpo-tabela tr').length > 0) {
            $('#corpo-tabela tr').each(function (i, item) {
                var preco = parseFloat(Number($(item).find('.preco').val().replace('.', '').replace(',', '.')).toFixed(2));
                var desconto = parseFloat(Number($(item).find('.desconto').val().replace('.', '').replace(',', '.')).toFixed(2));
                var quantidade = Number(parseInt($(item).find('.quantidade').val()));

                total = parseFloat((Number(total.toString().replace(',', '.')) + ((preco * quantidade) - desconto))).toFixed(2).replace('.', ',');
            });
            $('#subtotal').text(Number(total.replace(',', '.')).toLocaleString('pt-BR'));
        } else {
            $('#subtotal').text(0);
        }
    },
    CalculaSubTotalItem: function (id) {
        var preco = parseFloat(Number($('#preco_' + id).val().replace('.', '').replace(',', '.'))).toFixed(2);
        var desconto = parseFloat(Number($('#desconto_' + id).val().replace('.', '').replace(',', '.'))).toFixed(2);
        var quantidade = Number($('#quantidade_' + id).val());
        var subtotal = (preco * quantidade) - desconto;
        $('#subtotal_' + id).val(subtotal.toLocaleString('pt-BR'));
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
    }
};

$(function () {

    index = $('#corpo-tabela tr').length;

    $.each($('.subtotal'), function (i, item) {
        $(item).val(parseFloat(Number($(item).val().replace('.', '').replace(',', '.')).toFixed(2)).toLocaleString('pt-BR'));
    });

    $.each($('.preco'), function (i, item) {
        $(item).val(parseFloat(Number($(item).val().replace('.', '').replace(',', '.')).toFixed(2)).toLocaleString('pt-BR'));
    });

    $.each($('.desconto'), function (i, item) {
        $(item).val(parseFloat(Number($(item).val().replace('.', '').replace(',', '.')).toFixed(2)).toLocaleString('pt-BR'));
    });

    $('#subtotal').text(parseFloat(Number($('#subtotal').text().replace('.', '').replace(',', '.')).toFixed(2)).toLocaleString('pt-BR'));

    $(document).on('blur', '.desconto', function () {
        if ($(this).val() === "") {
            $(this).val(0);
        }
    });

    $('#cliente').autocomplete({
        serviceUrl: gHostProjeto + 'Pedido/GetCliente',
        transformResult: function (response) {
            var clientes = JSON.parse(response).listaJson;
            return {
                suggestions: $.map(clientes, function (dataItem) {
                    return { value: dataItem.NomeRazaoSocial, data: dataItem.ClienteId };
                })
            };
        },
        onSelect: function (suggestion) {
            $('#cliente').attr('readonly', true);
            $('#clienteId').val(suggestion.data);
            $('#btnTrocarCliente').removeAttr('style', 'display:none;');
            $('#representada').focus();
            functionsPedido.GetEnderecos(suggestion.data);
            functionsPedido.GetContatos(suggestion.data);
        }
    });

    $('#representada').autocomplete({
        serviceUrl: gHostProjeto + 'Pedido/GetRepresentadas',
        transformResult: function (response) {
            var representadas = JSON.parse(response).json;
            return {
                suggestions: $.map(representadas, function (dataItem) {
                    return { value: dataItem.RazaoSocial, data: dataItem.RepresentadaId };
                })
            };
        },
        onSelect: function (suggestion) {
            $('#representada').attr('readonly', true);
            $('#representadaId').val(suggestion.data);
            $('#btnTrocarRepresentada').removeAttr('style', 'display:none;');
            $('#btn-criar').removeAttr('disabled');
            functionsPedido.GetCondicoesPagamento(suggestion.data);
        }
    });

    $(document).on('focus', '.produto', function () {
        var i = $(this).closest('tr').attr('value');
        $('#corpo-tabela').find('#produto_' + i).autocomplete({
            params: { id: $('#representadaId').val() },
            serviceUrl: gHostProjeto + 'Pedido/GetProdutos',
            transformResult: function (response) {
                var produtos = JSON.parse(response).json;
                return {
                    suggestions: $.map(produtos, function (dataItem) {
                        return {
                            value: dataItem.Nome, data: dataItem.ProdutoId + ',' + dataItem.Preco
                        };
                    })
                };
            },
            onSelect: function (suggestion) {
                $(document).find('#produtoId_' + i).val(suggestion.data.split(',')[0]);
                $(document).find('#preco_' + i).val(Number(suggestion.data.split(',')[1]).toLocaleString('pt-BR'));
                $(document).find('#produto_' + i).attr('readonly', true);
                $(document).find('#btnTrocarProduto_' + i).removeAttr('disabled');
                $(document).find('#quantidade_' + i).focus();
                functionsPedido.CalculaTotal();
            }
        });
    });

    $('#btnTrocarCliente').on('click', function () {
        $('#cliente').removeAttr('readonly');
        $('#cliente').val('');
        $('#clienteId').val('');
        $(this).attr('style', 'display:none');
        functionsPedido.ClearSelect('#enderecoEntrega');
        functionsPedido.ClearSelect('#contato');
    });

    $('#btnTrocarRepresentada').on('click', function () {
        $('#representada').removeAttr('readonly');
        $('#produto').attr('readonly');
        $('#representada').val('');
        $('#representadaId').val('');
        $(this).attr('style', 'display:none');
        $('#corpo-tabela tr').remove();
        index = 1;
        $('#btn-criar').attr('disabled', true);
        $('#totalItens').text('0');
        $('#subtotal').text('0');
        functionsPedido.ClearSelect('#condicoesPagamento');
    });

    $(document).on('click', '.btn-trocarProduto', function () {
        $(this).closest('tr').find('.produto').removeAttr('readonly');
        $(this).closest('tr').find('.produto').val('');
        $(this).closest('tr').find('.produtoId').val('');
        $(this).closest('tr').find('.preco').val(0);
        $(this).closest('tr').find('.quantidade').val(1);
        $(this).closest('tr').find('.desconto').val(0);
        $(this).closest('tr').find('.subtotal').val(0);
        $(this).attr('disabled', true);
        functionsPedido.CalculaTotal();
    });

    $('#btn-criar').on('click', function () {
        functionsPedido.CriaLinhasTabela();
        functionsPedido.CalculaTotal();
    });

    $('#btnGerarOrcamento').on('click', function () {
        functionsPedido.ValidaObrigatorio();
        if (error === 0) {
            functionsPedido.GerarRequisicao("orçamento");
        }
    });

    $('#btnGerarPedido').on('click', function () {
        functionsPedido.ValidaObrigatorio();
        if (error === 0) {
            functionsPedido.GerarRequisicao("pedido");
        }
    });

    $("#btnSalvar").on('click', function () {
        functionsPedido.ValidaObrigatorio();
        if (error === 0) {
            functionsPedido.GerarRequisicao("Salvar Orçamento");
        }
    });

    $("#btnConfirmarRemocao").on('click', function () {
        functionsPedido.Remover($('#pedidoId').val());
    });

    $('#alterarStatus').on('click', function () {
        var statusId = $(this).data('status');
        var pedidoId = $('#pedidoId').val();
        functionsPedido.AlterarStatus(statusId, pedidoId);
    });

    $(document).on('click', '.btn-remover', function () {
        functionsPedido.RemoveLinhaTabela(this);
        functionsPedido.CalculaTotal();
    });

    $(document).on('blur', '.desconto', function () {
        functionsPedido.CalculaSubTotalItem($(this).attr('id').split('_')[1]);
        functionsPedido.CalculaTotal();
    });

    $(document).on('blur', '.quantidade', function () {
        if ($(this).val() === "0" || $(this).val() === "") {
            $(this).val(1);
        }
        functionsPedido.CalculaSubTotalItem($(this).attr('id').split('_')[1]);
        functionsPedido.CalculaTotal();
    });
});