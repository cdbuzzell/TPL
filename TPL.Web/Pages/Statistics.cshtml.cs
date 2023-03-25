using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TPL.Data;
using TPL.Model;

namespace TPL.Web.Pages
{
    public class StatisticsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public List<GolferSeasonTotal> Leaderboard { get; set; }
        public List<GolferRound> SeasonStatistics { get; set; }
        public List<GolferSeasonTotal> AllStatistics { get; set; }
        public List<SelectListItem> Seasons { get; set; }
        public List<Golfer> Golfers { get; set; }

        public StatisticsModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        public void OnGet()
        {
            string connectionString = _config["Data:DefaultConnection:ConnectionString"];
            int currentSeason = Convert.ToInt32(_config["AppSettings:CurrentSeason"]);
            int firstSeason = Convert.ToInt32(_config["AppSettings:FirstSeason"]);

            Logic bl = new Logic(connectionString);
            Seasons = bl.GetSeasons(firstSeason, currentSeason);

            GolferData da = new GolferData(connectionString);
            Golfers = da.GetGolfers();
        }

        public JsonResult OnGetStatisticsAjax(int season, string golfer)
        {
            string connectionString = _config["Data:DefaultConnection:ConnectionString"];
            GolferData da = new GolferData(connectionString);
            ScheduleData sda = new ScheduleData(connectionString);

            Statistics stats = new Statistics
            {
                //TODO: I don't like only populating part of the model
                Leaderboard = sda.GetLeaderboard(season),
                SeasonStatistics = da.GetGolferRounds(golfer, season),
                AllStatistics = da.GetGolferTotals(golfer)
            };

            return new JsonResult(stats);
        }
    }
}
