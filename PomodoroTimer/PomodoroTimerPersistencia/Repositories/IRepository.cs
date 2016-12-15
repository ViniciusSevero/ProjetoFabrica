using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimerPersistencia.Repositories
{
    public interface IRepository<T>
    {
        void Cadastrar(T t);
        void Atualizar(T t);
        void Remover(int id);
        T BuscarPorId(int id);
        ICollection<T> Listar();
        ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro);
    }
}
