using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.StatusPedidos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.StatusPedidos
{
    public class StatusPedidoEstaConsistenteValidation : Validator<StatusPedido>
    {
        public StatusPedidoEstaConsistenteValidation()
        {
            var descricao = new StatusPedidoDevePossuirDescricaoSpecification();
            this.Add("DescricaoVazia", new Rule<StatusPedido>(descricao, "Descrição não pode ser vazia!"));
        }
    }
}
