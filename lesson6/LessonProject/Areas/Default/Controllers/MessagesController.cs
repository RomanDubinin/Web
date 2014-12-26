using System.Linq;
using System.Web.Mvc;

namespace LessonProject.Areas.Default.Controllers
{
	public class MessagesController : DefaultController
    {
        //
        // GET: /Default/Messages/

		public ActionResult Index(int topicId)
        {
			return View(Repository.Messages.Where(m => m.TopicId == topicId).ToList());
        }

    }
}
