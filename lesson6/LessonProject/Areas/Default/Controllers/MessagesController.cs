using System.Linq;
using System.Web.Mvc;
using LessonProject.Model;
using LessonProject.Model.PageConfiguration;

namespace LessonProject.Areas.Default.Controllers
{
	public class MessagesController : DefaultController
	{
		//
		// GET: /Default/Messages/

		public ActionResult Index(int topicId)
		{
			UserContext.CurrentTopic = topicId;
			
			return View(CreatePageConfig());
		}

		[HttpPost]
		public ActionResult Index(string statement)
		{
			var message = new Message { Statement = statement, User = CurrentUser, TopicId = UserContext.CurrentTopic };
			Repository.CreateMessage(message);
			
			return View(CreatePageConfig());
		}

		private MessagesPageConfig CreatePageConfig()
		{
			var messages = Repository.Messages.Where(m => m.TopicId == UserContext.CurrentTopic).ToList();
			var pageConf = new MessagesPageConfig
			{
				Topic = messages.First().Topic.Name,
				Messages = messages,
				RightToAccess = UserRights
			};
			return pageConf;
		}
	}
}