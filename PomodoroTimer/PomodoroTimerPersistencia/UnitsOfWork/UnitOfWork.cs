using PomodoroTimerDominio.Models;
using PomodoroTimerPersistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PomodoroTimerPersistencia.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        private Entities _context = new Entities();

        private IRepository<Aluno> _alunoRepository;
        private IRepository<Curso> _cursoRepository;
        private IRepository<Materia> _materiaRepository;
        private IRepository<TipoSessao> _tipoSessaoRepository;
        private IRepository<Login> _loginRepository;
        private IRepository<Sessao> _sessaoRepository;

        public IRepository<Sessao> SessaoRepository
        {
            get
            {
                if (_sessaoRepository == null)
                {
                    _sessaoRepository = new GenericRepository<Sessao>(_context);
                }
                return _sessaoRepository;
            }
            set { _sessaoRepository = value; }
        }



        public IRepository<Login> LoginRepository
        {
            get
            {
                if (_loginRepository == null)
                {
                    _loginRepository = new LoginRepository(_context);
                }
                return _loginRepository;
            }
            set { _loginRepository = value; }
        }

        public IRepository<Aluno> AlunoRepository
        {
            get
            {
                if (_alunoRepository == null)
                {
                    _alunoRepository = new AlunoRepository(_context);
                }
                return _alunoRepository;
            }
            set { _alunoRepository = value; }
        }

        public IRepository<Curso> CursoRepository
        {
            get
            {
                if (_cursoRepository == null)
                {
                    _cursoRepository = new GenericRepository<Curso>(_context);
                }
                return _cursoRepository;
            }
            set { _cursoRepository = value; }
        }

        public IRepository<Materia> MateriaRepository
        {
            get
            {
                if (_materiaRepository == null)
                {
                    _materiaRepository = new GenericRepository<Materia>(_context);
                }
                return _materiaRepository;
            }
            set { _materiaRepository = value; }
        }

        public IRepository<TipoSessao> TipoSessaoRepository
        {
            get
            {
                if (_tipoSessaoRepository == null)
                {
                    _tipoSessaoRepository = new GenericRepository<TipoSessao>(_context);
                }
                return _tipoSessaoRepository;
            }
            set { _tipoSessaoRepository = value; }
        }


        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);//manda o GarbageCollector destruir esse objeto
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}