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
    public class MateriaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar(string msg)
        {
            MateriaViewModel materiaVM = new MateriaViewModel()
            {
                Cursos = carregarCursos(),
                Msg = msg
            };

            return View(materiaVM);
        }
        [HttpPost]
        public ActionResult Cadastrar(MateriaViewModel materiaVM)
        {
            if (ModelState.IsValid)
            {
                Materia m = new Materia()
                {
                   Nome = materiaVM.Nome,
                   CursoId = materiaVM.CursoId
                };

                _unit.MateriaRepository.Cadastrar(m);
                _unit.Save();

                return RedirectToAction("Cadastrar", new { msg = "Matéria cadastrada com sucesso" });
            }else
            {
                materiaVM.Cursos = carregarCursos();
                return View(materiaVM);
            }
        }

        #region UTILS
        public SelectList carregarCursos()
        {
            SelectList lista = new SelectList(_unit.CursoRepository.Listar(), "Id", "Nome");
            return lista;
        }
        #endregion

        #region AJAX
        public ActionResult VerificarNome(string nome, int cursoId)
        {
            bool jaExiste = _unit.MateriaRepository.BuscarPor(c => c.Nome == nome && c.CursoId == cursoId).Any();
            return Json(new { existe = jaExiste }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}