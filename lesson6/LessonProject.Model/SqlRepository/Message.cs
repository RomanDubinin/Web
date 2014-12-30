using System;
using System.Linq;

namespace LessonProject.Model.SqlRepository
{
	public partial class SqlRepository
	{
		public IQueryable<Message> Messages
		{
			get { return Db.Messages; }
		}

		public bool CreateMessage(Message instance)
		{
			if (instance.Id == 0)
			{
				instance.AddedDate = DateTime.Now;
				Db.Messages.InsertOnSubmit(instance);
				Db.Messages.Context.SubmitChanges();
				return true;
			}

			return false;
		}

		public bool RemoveMessage(int idMessage)
		{
			Message instance = Db.Messages.FirstOrDefault(p => p.Id == idMessage);
			if (instance != null)
			{
				Db.Messages.DeleteOnSubmit(instance);
				Db.Messages.Context.SubmitChanges();
				return true;
			}

			return false;
		}

		public Message GetMessage(int idMessage)
		{
			return Db.Messages.FirstOrDefault(p => p.Id == idMessage);
		}
	}
}
