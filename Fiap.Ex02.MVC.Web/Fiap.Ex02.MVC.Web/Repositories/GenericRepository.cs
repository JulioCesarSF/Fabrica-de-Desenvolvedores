using Fiap.Ex02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Fiap.Ex02.MVC.Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected PortalContext _context;
        protected DbSet<T> _dbset;

        public GenericRepository(PortalContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public void Alterar(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro)
        {
            return _dbset.Where(filtro).ToList();
        }       

        public T BuscarPorId(int id)
        {
            return _dbset.Find(id);
        }

        public void Cadastrar(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Added;
        }

        public ICollection<T> Listar()
        {
            return _dbset.ToList();
        }

        public void Remover(int id)
        {
            _dbset.Remove(BuscarPorId(id));
        }
    }
}