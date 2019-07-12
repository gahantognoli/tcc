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

        public ParcelaService(IParcelaRepositorio parcelaRepositorio)
        {
            _parcelaRepositorio = parcelaRepositorio;
        }

        public Parcela Adicionar(Parcela parcela)
        {
            if (!parcela.EhValido())
                return parcela;

            return _parcelaRepositorio.Adicionar(parcela);
        }

        public Parcela Atualizar(Parcela parcela)
        {
            if (!parcela.EhValido())
                return parcela;

            return _parcelaRepositorio.Atualizar(parcela);
        }

        public decimal CalcularComissao(decimal valorFaturamento, decimal comissao, int numParcela)
        {
            var calculo = (valorFaturamento * comissao) / numParcela;

            return calculo;
        }

        public void Dispose()
        {
            _parcelaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Parcela ObterPorId(int id)
        {
            return _parcelaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Parcela> ObterTodos(int faturamentoId)
        {
            return _parcelaRepositorio.ObterTodos(faturamentoId);
        }

        public void Remover(int parcelaId)
        {
            _parcelaRepositorio.Remover(parcelaId);
        }
    }
}
