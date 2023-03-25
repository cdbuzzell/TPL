using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TPL.Data;
using TPL.Model;

namespace TPL.Web.Pages
{
    public class MembersModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public List<GolferSummary> GolferSummaries { get; set; }

        public MembersModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }
        public void OnGet()
        {
            string connectionString = _config["Data:DefaultConnection:ConnectionString"];
            GolferData da = new GolferData(connectionString);

            GolferSummaries = da.GetGolferSummaries(Convert.ToInt32(_config["AppSettings:CurrentSeason"]));
        }
    }
}
