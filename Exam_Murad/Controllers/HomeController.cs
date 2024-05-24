using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam_Murad.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() 
        {
            return View();
        }
    }
}
