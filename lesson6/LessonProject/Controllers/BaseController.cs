﻿using System.Linq;
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

	    public int UserRights
	    {
		    get
		    {
			    if(CurrentUser == null)
			    {
				    return 0;
			    }
			    return CurrentUser.UserRoles.Max(role => role.Role.Code);
		    }
	    }

	    public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }
    }
}
