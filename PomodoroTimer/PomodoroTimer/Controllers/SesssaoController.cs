using PomodoroTimer.Models;
using PomodoroTimer.UnitsOfWork;
using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroTimer.Controllers
{
    public class SesssaoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Sesssao
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
            //vou pegar as materias do curso do Aluno logado
            //agora é só Mock
            List<Materia> lista = (List<Materia>)_unit.MateriaRepository.Listar();
            return new SelectList(lista, "Id", "Nome");
        }
        #endregion
    }
}