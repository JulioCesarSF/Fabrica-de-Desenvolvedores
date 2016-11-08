using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class GrupoRepository : IGrupoRepository
    {
        private PortalContext _context;

        public GrupoRepository(PortalContext context)
        {
            _context = context;
        }
        public void Atualizar(Grupo grupo)
        {
            throw new NotImplementedException();
        }

        public ICollection<Grupo> BuscarPor(Expression<Func<Grupo, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public Grupo BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Grupo grupo)
        {
            throw new NotImplementedException();
        }

        public ICollection<Grupo> Listar()
        {
            return _context.Grupo.ToList();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}