using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlaipedaCity.Models
{
    public class CommentVM
    {
        public int PostID { get; set; }

        public string PostSubject { get; set; }

        public string CommentBody { get; set; }
    }
}
