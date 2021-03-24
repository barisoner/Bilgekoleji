using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        void CreateUser(User user);

        void DeleteUser(int userid);

        User GetById(int userid);    
        void UpdateUser(User user);
        User Login(string username, string password);
    }
}
