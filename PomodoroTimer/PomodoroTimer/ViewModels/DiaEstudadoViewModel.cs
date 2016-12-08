using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PomodoroTimer.ViewModels
{
    public class DiaEstudadoViewModel
    {
        public int DiaEstudado { get; set; }
        public double Minutos { get; set; } //pra fazer a média
    }
}