using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public User Start()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("Type 1 - Login, 2 - SignUp");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    return Login();
                case 2:
                    return SignUp();
            }
            return null;
        }

        public User Login()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("Enter the login");
            string login = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string password = Console.ReadLine();
            var user = _context.Users.FirstOrDefault(u => u.Login == login);
            if (user == null || !Hashing.Verify(password, user.Password))
            {
                Console.WriteLine("User with this login not exist");
                Console.WriteLine("Type 1 - Login again, 2 - SignUp");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        return Login();
                    case 2:
                        return SignUp();
                }
            }
            else
            {
                return user;
            }
            return null;
        }

        public User SignUp()
        {
            Console.WriteLine("Enter login:");
            string login = Console.ReadLine();

            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            string email = RegisterEmail();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            string hash = Hashing.Hash(password);

            Console.WriteLine("Enter birthday (yyyy-mm-dd):");
            DateTime birthday;
            while (!DateTime.TryParse(Console.ReadLine(), out birthday))
            {
                Console.WriteLine("Invalid date format. Please enter again (yyyy-mm-dd):");
            }

            Console.WriteLine("Enter role (Admin, Moderator, User):");
            RoleType role;
            while (!Enum.TryParse(Console.ReadLine(), true, out role) || !Enum.IsDefined(typeof(RoleType), role))
            {
                Console.WriteLine("Invalid role. Please enter one of the following (Admin, Moderator, User):");
            }

            User user = new User()
            {
                Login = login,
                Name = name,
                Email = email,
                Password = hash,
                Birthday = birthday,
                Role = role,
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public static string RegisterEmail()
        {
            while (true)
            {
                Console.WriteLine("Enter email:");
                string email = Console.ReadLine();

                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (Regex.IsMatch(email, pattern))
                {
                    if (IsEmailUnique(email))
                    {
                        return email;
                    }
                    else
                    {
                        Console.WriteLine("This email is already taken. Please try another.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid email format. Please try again.");
                }
            }
        }

        public static bool IsEmailUnique(string email)
        {
            using (var context = new QuizContext())
            {
                return !context.Users.Any(x => x.Email == email);
            }
        }
    }
}
