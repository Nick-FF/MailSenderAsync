using System;
using System.Windows.Controls;

namespace MailSender
{
	public class DemoValidator : ValidationRule
	{
		public override ValidationResult Validate(object value,
			System.Globalization.CultureInfo cultureInfo)
		{
			int IntValue = 0;
			ValidationResult result = null;
			try
			{
				IntValue = Convert.ToInt16(value);
			}
			catch (Exception)
			{
				return new ValidationResult(false, "Введите число");
			}
			if (IntValue < 0) return new ValidationResult(false, "Введите число больше 0");
			return new ValidationResult(true, null);
		}
	}
}