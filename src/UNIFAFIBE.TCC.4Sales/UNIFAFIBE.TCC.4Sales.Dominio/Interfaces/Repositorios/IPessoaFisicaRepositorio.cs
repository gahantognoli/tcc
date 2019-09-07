using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios
{
    public interface IPessoaFisicaRepositorio : IRepositorio<PessoaFisica>
    {
        IEnumerable<PessoaFisica> ObterPorNome(string nome);
        IEnumerable<PessoaFisica> ObterPorCPF(string cpf);
        IEnumerable<PessoaFisica> ObterPorSegmento(Guid segmentoId);
    }
}
