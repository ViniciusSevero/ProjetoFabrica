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
    [PermissoesFiltro(Roles = "ADMIN")]
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
            if (ModelState.IsValid)
            {
                Login login = new Login()
                {
                    Username = admViewModel.Username,
                    Senha = admViewModel.Senha
                };
                ((LoginRepository)_unit.LoginRepository).CadastrarADM(login);
                _unit.Save();

                return RedirectToAction("Cadastrar", new { msg = "Administrador cadastrado com sucesso!" });
            }else
            {
                return View(admViewModel);
            }
        }
    }
}