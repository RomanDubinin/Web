using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum
{
	class Program
	{
		private static ForumDbEntities db;
		private static Role simpleUser;
		private static Role superUser;

		private static Role CreateRole(string roleName)
		{
			var role = new Role { RoleName = roleName };
			db.Roles.Add(role);
			db.SaveChanges();
			return role;
		}

		private static User CreateUser(string userName, ICollection<Role> roles)
		{
			var user = new User {UserName = userName, Roles = roles};
			db.Users.Add(user);
			db.SaveChanges();
			return user;
		}

		private static Conversation CreateConversation(string theme, User creator)
		{
			var conversation = new Conversation {Theme = theme, Creator = creator};
			db.Conversations.Add(conversation);
			db.SaveChanges();
			return conversation;
		}

		private static Message createMessage(string statement, User user, Conversation conversation)
		{
			var message = new Message {User = user, Conversation = conversation, DateTime = DateTime.Now, Statement = statement};
			db.Messages.Add(message);
			db.SaveChanges();
			return message;
		}

		static void Main(string[] args)
		{
			using (db = new ForumDbEntities())
			{
				//CreateRole("SimpleUser");
				//CreateRole("SuperUser");
				simpleUser = db.Roles.Find(1);
				superUser = db.Roles.Find(2);

				var userRoma = CreateUser("user1", new List<Role> {simpleUser});

				var conv = CreateConversation("things", userRoma);

				createMessage("Hello", userRoma, conv);

				//var query = from b in db.Users
				//			orderby b.UserName
				//			select b;

				//Console.WriteLine("All blogs in the database:");
				//foreach (var item in query)
				//{
				//	Console.WriteLine(item.UserName + " has id " + item.UserId + ": ");
				//	foreach (var currenrRole in item.Roles)
				//	{
				//		Console.WriteLine(currenrRole.RoleName);
				//	}
				//	Console.WriteLine("=========");
				//}
			}
		}
	}
}
