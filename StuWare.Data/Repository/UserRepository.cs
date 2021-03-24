using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private StuWareContext _context;

        public UserRepository(StuWareContext context)
        {
            _context = context;
        }

        public IQueryable<User> Users => _context.User;

        public void CreateUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public User Login(string email, string password)
        {
            var user = _context.User.Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
            return user;
        }


        public User GetById(int userid)
        {
            return _context.User.FirstOrDefault(i => i.ID == userid);
        }

        public void DeleteUser(int userid)
        {
            var user = GetById(userid);

            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }
    }
}
