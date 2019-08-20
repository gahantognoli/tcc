﻿using DomainValidation.Interfaces.Specification;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.Pedidos
{
    public class PedidoDevePossuirVendedorSpecification : ISpecification<Pedido>
    {
        public bool IsSatisfiedBy(Pedido pedido)
        {
            return pedido.UsuarioId != null;
        }
    }
}
