using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TPL.Data;
using TPL.Model;

namespace TPL.Web.Pages
{
    public class ScheduleModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public List<SelectListItem> Seasons { get; set; }

        public ScheduleModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        public void OnGet()
        {
            string connectionString = _config["Data:DefaultConnection:ConnectionString"];
            Logic bl = new Logic(connectionString);

            int currentSeason = Convert.ToInt32(_config["AppSettings:CurrentSeason"]);
            int firstSeason = Convert.ToInt32(_config["AppSettings:FirstSeason"]);
            Seasons = bl.GetSeasons(firstSeason, currentSeason);
        }

        public JsonResult OnGetScheduleAjax(int season)
        {
            string connectionString = _config["Data:DefaultConnection:ConnectionString"];
            ScheduleData da = new ScheduleData(connectionString);

            List<Round> schedule = da.GetSchedule(season);

            return new JsonResult(schedule);
        }
    }
}
