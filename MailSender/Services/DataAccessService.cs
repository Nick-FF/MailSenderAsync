using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace MailSender.Services
{
	public interface IDataAccessService
	{
		ObservableCollection<Email> GetEmails();
		int CreateEmail(Email email);
	}

	public class DataAccessService : IDataAccessService
	{
		private readonly EmailsDataContext _context;

		public DataAccessService()
		{
			_context = new EmailsDataContext();
		}

		public ObservableCollection<Email> GetEmails()
		{
			var emails = new ObservableCollection<Email>();
			foreach (var item in _context.Email)
			{
				emails.Add(item);
			}

			return emails;
		}

		public int CreateEmail(Email email)
		{
			_context.Email.InsertOnSubmit(email);
			_context.SubmitChanges();
			return email.Id;
		}
	}
}