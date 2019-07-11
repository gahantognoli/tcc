using System.Threading.Tasks;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
