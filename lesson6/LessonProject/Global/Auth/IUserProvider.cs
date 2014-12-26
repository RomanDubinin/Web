using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonProject.Model;

namespace LessonProject.Global.Auth
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}
