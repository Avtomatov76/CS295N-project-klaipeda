using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KlaipedaCity.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public string CommentBody { get; set; }

        public DateTime CommentDate { get; set; }

        public AppUser CommentAuthor { get; set; }
    }
}
