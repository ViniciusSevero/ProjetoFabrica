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


        #region AJAX
        public ActionResult ValidarLogin(string username, string senha)
        {
            //retorna true se existir login no banco de dados
            //retorna true se existir senha no banco de dados

            bool usernameOk = _unit.LoginRepository.BuscarPor(l => l.Username == username).Any();
            bool senhaOk = _unit.LoginRepository.BuscarPor(l => l.Senha == senha).Any();

            
            //retorna json existe
            return Json(new { username = usernameOk, senha = senhaOk }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        
        [HttpPost]
        public ActionResult Logar(LoginViewModel login)
        {
            //conflito 2 repository
            LoginRepository loginRepository = (LoginRepository) _unit.LoginRepository;
            
            //Validar nome consta Repositories/LoginRepository.cs, retorna objeto login, caso exista
            Login l = loginRepository.ValidarLogin(login.Username, login.Senha);

            if (l != null)//Se cliente localizado
            {
                //Se permissao == a ADMIN
                if (l.Permissao.Select(p => p.Permissao1 == "ADMIN").Single())
                {
                    //sessao tipo de usuario recebe Admin
                    Session["TipoUsuario"] = "ADMIN";
                    //redirecionar pagina para controller Aluno, Cadastrar, #corrigir
                    return RedirectToAction("Cadastrar", "Aluno");
                }
                else
                {
                    //Sessao tipousuario recebe aluno
                    Session["TipoUsuario"] = "ALUNO";
                    //Sessao Nome recebe , nome do aluno
                    Session["Nome"] = l.Aluno.First().Nome;
                    //redirezionar para a Index do controller sessao
                    return RedirectToAction("Index", "Sessao");
                }
               
            }
            
            else
            {
                //Se usuario e login estiverem incorretos, redirecionar para action Logar com a mensagem abaixo
                return RedirectToAction("Logar");
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
