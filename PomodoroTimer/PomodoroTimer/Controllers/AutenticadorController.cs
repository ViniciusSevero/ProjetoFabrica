using Filtros.Security;
using PomodoroTimer.ViewModels;
using PomodoroTimerDominio.Models;
using PomodoroTimerPersistencia.Repositories;
using PomodoroTimerPersistencia.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PomodoroTimer.Controllers
{
    public class AutenticadorController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Logar(string msg)
        {
            return View(new LoginViewModel() { Msg = msg});
        }

        [HttpPost]
        public ActionResult Logar(LoginViewModel login)
        {
            LoginRepository loginRepository = (LoginRepository) _unit.LoginRepository;
            Login l = loginRepository.ValidarLogin(login.Username, login.Senha);

            if (l != null)
            {
              
                if (l.Permissao.Select(p => p.Permissao1 == "ADMIN").Single())
                {
                    Session["TipoUsuario"] = "ADMIN";
                    return RedirectToAction("Cadastrar", "Aluno");
                }
                else
                {
                    Session["TipoUsuario"] = "ALUNO";
                    return RedirectToAction("Index", "Sessao");
                }
               
            }else
            {
                return RedirectToAction("Logar", new { msg = "Usuário e/ou senha inválidos"});
            }
            
        }

        [HttpGet]
        public ActionResult Sair()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Logar");
        }

        [HttpGet]
        public ActionResult Negado()
        {
            return View();
        }
    }
}