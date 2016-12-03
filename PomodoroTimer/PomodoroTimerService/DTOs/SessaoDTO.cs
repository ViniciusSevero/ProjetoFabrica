using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimerService.DTOs
{
    public class SessaoDTO
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public int AlunoId { get; set; }
        public int MateriaId { get; set; }
        public String Observacao { get; set; }

    }
}
