using KlaipedaCity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlaipedaCity.Repos
{
    public class HotelRepository : IHotelRepository
    {
        private KlaipedaDbContext context;

        // Constructor
        public HotelRepository(KlaipedaDbContext c)
        {
            context = c;
        }

        public IQueryable<Hotel> Hotels
        {
            get
            {
                return context.Hotels.Include(h => h.Sender);
            }
        }

        public void CreateHotel(Hotel h)
        {
            context.Hotels.Add(h);
            context.SaveChanges();
        }

        public void DeleteHotel(Hotel h)
        {
            var hotel = context.Hotels.Find(h.HotelID);
            context.Remove(hotel);
            context.SaveChanges();
        }

        public void UpdateHotel(Hotel h)
        {
            var hotel = context.Hotels.Include("Sender")
                .Where(htl => htl.HotelID == h.HotelID).FirstOrDefault(); 
            // updating individual values
            hotel.HotelID = h.HotelID;
            hotel.HotelName = h.HotelName;
            hotel.HotelAddress = h.HotelAddress;
            hotel.HotelRating = h.HotelRating;
            hotel.HotelPrice = h.HotelPrice;
            hotel.HotelLink = h.HotelLink;
            hotel.Sender.SenderName = h.Sender.SenderName;

            context.SaveChanges();
        }
    }
}
