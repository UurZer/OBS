using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Business.LoginManager
{
    public interface ILoginManager
    {
        bool IsLoginSuccess(string user, string password);
    }
}
