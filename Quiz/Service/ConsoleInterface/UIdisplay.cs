using Quiz.Models;
using Quiz.Service.ConsoleInterface.Interfaces;
using Quiz.Service.ConsoleInterface.RealiseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.ConsoleInterface
{
    internal class UIdisplay
    {
        public static IRoleUI CreateStrategy(RoleType role)
        {
            return role switch
            {
                RoleType.Admin => new AdminUI(),
                RoleType.Moderator => new ModeratorUI(),
                RoleType.User => new UserUI(),
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
