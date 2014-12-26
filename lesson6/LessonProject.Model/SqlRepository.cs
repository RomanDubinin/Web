using Ninject;

namespace LessonProject.Model
{
	public partial class SqlRepository : IRepository
	{
		[Inject]
		public LessonProjectDbDataContext Db { get; set; }
	}
}