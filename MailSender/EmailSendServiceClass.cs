using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
	public class EmailSendServiceClass
	{
		#region vars

		private readonly string _strLogin; // email, c которого будет рассылаться почта
		private readonly string _strPassword; // пароль к email, с которого будет рассылаться почта
		private readonly string _strSmtp = "smtp.yandex.ru"; // smtp - server
		private readonly int _iSmtpPort = 25; // порт для smtp-server
		public string Body { get; set; }
		public string Subject { get; set; }

		#endregion

		public EmailSendServiceClass(string sLogin, string sPassword)
		{
			_strLogin = sLogin;
			_strPassword = sPassword;
		}
	

		private void SendMail(string mail, string name) // Отправка email конкретному адресату
		{
			using (var mm = new MailMessage(_strLogin, mail))
			{
				mm.Subject = Subject;
				mm.Body = Body;
				mm.IsBodyHtml = false;
				SmtpClient sc = new SmtpClient(_strSmtp, _iSmtpPort)
				{
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential(_strLogin, _strPassword)
				};
				try
				{
					sc.Send(mm);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Невозможно отправить письмо {ex.Message}");
				}
			}
		}

		public void SendMails(ObservableCollection<Email> emails)
		{
			foreach (Email email in emails)
			{
				Task.Factory.StartNew(()=> SendMail(email.Value, email.Name));
			}
		}

        //        public void SendMails1(ObservableCollection<Email> emails)
        //        { 
        //​               Parallel.ForEach(emails, SendMail);
        //        }

        private Task SendMailasync(string mail, string name) // Отправка email конкретному адресату
        {
            return Task.Run(() =>
            {
                using (var mm = new MailMessage(_strLogin, mail))
                {
                    mm.Subject = Subject;
                    mm.Body = Body;
                    mm.IsBodyHtml = false;
                    SmtpClient sc = new SmtpClient(_strSmtp, _iSmtpPort)
                    {
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(_strLogin, _strPassword)
                    };
                    try
                    {
                        sc.Send(mm);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Невозможно отправить письмо {ex.Message}");
                    }
                }
            });
           
        }



        public async void asyncSendMails(ObservableCollection<Email> emails)
        {
            foreach (Email email in emails)
            {
                await SendMailasync(email.Value, email.Name);
            }
        }

    }
}