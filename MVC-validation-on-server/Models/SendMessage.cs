using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace MVC_validation_on_server.Models
{
    public static class SendMessage
    {
        public static void SendMessageAsync(MailAddress from, MailAddress to, string body, string subject, string host, int port, string login, string password)
        {
            try
            {
                Task t = new Task(() =>
                 {
                    // создаем объект сообщения
                    MailMessage m = new MailMessage(from, to);
                    // тема письма
                    m.Subject = subject;
                    // текст письма
                    m.Body = body;
                     SmtpClient smtp = new SmtpClient(host, port);
                    // логин и пароль
                    smtp.Credentials = new NetworkCredential(login, password);
                     smtp.EnableSsl = true;
                     smtp.Send(m);
                 });
                t.Start();

            }
            catch (Exception e)
            {

                // ignored
            }
        }

    }
}