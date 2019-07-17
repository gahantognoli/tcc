using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.CondicoesPagamento;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.CondicoesPagamento
{
    public class CondicaoPagamentoEstaAptaValidation : Validator<CondicaoPagamento>
    {
        public CondicaoPagamentoEstaAptaValidation(ICondicaoPagamentoRepositorio condicaoPagamentoRepositorio)
        {
            var descricao = new CondicaoPagamentoDevePossuirDescricaoUnicaSpecification(condicaoPagamentoRepositorio);
            this.Add("DescricaoInvalida", new Rule<CondicaoPagamento>(descricao, "Essa Condição de pagamento já está em uso!"));
        }
    }
}
