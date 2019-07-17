using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos
{
    public interface IEmailAppService
    {
        bool Enviar(EmailViewModel email);
    }
}
