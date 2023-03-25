using TPL.Model;
using TPL.Data;

namespace TPL.Web
{
    public class Logic
    {
        string _connectionString = string.Empty;

        public Logic(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<SeasonChampion> GetChampions(int season)
        {
            // get champs for all seasons, then filter out current season because we may not be done yet
            ScheduleData da = new ScheduleData(_connectionString);

            // filter to exclude current season because it may still be in-progress
            List<GolferSeasonTotal> golfers = da.GetChampions().Where(golfer => !golfer.Season.Equals(season)).ToList();

            List<SeasonChampion> champions = new List<SeasonChampion>();

            for (int i = 0; i <= golfers.Count - 3; i = i + 3)
            {
                // group 3 golfers into a single object
                champions.Add(new SeasonChampion
                {
                    Season = golfers[i].Season,
                    Champion = golfers[i],
                    RunnerUp = golfers[i + 1],
                    SecondRunnerUp = golfers[i + 2]
                });
            }

            return champions;
        }
    }
}
