﻿using System.Linq;

namespace LessonProject.Model
{
    public interface IRepository
    {
        #region Role
        IQueryable<Role> Roles { get; }

        bool CreateRole(Role instance);

        bool UpdateRole(Role instance);

        bool RemoveRole(int idRole);

        #endregion

        #region User

        IQueryable<User> Users { get; }

        bool CreateUser(User instance);

        bool UpdateUser(User instance);

        bool RemoveUser(int idUser);

        User GetUser(string email);

        User Login(string email, string password);

        #endregion 
        
        #region UserRole

        IQueryable<UserRole> UserRoles { get; }

        bool CreateUserRole(UserRole instance);

        bool UpdateUserRole(UserRole instance);

        bool RemoveUserRole(int idUserRole);

        #endregion 

		#region Topic

		IQueryable<Topic> Topics { get; }

		bool CreateTopic(Topic instance);

		bool UpdateTopic(Topic instance);

		bool RemoveTopic(int idTopic);

		Topic GetTopic(int idTopic);

		#endregion 

		#region Message

		IQueryable<Message> Messages { get; }

		bool CreateMessage(Message instance);

		bool RemoveMessage(int idMessage);

		Message GetMessage(int idMessage);

		#endregion 
    }
}
