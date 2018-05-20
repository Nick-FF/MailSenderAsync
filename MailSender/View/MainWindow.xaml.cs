using System;
using System.Windows;
using MailSender.ViewModel;

namespace MailSender.View
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly ViewModelLocator _locator;
		public MainWindow()
		{
			InitializeComponent();

			cbSenderSelect.ItemsSource = VariablesClass.Senders;
			cbSenderSelect.DisplayMemberPath = "Key";
			cbSenderSelect.SelectedValuePath = "Value";
			cbSenderSelect.SelectedIndex = 0;

			//cbSmtpSelect.ItemsSource = VariablesClass.SmtpServers;
			//cbSmtpSelect.DisplayMemberPath = "Key";
			//cbSmtpSelect.SelectedValuePath = "Value";
			//cbSmtpSelect.SelectedIndex = 0;

			_locator = (ViewModelLocator)FindResource("Locator");
		}

		private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
		{
			var strLogin = cbSenderSelect.Text;
			var strPassword = cbSenderSelect.SelectedValue.ToString();
			if (string.IsNullOrEmpty(strLogin))
			{
				MessageBox.Show("Выберите отправителя");
				return;
			}
			if (string.IsNullOrEmpty(strPassword))
			{
				MessageBox.Show("Укажите пароль отправителя");
				return;
			}
			var emailSender = new EmailSendServiceClass(strLogin, strPassword);

			emailSender.SendMails(_locator.Main.Emails);
		}

		private void btnSend_Click(object sender, RoutedEventArgs e)
		{
			var sc = new SchedulerClass();
			var tsSendTime = sc.GetSendTime(tbTimePicker.Text);
			if (tsSendTime == new TimeSpan())
			{
				MessageBox.Show("Некорректный формат даты");
				return;
			}
			var dtSendDateTime = (cldSchedulDateTimes.SelectedDate ??
									   DateTime.Today).Add(tsSendTime);
			if (dtSendDateTime < DateTime.Now)
			{
				MessageBox.Show("Дата и время отправки писем не могут быть раньше, чем настоящее время");
				return;
			}
			var emailSender = new EmailSendServiceClass(cbSenderSelect.Text,
				cbSenderSelect.SelectedValue.ToString());

			sc.SendEmails(dtSendDateTime, emailSender, _locator.Main.Emails);
		}


		private void btnSendEmail_Click(object sender, RoutedEventArgs e)
		{
			tabControl.SelectedItem = tabPlanner;
		}
	}
}
