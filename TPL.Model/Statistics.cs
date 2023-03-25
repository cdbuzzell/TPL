using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL.Model
{
    public class Statistics
    {
        public List<GolferSeasonTotal> Leaderboard { get; set; }
        public List<GolferRound> SeasonStatistics { get; set; }
        public List<GolferSeasonTotal> AllStatistics { get; set; }
        //public List<SelectListItem> Seasons { get; set; }
        public List<Golfer> Golfers { get; set; }
    }
}
