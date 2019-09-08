using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Transportadoras;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.Transportadoras
{
    public class TransportadoraEstaAptaParaRemoverValidation : Validator<Transportadora>
    {
        public TransportadoraEstaAptaParaRemoverValidation(IPedidoRepositorio pedidoRepositorio)
        {
            var pedidosTransportadora = new TransportadoraNaoDevePossuirPedidosVinculadosSpecification(pedidoRepositorio);

            this.Add("transportadoraPossuirPedidoVinculados", new Rule<Transportadora>(pedidosTransportadora,
                "Essa transportadora possui pedidos vinculados a ela, remova-os e tente novamente."));
        }
    }
}
