using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Model
{
    public class SeasonChampion
    {
        public int Season { get; set; }
        public GolferSeasonTotal Champion { get; set; }
        public GolferSeasonTotal RunnerUp { get; set; }
        public GolferSeasonTotal SecondRunnerUp { get; set; }
    }
}
