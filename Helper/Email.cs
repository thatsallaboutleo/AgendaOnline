using AgendaOnline.Helper.Interface;
using System.Net;
using System.Net.Mail;

namespace AgendaOnline.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _config;

        public Email(IConfiguration config)
        {
            _config = config;
        }

        public bool Enviar(string email, string assunto, string msg)
        {
            try
            {
                string host = _config.GetValue<string>("SMTP:Host");
                string nome = _config.GetValue<string>("SMTP:Nome");
                string username = _config.GetValue<string>("SMTP:UserName");
                string senha = _config.GetValue<string>("SMTP:Senha");
                int porta = _config.GetValue<int>("SMTP:Porta");

                MailMessage mm = new MailMessage()
                {
                    From = new MailAddress(username, nome)
                };

                mm.To.Add(email);
                mm.Subject = assunto;
                mm.Body = msg;
                mm.IsBodyHtml = true;
                mm.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(username, senha);
                    smtp.EnableSsl = true;
                    smtp.Send(mm);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
