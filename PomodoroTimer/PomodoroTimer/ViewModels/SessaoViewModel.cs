using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PomodoroTimer.ViewModels
{
    public class SessaoViewModel
    {
        [Display(Name = "Tipo da Sessão")]
        public int TipoId { get; set; }
        //provavelmente vou pegar o aluno pela sessão
        public int AlunoId { get; set; }
        [Display(Name = "Matéria")]
        public int MateriaId { get; set; }
        public String Observacao { get; set; }

        public SelectList TiposSessao { get; set; }
        public SelectList Materias { get; set; }

        public string Msg { get; set; }
    }
}