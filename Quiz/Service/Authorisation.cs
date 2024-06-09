using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service
{
    internal class Authorisation
    {
        private QuizContext _context { get; set; }

        public Authorisation(QuizContext context)
        {
            _context = context;
        }

        public User Login(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            return user;
        }

        public User SignUp(string login, string password, string name, string email, DateTime birthday)
        {
            User user = new User()
            {
                Login = login,
                Name = name,
                Email = email,
                Password = password,
                Birthday = birthday,
                Role = RoleType.User,
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
