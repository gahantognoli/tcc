using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class ParcelaService : IParcelaService
    {
        private readonly IParcelaRepositorio _parcelaRepositorio;
        private readonly IFaturamentoRepositorio _faturamentoRepositorio;

        public ParcelaService(IParcelaRepositorio parcelaRepositorio, IFaturamentoRepositorio faturamentoRepositorio)
        {
            _parcelaRepositorio = parcelaRepositorio;
            _faturamentoRepositorio = faturamentoRepositorio;
        }

        public Parcela Adicionar(Parcela parcela)
        {
            if (!parcela.EhValido(_faturamentoRepositorio))
                return parcela;

            return _parcelaRepositorio.Adicionar(parcela);
        }

        public Parcela Atualizar(Parcela parcela)
        {
            if (!parcela.EhValido(_faturamentoRepositorio))
                return parcela;

            return _parcelaRepositorio.Atualizar(parcela);
        }

        public decimal CalcularComissao(decimal valorParcela, decimal comissao, int numParcela)
        {
            var calculoComissao = (valorParcela * comissao) / numParcela;
            return calculoComissao;
        }

        public void Dispose()
        {
            _parcelaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Parcela ObterPorId(Guid id)
        {
            return _parcelaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Parcela> ObterTodos(Guid faturamentoId)
        {
            return _parcelaRepositorio.ObterTodos(faturamentoId);
        }

        public void Remover(Guid parcelaId)
        {
            _parcelaRepositorio.Remover(parcelaId);
        }
    }
}
