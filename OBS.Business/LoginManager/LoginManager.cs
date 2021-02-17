using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using OBS.DAL.Orm.EFCore;
using OBS.Entities.Tables;
using System.Web;

namespace OBS.Business.LoginManager
{
    public class LoginManager :ILoginManager
    {
        private readonly IObsRepository<Login> _repository;

        public LoginManager(IObsRepository<Login> repository)
        {
            _repository = repository;
        }
        public bool IsLoginSuccess(string user, string password)
        {
            Login resultUser =_repository.Get().Where(x => x.Password.Equals(password) && x.UserName.Equals(user)).FirstOrDefault();

            if (resultUser!=null )
            {
                resultUser.LastLogin =  DateTime.Now;
                _repository.Update(resultUser);
                return true;
            }
            return false;
        }
    }
}
