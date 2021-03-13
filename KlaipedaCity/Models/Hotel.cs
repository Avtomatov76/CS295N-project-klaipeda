using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KlaipedaCity.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }

        public AppUser Sender { get; set; } 

        [Required(ErrorMessage = "Please enter a hotel name.")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "The name should be between 2 and 55 characters long.")]
        public string HotelName { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "Your entry should be between 15 and 55 characters long.")]
        public string HotelAddress { get; set; }

        [Range(1, 5, ErrorMessage = "Your entry should be between 1 and 5.")]
        [Required(ErrorMessage = "Please enter a rating.")]
        public int HotelRating { get; set; }

        [Range(1, 1000, ErrorMessage = "Your entry should be between 1 and 1000.")]
        [Required(ErrorMessage = "Please enter a nightly rate.")]
        public int HotelPrice { get; set; }

        [Required(ErrorMessage = "Please enter a web address.")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "Your entry should be between 5 and 65 characters long.")]
        public string HotelLink { get; set; }
    }
}
