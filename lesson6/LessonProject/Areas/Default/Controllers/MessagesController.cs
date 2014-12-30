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

		//from topics
		public ActionResult Index(int topicId)
		{
			UserContext.CurrentTopic = topicId;
			
			return View(CreatePageConfig());
		}

		//after adding or deleting message
		[HttpPost]
		public ActionResult Index(string statement, int messageId)
		{
			if(!string.IsNullOrEmpty(statement))
			{
				var message = new Message { Statement = statement, User = CurrentUser, TopicId = UserContext.CurrentTopic };
				Repository.CreateMessage(message);
			}
			if(messageId != 0)
			{
				Repository.RemoveMessage(messageId);
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