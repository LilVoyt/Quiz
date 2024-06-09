using Quiz.Service.ConsoleInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.ConsoleInterface.RealiseClass
{
    internal class AdminUI : IAdminUI
    {
        public void DisplayMenu()
        {
            Console.WriteLine("1. Manage Users");
            Console.WriteLine("2. View Reports");
        }

        public void ManageUsers()
        {
            Console.WriteLine("Managing users...");
        }
    }
}
