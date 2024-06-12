using Quiz.Data;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service.Functionality
{
    internal class LeaderboardInteraction
    {
        public static void AddResults(int userId, int grade)
        {
            using (var context = new QuizContext())
            {
                var user = context.Users.Find(userId);
                if (user == null)
                {
                    Console.WriteLine("User not found");
                    return;
                }

                Leaderboard leaderboard = new Leaderboard()
                {
                    Grade = grade,
                    UserId = userId,
                    Date = DateTime.Now,
                };

                context.Leaders.Add(leaderboard);
                context.SaveChanges();
                Console.WriteLine($"You are {GetResult(leaderboard)} in a leaderboard!");
            }
        }
        public static int GetResult(Leaderboard leaderboard)
        {
            using(var context = new QuizContext())
            {
                var board = context.Leaders.AsEnumerable().OrderByDescending(x => x.Grade).ThenByDescending(x => x.Date).ToList();
                foreach (var item in board)
                {
                    Console.WriteLine(item.Grade);
                }
                return board.FindIndex(x => x.Id == leaderboard.Id) + 1;
            }
        }
    }
}
