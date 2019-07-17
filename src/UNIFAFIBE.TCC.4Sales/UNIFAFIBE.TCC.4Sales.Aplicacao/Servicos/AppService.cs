using UNIFAFIBE.TCC._4Sales.Persistencia.UnitOfWork;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos
{
    public class AppService
    {

        private readonly IUnitOfWork _uow;

        public AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void Commit()
        {
            _uow.Commit();
        }
    }
}
