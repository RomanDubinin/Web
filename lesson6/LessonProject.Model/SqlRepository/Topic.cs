using System;
using System.Linq;

namespace LessonProject.Model.SqlRepository
{
	public partial class SqlRepository
	{
		public IQueryable<Topic> Topics
		{
			get { return Db.Topics; }
		}

		public bool CreateTopic(Topic instance)
		{
			if(instance.Id == 0)
			{
				instance.AddedDate = DateTime.Now;
				Db.Topics.InsertOnSubmit(instance);
				Db.Topics.Context.SubmitChanges();
				return true;
			}

			return false;
		}

		public bool UpdateTopic(Topic instance)
		{
			Topic cache = Db.Topics.FirstOrDefault(p => p.Id == instance.Id);
			if(cache != null)
			{
				cache.Name = instance.Name;
				Db.Topics.Context.SubmitChanges();
				return true;
			}

			return false;
		}

		public bool RemoveTopic(int idTopic)
		{
			Topic instance = Db.Topics.FirstOrDefault(p => p.Id == idTopic);
			if(instance != null)
			{
				Db.Topics.DeleteOnSubmit(instance);
				Db.Topics.Context.SubmitChanges();
				return true;
			}

			return false;
		}

		public Topic GetTopic(int topicId)
		{
			return Db.Topics.FirstOrDefault(p => p.Id == topicId);
		}
	}
}
