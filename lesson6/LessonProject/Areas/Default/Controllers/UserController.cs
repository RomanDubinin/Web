using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web.Mvc;
using LessonProject.Model;
using LessonProject.Models.ViewModels;
using LessonProject.Tools;

namespace LessonProject.Areas.Default.Controllers
{
	public class UserController : DefaultController
	{
		public ActionResult Index()
		{
			List<User> users = Repository.Users.ToList();
			return View(users);
		}

		[HttpGet]
		public ActionResult Register()
		{
			var newUserView = new UserView();
			return View(newUserView);
		}

		[HttpPost]
		public ActionResult Register(UserView userView)
		{
			if(userView.Captcha != (string) Session[CaptchaImage.CaptchaValueKey])
			{
				ModelState.AddModelError("Captcha", "Текст с картинки введен неверно");
			}
			bool anyUser = Repository.Users.Any(p => string.Compare(p.Email, userView.Email) == 0);
			if(anyUser)
			{
				ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
			}

			if(ModelState.IsValid)
			{
				var user = (User) ModelMapper.Map(userView, typeof(UserView), typeof(User));

				Repository.CreateUser(user);
				var userRole = new UserRole {UserId = user.Id, RoleId = 1};
				Repository.CreateUserRole(userRole);
				return RedirectToAction("Index");
			}
			return View(userView);
		}

		public void Captcha()
		{
			Session[CaptchaImage.CaptchaValueKey] = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
			var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Arial");

			// Change the response headers to output a JPEG image.
			Response.Clear();
			Response.ContentType = "image/jpeg";

			// Write the image to the response stream in JPEG format.
			ci.Image.Save(Response.OutputStream, ImageFormat.Jpeg);

			// Dispose of the CAPTCHA image object.
			ci.Dispose();
			
		}
	}
}
