using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IRepresentadaService : IDisposable
    {
        Representada Adicionar(Representada representada);
        Representada Atualizar(Representada representada);
        void Remover(int id);
        Representada ObterPorId(int id);
        IEnumerable<Representada> ObterTodos();
        IEnumerable<Representada> ObterPorRazaoSocial(string razaoSocial);
        IEnumerable<Representada> ObterPorNomeFantansia(string nomeFantasia);
        IEnumerable<Representada> ObterPorCnpj(string cnpj);
    }
}
