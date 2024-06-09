﻿using Quiz.Data;
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

            //Role role = new Role()
            //{
            //    Name = "Test",
            //    Description = "Test",
            //    Permisions = "delete, change, other"
            //};
            //context.Roles.Add(role);
            //context.SaveChanges();
            //User user = new User()
            //{
            //    Login = "login",
            //    Name = "Test",
            //    Email = "test@gmail.com",
            //    Password = "Password",
            //    Birthday = DateTime.Now,
            //    RoleId = 1
            //};
            //context.Users.Add(user);
            //context.SaveChanges();

            Console.WriteLine("good");

            var user = context.Users.Select(x => x.Name);
            foreach(var u in user)
            {
                Console.WriteLine(u);
            }

            var Join = context.Users.Join(context.Roles,
                user => user.RoleId,
                role => role.Id,
                (user, role) => new
                {
                    UserName = user.Name,
                    RoleName = role.Name
                });
            foreach(var u in Join)
            {
                Console.WriteLine($"{u.UserName} => {u.RoleName}");
            }

            Authorisation authorisation = new Authorisation(context);

            User user1 = authorisation.Login("login", "Password");
            Console.WriteLine(user1.Email);
        }
    }
}