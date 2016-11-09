using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Fiap.Exemplo02.MVC.Web.Models;
using System.Data.Entity;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private PortalContext _context;

        public ProjetoRepository(PortalContext _context)
        {
            this._context = _context;
        }

        public void Atualizar(Projeto projeto)
        {
            _context.Entry(projeto).State = EntityState.Modified;
        }

        public ICollection<Projeto> BuscarPor(Expression<Func<Projeto, bool>> filtro)
        {
            return _context.Projeto.Where(filtro).ToList();
        }

        public Projeto BuscarPorId(int id)
        {
            return _context.Projeto.Find(id);
        }

        public void Cadastrar(Projeto projeto)
        {
            _context.Entry(projeto).State = EntityState.Added;
        }

        public ICollection<Projeto> Listar()
        {
            return _context.Projeto.ToList();
        }

        public void Remover(int id)
        {
            _context.Entry(BuscarPorId(id)).State = EntityState.Deleted;
        }
    }
}