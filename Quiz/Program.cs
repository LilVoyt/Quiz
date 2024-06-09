using Quiz.Data;
using Quiz.Models;
using Quiz.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal class Program
    {
        static void Main()
        {
            QuizContext context = new QuizContext();

            User user = new User()
            {
                Login = "login",
                Name = "Test",
                Email = "test@gmail.com",
                Password = "Password",
                Birthday = DateTime.Now,
                Role = RoleType.Moderator,
            };
            context.Users.Add(user);
            context.SaveChanges();

            //Console.WriteLine("good");

            //var userName = context.Users.Select(x => x.Name);
            //foreach(var u in userName)
            //{
            //    Console.WriteLine(u);
            //}

            //var Join = context.Users.Join(context.Roles,
            //    user => user.RoleId,
            //    role => role.Id,
            //    (user, role) => new
            //    {
            //        UserName = user.Name,
            //        RoleName = role.Name
            //    });
            //foreach(var u in Join)
            //{
            //    Console.WriteLine($"{u.UserName} => {u.RoleName}");
            //}

            Authorisation authorisation = new Authorisation(context);

            User user1 = authorisation.Login("login", "Password");
            //Console.WriteLine(user1.Email);

            //User user2 = authorisation.SignUp("qwert", "12345", "Oleg", "oleg@gmail.com", DateTime.Now);
            //Console.WriteLine(user2.Login);

            Console.WriteLine(Enum.GetName(typeof(RoleType), user1.Role));

        }
    }
}