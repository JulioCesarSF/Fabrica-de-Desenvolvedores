using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Fields
        private PortalContext _context = new PortalContext();

        //private IAlunoRepository _alunoRepository;
        //private IGrupoRepository _grupoRepository;
        //private IProjetoRepository _projetoRepository;
        private IGenericRepository<Projeto> _projetoRepository;
        private IGenericRepository<Grupo> _grupoRepository;
        private IGenericRepository<Aluno> _alunoRepository;
       // private IGenericRepository<Professor> _professorRepository;
        private IProfessorRepository _professorRepository;

        #endregion
        #region Gets
        public IProfessorRepository ProfessorRepository
        {
            get
            {
                if(_professorRepository == null)
                {
                    _professorRepository = new ProfessorRepository(_context);
                }

                return _professorRepository;
            }
            set { _professorRepository = value; }
        }      

        public IGenericRepository<Projeto> ProjetoRepository
        {
            get
            {
                if(_projetoRepository == null)
                {
                    _projetoRepository = new GenericRepository<Projeto>(_context);
                }
                return _projetoRepository;
            }
            set { _projetoRepository = value; }
        }


        public IGenericRepository<Grupo> GrupoRepository
        {
            get
            {
                if(_grupoRepository == null)
                {
                    _grupoRepository = new GenericRepository<Grupo>(_context);
                }
                return _grupoRepository;
            }
            set { _grupoRepository = value; }
        }


        public IGenericRepository<Aluno> AlunoRepository
        {
            get
            {
                if (_alunoRepository == null)
                {
                    _alunoRepository = new GenericRepository<Aluno>(_context);
                }
                return _alunoRepository;
            }
            set { _alunoRepository = value; }
        }

        #endregion
        #region Dispose
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
        #region Save
        public void Save()
        {           
           _context.SaveChanges();
        }
        #endregion
    }
}
