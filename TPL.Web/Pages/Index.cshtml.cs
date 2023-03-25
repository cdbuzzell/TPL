using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TPL.Data;
using TPL.Model;

namespace TPL.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public int Season { get; set; }
        public List<Round> Schedule { get; set; }
        public List<GolferSeasonTotal> Leaderboard { get; set; }
        public List<SeasonChampion> Champions { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        public void OnGet()
        {
            string connectionString = _config["Data:DefaultConnection:ConnectionString"];
            ScheduleData da = new ScheduleData(connectionString);

            // get year from appSettings
            //Season = _appSettings.Value.CurrentSeason;
            //Season = Convert.ToInt32(_config.GetSection("AppSettings")["CurrentSeason"]);
            Season = Convert.ToInt32(_config["AppSettings:CurrentSeason"]);

            //List<GolferSeasonTotal> leaderboard = da.GetLeaderboard(season);

            // filter schedule to upcoming dates only
            DateTime today = DateTime.Now.AddHours(-5); //TODO: azure sql server is local while DateTime.Now is UTC, so this is a hack until I figure out how to get it to work the right way
            Schedule = da.GetSchedule(Season).Where(round => DateTime.Compare(round.Date, today) >= 0).ToList();

            //List<SeasonChampion> champions = new List<SeasonChampion>();
            //// only display past champions if we have <10 rounds remaining this year to fill the page
            //if (Schedule.Count < 10)
            //{
            //    champions = GetChampions();
            //}
        }
    }
}