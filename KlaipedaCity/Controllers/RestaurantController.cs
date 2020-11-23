using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KlaipedaCity.Models;

namespace KlaipedaCity.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Restaurant model)
        {
            //model.DateSent = DateTime.Now;
            // Store the model in the database
            //repo.AddMessage(model);
            return View(model);
            //return View("SingleMessage", model); // dusplays a single message   
            //return Redirect("Messages"); // displays all messages
        }
    }
}
