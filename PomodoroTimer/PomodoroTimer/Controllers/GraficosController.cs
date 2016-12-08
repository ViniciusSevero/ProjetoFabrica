﻿using PomodoroTimer.ViewModels;
using PomodoroTimerDominio.Models;
using PomodoroTimerPersistencia.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroTimer.Controllers
{
    public class GraficosController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Graficos
        [HttpGet]
        public ActionResult MinutosMensalAluno()
        {
            TempData["Aluno"] = getAlunoLoginSessao().Nome;
            return View();
        }


        public Aluno getAlunoLoginSessao()
        {
            var userName = User.Identity.Name;
            int loginId = _unit.LoginRepository.BuscarPor(l => l.Username == userName).FirstOrDefault().Id;
            return _unit.AlunoRepository.BuscarPor(a => a.LoginId == loginId).FirstOrDefault();
        }

        #region AJAX
        [HttpGet]
        public ActionResult GetMediaMensalAluno()
        {
            ICollection<Sessao> sessoes = (ICollection<Sessao>)_unit.SessaoRepository.Listar();
            var query =
                from sessao in sessoes
                where sessao.Data.Value.Month == DateTime.Now.Month && sessao.AlunoId == getAlunoLoginSessao().Id
                group sessao by sessao.Data.Value.Day into grupo
                orderby grupo.Key
                select new
                {
                    dia = grupo.Key, //dia a ser agrupado
                    grupos = grupo //lista com as sessoes agrupadas por dia
                };

            List<DiaEstudadoViewModel> listaFiltrada = new List<DiaEstudadoViewModel>();
            //itero sobre os grupos criados
            foreach (var grupo in query)
            {
                int tempoEstudo = 0;
                int dia = grupo.dia;
                foreach (var sessao in grupo.grupos)//itero sobre as sessoes dos grupos
                {
                    tempoEstudo += sessao.TipoSessao.TempoEstudo;
                }

                listaFiltrada.Add(new DiaEstudadoViewModel { DiaEstudado = dia, Minutos = tempoEstudo });
            }

            return Json(new { listaAluno = listaFiltrada, listaMedias = GetMediaAritmeticaMensal() }, JsonRequestBehavior.AllowGet);
        }



        #endregion

        #region UTILS
        [HttpGet]
        public List<DiaEstudadoViewModel> GetMediaAritmeticaMensal()
        {
            ICollection<Sessao> sessoes = (ICollection<Sessao>)_unit.SessaoRepository.Listar();
            var query =
                from sessao in sessoes
                where sessao.Data.Value.Month == DateTime.Now.Month
                group sessao by sessao.Data.Value.Day into grupo
                orderby grupo.Key
                select new
                {
                    dia = grupo.Key, //dia a ser agrupado
                    grupos = grupo //lista com as sessoes agrupadas por dia
                };

            List<DiaEstudadoViewModel> listaMedias = new List<DiaEstudadoViewModel>();
            //itero sobre os grupos criados
            foreach (var grupo in query)
            {
                double tempoTotal = 0;
                int dia = grupo.dia;
                foreach (var sessao in grupo.grupos)//itero sobre as sessoes dos grupos
                {
                    tempoTotal += sessao.TipoSessao.TempoEstudo;
                }
                double tempoEstudo = tempoTotal / _unit.AlunoRepository.Listar().Count; //divide por todos os alunos

                listaMedias.Add(new DiaEstudadoViewModel { DiaEstudado = dia, Minutos = tempoEstudo });
            }

            return listaMedias;
        }
        #endregion

    }


}