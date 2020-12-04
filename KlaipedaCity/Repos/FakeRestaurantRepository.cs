using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaipedaCity.Models;
using KlaipedaCity.Repos;

namespace KlaipedaCity.Repos
{
    public class FakeRestaurantRepository : IRestaurantRepository
    {
        private List<Restaurant> restaurants = new List<Restaurant>();

        public IQueryable<Restaurant> Restaurants { get { return restaurants.AsQueryable<Restaurant>(); } }

        public void CreateRestaurant(Restaurant restaurant)
        {
            restaurant.RestaurantID = restaurants.Count;
            restaurants.Add(restaurant);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            var restaurantToDel = restaurants.Where(r => r.RestaurantID == restaurant.RestaurantID).FirstOrDefault();
            restaurants.Remove(restaurantToDel);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            var oldRestaurant = new Restaurant()
            {
                RestaurantID = 1,
                RestaurantName = "Stora Antis",
                CuisineName = new Cuisine() { CuisineName = "Russian" },
                RestaurantDesc = "Manto g. 12",
                RestaurantRating = 5,
                RestaurantPrice = 45,
                RestaurantLink = "www.storaantis.lt"
            };

            // updating individual values
            oldRestaurant.RestaurantID = restaurant.RestaurantID;
            oldRestaurant.RestaurantName = restaurant.RestaurantName;
            oldRestaurant.CuisineName = restaurant.CuisineName;
            oldRestaurant.RestaurantDesc = restaurant.RestaurantDesc;
            oldRestaurant.RestaurantRating = restaurant.RestaurantRating;
            oldRestaurant.RestaurantPrice = restaurant.RestaurantPrice;
            oldRestaurant.RestaurantLink = restaurant.RestaurantLink;

            restaurants.Add(oldRestaurant);
        }
    }
}
