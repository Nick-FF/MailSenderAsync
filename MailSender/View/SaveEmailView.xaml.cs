using System.Windows.Controls;

namespace MailSender.View
{
	/// <summary>
	/// Логика взаимодействия для SaveEmailView.xaml
	/// </summary>
	public partial class SaveEmailView : UserControl
	{
		public SaveEmailView()
		{
			InitializeComponent();
		}

		private void TextBox_Error(object sender, ValidationErrorEventArgs e)
		{
			((Control)sender).ToolTip = e.Action == ValidationErrorEventAction.Added ? e.Error.ErrorContent.ToString() : "";
		}
	}
}
