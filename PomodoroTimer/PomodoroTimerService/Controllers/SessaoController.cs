using PomodoroTimerDominio.Models;
using PomodoroTimerPersistencia.UnitsOfWork;
using PomodoroTimerService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PomodoroTimerService.Controllers
{
    public class SessaoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public IHttpActionResult Post(SessaoDTO sessaoDTO)
        {
            if (ModelState.IsValid)
            {
                Sessao sessao = new Sessao()
                {
                    AlunoId = sessaoDTO.AlunoId,
                    MateriaId = sessaoDTO.MateriaId,
                    TipoId = sessaoDTO.TipoId,
                    Observacao = sessaoDTO.Observacao
                };


                _unit.SessaoRepository.Cadastrar(sessao);
                _unit.Save();

                var uri = Url.Link("DefaultApi", new { id = sessao.Id });
                return Created<Sessao>(new Uri(uri), sessao);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        public ICollection<Sessao> Get()
        {
            return _unit.SessaoRepository.Listar();
        }
    }
}
