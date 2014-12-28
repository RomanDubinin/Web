using System.Collections.Generic;

namespace LessonProject.Model.PageConfiguration
{
	public class MessagesPageConfig : PageConfig
	{
		public string Topic { get; set; }
		public IList<Message> Messages { get; set; }
	}
}
