using PomodoroTimerDominio.Models;
using PomodoroTimerPersistencia.UnitsOfWork;
using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroTimer.Controllers
{
    public class TipoSessaoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar(string msg)
        {
            TipoSessaoViewModel tipoSessaoVM = new TipoSessaoViewModel()
            {
                Msg = msg
            };
            return View(tipoSessaoVM);
        }

        [HttpPost]
        public ActionResult Cadastrar(TipoSessaoViewModel tipoSessaoVM)
        {
            if (ModelState.IsValid) {
                TipoSessao tipoSessao = new TipoSessao()
                {
                    Duracao = tipoSessaoVM.Duracao,
                    TempoDescanso = tipoSessaoVM.TempoDescanso,
                    TempoEstudo = tipoSessaoVM.TempoEstudo,
                    Tipo = tipoSessaoVM.Tipo
                };

                _unit.TipoSessaoRepository.Cadastrar(tipoSessao);
                _unit.Save();
                
                return RedirectToAction("Cadastrar", new { msg = "Tipo de Sessão Cadastrado com sucesso!" });
            }else
            {
                return View(tipoSessaoVM);
            }
        }
    }
}