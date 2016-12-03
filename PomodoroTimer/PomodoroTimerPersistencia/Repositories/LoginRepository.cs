using PomodoroTimerDominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PomodoroTimerPersistencia.Repositories
{
    public class LoginRepository : GenericRepository<Login>, IRepository<Login>
    {
        private Entities _ctx;

        public LoginRepository(Entities context) :base(context)
        {
            _ctx = context;       
        }

        public Login ValidarLogin(string user, string senha)
        {
            Login login = _ctx.Login.Where(l => l.Username == user && l.Senha == senha).FirstOrDefault();

            if(login == null)
            {
                return null;
            }

            FormsAuthentication.SetAuthCookie(login.Username, false);

            return login;
        }
    }
}