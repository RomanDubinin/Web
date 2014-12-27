using System.Linq;
using System.Web.Mvc;
using LessonProject.Model;

namespace LessonProject.Areas.Default.Controllers
{
	public class MessagesController : DefaultController
	{
		//
		// GET: /Default/Messages/

		public ActionResult Index(int topicId)
		{
			UserContext.CurrentTopic = topicId;
			return View(Repository.Messages.Where(m => m.TopicId == UserContext.CurrentTopic).ToList());
		}

		[HttpPost]
		public ActionResult Index(string statement)
		{
			var message = new Message { Statement = statement, User = CurrentUser, TopicId = UserContext.CurrentTopic };
			Repository.CreateMessage(message);
			return View(Repository.Messages.Where(m => m.TopicId == UserContext.CurrentTopic).ToList());
		}
	}
}