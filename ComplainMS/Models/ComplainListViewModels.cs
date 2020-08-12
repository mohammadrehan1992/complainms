using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplainMS.Models
{
    public class ComplainListViewModels
    {
        public int ComplainId { get; set; }
        public int ComplainerId { get; set; }

        public string ComplainerEmail { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}