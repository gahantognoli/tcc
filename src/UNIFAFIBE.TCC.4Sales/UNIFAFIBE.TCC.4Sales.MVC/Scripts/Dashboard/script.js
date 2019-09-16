var dashboardFunctions = {
    GetDados: function (ano, mes) {
        fGlobal.Ajax(gHostProjeto + 'Dashboard/GetDados?ano=' + ano + "&mes=" + mes, "GET", null, this.HtmlDados, null,
            null, null);
    },
    HtmlDados: function (data) {
        $('#meta').text(Number(data.meta).toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }));
        $('#totalFaturado').text(Number(data.totalFaturado).toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }));
        $('#totalAReceber').text(Number(data.totalReceber).toLocaleString('pt-br',{style: 'currency', currency: 'BRL'}));
    }
};

$(function () {
    var mes = $('#mes-dashboards').val();
    var ano = $('#ano-dashboards').val();
    dashboardFunctions.GetDados(ano, mes);

    $('#mes-dashboards').on('change', function () {
        var mes = $(this).val();
        var ano = $('#ano-dashboards').val();
        dashboardFunctions.GetDados(ano, mes);
    });

    $('#ano-dashboards').on('change', function () {
        var mes = $('#mes-dashboards').val();
        var ano = $(this).val();
        dashboardFunctions.GetDados(ano, mes);
    });

});