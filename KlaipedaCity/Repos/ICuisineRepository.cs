using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaipedaCity.Models;

namespace KlaipedaCity.Repos
{
    public interface ICuisineRepository
    {
        IQueryable<Cuisine> Cuisines { get; } // Reading or Retrieving  
        void CreateCuisine(Cuisine cuisine); // Creating a restaurant 
        void UpdateCuisine(Cuisine cuisine); // Updating a restaurant
        void DeleteCuisine(Cuisine cuisine); // Deleting a restaurant
    }
}
