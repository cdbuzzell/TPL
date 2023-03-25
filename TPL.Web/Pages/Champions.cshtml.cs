using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TPL.Model;

namespace TPL.Web.Pages
{
    public class ChampionsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public List<SeasonChampion> Champions { get; set; }

        public ChampionsModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        public void OnGet()
        {
            int season = Convert.ToInt32(_config["AppSettings:CurrentSeason"]);
            string connectionString = _config["Data:DefaultConnection:ConnectionString"];
            Logic bl = new Logic(connectionString);

            Champions = bl.GetChampions(season);
        }
    }
}
