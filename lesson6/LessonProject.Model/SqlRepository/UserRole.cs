using System.Linq;

namespace LessonProject.Model.SqlRepository
{
	public partial class SqlRepository
	{
		public IQueryable<UserRole> UserRoles
		{
			get { return Db.UserRoles; }
		}

		public bool CreateUserRole(UserRole instance)
		{
			if(instance.Id == 0)
			{
				Db.UserRoles.InsertOnSubmit(instance);
				Db.UserRoles.Context.SubmitChanges();
				return true;
			}

			return false;
		}

		public bool UpdateUserRole(UserRole instance)
		{
			UserRole cache = Db.UserRoles.FirstOrDefault(p => p.Id == instance.Id);
			if(cache != null)
			{
				cache.Role = instance.Role;
				cache.User = instance.User;
				Db.UserRoles.Context.SubmitChanges();
				return true;
			}

			return false;
		}

		public bool RemoveUserRole(int idUserRole)
		{
			UserRole instance = Db.UserRoles.FirstOrDefault(p => p.Id == idUserRole);
			if(instance != null)
			{
				Db.UserRoles.DeleteOnSubmit(instance);
				Db.UserRoles.Context.SubmitChanges();
				return true;
			}

			return false;
		}
	}
}
