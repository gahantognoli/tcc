using System.Data.Entity;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto() : base("4Sales")
        {

        }
    }
}
