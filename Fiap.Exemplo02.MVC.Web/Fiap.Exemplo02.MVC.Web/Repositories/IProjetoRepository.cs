using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IProjetoRepository
    {
        void Cadastrar(Projeto aluno);
        void Atualizar(Projeto aluno);
        void Remover(int id);
        Projeto BuscarPorId(int id);
        ICollection<Projeto> Listar();
        ICollection<Projeto> BuscarPor(Expression<Func<Projeto, bool>> filtro);
    }
}
