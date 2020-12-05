using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaipedaCity.Models;
using Microsoft.AspNetCore.Mvc;
using KlaipedaCity.Repos;

namespace KlaipedaCity.Controllers
{
    public class HotelController : Controller
    {
        IHotelRepository repo;

        List<Hotel> hotels = null;

        public HotelController(IHotelRepository r)
        {
            repo = r;
        }

        // Displays a list of hotels by default
        public IActionResult Index()
        {
            hotels = repo.Hotels.ToList();

            return View(hotels);
        }

        // Displays search results by hotel name or cruisine type
        [HttpPost]
        public IActionResult Index(string searchParam)
        {
            hotels = repo.Hotels.ToList();
            bool result = false;
            int rating = 0; // will be used to search by rating if searchParam is not null

            if (searchParam != null)
            {
                searchParam.ToLower();
                result = Int32.TryParse(searchParam, out rating); // Checking if user entered a number to search by rating
            }
            else
                return View(hotels);

            if (searchParam != null && result) // searching by hotel rating
            {
                var hotel = repo.Hotels.Where(
                    h => h.HotelRating == rating).ToList();
                return View(hotel);
            }
            else if (searchParam != null) // searching by hotel name
            {
                //var restaurants = repo.Restaurants.Where(r => r.RestaurantName == restaurantName).ToList(); // exact match
                var hotel = repo.Hotels.Where(
                    h => h.HotelName.ToLower().Contains(searchParam)).ToList(); // more generic match
                return View(hotel);
            }
            return View(hotels);
        }

        // GET: Hotels/Add - Displays Add Hotel form
        public IActionResult Add()
        {
            return View();
        }

        // POST: Hotels/Add - Adds a hotel to the list and displays it on the 'Index' page
        [HttpPost]
        public IActionResult Add(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                repo.CreateHotel(hotel);

                return Redirect("Index");
            }
            return View(hotel);
        }

        // GET: Hotels/Edit/{id} - Displays Edit form for a particular hotel
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var hotel = repo.Hotels.Where(h => h.HotelID == id).FirstOrDefault();

            return View(hotel);
        }

        // PUT: Restaurants/Edit - updating a hotel and re-displaying the list of entries from the DB
        [HttpPost]
        public IActionResult Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                if (hotel.HotelID == 0)
                    repo.CreateHotel(hotel);
                else
                    repo.UpdateHotel(hotel);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (hotel.HotelID == 0) ? "Add" : "Edit";
                return View(hotel);
            }
        }

        // GET: Hotels/Edit/{id} - Displays Edit form for a particular hotel
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";

            var hotel = repo.Hotels.Where(r => r.HotelID == id).FirstOrDefault();

            return View(hotel);
        }

        // Removes a hotel from the database and displays updated info
        [HttpPost]
        public IActionResult Delete(Hotel hotel)
        {
            repo.DeleteHotel(hotel);

            return RedirectToAction("Index");
        }
    }
}
