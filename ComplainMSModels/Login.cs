using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplainMSModels
{
    
    public class Login
    {
        public Login()
        {
            Complains = new List<Complain>();
        }

        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVerson { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }


        public ICollection<Complain> Complains { get; set; }

    }
}
