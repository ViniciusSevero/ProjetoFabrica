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

namespace PomodoroTimer.Controllers
{
    //[PermissoesFiltro(Roles = "ADMIN")]
    public class AdministradorController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar(String msg)
        {
            AdministradorViewModel admViewModel = new AdministradorViewModel()
            {
               Msg = msg
            };
            return View(admViewModel);
        }

        [HttpPost]
        public ActionResult Cadastrar(AdministradorViewModel admViewModel)
        {
            //Se validação ok
            if (ModelState.IsValid)
            {
            //Passando os dados do view admViewModel para o modelo Login
                Login login = new Login()
                {
                    Username = admViewModel.Username,
                    Senha = admViewModel.Senha
                };
                //CadastrarADm do login repositorio, cadasto no banco na tabela Login
                ((LoginRepository)_unit.LoginRepository).CadastrarADM(login);
                _unit.Save();
                //redirecionar para a View Cadastrar
                return RedirectToAction("Cadastrar", new { msg = "Administrador cadastrado com sucesso!" });
            }else
            {
                return View(admViewModel);
            }
        }
    }
}
