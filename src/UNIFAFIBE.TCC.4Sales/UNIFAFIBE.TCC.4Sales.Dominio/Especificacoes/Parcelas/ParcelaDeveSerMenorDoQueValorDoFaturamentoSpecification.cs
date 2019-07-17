using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Parcelas
{
    public class ParcelaDeveSerMenorDoQueValorDoFaturamentoSpecification : ISpecification<Parcela>
    {
        private readonly IFaturamentoRepositorio _faturamentoRepositorio;

        public ParcelaDeveSerMenorDoQueValorDoFaturamentoSpecification(IFaturamentoRepositorio faturamentoRepositorio)
        {
            _faturamentoRepositorio = faturamentoRepositorio;
        }

        public bool IsSatisfiedBy(Parcela parcela)
        {
            return _faturamentoRepositorio.ObterPorId(parcela.Faturamento.PedidoId).Valor >= parcela.ValorParcela;
        }
    }
}
