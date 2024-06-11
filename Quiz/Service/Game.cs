using Quiz.Data;
using Quiz.Models;
using Quiz.Service.ConsoleInterface;
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

            UIdisplay.DrawUI(UIdisplay.CreateStrategy(User.Role));
        }


    }
}
