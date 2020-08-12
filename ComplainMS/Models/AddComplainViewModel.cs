using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComplainMS.Models
{
    public class AddComplainViewModel
    {
        public int ComplainId { get; set; }
        

        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        public string Status { get; set; }
    }
}