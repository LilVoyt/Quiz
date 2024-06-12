using Quiz.Data;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.Functionality
{
    internal class LeatherboardInteraction
    {
        public static void AddResults(User user, int grade)
        {
            using(var context = new QuizContext())
            {
                Leaderboard leaderboard = new Leaderboard()
                {
                    Grade = grade,
                    User = user,
                    Date = DateTime.Now,
                };
                context.Leaders.Add(leaderboard);
                context.SaveChanges();
            }
        }
    }
}
