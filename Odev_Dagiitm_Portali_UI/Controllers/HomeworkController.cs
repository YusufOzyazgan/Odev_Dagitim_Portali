using Microsoft.AspNetCore.Mvc;

namespace Odev_Dagiitm_Portali_UI.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeworkController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IActionResult AddHomework()
        {
          
            return View();

        }
        public IActionResult HomeworkSubmission()
        {
          
            return View();

        }

        public IActionResult MyHomeworks()
        {
            
            return View();

        }

        [Route("EditHomework/{id}")]
        public IActionResult EditHomework(int id)
        {
            
            ViewBag.HomeworkId = id;
            return View();

        }

        public IActionResult StudentHomework()
        {
            

            return View();
        }

        public IActionResult ShowHomework(int id)
        {
            
            ViewBag.HomeworkId = id;
            return View();
        }

        public IActionResult AddHomeworkSubmission(int id) {
          
            ViewBag.HomeworkId = id;
            return View();
        }


        public IActionResult MyHomeworkSubmission()
        {
            
            return View();
        }

        [Route("EdithomeworkSubmission/{id}")]
        public IActionResult EditHomeworkSubmission(int id)
        {
           
            ViewBag.HomeworkSubmissionId = id;
            return View();
      
        }

    }
}
