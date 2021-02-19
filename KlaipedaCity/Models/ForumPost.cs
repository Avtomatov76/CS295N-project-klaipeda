using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KlaipedaCity.Models
{
    public class ForumPost
    {
        private List<Comment> comments = new List<Comment>();

        public int ForumPostID { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "Subject should be between 2 and 35 characters long.")]
        public string Subject { get; set; }

        public AppUser Sender { get; set; } // watch 

        //[Required(ErrorMessage = "Please enter a Recipient's name.")]
        //[StringLength(25, MinimumLength = 2, ErrorMessage = "Sender's name should be between 2 and 25 characters long.")]
        //public string Recipient { get; set; }

        [Required(ErrorMessage = "Please enter your post here.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Your post should be between 5 and 500 characters long.")]
        public string ForumPostBody { get; set; }

        public DateTime DateSent { get; set; }

        public List<Comment> Comments
        {
            get { return comments; }
        }

    }
}
