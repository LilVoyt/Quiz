using Quiz.Service.ConsoleInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.ConsoleInterface.RealiseClass
{
    internal class ModeratorUI : IModeratorUI
    {
        public void DisplayMenu()
        {
            Console.WriteLine("DisplayMenu");
        }

        public void ChooseFunction()
        {
            ManageUsers();
        }

        public void ManageUsers()
        {
            Console.WriteLine("ManageUsers");
        }
    }
}
