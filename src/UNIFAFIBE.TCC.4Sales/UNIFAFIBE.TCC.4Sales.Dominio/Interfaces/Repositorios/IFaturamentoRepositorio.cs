﻿using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IFaturamentoRepositorio : IRepositorio<Faturamento>
    {
        IEnumerable<Faturamento> ObterTodos(Guid pedidoId);
        decimal ObterTotalFaturamento(Guid pedidoId);
    }
}
