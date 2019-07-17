using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.ItensPedido;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.ItensPedido
{
    public class ItemPedidoEstaConsistenteValidation : Validator<ItemPedido>
    {
        public ItemPedidoEstaConsistenteValidation()
        {
            var quantidade = new ItemPedidoQuantidadeDeveSerMaiorQueZero();
            this.Add("QuantidadeZerada", new Rule<ItemPedido>(quantidade, "A quantidade do produto não pode ser zero!"));
        }
    }
}
