using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaipedaCity.Models;

namespace KlaipedaCity.Repos
{
    public interface IHotelRepository
    {
        IQueryable<Hotel> Hotels { get; } // Reading or Retrieving  
        void CreateHotel(Hotel hotel); // Creating a restaurant 
        void UpdateHotel(Hotel hotel); // Updating a restaurant
        void DeleteHotel(Hotel hotel); // Deleting a restaurant
    }
}
