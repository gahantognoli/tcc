﻿using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface ITipoPedidoRepositorio : IRepositorio<TipoPedido>
    {
        IEnumerable<TipoPedido> ObterPorDescricao(string tipoPedido);
    }
}
