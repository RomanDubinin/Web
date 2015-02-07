using System;
using System.Linq;

namespace LessonProject.Model
{
	/// <summary>
	/// дополнение к юзеру из бд
	/// </summary>
	public partial class User
	{
		public string ConfirmPassword { get; set; }

		public string Captcha { get; set; }

		public static string GetActivateUrl()
		{
			return Guid.NewGuid().ToString("N");
		}

		public bool InRoles(string roles)
		{
			if(string.IsNullOrWhiteSpace(roles))
			{
				return false;
			}

			string[] rolesArray = roles.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
			foreach(string role in rolesArray)
			{
				bool hasRole = UserRoles.Any(p => string.Compare(p.Role.Code.ToString(), role, true) == 0);
				if(hasRole)
				{
					return true;
				}
			}
			return false;
		}
	}
}