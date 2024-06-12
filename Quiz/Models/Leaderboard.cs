using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models
{
    internal class Leaderboard
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
    }
}
