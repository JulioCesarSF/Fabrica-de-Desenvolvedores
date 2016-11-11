using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        void Promocao(double valor);
    }
}
