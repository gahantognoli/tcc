using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.TiposPedido;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.TiposPedido
{
    public class TipoPedidoEstaConsistenteValidation : Validator<TipoPedido>
    {
        public TipoPedidoEstaConsistenteValidation()
        {
            var descricao = new TipoPedidoDevePossuirDescricaoSpecification();
            this.Add("DescricaoVazia", new Rule<TipoPedido>(descricao, "Descrição não pode ser vazia!"));
        }
    }
}
