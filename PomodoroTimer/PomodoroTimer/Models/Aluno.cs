//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PomodoroTimer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Rm { get; set; }
        public System.DateTime DtNascimento { get; set; }
        public int CursoId { get; set; }
    
        public virtual Curso Curso { get; set; }
    }
}