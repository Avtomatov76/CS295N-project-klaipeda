using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KlaipedaCity.Models
{
    public class Cuisine
    {
        public int CuisineID { get; set; }

        [Required(ErrorMessage = "Please enter a type/name of cuisine.")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "The name should be between 3 and 20 characters long.")]
        public string CuisineName { get; set; }
    }
}
