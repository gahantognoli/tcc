using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class PessoaJuridicaRepositorio : ClienteRepositorio, IPessoaJuridicaRepositorio
    {
        public PessoaJuridicaRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }

        public override Cliente ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PessoaJuridica> ObterPorCPNJ(string cnpj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PessoaJuridica> ObterPorInscricaoEstadual(string inscricaoEstadual)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PessoaJuridica> ObterPorNomeFantasia(string nomeFantasia)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PessoaJuridica> ObterPorRazaoSocial(string razaoSocial)
        {
            throw new NotImplementedException();
        }
    }
}
