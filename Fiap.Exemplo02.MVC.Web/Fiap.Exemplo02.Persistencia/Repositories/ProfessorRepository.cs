using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Fiap.Exemplo02.Dominio.Models;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(PortalContext context) : base(context)
        {

        }

        public void Promocao(decimal valor, int id)
        {
            var prof = BuscarPorId(id);
            prof.Salario += prof.Salario * valor;
        }
    }
}