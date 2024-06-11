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
    internal class AdminUI : IAdminUI
    {
        public void DisplayMenu()
        {
            Console.WriteLine("1. Manage Users");
            Console.WriteLine("2. View Reports");
            Console.WriteLine("You choosed right think!");
        }

        public void ChooseFunction()
        {
            ManageUsers();
        }

        public void ManageUsers()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Delete user");
            Console.WriteLine("Choose what you need (1, 2) or exit (-1):");
            int choose;

            while (!int.TryParse(Console.ReadLine(), out choose) || (choose != 1 && choose != 2 && choose != -1))
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2:");
            }

            Console.Clear();
            Thread.Sleep(1000);

            switch (choose)
            {
                case 1:
                    UserInteraction.AddUserFromConsole();
                    AskToContinue();
                    break;
                case 2:
                    Console.WriteLine("Enter user ID to delete:");
                    int userId;
                    while (!int.TryParse(Console.ReadLine(), out userId))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid user ID:");
                    }
                    UserInteraction.DeleteUser(userId);
                    Console.WriteLine("User deleted!");
                    AskToContinue();
                    break;
                case -1:
                    Game game = new Game();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    AskToContinue();
                    break;
            }
        }

        public void AskToContinue()
        {
            Console.WriteLine("Do you want to continue(1 - yes, 2 - no)? ");
            int choose = int.Parse(Console.ReadLine());
            if(choose == 1)
            {
                ManageUsers();
            }
            else if(choose == 2)
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
