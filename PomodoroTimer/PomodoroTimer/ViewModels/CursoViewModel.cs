using PomodoroTimerDominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PomodoroTimer.ViewModels
{
    public class CursoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do Curso Obrigatório")]
        public string Nome { get; set; }

        //Msg
        public string Msg { get; set; }

        //Se precisar listar 
        public virtual ICollection<Aluno> Aluno { get; set; }
        public virtual ICollection<Materia> Materia { get; set; }
    }
}