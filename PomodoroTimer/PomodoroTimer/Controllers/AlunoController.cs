﻿using PomodoroTimer.Models;
using PomodoroTimer.UnitsOfWork;
using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroTimer.Controllers
{
    public class AlunoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar(string msg)
        {
            AlunoViewModel alunoVM = new AlunoViewModel()
            {
                Msg = msg,
                Cursos = carregarCursos()
            };

            return View(alunoVM);
        }

        [HttpPost]
        public ActionResult Cadastrar(AlunoViewModel alunoVM)
        {
            if (ModelState.IsValid)
            {
                Aluno a = new Aluno()
                {
                    CursoId = alunoVM.CursoId,
                    DtNascimento = alunoVM.DtNascimento,
                    Nome = alunoVM.Nome,
                    Rm = alunoVM.Rm
                };
                _unit.AlunoRepository.Cadastrar(a);
                _unit.Save();

                return RedirectToAction("Cadastrar", new { msg = "Aluno cadastrado com sucesso" });
            }else {
                alunoVM.Cursos = carregarCursos();
                return View(alunoVM);
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
        public ActionResult VerificarRM(int rm)
        {
            bool jaExiste = _unit.AlunoRepository.BuscarPor(c => c.Rm == rm).Any();
            return Json(new { existe = jaExiste }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}