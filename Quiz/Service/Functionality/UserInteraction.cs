using Quiz.Data;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.Functionality
{
    internal class UserInteraction
    {
        public static void DeleteUser(int userID)
        {
            using (var context = new QuizContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userID);

                if (user != null)
                {
                    context.Users.Remove(user);

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Error User with id: {userID} was not founded");
                }
            }
        }
        public static void AddUser(string login, string name, string email, string password, DateTime birthday, RoleType role)
        {
            using (var context = new QuizContext())
            {
                User user = new User()
                {
                    Login = login,
                    Name = name,
                    Email = email,
                    Password = password,
                    Birthday = birthday,
                    Role = role,
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddUserFromConsole()
        {
            Console.WriteLine("Enter login:");
            string login = Console.ReadLine();

            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

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
            AddUser(login, name, email, password, birthday, role);
            Console.WriteLine("User added successfully.");
        }
    }
}
