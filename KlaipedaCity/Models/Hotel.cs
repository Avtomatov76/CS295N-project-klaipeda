using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlaipedaCity.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }

        public string HotelName { get; set; }

        public string HotelAddress { get; set; }

        public int HotelRating { get; set; }

        public int HotelPrice { get; set; }

        public string HotelLink { get; set; }
    }
}
