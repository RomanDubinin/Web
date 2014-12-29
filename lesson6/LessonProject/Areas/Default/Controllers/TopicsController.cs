using System.Linq;
using System.Web.Mvc;
using LessonProject.Model;
using LessonProject.Model.PageConfiguration;

namespace LessonProject.Areas.Default.Controllers
{
	public class TopicsController : DefaultController
	{
		//
		// GET: /Default/Themes/

		public ActionResult Index()
		{
			return View(CreateConfig());
		}

		[HttpPost]
		public ActionResult Index(string topicName, int topicId)
		{
			if(!string.IsNullOrEmpty(topicName))
			{
				var topic = new Topic {Name = topicName, UserId = CurrentUser.Id};
				Repository.CreateTopic(topic);
			}
			if(topicId != 0)
			{
				foreach(var message in Repository.Messages.Where(m => m.TopicId == topicId))
				{
					Repository.RemoveMessage(message.Id);
				}
				Repository.RemoveTopic(topicId);
			}
			return View(CreateConfig());
		}

		private TopicsPageConfig CreateConfig()
		{
			var topics = Repository.Topics.ToList();
			var pageConf = new TopicsPageConfig
			{
				Topics = topics,
				RightToAccess = UserRights
			};
			return pageConf;
		}
	}
}