using Quiz.Data;
using Quiz.Models;
using Quiz.Service.ConsoleInterface;
using Quiz.Service.ConsoleInterface.Interfaces;
using Quiz.Service.ConsoleInterface.RealiseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service
{
    internal class Game
    {
        public QuizContext context { get; set; }
        public Authorisation authorisation { get; set; }
        public User User { get; set; }
        public Game()
        {
            context = new QuizContext();

            authorisation = new Authorisation(context);

            User = authorisation.Start();

            DrawUI(CreateStrategy(User));
        }
        public static IRoleUI CreateStrategy(User user)
        {
            var role = user.Role;
            return role switch
            {
                RoleType.Admin => new AdminUI(user),
                RoleType.Moderator => new ModeratorUI(user),
                RoleType.User => new UserUI(user),
                _ => throw new ArgumentException("Invalid role type"),
            };
        }

        public static void DrawUI(IRoleUI roleUI)
        {
            roleUI.DisplayMenu();
            roleUI.ChooseFunction();
        }
    }
}
