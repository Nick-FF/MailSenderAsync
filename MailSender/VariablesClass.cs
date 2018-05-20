using System.Collections.Generic;
using PasswordDLL;

namespace MailSender
{
	public static class VariablesClass
	{
		public static Dictionary<string, string> Senders => _dicSenders;

		private static readonly Dictionary<string, string> _dicSenders = new Dictionary<string, string>()
		{
			{ "79257443993@yandex.ru",CodePassword.GetPassword("1234l;i") },
			{ "sok74@yandex.ru",CodePassword.GetPassword(";liq34tjk") }
		};

	}
}