using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos.Relatorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades.Relatorios;
using UNIFAFIBE.TCC._4Sales.MVC.Relatorios.Clientes;
using UNIFAFIBE.TCC._4Sales.MVC.Relatorios.Comissoes;
using UNIFAFIBE.TCC._4Sales.MVC.Relatorios.Faturamentos;
using UNIFAFIBE.TCC._4Sales.MVC.Relatorios.Vendas;

namespace UNIFAFIBE.TCC._4Sales.MVC.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IRelatoriosVendaAppService _relatoriosVendaAppService;
        private readonly IRelatoriosFaturamentoAppService _relatoriosFaturamentoAppService;
        private readonly IRelatoriosComissaoAppService _relatoriosComissaoAppService;
        private readonly IRelatoriosClienteAppService _relatoriosClienteAppService;

        public RelatoriosController(IRelatoriosVendaAppService relatoriosVendaAppService,
            IRelatoriosFaturamentoAppService relatoriosFaturamentoAppService, 
            IRelatoriosComissaoAppService relatoriosComissaoAppService,
            IRelatoriosClienteAppService relatoriosClienteAppService)
        {
            _relatoriosVendaAppService = relatoriosVendaAppService;
            _relatoriosFaturamentoAppService = relatoriosFaturamentoAppService;
            _relatoriosComissaoAppService = relatoriosComissaoAppService;
            _relatoriosClienteAppService = relatoriosClienteAppService;
        }

        public ActionResult VendasPorPeriodo()
        {
            return View();
        }

        public FileResult GerarRelatorioVendasPorPeriodo(string dataEmissaoInicio, string dataEmissaoFim, string exportarPara)
        {
            var dataEmissaoInicioConvertida = Convert.ToDateTime(dataEmissaoInicio);
            var dataEmissaoFimConvertida = Convert.ToDateTime(dataEmissaoFim + " 23:59:59");

            var dados = _relatoriosVendaAppService.PorPeriodo(dataEmissaoInicioConvertida, dataEmissaoFimConvertida);

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\Vendas\\RelatorioVendasPorPeriodo.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Vendas);
            localReport.DataSources.Add(dataSource);

            if (exportarPara == "pdf")
            {
                var bytes = localReport.Render("PDF");
                return File(bytes, "application/pdf");
            }
            else
            {
                var bytes = localReport.Render("EXCELOPENXML");
                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private DatasetRelatorioVendasPorPeriodo PopularDataset(IEnumerable<VendaPorPeriodo> dados)
        {
            var dataset = new DatasetRelatorioVendasPorPeriodo();

            foreach (var item in dados)
            {
                var venda = dataset.Vendas.NewVendasRow();
                venda.DataEmissao = item.DataEmissao;
                venda.Cliente = item.Cliente;
                venda.NumeroPedido = item.NumeroPedido;
                venda.Representada = item.Representada;
                venda.Vendedor = item.Vendedor;
                venda.ValorTotal = item.ValorTotal;
                dataset.Vendas.AddVendasRow(venda);
            }

            return dataset;
        }

        public ActionResult RankingVendedores()
        {
            return View();
        }

        public FileResult GerarRelatorioRankingVendedores(string mes, string ano, string exportarPara)
        {
            var intMes = Convert.ToInt32(mes);
            var intAno = Convert.ToInt32(ano);

            var dados = _relatoriosVendaAppService.RankingVendedores(intMes, intAno);

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\Vendas\\RelatorioVendasRakingVendedores.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Vendas);
            localReport.DataSources.Add(dataSource);

            if (exportarPara == "pdf")
            {
                var bytes = localReport.Render("PDF");
                return File(bytes, "application/pdf");
            }
            else
            {
                var bytes = localReport.Render("EXCELOPENXML");
                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private DatasetRelatorioRankingVendedores PopularDataset(IEnumerable<VendaRankingVendedor> dados)
        {
            var dataset = new DatasetRelatorioRankingVendedores();
            int posicao = 0;

            foreach (var item in dados)
            {
                var venda = dataset.Vendas.NewVendasRow();
                posicao++;
                venda.Vendedor = item.Vendedor;
                venda.ValorVendido = item.ValorVendido;
                venda.Posicao = posicao;
                dataset.Vendas.AddVendasRow(venda);
            }

            return dataset;
        }

        public ActionResult FaturamentoPorPeriodo()
        {
            return View();
        }

        public FileResult GerarRelatorioFaturamentosPorPeriodo(string dataEmissaoInicio, string dataEmissaoFim, string exportarPara)
        {
            var dataEmissaoInicioConvertida = Convert.ToDateTime(dataEmissaoInicio);
            var dataEmissaoFimConvertida = Convert.ToDateTime(dataEmissaoFim + " 23:59:59");

            var dados = _relatoriosFaturamentoAppService.PorPeriodo(dataEmissaoInicioConvertida, dataEmissaoFimConvertida);

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\Faturamentos\\RelatoriosFaturamento.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Faturamentos);
            localReport.DataSources.Add(dataSource);

            if (exportarPara == "pdf")
            {
                var bytes = localReport.Render("PDF");
                return File(bytes, "application/pdf");
            }
            else
            {
                var bytes = localReport.Render("EXCELOPENXML");
                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private DatasetRelatoriosFaturamentos PopularDataset(IEnumerable<FaturamentoPorPeriodo> dados)
        {
            var dataset = new DatasetRelatoriosFaturamentos();

            foreach (var item in dados)
            {
                var faturamento = dataset.Faturamentos.NewFaturamentosRow();
                faturamento.DataEmissao = item.DataEmissao;
                faturamento.NumeroPedido = item.NumeroPedido;
                faturamento.RazaoSocial = item.RazaoSocial;
                faturamento.Cliente = item.Cliente;
                faturamento.Vendedor = item.Vendedor;
                faturamento.ValorTotal = item.ValorTotal;
                faturamento.Faturado = item.Faturado;
                faturamento.NaoFaturado = item.NaoFaturado;
                dataset.Faturamentos.AddFaturamentosRow(faturamento);
            }

            return dataset;
        }

        public ActionResult ComissaoPorPeriodo()
        {
            return View();
        }

        public FileResult GerarRelatorioComissaoPorPeriodo(string dataEmissaoInicio, string dataEmissaoFim, string exportarPara)
        {
            var dataEmissaoInicioConvertida = Convert.ToDateTime(dataEmissaoInicio);
            var dataEmissaoFimConvertida = Convert.ToDateTime(dataEmissaoFim + " 23:59:59");

            var dados = _relatoriosComissaoAppService.PorPeriodo(dataEmissaoInicioConvertida, dataEmissaoFimConvertida);

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\Comissoes\\RelatorioComissoesPorPeriodo.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Comissoes);
            localReport.DataSources.Add(dataSource);

            if (exportarPara == "pdf")
            {
                var bytes = localReport.Render("PDF");
                return File(bytes, "application/pdf");
            }
            else
            {
                var bytes = localReport.Render("EXCELOPENXML");
                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private DatasetRelatorioComissoesPorPeriodo PopularDataset(IEnumerable<ComissaoPorPeriodo> dados)
        {
            var dataset = new DatasetRelatorioComissoesPorPeriodo();

            foreach (var item in dados)
            {
                var comissao = dataset.Comissoes.NewComissoesRow();
                comissao.DataPagamento = item.DataPagamento;
                comissao.NumeroPedido = item.NumeroPedido;
                comissao.DataFaturamento = item.DataFaturamento;
                comissao.Representada = item.Representada;
                comissao.Cliente = item.Cliente;
                comissao.ValorPedido = item.ValorPedido;
                comissao.NumeroPedido = item.NumeroPedido;
                comissao.NumeroParcela = item.NumeroParcela;
                comissao.ValorComissao = item.ValorComissao;
                comissao.Comissao = item.Comissao;
                comissao.Paga = item.Paga;
                dataset.Comissoes.AddComissoesRow(comissao);
            }

            return dataset;
        }

        public ActionResult SituacaoCarteiraClientes()
        {
            return View();
        }

        public FileResult GerarRelatorioSituacaoCarteiraClientes(string exportarPara)
        {
            var dados = _relatoriosClienteAppService.SituacaoCarteiraClientes();

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\Clientes\\RelatorioSituacaoCarteiraClientes.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Clientes);
            localReport.DataSources.Add(dataSource);

            if (exportarPara == "pdf")
            {
                var bytes = localReport.Render("PDF");
                return File(bytes, "application/pdf");
            }
            else
            {
                var bytes = localReport.Render("EXCELOPENXML");
                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        private DatasetRelatorioSituacaoCarteiraClientes PopularDataset(IEnumerable<SituacaoCarteiraClientes> dados)
        {
            var dataset = new DatasetRelatorioSituacaoCarteiraClientes();

            foreach (var item in dados)
            {
                var cliente = dataset.Clientes.NewClientesRow();
                cliente.Cliente = item.Cliente;
                cliente.UltimoPedido = item.UltimoPedido;
                cliente.DataUltimoPedido = item.DataUltimoPedido;
                cliente.ValorUltimoPedido = item.ValorUltimoPedido;
                cliente.DiasSemComprar = item.DiasSemComprar;
                dataset.Clientes.AddClientesRow(cliente);
            }

            return dataset;
        }

    }
}