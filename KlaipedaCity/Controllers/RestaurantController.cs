using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KlaipedaCity.Models;
using KlaipedaCity.Repos;
using Microsoft.AspNetCore.Authorization;


namespace KlaipedaCity.Controllers
{
    public class RestaurantController : Controller
    {
        IRestaurantRepository repo;

        List<Restaurant> restaurants = null;
        
        // Array of strings that is used to determine whether a search is by cusine type or by restaurant name
        private string[] cTypes = { "lithuanian", "russian", "american", "coffee",
            "italian", "bar", "georgian", "german", "ukrainian", "gastroPub",
            "french", "cafe", "pizza", "burger", "fast food" };

        public RestaurantController(IRestaurantRepository r)
        {
            repo = r;
        }

        // Displays a list of restaurants by default
        public IActionResult Index()
        {
            restaurants = repo.Restaurants.ToList();

            return View(restaurants);
        }

        // Displays search results by restaurant name or cruisine type
        [HttpPost]
        public IActionResult Index(string searchParam)
        {
            restaurants = repo.Restaurants.ToList(); 

            if (searchParam != null && cTypes.Contains(searchParam))
            {
                searchParam.ToLower();
                var cuisineType = repo.Restaurants.Where(
                    r => r.CuisineName.CuisineName.ToLower() == searchParam).ToList();
                return View(cuisineType);
            }
            else if (searchParam != null)
            {
                searchParam.ToLower();
                //var restaurants = repo.Restaurants.Where(r => r.RestaurantName == restaurantName).ToList(); // exact match
                var restaurantSearch = repo.Restaurants.Where(
                    r => r.RestaurantName.ToLower().Contains(searchParam)).ToList(); // more generic match
                return View(restaurantSearch);
            }
            return View(restaurants);
        }

        // GET: Restaurants/Add - Displays Add Restaurant form
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Restaurants/AddRestaurant - Adds a restaurant to the list and displays it on the 'Index' page
        [HttpPost]
        public IActionResult Add(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                repo.CreateRestaurant(restaurant);

                return Redirect("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Edit/{id} - Displays EditRestaurant form for a particular restaurant
        [Authorize]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var restaurant = repo.Restaurants.Where(r => r.RestaurantID == id).FirstOrDefault(); 

            return View(restaurant);
        }

        // POST: Restaurants/Edit - updating a restaurant and re-displaying all restaurants
        [HttpPost]
        public IActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                if (restaurant.RestaurantID == 0)
                    repo.CreateRestaurant(restaurant);
                else
                    repo.UpdateRestaurant(restaurant);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (restaurant.RestaurantID == 0) ? "Add" : "Edit";
                return View(restaurant);
            }            
        }

        // GET: Restaurants/Edit/{id} - Displays Edit form for a particular restaurant
        [Authorize]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";

            var restaurant = repo.Restaurants.Where(r => r.RestaurantID == id).FirstOrDefault(); 

            return View(restaurant);
        }

        // Removes a restaurant from the database and displays updated info
        [HttpPost]
        public IActionResult Delete(Restaurant restaurant)
        {
            repo.DeleteRestaurant(restaurant);

            return RedirectToAction("Index");
        }
    }
}
