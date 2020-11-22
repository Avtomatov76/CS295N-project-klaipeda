using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KlaipedaCity.Models;

namespace KlaipedaCity.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(QuizVM quiz)
        {
            quiz.CheckAnswers();
            return View(quiz);
        }
    }
}
