using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IPessoaJuridicaRepositorio : IRepositorio<PessoaJuridica>
    {
        IEnumerable<PessoaJuridica> ObterPorCPNJ(string cnpj);
        IEnumerable<PessoaJuridica> ObterPorRazaoSocial(string razaoSocial);
        IEnumerable<PessoaJuridica> ObterPorNomeFantasia(string nomeFantasia);
        IEnumerable<PessoaJuridica> ObterPorInscricaoEstadual(string inscricaoEstadual);
    }
}
