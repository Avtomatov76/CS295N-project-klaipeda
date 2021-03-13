using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KlaipedaCity.Models
{
    public class CommentVM
    {
        public int ForumPostID { get; set; }

        [Required(ErrorMessage = "Please enter a Subject.")]
        [StringLength(65, MinimumLength = 2, ErrorMessage = "The subject should be between 2 and 65 characters long.")]
        public string PostSubject { get; set; }

        [Required(ErrorMessage = "Please write a comment.")]
        [StringLength(255, MinimumLength = 4, ErrorMessage = "The comment should be between 4 and 255 characters long.")]
        public string CommentBody { get; set; }
    }
}
