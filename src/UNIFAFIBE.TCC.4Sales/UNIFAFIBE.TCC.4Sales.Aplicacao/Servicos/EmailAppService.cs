using AutoMapper;
using UNIFAFIBE.TCC._4Sales.Aplicacao.Interfaces.Servicos;
using UNIFAFIBE.TCC._4Sales.Aplicacao.ViewModel;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Aplicacao.Servicos
{
    public class EmailAppService : IEmailAppService
    {
        private readonly IEmailService _emailService;

        public EmailAppService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public bool Enviar(EmailViewModel email)
        {
            return _emailService.Enviar(Mapper.Map<Email>(email));
        }
    }
}
