namespace RSDNMag.Forum
{
	class Post
	{
		public string Source { get; private set; }
		public int ID { get; private set; }

		public Post(string source, int id)
		{
			Source = source;
			ID = id;
		}

		public override string ToString()
		{
			return Source;
		}
	}
}