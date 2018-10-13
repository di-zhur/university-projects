using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Jackdaw.Infrastructure
{
    public static class Email
    {
        private const string _emailFrom = "62rgddt@gmail.com";
        private const string _password = "qwerty123qwerty";

        public static void Send(List<EmailEntity> emailData)
        {
            foreach (var item in emailData)
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                var from = new MailAddress(_emailFrom);
                // кому отправляем
                var to = new MailAddress(item.Email);
                // создаем объект сообщения
                var m = new MailMessage(from, to);
                // тема письма
                m.Subject = $"Результат конкурса {item.Contest}";
                // текст письма
                m.Body = $"<h3>Уважаемый {item.Fio} вы заняли {item.Place} место!</h3>";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential(_emailFrom, _password);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Send(m);
            }
        }
    }

    public class EmailEntity
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// ФИО Участника
        /// </summary>
        public string Fio { get; set; }
        /// <summary>
        /// Конкурс
        /// </summary>
        public string Contest { get; set; }
        /// <summary>
        /// Место
        /// </summary>
        public string Place { get; set; }
    }
}

