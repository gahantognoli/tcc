using System;
using System.Collections.Generic;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class FaturamentoService : IFaturamentoService
    {
        private readonly IFaturamentoRepositorio _faturamentoRepositorio;

        public FaturamentoService(IFaturamentoRepositorio faturamentoRepositorio)
        {
            _faturamentoRepositorio = faturamentoRepositorio;
        }

        public Faturamento Atualizar(Faturamento faturamento)
        {
            if (!faturamento.EhValido())
                return faturamento;

            return _faturamentoRepositorio.Atualizar(faturamento);
        }

        public void Dispose()
        {
            _faturamentoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Faturamento Faturar(Faturamento faturamento)
        {
            if (!faturamento.EhValido())
                return faturamento;

            var fat = _faturamentoRepositorio.Adicionar(faturamento);
            
            return fat;
        }

        public Faturamento ObterPorId(Guid id)
        {
            return _faturamentoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Faturamento> ObterTodos(Guid pedidoId)
        {
            return _faturamentoRepositorio.ObterTodos(pedidoId);
        }

        public decimal ObterTotalFaturamento(Guid pedidoId)
        {
            return _faturamentoRepositorio.ObterTotalFaturamento(pedidoId);
        }

        public void Remover(Guid id)
        {
            _faturamentoRepositorio.Remover(id);
        }
    }
}
