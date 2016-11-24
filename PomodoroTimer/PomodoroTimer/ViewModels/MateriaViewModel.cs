using PomodoroTimer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroTimer.ViewModels
{
    public class MateriaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome da Matéria Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Selecione um Curso")]
        public int CursoId { get; set; }

        //msg
        public string Msg { get; set; }

        //lista de cursos
        public SelectList Cursos { get; set; }
    }
}