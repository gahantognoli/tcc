using Dapper;
using Slapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Infra.Helpers;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;
using UNIFAFIBE.TCC._4Sales.Persistencia.Procedures;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class PessoaJuridicaRepositorio : Repositorio<PessoaJuridica>, IPessoaJuridicaRepositorio
    {
        private readonly IEnderecoClienteRepositorio _enderecoClienteRepositorio;
        private readonly IContatoClienteRepositorio _contatoClienteRepositorio;

        public PessoaJuridicaRepositorio(TCC_Contexto contexto, IEnderecoClienteRepositorio enderecoClienteRepositorio,
            IContatoClienteRepositorio contatoClienteRepositorio) : base(contexto)
        {
            _enderecoClienteRepositorio = enderecoClienteRepositorio;
            _contatoClienteRepositorio = contatoClienteRepositorio;
        }

        public override PessoaJuridica Atualizar(PessoaJuridica pessoaJuridica)
        {
            PessoaJuridica existingPessoaJuridica = Db.PessoasJuridicas.Include("ContatosCliente")
               .Include("EnderecosCliente")
               .Where(e => e.ClienteId == pessoaJuridica.ClienteId).FirstOrDefault<PessoaJuridica>();

            List<EnderecoCliente> deletedEnderecos = existingPessoaJuridica.EnderecosCliente.Except(pessoaJuridica.EnderecosCliente, e => e.EnderecoClienteId).ToList<EnderecoCliente>();
            List<ContatoCliente> deletedContatos = existingPessoaJuridica.ContatosCliente.Except(pessoaJuridica.ContatosCliente, c => c.ContatoClienteId).ToList<ContatoCliente>();

            List<EnderecoCliente> addedEnderecos = pessoaJuridica.EnderecosCliente.Except(existingPessoaJuridica.EnderecosCliente, e => e.EnderecoClienteId).ToList<EnderecoCliente>();
            List<ContatoCliente> addedContatos = pessoaJuridica.ContatosCliente.Except(existingPessoaJuridica.ContatosCliente, c => c.ContatoClienteId).ToList<ContatoCliente>();

            if (deletedEnderecos.Count() > 0 || deletedContatos.Count() > 0)
            {
                deletedEnderecos.ForEach(e => { existingPessoaJuridica.EnderecosCliente.Remove(e); _enderecoClienteRepositorio.Remover(e.EnderecoClienteId); });
                deletedContatos.ForEach(c => { existingPessoaJuridica.ContatosCliente.Remove(c); _contatoClienteRepositorio.Remover(c.ContatoClienteId); });
            }

            if (addedContatos.Count() > 0 || addedEnderecos.Count() > 0)
            {
                foreach (ContatoCliente c in addedContatos)
                {
                    c.ClienteId = pessoaJuridica.ClienteId;
                    if (Db.Entry(c).State == System.Data.Entity.EntityState.Detached)
                    {
                        Db.ContatosClientes.Attach(c);
                    }

                    _contatoClienteRepositorio.Adicionar(c);
                }

                foreach (EnderecoCliente e in addedEnderecos)
                {
                    e.ClienteId = pessoaJuridica.ClienteId;
                    if (Db.Entry(e).State == System.Data.Entity.EntityState.Detached)
                    {
                        Db.EnderecosClientes.Attach(e);
                    }

                    _enderecoClienteRepositorio.Adicionar(e);
                }
            }

            Db.Set<PessoaJuridica>().AddOrUpdate(pessoaJuridica);

            List<EnderecoCliente> modifiedEnderecos = pessoaJuridica.EnderecosCliente.Except(addedEnderecos, e => e.EnderecoClienteId).ToList<EnderecoCliente>();
            List<ContatoCliente> modifiedContatos = pessoaJuridica.ContatosCliente.Except(addedContatos, c => c.ContatoClienteId).ToList<ContatoCliente>();

            foreach (var item in modifiedEnderecos)
            {
                Db.Set<EnderecoCliente>().AddOrUpdate(item);
            }

            foreach (var item in modifiedContatos)
            {
                Db.Set<ContatoCliente>().AddOrUpdate(item);
            }

            return existingPessoaJuridica;
        }

        public override PessoaJuridica ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;

            IEnumerable<dynamic> query = cn.Query<dynamic>(PessoaJuridicaProcedures.ObterPorId.GetDescription(),
                new { pjId = id },
                commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Segmento), "SegmentoId");

            PessoaJuridica pessoaJuridica = (AutoMapper.MapDynamic<PessoaJuridica>(query, false) as IEnumerable<PessoaJuridica>).FirstOrDefault();

            return pessoaJuridica;
        }

        public override IEnumerable<PessoaJuridica> ObterTodos()
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaJuridica> retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterTodos.GetDescription(),
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaJuridica> ObterPorCPNJ(string cnpj)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaJuridica> retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterPorCNPJ.GetDescription(),
                new { cnpj = cnpj },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaJuridica> ObterPorInscricaoEstadual(string inscricaoEstadual)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaJuridica> retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterPorInscricaoEstadual.GetDescription(),
                new { inscricaoEstadual = inscricaoEstadual },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaJuridica> ObterPorNomeFantasia(string nomeFantasia)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaJuridica> retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterPorNomeFantasia.GetDescription(),
                new { nomeFantasia = nomeFantasia },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }

        public IEnumerable<PessoaJuridica> ObterPorRazaoSocial(string razaoSocial)
        {
            var cn = Db.Database.Connection;
            IEnumerable<PessoaJuridica> retornoCliente;

            retornoCliente = cn.Query<PessoaJuridica>(PessoaJuridicaProcedures.ObterPorRazaoSocial.GetDescription(),
                new { razaoSocial = razaoSocial },
                commandType: CommandType.StoredProcedure);

            return retornoCliente;
        }
    }
}
