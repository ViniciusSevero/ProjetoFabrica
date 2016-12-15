using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PomodoroTimer.ViewModels
{
    public class AdministradorViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nome de Usuário")]
        [Required(ErrorMessage = "Nome de Usuário Obrigatório")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Senha Obrigatória")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 16 caracteres")]
        public string Senha { get; set; }

        public string Msg { get; set; }
    }
}