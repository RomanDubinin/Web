using Ninject;

namespace LessonProject.Model.SqlRepository
{
	public partial class SqlRepository : IRepository
	{
		[Inject]
		public LessonProjectDbDataContext Db { get; set; }
	}
}