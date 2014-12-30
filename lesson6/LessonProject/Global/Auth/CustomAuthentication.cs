using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using LessonProject.Model;
using Ninject;

namespace LessonProject.Global.Auth
{
	public class CustomAuthentication : IAuthentication
	{
		private const string cookieName = "__AUTH_COOKIE";

		[Inject]
		public IRepository Repository { get; set; }

		#region IAuthentication Members

		private IPrincipal _currentUser;

		public User Login(string userName, string password, bool isPersistent)
		{
			var retUser = Repository.Login(userName, password);
			if(retUser != null)
			{
				CreateCookie(userName, isPersistent);
			}
			return retUser;
		}

		public User Login(string userName)
		{
			var retUser = Repository.Users.FirstOrDefault(p => string.Compare(p.Email, userName, true) == 0);
			if(retUser != null)
			{
				CreateCookie(userName);
			}
			return retUser;
		}

		public void LogOut()
		{
			var httpCookie = HttpContext.Response.Cookies[cookieName];
			if(httpCookie != null)
			{
				httpCookie.Value = string.Empty;
			}
		}

		public IPrincipal CurrentUser
		{
			get
			{
				if(_currentUser == null)
				{
					try
					{
						HttpCookie authCookie = HttpContext.Request.Cookies.Get(cookieName);
						if(authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
						{
							FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
							_currentUser = new UserProvider(ticket.Name, Repository);
						}
						else
						{
							_currentUser = new UserProvider(null, null);
						}
					}
					catch(Exception ex)
					{
						_currentUser = new UserProvider(null, null);
					}
				}
				return _currentUser;
			}
		}

		private void CreateCookie(string userName, bool isPersistent = false)
		{
			var ticket = new FormsAuthenticationTicket(
				1,
				userName,
				DateTime.Now,
				DateTime.Now.Add(FormsAuthentication.Timeout),
				isPersistent,
				string.Empty,
				FormsAuthentication.FormsCookiePath);

			// Encrypt the ticket.
			string encTicket = FormsAuthentication.Encrypt(ticket);

			// Create the cookie.
			var authCookie = new HttpCookie(cookieName)
			{
				Value = encTicket,
				Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
			};
			HttpContext.Response.Cookies.Set(authCookie);
		}

		#endregion

		public HttpContext HttpContext { get; set; }
	}
}