using Quiz.Service.ConsoleInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.ConsoleInterface.RealiseClass
{
    internal class UserUI : IUserUI
    {
        public void DisplayMenu()
        {
            Console.WriteLine("1. Take Quiz");
            Console.WriteLine("2. View Results");
            Console.WriteLine("3. Delete my account");
        }

        public void TakeQuiz()
        {
            Console.WriteLine("Taking quiz...");
        }


        public void ChooseFunction()
        {
            Console.WriteLine("enter a possible function: ");
            int choose = int.Parse(Console.ReadLine());
            Console.WriteLine($"You choosed {choose}");
            TakeQuiz();
        }
    }
}
