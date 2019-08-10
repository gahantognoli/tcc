using System;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Web.Configuration;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Transversal.EnvioEmail
{
    public class EmailService : IEmailService
    {
        public void Enviar(Email email)
        {
            try
            {
                Configuration configurationFile = WebConfigurationManager.OpenWebConfiguration(null);
                MailSettingsSectionGroup mailSettings = configurationFile.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;

                if (mailSettings != null)
                {
                    string host = "smtp.gmail.com";
                    string password = "Senha@123";
                    string username = "contato.4sales@gmail.com";
                    int port = 587;
                    //  string host = mailSettings.Smtp.Network.Host;
                    //string password = mailSettings.Smtp.Network.Password;
                    //string username = mailSettings.Smtp.Network.UserName;
                    //int port = mailSettings.Smtp.Network.Port;

                    foreach (var item in email.Destinatios)
                    {
                        MailMessage emailMessage = new MailMessage(email.Rementente, item, email.Assunto, 
                            email.Mensagem);

                        if (email.Anexos != null)
                        {
                            foreach (string anexo in email.Anexos)
                            {
                                Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                                emailMessage.Attachments.Add(anexado);
                            }
                        }

                        SmtpClient smtp = new SmtpClient(host, port);
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        NetworkCredential credenciais = new NetworkCredential(username, password);
                        smtp.Credentials = credenciais;

                        smtp.Send(emailMessage);
                    }
                }
                
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
