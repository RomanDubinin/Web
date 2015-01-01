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
		public ActionResult CreateTopic(string topicName)
		{
			if(!string.IsNullOrEmpty(topicName))
			{
				var topic = new Topic {Name = topicName, UserId = CurrentUser.Id};
				Repository.CreateTopic(topic);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult DeleteTopic(int topicId)
		{
			foreach(var message in Repository.Messages.Where(m => m.TopicId == topicId))
			{
				Repository.RemoveMessage(message.Id);
			}
			Repository.RemoveTopic(topicId);
			return RedirectToAction("Index");
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