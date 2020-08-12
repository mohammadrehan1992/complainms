using ComplainMSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplainMSDAL.CoreRepositories
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        private ComplainDBContext _dbContext
        {
            get { return _dbContext as ComplainDBContext; }
        }

        public LoginRepository(ComplainDBContext dbContext) : base(dbContext)
        {

        }
    } 
    
}
