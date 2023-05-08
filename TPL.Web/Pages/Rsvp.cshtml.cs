using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TPL.Data;
using TPL.Model;

namespace TPL.Web.Pages
{
    public class RsvpModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public List<RoundRsvp> Rsvps { get; set; }

        public RsvpModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }
        public void OnGet()
        {

            string connectionString = _config["Data:DefaultConnection:ConnectionString"];
            ScheduleData da = new ScheduleData(connectionString);

            Rsvps = da.GetRoundRsvps(System.Guid.Empty);
        }
    }
}
