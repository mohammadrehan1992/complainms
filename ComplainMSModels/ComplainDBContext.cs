using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplainMSModels
{
    public class ComplainDBContext : DbContext
    {
        public ComplainDBContext() : base("name=ComplainDBConnection")
        {
            Configuration.ProxyCreationEnabled = false;//this is line to be added
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Complain> Complains { get; set; }

    }

    

}
