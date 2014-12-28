using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
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
			if(!statement.IsEmpty())
			{
				var message = new Message { Statement = statement, User = CurrentUser, TopicId = UserContext.CurrentTopic };
				Repository.CreateMessage(message);
			}

			return View(CreatePageConfig());
		}

		private MessagesPageConfig CreatePageConfig()
		{
			var messages = Repository.Messages.Where(m => m.TopicId == UserContext.CurrentTopic).ToList();
			var topicName = Repository.Topics.First(m => m.Id == UserContext.CurrentTopic).Name;
			var pageConf = new MessagesPageConfig
			{
				Topic = topicName,
				Messages = messages,
				RightToAccess = UserRights
			};
			return pageConf;
		}
	}
}