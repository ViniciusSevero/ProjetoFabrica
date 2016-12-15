using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PomodoroTimer.ViewModels
{
    public class TipoSessaoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tipo da sessão Obrigatório")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Duração da sessão Obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite apenas números inteiros")]
        [Display(Name = "Duração")]
        public int Duracao { get; set; }
        [Required(ErrorMessage = "Tempo de estudo da sessão Obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite apenas números inteiros")]
        [Display(Name = "Tempo de Estudo")]
        public int TempoEstudo { get; set; }
        [Required(ErrorMessage = "Tempo de descanso da sessão Obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite apenas números inteiros")]
        [Display(Name = "Tempo de Descanso")]
        public int TempoDescanso { get; set; }

        public string Msg { get; set; }
    }
}