using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KlaipedaCity.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; } // primary key

        [Required(ErrorMessage = "Please enter a restaurant name.")]
        [StringLength(55, MinimumLength = 2, ErrorMessage = "The name should be between 2 and 55 characters long.")]
        public string RestaurantName { get; set; }
 
        public Cuisine CuisineName { get; set; } // property from Cuisine model

        public AppUser Sender { get; set; } 

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(255, MinimumLength = 4, ErrorMessage = "The description should be between 4 and 255 characters long.")]
        public string RestaurantDesc { get; set; }

        [Range(1, 5, ErrorMessage = "Your entry should be between 1 and 5.")]
        [Required(ErrorMessage = "Please enter a rating.")]
        public int RestaurantRating { get; set; }

        [Range(1, 1000, ErrorMessage = "Your entry should be between 1 and 1000.")]
        [Required(ErrorMessage = "Please enter an average check amount.")]
        public int RestaurantPrice { get; set; }

        [Required(ErrorMessage = "Please enter a web address.")]
        [StringLength(65, MinimumLength = 5, ErrorMessage = "Your entry should be between 5 and 65 characters long.")]
        public string RestaurantLink { get; set; }
    }
}
