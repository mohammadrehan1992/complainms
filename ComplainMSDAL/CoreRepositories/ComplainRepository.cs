using ComplainMSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ComplainMSDAL.CoreRepositories
{
    public class ComplainRepository : Repository<Complain>, IComplainRepository
    {
        private ComplainDBContext _dbContext
        {
            get { return _dbContext as ComplainDBContext; }
        }

        public ComplainRepository(ComplainDBContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Complain> GetComplains()
        {
            return GetAll();
        }

        
    } 
    
}
