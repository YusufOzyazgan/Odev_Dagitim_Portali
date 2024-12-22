using Microsoft.AspNetCore.Mvc;

namespace Odev_Dagiitm_Portali_UI.Controllers
{
    public class AdminController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public AdminController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            

            return View();
        }
        public IActionResult Users()
        {
            
            return View();

        }
        public IActionResult Homeworks()
        {
            
            return View();

        }
        public IActionResult HomeworkSubmissions()
        {
           
            return View();

        }
        [Route("GiveRole/{userId}")]
        public  IActionResult GiveRole(string userId)
        {
            
            ViewBag.userId = userId;    

            return View();
        }
    }
}
