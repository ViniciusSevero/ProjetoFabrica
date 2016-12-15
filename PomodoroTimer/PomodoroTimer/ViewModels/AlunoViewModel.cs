using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroTimer.ViewModels
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "RM Obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite apenas números inteiros")]
        public int Rm { get; set; }
        [Required(ErrorMessage = "Data de Nascimento Obrigatório")]
       // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime DtNascimento { get; set; }
        [Required(ErrorMessage = "Selecione um Curso")]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }

        public string Msg { get; set; }

        public SelectList Cursos { get; set; }
    }
}