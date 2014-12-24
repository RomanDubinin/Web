using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RSDNMag.Forum
{
	class TopicPost : Post
	{
		public List<Post> ChildNodes { get; private set; }

		public TopicPost(string source, int id) : base(source, id)
		{
			ChildNodes = new List<Post>();
		}

		public override string ToString()
		{
			var result = new StringBuilder();

			foreach (var child in ChildNodes)
				result.Append(child);

			return base.ToString() + result + "</DIV>";
		}

		public ArrayList GetEnumeration()
		{
			ArrayList enumeration = new ArrayList();
			enumeration.AddRange(ChildNodes);

			foreach (var o in ChildNodes)
			{
				if (o.GetType() == typeof(TopicPost))
					enumeration.AddRange(((TopicPost)o).GetEnumeration());
			}

			return enumeration;
		}
	}
}