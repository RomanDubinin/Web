using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new ForumDbEntities())
			{
				//var role = new Role{RoleId = 0, RoleName = "lox"};
				var user = new User {UserName = "name1", Roles = {db.Roles.Find(1)}};
				//
				db.Users.Add(user);
				//db.Roles.Add(role);
				db.SaveChanges();

				var query = from b in db.Users
							orderby b.UserName
							select b;

				Console.WriteLine("All blogs in the database:");
				foreach (var item in query)
				{
					Console.WriteLine(item.UserName + ": ");
					foreach (var currenrRole in item.Roles)
					{
						Console.WriteLine(currenrRole.RoleName);
					}
					Console.WriteLine("=========");
				}
			}
		}
	}
}
