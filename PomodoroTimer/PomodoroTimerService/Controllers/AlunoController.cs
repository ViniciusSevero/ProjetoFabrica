using PomodoroTimerDominio.Models;
using PomodoroTimerPersistencia.UnitsOfWork;
using PomodoroTimerService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PomodoroTimerService.Controllers
{
    public class AlunoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Aluno
        public ICollection<AlunoDTO> Get(string param)
        {
            ICollection<AlunoDTO> listaFiltrada = new List<AlunoDTO>();
            List<Aluno> temp = null;

            if (param == null)
            {
               temp = (List<Aluno>) _unit.AlunoRepository.Listar();
            }else
            {
                try
                {
                    int idORrm = Convert.ToInt32(param);
                    temp = (List<Aluno>) _unit.AlunoRepository.BuscarPor(a => a.Id == idORrm || a.Rm == idORrm);
                }
                catch
                {
                    string nome = param;
                    temp = (List<Aluno>) _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nome));
                }
              
            }

            foreach(var aluno in temp)
            {
                listaFiltrada.Add(new AlunoDTO()
                {
                    Id = aluno.Id,
                    Rm = aluno.Rm,
                    Nome = aluno.Nome
                });
            }

            return listaFiltrada;
            
        }
    }
}