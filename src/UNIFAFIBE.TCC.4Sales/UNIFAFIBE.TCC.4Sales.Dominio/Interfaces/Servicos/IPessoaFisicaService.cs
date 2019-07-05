using System;
using System.Collections.Generic;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    interface IPessoaFisicaService : IDisposable, IClienteService
    {
        IEnumerable<PessoaFisica> ObterPorNome(string nome);
        IEnumerable<PessoaFisica> ObterPorCPF(string cpf);
    }
}
