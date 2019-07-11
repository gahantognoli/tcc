using UNIFAFIBE.TCC._4Sales.Persistencia.Contexto;

namespace UNIFAFIBE.TCC._4Sales.Persistencia.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TCC_Contexto _contexto;
        private bool _disposed;

        public UnitOfWork(TCC_Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
