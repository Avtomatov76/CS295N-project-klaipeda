using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace KlaipedaCity.Models
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "Please enter Sender's name.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Sender's name should be between 2 and 25 characters long.")]
        public string SenderName { get; set; }
        //public string RecipientName { get; set; }

        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
}
