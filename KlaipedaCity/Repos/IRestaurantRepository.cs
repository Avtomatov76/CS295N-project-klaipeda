using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaipedaCity.Models;

namespace KlaipedaCity.Repos
{
    public interface IRestaurantRepository
    {
        IQueryable<Restaurant> Restaurants { get; } // Reading or Retrieving  
        void CreateRestaurant(Restaurant restaurant); // Creating a restaurant 
        void UpdateRestaurant(Restaurant restaurant); // Updating a restaurant
        void DeleteRestaurant(Restaurant restaurant); // Deleting a restaurant
    }
}
