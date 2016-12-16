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
    public class AlunoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar(string msg)
        {
            AlunoViewModel alunoVM = new AlunoViewModel()
            {
                Msg = msg,
                //Cursos e a variavel SelectList dentro do ViewModel AlunoViewModel
                Cursos = carregarCursos() //vai ser retornado uma lista de cursos
            };

            return View(alunoVM);
        }

        public ActionResult Listar()
        {
            return View();
        }

        [HttpGet]
        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult GetAlunos()
        {

            List<Aluno> alunos = (List<Aluno>)_unit.AlunoRepository.Listar();
            List<Object> lista = new List<object>();
            foreach (var aluno in alunos)
            {
                lista.Add(new
                {
                    Rm = aluno.Rm,
                    Nome = aluno.Nome,
                    Curso = aluno.Curso.Nome
                });
            }
            return Json(new { lista = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCursos()
        {

            List<Curso> cursos = (List<Curso>)_unit.CursoRepository.Listar();
            List<Object> lista = new List<object>();
            foreach (var curso in cursos)
            {
                lista.Add(new
                {
                    Nome = curso.Nome,
                    QtdeAlunos = curso.Aluno.Count
                });
            }
            return Json(new { lista = lista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Cadastrar(AlunoViewModel alunoVM)
        {
            //Se View Model valido
            if (ModelState.IsValid)
            {
                //Objeto aluno recebe dados do viewmodel
                Aluno a = new Aluno()
                {
                    CursoId = alunoVM.CursoId,
                    DtNascimento = alunoVM.DtNascimento,
                    Nome = alunoVM.Nome,
                    Rm = alunoVM.Rm
                };
                //cadastrar Aluno
                _unit.AlunoRepository.Cadastrar(a);
                //Salvar
                _unit.Save();

                
                 //redirecionar para Cadastrar   
                return RedirectToAction("Cadastrar", new { msg = "Aluno cadastrado com sucesso" });

            }else {
                //Seão for validado, devolve a lista de Cursos
                alunoVM.Cursos = carregarCursos();
                return View(alunoVM);
            }
        }

        #region UTILS
        //Método para retornar lista de cursos
        public SelectList carregarCursos()
        {
            //Listar cursos, Id e Nome do curso
            SelectList lista = new SelectList(_unit.CursoRepository.Listar(), "Id", "Nome");
            return lista;
        }
        #endregion

        #region AJAX
        public ActionResult VerificarRM(int rm)
        {
            //retorna true se existir RM no banco de dados
            bool jaExiste = _unit.AlunoRepository.BuscarPor(c => c.Rm == rm).Any();
            //retorna json existe
            return Json(new { existe = jaExiste }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
