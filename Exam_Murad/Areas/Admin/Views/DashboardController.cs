﻿using Microsoft.AspNetCore.Mvc;

namespace Exam_Murad.Areas.Admin.Views
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
