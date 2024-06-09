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
        private List<User> Users { get; set; }

        public Authorisation(QuizContext context)
        {
            Users = context.Users.ToList();
        }

        public User Login(string login, string password)
        {
            var user = Users.Find(u => u.Login == login && u.Password == password);
            return user;
        }
    }
}
