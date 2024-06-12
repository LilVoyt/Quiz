using Quiz.Models;
using Quiz.Service.ConsoleInterface.Interfaces;
using Quiz.Service.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.ConsoleInterface.RealiseClass
{
    internal class UserUI : IUserUI
    {
        public User _User { get; set; }
        public UserUI(User user)
        {
            _User = user;
        }
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
            Console.WriteLine("Choose what you need (1, 2, 3) or exit (-1):");
            int choose;

            while (!int.TryParse(Console.ReadLine(), out choose) || (choose != 1 && choose != 2 && choose != 3 && choose != -1))
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2:");
            }

            Console.Clear();
            Thread.Sleep(1000);

            switch (choose)
            {
                case 1:
                    QuestionsInteraction.AnswerQuestion();
                    break;
                case 2:
                    
                    break;
                case 3:
                    DeleteMyself();
                    break;
                case -1:
                    Game game = new Game();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        }

        public void DeleteMyself()
        {
            var Id = _User.Id;
            UserInteraction.DeleteUser(Id);
            Console.WriteLine("You are deleted from db!");

        }

        public void AskToContinue()
        {
            Console.WriteLine("Do you want to reboot(1 - yes, 2 - no)? ");
            int choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                Game game = new Game();
            }
            else if (choose == 2)
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid choise! \n Try again");
                AskToContinue();
            }
        }
    }
}
