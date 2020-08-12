using ComplainMSDAL;
using ComplainMSDAL.CoreRepositories;
using ComplainMSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplainMSService
{

    public interface IComplainService
    {
        /// <summary>
        /// Used to fetch all complains
        /// </summary>
        /// <returns></returns>
        IEnumerable<Complain> GetComplains();

        /// <summary>
        /// This function is used to add complain
        /// </summary>
        /// <param name="complain">It takes complain object containing title,description</param>
        /// <returns></returns>
        int AddComplain(Complain complain);
    }
    public class ComplainService : IComplainService
    {
        IComplainRepository complainRepository = null;
        ComplainDBContext _dbContext = null;
        public ComplainService()
        {
            _dbContext = new ComplainDBContext();
            this.complainRepository = new ComplainRepository(_dbContext);
        }
        public IEnumerable<Complain> GetComplains()
        {
            return complainRepository.GetAll();
        }

        public int AddComplain(Complain complain)
        {
            complain.CreatedDate = DateTime.Now;
            complain.UpdatedDate = DateTime.Now;
            complain.IsActive = true;
            complainRepository.Add(complain);
            return _dbContext.SaveChanges();
        }

    }
}
