using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IAlunoRepository
    {
        void Cadastrar(Aluno aluno);
        void Atualizar(Aluno aluno);
        void Remover(int id);
        Aluno BuscarPorId(int id);       
        ICollection<Aluno> Listar();
        ICollection<Aluno> BuscarPor(Expression<Func<Aluno, bool>> filtro);
    }
}
