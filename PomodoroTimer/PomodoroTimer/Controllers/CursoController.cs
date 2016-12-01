using PomodoroTimerDominio.Models;
using PomodoroTimerPersistencia.UnitsOfWork;
using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filtros.Security;

namespace PomodoroTimer.Controllers
{
    [PermissoesFiltro(Roles = "ADMIN")]
    public class CursoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar(string msg)
        {
            CursoViewModel cursoVM = new CursoViewModel()
            {
                Msg = msg
            };

            return View(cursoVM);
        }

        [HttpPost]
        public ActionResult Cadastrar(CursoViewModel cursoVM)
        {
            if (ModelState.IsValid)
            {
                Curso c = new Curso()
                {
                    Nome = cursoVM.Nome
                };
                _unit.CursoRepository.Cadastrar(c);
                _unit.Save();

                return RedirectToAction("Cadastrar", new { msg = "Curso cadastrado com sucesso!" });
            }else
            {
                return View(cursoVM);
            }
        }

        #region AJAX
        public ActionResult VerificarNome(string nome)
        {
            bool jaExiste = _unit.CursoRepository.BuscarPor(c => c.Nome == nome).Any();
            return Json(new { existe = jaExiste }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}