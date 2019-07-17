using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.CondicoesPagamento
{
    public class CondicaoPagamentoDevePossuirDescricaoUnicaSpecification : ISpecification<CondicaoPagamento>
    {
        private readonly ICondicaoPagamentoRepositorio _condicaoPagamentoRepositorio;

        public CondicaoPagamentoDevePossuirDescricaoUnicaSpecification(ICondicaoPagamentoRepositorio condicaoPagamentoRepositorio)
        {
            _condicaoPagamentoRepositorio = condicaoPagamentoRepositorio;
        }

        public bool IsSatisfiedBy(CondicaoPagamento condicaoPagamento)
        {
            return _condicaoPagamentoRepositorio.ObterPorDescricao(condicaoPagamento.Descricao) == null;
        }
    }
}
