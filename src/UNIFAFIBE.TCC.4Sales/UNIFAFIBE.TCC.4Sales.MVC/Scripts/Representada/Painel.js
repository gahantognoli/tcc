var functionsPainelRepresentada = {
    Listar: function () {
        var representadaId = $('#representadaId').val();
        var parametro = $('#parametro').val();
        var busca = $('#busca').val();
        var ordemAlfabetica = "";
        if ($('#OrdemCrescente').is(':checked')) {
            ordemAlfabetica = $('#OrdemCrescente').val();
        } else if ($('#OrdemDecrescente').is(':checked')) {
            ordemAlfabetica = $('#OrdemDecrescente').val();
        }
        var ordemPreco = "";
        if ($('#MaiorPreco').is(':checked')) {
            ordemPreco = $('#MaiorPreco').val();
        } else if ($('#MenorPreco').is(':checked')) {
            ordemPreco = $('#MenorPreco').val();
        }
        var url = gHostProjeto + "Representada/Listar?representadaId=" + representadaId + "&ordemAlfabetica="
            + ordemAlfabetica + "&ordemPreco=" + ordemPreco + "&parametro=" + parametro
            + "&busca=" + busca;
        fGlobal.Ajax(url, "GET", null, functionsPainelRepresentada.HtmlProdutos, null, functionsPainelRepresentada.HideLoading, functionsPainelRepresentada.ShowLoading);
    },
    HtmlProdutos: function (pData) {
        var data = JSON.parse(pData.produtos);
        functionsPainelRepresentada.TableClear("corpoTabelaProdutos");

        functionsPainelRepresentada.TableFill(data);
    },
    TableFill: function (data) {
        $.each(data, function (index, value) {
            var row = $('<tr>');
            var columns = "";
            var ipi = value.IPI.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
            var preco = value.Preco.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
            columns += '<td>' + (value.Codigo === null ? "  " : value.Codigo) + '</td>';
            columns += '<td><a href="/Produto/Detalhes/' + value.ProdutoId + '" class="link-detalhes">' + value.Nome + '</a></td>';
            columns += '<td>' + ipi + '</td>';
            columns += '<td>' + value.UnidadeMedida + '</td>';
            columns += '<td>' + preco + '</td>';
            columns += '<td>';
            columns += '<div>';
            columns += '<a href="/Produto/Alterar/' + value.ProdutoId + '" class="btn btn-sm btn-warning mr-1">';
            columns += '<i class="fas fa-pencil-alt icone-edit"></i>Alterar';
            columns += '</a>';
            columns += '<a href="/Produto/Remover/' + value.ProdutoId + '" class="btn btn-sm btn-danger">';
            columns += '<i class="fas fa-trash-alt icone-remove"></i>Remover';
            columns += '</a>';
            columns += '</div>';
            columns += '</td >';

            row.append(columns);
            $("#corpoTabelaProdutos").append(row);
        });

    }, TableClear: function (tableId) {
        var tableRows = $("#" + tableId + " tr");
        if (tableRows.length > 0) {
            tableRows.each(function () {
                this.remove();
            });
        }
    },
    HideLoading: function () {
        $('#loading-produto').attr('style', 'display:none;');
    },
    ShowLoading: function () {
        $('#loading-produto').removeAttr('style', 'display:none;');
    },
    DetalhesRepresentada: function (pIdRepresentada) {
        fGlobal.Ajax(gHostProjeto + "Representada/DetalhesRepresentada?representadaId=" + pIdRepresentada, "GET", null, functionsPainelRepresentada.HtmlDetalhes, null, null, null);
    },
    HtmlDetalhes: function (data) {
        var html = "";
        var json = JSON.parse(data.representada);

        functionsPainelRepresentada.DivClear("content-detalhes");

        html += '<div id="content-detalhes">';
        html += '<div class="row mt-3" id="content-detalhes">';
        html += '<div class="col-md-12 d-flex justify-content-lg-between pl-0 pr-0">';
        html += '<div class="col-md-5">';
        html += '<h2 id="nomeEmpresa">' + json.NomeFantasia + '</h2>';
        html += '</div>';
        html += '<div class="col-md-7">';
        html += '<div class="d-flex justify-content-end mt-1">';
        html += '<a href="/Representada/Atualizar/' + json.RepresentadaId + '" class="btn btn-sm btn-warning mr-1">';
        html += '<i class="fas fa-pencil-alt icone-edit"></i>Alterar';
        html += '</a>';
        html += '<a href="/Representada/Remover/' + json.RepresentadaId + '" class="btn btn-sm btn-danger">';
        html += '<i class="fas fa-trash-alt icone-remove"></i>Remover';
        html += '</a>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        html += '<hr />';
        html += '<div class="row">';
        html += '<div class="col-md-6">';
        html += '<div id="content-telefone" style="margin-bottom: 10px;">';
        html += '<h5 class="text-muted mb-1">Telefone</h5>';
        html += '<span>' + json.Telefone + '</span>';
        html += '</div>';
        html += '<div id="content-email" style="margin-bottom: 10px;">';
        html += '<h5 class="text-muted mb-1">Email</h5>';
        html += '<span>' + json.Email + '</span>';
        html += '</div>';
        html += '</div>';
        html += '<div class="col-md-6 mb-4">';
        html += '<div id="content-razaoSocial" style="margin-bottom: 10px;">';
        html += '<h5 class="text-muted mb-1">Razão social</h5>';
        html += '<span>' + json.RazaoSocial + '</span>';
        html += '</div>';
        html += '<div id="content-nomeFantasia" style="margin-bottom: 10px;">';
        html += '<h5 class="text-muted mb-1">Nome fantasia</h5>';
        html += '<span>' + json.NomeFantasia + '</span>';
        html += '</div>';
        html += '<div id="content-razaoSocial" style="margin-bottom: 10px;">';
        html += '<h5 class="text-muted mb-1">CNPJ</h5>';
        html += '<span>' + json.CNPJ + '</span>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        html += '<hr />';
        html += '<div class="row">';
        html += '<div class="col-md-12">';
        html += '<div id="content-Comissao" style="margin-bottom: 10px;">';
        html += '<h5 class="text-muted mb-1">Comissão</h5>';
        html += '<span id="comissao">' + json.Comissao + '%</span>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        html += '<hr />';
        html += '</div>';

        $("#detalhes").append(html);
    },
    DivClear: function (pDivId) {
        $("#" + pDivId).remove();
    }
};

$(function () {
    functionsPainelRepresentada.Listar();
});

$("#btnPesquisarProduto").on('click', function () {
    functionsPainelRepresentada.Listar();
});

$('.ordenacao').on('change', function () {
    functionsPainelRepresentada.Listar();
});

$(document).on('click', '#produto-tab', function () {
    functionsPainelRepresentada.Listar();
});

$(document).on('click', '#detalhes-tab', function () {
    var representadaId = $("#representadaId").val();

    if (fGlobal.IsNotEmpty(representadaId)) {
        functionsPainelRepresentada.DetalhesRepresentada(representadaId);
    }
});