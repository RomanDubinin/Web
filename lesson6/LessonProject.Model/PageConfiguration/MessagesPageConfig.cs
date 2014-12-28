using System.Collections.Generic;

namespace LessonProject.Model.PageConfiguration
{
	public class MessagesPageConfig
	{
		public string Topic { get; set; }
		public IList<Message> Messages { get; set; }
		public int RightToAccess { get; set; }
	}
}
