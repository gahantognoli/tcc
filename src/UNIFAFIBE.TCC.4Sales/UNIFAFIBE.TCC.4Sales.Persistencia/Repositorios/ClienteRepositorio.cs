using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente>
    {
        public ClienteRepositorio(TCC_Contexto contexto) : base(contexto)
        {
        }
    }
}
