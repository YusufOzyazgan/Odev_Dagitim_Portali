using Microsoft.AspNetCore.Mvc;
using Odev_Dagiitm_Portali_UI.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Odev_Dagiitm_Portali_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            

            return View();
        }


       
        public IActionResult Login()
        {
            
            return View();
        }
            


        public IActionResult Register()
        {
            return View();

        }

        public IActionResult RegisterTeacher()
        {
          
            return View();
            

        }

        public IActionResult RegisterStudent()
        {
           
            return View();


        }


        public IActionResult addUserClass()
        {
          
            return View();
        }






        public IActionResult UserPage()
        {
         
            return View();

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
