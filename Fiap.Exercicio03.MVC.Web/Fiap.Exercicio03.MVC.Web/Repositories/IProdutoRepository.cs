using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exercicio03.MVC.Web.Repositories
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(int id);
        Produto BuscarPorId(int id);
        ICollection<Produto> Listar();
        ICollection<Produto> BuscarPorId(Expression<Func<Produto, bool>> filtro);
    }
}
