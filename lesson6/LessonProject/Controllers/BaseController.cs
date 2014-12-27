using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LessonProject.Global.Auth;
using LessonProject.Global.UserContext;
using LessonProject.Mappers;
using LessonProject.Model;
using Ninject;

namespace LessonProject.Controllers
{
    public abstract class BaseController : Controller
    {
        [Inject]
        public IRepository Repository { get; set; }

        [Inject]
        public IMapper ModelMapper { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }

		[Inject]
		public IUserContext UserContext { get; set; }

        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }
    }
}
