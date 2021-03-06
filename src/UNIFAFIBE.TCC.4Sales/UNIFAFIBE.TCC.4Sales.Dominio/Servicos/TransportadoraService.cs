﻿using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class TransportadoraService : ITransportadoraService
    {
        private readonly ITransportadoraRepositorio _transportadoraRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public TransportadoraService(ITransportadoraRepositorio transportadoraRepositorio,
            IPedidoRepositorio pedidoRepositorio)
        {
            _transportadoraRepositorio = transportadoraRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
        }

        public Transportadora Adicionar(Transportadora transportadora)
        {
            //if (!transportadora.EhValido())
            //    return transportadora;
            return _transportadoraRepositorio.Adicionar(transportadora);
        }

        public Transportadora Atualizar(Transportadora transportadora)
        {
            //if (!transportadora.EhValido())
            //    return transportadora;
            return _transportadoraRepositorio.Atualizar(transportadora);
        }

        public void Dispose()
        {
            _transportadoraRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Transportadora> ObterPorCidade(string cidade)
        {
            return _transportadoraRepositorio.ObterPorCidade(cidade);
        }

        public IEnumerable<Transportadora> ObterPorEstado(string estado)
        {
            return _transportadoraRepositorio.ObterPorEstado(estado);
        }

        public Transportadora ObterPorId(Guid id)
        {
            return _transportadoraRepositorio.ObterPorId(id);
        }

        public IEnumerable<Transportadora> ObterPorNome(string nome)
        {
            return _transportadoraRepositorio.ObterPorNome(nome);
        }

        public IEnumerable<Transportadora> ObterTodos()
        {
            return _transportadoraRepositorio.ObterTodos();
        }

        public Transportadora Remover(Guid id)
        {
            var transpordoraRetorno = _transportadoraRepositorio.ObterPorId(id);
            if (transpordoraRetorno.EstaAptaParaRemover(_pedidoRepositorio))
            {
                _transportadoraRepositorio.Remover(id);
            }
            return transpordoraRetorno;
        }
    }
}
