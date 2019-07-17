using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Servicos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoService(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public Produto Adicionar(Produto produto)
        {
            if (!produto.EhValido())
                return produto;

            return _produtoRepositorio.Adicionar(produto);
        }

        public Produto Atualizar(Produto produto)
        {
            if (!produto.EhValido())
                return produto;

            return _produtoRepositorio.Atualizar(produto);
        }

        public void Dispose()
        {
            _produtoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Produto> ObterPorFaixaDePreco(decimal valorInicial, decimal valorFinal, Guid representadaId)
        {
            return _produtoRepositorio.ObterPorFaixaDePreco(valorInicial, valorFinal, representadaId);
        }

        public Produto ObterPorId(Guid id)
        {
            return _produtoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Produto> ObterPorNome(string nome, Guid representadaId)
        {
            return _produtoRepositorio.ObterPorNome(nome, representadaId);
        }

        public IEnumerable<Produto> ObterTodos(Guid representadaId)
        {
            return _produtoRepositorio.ObterTodos(representadaId);
        }

        public void Remover(Guid id)
        {
            _produtoRepositorio.Remover(id);
        }
    }
}
