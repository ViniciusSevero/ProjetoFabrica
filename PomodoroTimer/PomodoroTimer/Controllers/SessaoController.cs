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
    [PermissoesFiltro(Roles = "ALUNO")]
    public class SessaoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        public ActionResult Index()
        {
            SessaoViewModel sessaoVM = new SessaoViewModel()
            {
                Materias = carregarMaterias(),
                TiposSessao = carregarTipos()
            };
            return View(sessaoVM);
        }

        

        #region
        public SelectList carregarTipos()
        {
            List<TipoSessao> lista = (List<TipoSessao>)_unit.TipoSessaoRepository.Listar();
            return new SelectList(lista, "Id", "Tipo");
        }
        public SelectList carregarMaterias()
        {
                var userName = User.Identity.Name;
                int loginId = _unit.LoginRepository.BuscarPor(l => l.Username == userName).FirstOrDefault().Id;
                Aluno aluno = _unit.AlunoRepository.BuscarPor(a => a.LoginId == loginId).FirstOrDefault();

                ICollection<Materia> lista = (ICollection<Materia>) aluno.Curso.Materia;
                return new SelectList(lista, "Id", "Nome"); 
        }
        #endregion

        #region AJAX
        public ActionResult PegarTempoSessao(int tipo)
        {
            var tipoSessao = _unit.TipoSessaoRepository.BuscarPorId(tipo);
            return Json(new { estudo = tipoSessao.TempoEstudo, descanso = tipoSessao.TempoDescanso }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}