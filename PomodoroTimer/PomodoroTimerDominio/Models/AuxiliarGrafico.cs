using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PomodoroTimerDominio.Models
{
    public class AuxiliarGrafico
    {
        public int UnidadeDeGrupoEstudada { get; set; } //Mes ou dia
        public double Minutos { get; set; } //pra fazer a média
    }
}