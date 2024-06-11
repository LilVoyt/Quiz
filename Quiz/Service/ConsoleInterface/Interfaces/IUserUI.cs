using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.ConsoleInterface.Interfaces
{
    internal interface IUserUI : IRoleUI
    {
        void TakeQuiz();
        void DeleteMyself();
    }
}
