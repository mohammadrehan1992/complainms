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
    public interface ILoginService
    {
        Login GetLogin(string email,string password);
    }
    public class LoginService : ILoginService
    {
        ILoginRepository loginRepository = null;
        ComplainDBContext _dbContext = null;
        public LoginService()
        {
            _dbContext = new ComplainDBContext();
            this.loginRepository = new LoginRepository(_dbContext);
        }
        public Login GetLogin(string email, string password)
        {
            var user = loginRepository.Find(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();
            return user;
        }
    }
}
