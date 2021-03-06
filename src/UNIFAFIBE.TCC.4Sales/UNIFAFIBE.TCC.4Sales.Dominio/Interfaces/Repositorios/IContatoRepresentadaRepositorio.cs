﻿using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IContatoRepresentadaRepositorio : IRepositorio<ContatoRepresentada>
    {
        IEnumerable<ContatoRepresentada> ObterTodos(Guid representadaId);
    }
}
