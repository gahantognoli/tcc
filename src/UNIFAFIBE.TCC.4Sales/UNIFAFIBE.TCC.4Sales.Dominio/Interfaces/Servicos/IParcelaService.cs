﻿using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IParcelaService : IDisposable
    {
        Parcela Adicionar(Parcela parcela);
        Parcela Atualizar(Parcela parcela);
        decimal CalcularComissao(decimal valorFaturamento, decimal comissao, int numParcela);
        void Remover(int parcelaId);
        Parcela ObterPorId(int id);
        IEnumerable<Parcela> ObterTodos(int faturamentoId);
    }
}
