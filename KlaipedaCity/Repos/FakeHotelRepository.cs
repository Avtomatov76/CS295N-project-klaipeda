using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaipedaCity.Models;
using KlaipedaCity.Repos;

namespace KlaipedaCity.Repos
{
    public class FakeHotelRepository : IHotelRepository
    {
        private List<Hotel> hotels = new List<Hotel>();

        public IQueryable<Hotel> Hotels { get { return hotels.AsQueryable<Hotel>(); } }

        public void CreateHotel(Hotel hotel)
        {
            hotel.HotelID = hotels.Count;
            hotels.Add(hotel);
        }

        public void DeleteHotel(Hotel hotel)
        {
            var hotelToDel = hotels.Where(h => h.HotelID == hotel.HotelID).FirstOrDefault();
            hotels.Remove(hotelToDel);
        }

        public void UpdateHotel(Hotel hotel)
        {
            var oldHotel = new Hotel()
            {
                HotelID = 1,
                HotelName = "Klaipeda",
                HotelAddress = "Zardininku g. 21",
                HotelRating = 3,
                HotelPrice = 35,
                HotelLink = "www.zarde.lt"
            };

            // updating individual values
            oldHotel.HotelID = hotel.HotelID;
            oldHotel.HotelName = hotel.HotelName;
            oldHotel.HotelAddress = hotel.HotelAddress;
            oldHotel.HotelRating = hotel.HotelRating;
            oldHotel.HotelPrice = hotel.HotelPrice;
            oldHotel.HotelLink = hotel.HotelLink;

            hotels.Add(oldHotel);
        }
    }
}
