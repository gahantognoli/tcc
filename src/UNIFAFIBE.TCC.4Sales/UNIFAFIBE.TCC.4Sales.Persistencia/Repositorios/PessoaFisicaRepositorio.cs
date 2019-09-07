using Dapper;
using Slapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Infra.Helpers;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;
using UNIFAFIBE.TCC._4Sales.Persistencia.Procedures;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class PessoaFisicaRepositorio : Repositorio<PessoaFisica>, IPessoaFisicaRepositorio
    {
        private readonly IEnderecoClienteRepositorio _enderecoClienteRepositorio;
        private readonly IContatoClienteRepositorio _contatoClienteRepositorio;
        public PessoaFisicaRepositorio(TCC_Contexto contexto, IEnderecoClienteRepositorio enderecoClienteRepositorio,
            IContatoClienteRepositorio contatoClienteRepositorio) : base(contexto)
        {
            _enderecoClienteRepositorio = enderecoClienteRepositorio;
            _contatoClienteRepositorio = contatoClienteRepositorio;
        }

        public override PessoaFisica Atualizar(PessoaFisica pessoaFisica)
        {
            PessoaFisica existingPessoaFisica = Db.PessoasFisicas.Include("ContatosCliente")
               .Include("EnderecosCliente")
               .Where(e => e.ClienteId == pessoaFisica.ClienteId).FirstOrDefault<PessoaFisica>();

            List<EnderecoCliente> deletedEnderecos = existingPessoaFisica.EnderecosCliente.Except(pessoaFisica.EnderecosCliente, e => e.EnderecoClienteId).ToList<EnderecoCliente>();
            List<ContatoCliente> deletedContatos = existingPessoaFisica.ContatosCliente.Except(pessoaFisica.ContatosCliente, c => c.ContatoClienteId).ToList<ContatoCliente>();

            List<EnderecoCliente> addedEnderecos = pessoaFisica.EnderecosCliente.Except(existingPessoaFisica.EnderecosCliente, e => e.EnderecoClienteId).ToList<EnderecoCliente>();
            List<ContatoCliente> addedContatos = pessoaFisica.ContatosCliente.Except(existingPessoaFisica.ContatosCliente, c => c.ContatoClienteId).ToList<ContatoCliente>();

            if (deletedEnderecos.Count() > 0 || deletedContatos.Count() > 0)
            {
                deletedEnderecos.ForEach(e => { existingPessoaFisica.EnderecosCliente.Remove(e); _enderecoClienteRepositorio.Remover(e.EnderecoClienteId); });
                deletedContatos.ForEach(c => { existingPessoaFisica.ContatosCliente.Remove(c); _contatoClienteRepositorio.Remover(c.ContatoClienteId); });
            }

            if (addedContatos.Count() > 0 || addedEnderecos.Count() > 0)
            {
                foreach (ContatoCliente c in addedContatos)
                {
                    c.ClienteId = pessoaFisica.ClienteId;
                    if (Db.Entry(c).State == System.Data.Entity.EntityState.Detached)
                    {
                        Db.ContatosClientes.Attach(c);
                    }

                    _contatoClienteRepositorio.Adicionar(c);
                }

                foreach (EnderecoCliente e in addedEnderecos)
                {
                    e.ClienteId = pessoaFisica.ClienteId;
                    if (Db.Entry(e).State == System.Data.Entity.EntityState.Detached)
                    {
                        Db.EnderecosClientes.Attach(e);
                    }

                    _enderecoClienteRepositorio.Adicionar(e);
                }
            }

            Db.Set<PessoaFisica>().AddOrUpdate(pessoaFisica);

            List<EnderecoCliente> modifiedEnderecos = pessoaFisica.EnderecosCliente.Except(addedEnderecos, e => e.EnderecoClienteId).ToList<EnderecoCliente>();
            List<ContatoCliente> modifiedContatos = pessoaFisica.ContatosCliente.Except(addedContatos, c => c.ContatoClienteId).ToList<ContatoCliente>();

            foreach (var item in modifiedEnderecos)
            {
                Db.Set<EnderecoCliente>().AddOrUpdate(item);
            }

            foreach (var item in modifiedContatos)
            {
                Db.Set<ContatoCliente>().AddOrUpdate(item);
            }

            return existingPessoaFisica;
        }

        public override PessoaFisica ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PessoaFisicaProcedures.ObterPorId.GetDescription(),
                new { pfId = id },
                commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Segmento), "SegmentoId");

            PessoaFisica pessoaFisica = (AutoMapper.MapDynamic<PessoaFisica>(query, false) as IEnumerable<PessoaFisica>).FirstOrDefault();

            return pessoaFisica;
        }

        public override IEnumerable<PessoaFisica> ObterTodos()
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaFisica> retornoCliente;

            retornoCliente = cn.Query<PessoaFisica>(PessoaFisicaProcedures.ObterTodos.GetDescription(),
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaFisica> ObterPorCPF(string cpf)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaFisica> retornoCliente;

            retornoCliente = cn.Query<PessoaFisica>(PessoaFisicaProcedures.ObterPorCPF.GetDescription(),
                new { cpf = cpf },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaFisica> ObterPorNome(string nome)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaFisica> retornoCliente;

            retornoCliente = cn.Query<PessoaFisica>(PessoaFisicaProcedures.ObterPorNome.GetDescription(),
                new { nome = nome },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaFisica> ObterPorSegmento(Guid segmentoId)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaFisica> retornoCliente;

            retornoCliente = cn.Query<PessoaFisica>(PessoaFisicaProcedures.ObterPorSegmento.GetDescription(),
                new { segmentoId = segmentoId },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }
    }
}
