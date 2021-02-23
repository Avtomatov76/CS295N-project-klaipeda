using KlaipedaCity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlaipedaCity.Repos
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private KlaipedaDbContext context;

        // Constructor
        public RestaurantRepository(KlaipedaDbContext c)
        {
            context = c;
        }

        public IQueryable<Restaurant> Restaurants
        {
            get
            {
                return context.Restaurants.Include(r => r.CuisineName)
                        .Include(r => r.Sender); // to see the sender info
            }
        }

        public void CreateRestaurant(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            context.SaveChanges();
        }

        public void UpdateRestaurant(Restaurant r)
        {
            var updRestaurant = context.Restaurants.Include("CuisineName").Include("Sender") // use navigational property here NOT table name...
                .Where(re => re.RestaurantID == r.RestaurantID).FirstOrDefault();
            // updating individual values 
            updRestaurant.RestaurantName = r.RestaurantName;
            updRestaurant.CuisineName.CuisineName = r.CuisineName.CuisineName;
            updRestaurant.RestaurantDesc = r.RestaurantDesc;
            updRestaurant.RestaurantRating = r.RestaurantRating;
            updRestaurant.RestaurantPrice = r.RestaurantPrice;
            updRestaurant.RestaurantLink = r.RestaurantLink;
            updRestaurant.Sender.SenderName = r.Sender.SenderName;

            context.SaveChanges();
        }

        public void DeleteRestaurant(Restaurant r)
        {
            var restaurant = context.Restaurants.Find(r.RestaurantID);
            context.Remove(restaurant);
            context.SaveChanges();
        }
    }
}
