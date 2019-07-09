using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class PessoaFisicaRepositorio : ClienteRepositorio, IPessoaFisicaRepositorio
    {
        public PessoaFisicaRepositorio(TCC_Contexto contexto) : base(contexto)
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

        public IEnumerable<PessoaFisica> ObterPorCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PessoaFisica> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
