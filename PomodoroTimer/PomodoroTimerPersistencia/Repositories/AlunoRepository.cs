using PomodoroTimerDominio.Models;
using PomodoroTimerPersistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PomodoroTimerPersistencia.Repositories
{
    public class AlunoRepository : GenericRepository<Aluno>, IRepository<Aluno>
    {
        private Entities _ctx;

        public AlunoRepository(Entities context) : base(context)
        {
            _ctx = context;
        }

        public override void Cadastrar(Aluno aluno)
        {
            Permissao permissaoALuno = new GenericRepository<Permissao>(_ctx).BuscarPor(p => p.Permissao1 == "ALUNO").FirstOrDefault();
            List<Permissao> permissoes = new List<Permissao>();
            permissoes.Add(permissaoALuno);

            Login login = new Login()
            {
                Username = "RM" + aluno.Rm,
                Senha = aluno.DtNascimento.ToString("ddMMyy"),
                Permissao = permissoes
            };
            new GenericRepository<Login>(_ctx).Cadastrar(login);

            aluno.LoginId = login.Id;

            base.Cadastrar(aluno);
        }
    }
}