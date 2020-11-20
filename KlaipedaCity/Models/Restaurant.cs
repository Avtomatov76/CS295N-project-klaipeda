using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlaipedaCity.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; } // primary key

        public string RestaurantName { get; set; }

        public Cuisine CuisineName { get; } // property from Cuisine model

        public string RestaurantDesc { get; set; }

        public int RestaurantRating { get; set; }

        public int RestaurantPrice { get; set; }

        public string RestaurantLink { get; set; }
    }
}
