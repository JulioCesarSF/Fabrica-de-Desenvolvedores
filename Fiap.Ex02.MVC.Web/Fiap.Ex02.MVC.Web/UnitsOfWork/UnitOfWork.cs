using Fiap.Ex02.MVC.Web.Models;
using Fiap.Ex02.MVC.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.Ex02.MVC.Web.UnitsOfWork
{
    public class UnitOfWork
    {

        #region FIELDS
        private PortalContext _context = new PortalContext();
        private IGenericRepository<Projeto> _projetoRepository;
        private IGenericRepository<Grupo> _grupoRepository;
        private IGenericRepository<Professor> _professorRepository;
        private IGenericRepository<Aluno> _alunoRepository;
        #endregion

        #region GETS

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
                if (_grupoRepository == null)
                {
                    _grupoRepository = new GenericRepository<Grupo>(_context);
                }
                return _grupoRepository;
            }
            set { _grupoRepository = value; }
        }
        public IGenericRepository<Professor> ProfessorRepository
        {
            get
            {
                if (_professorRepository == null)
                {
                    _professorRepository = new GenericRepository<Professor>(_context);
                }
                return _professorRepository;
            }
            set { _professorRepository = value; }
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

        #region DISPOSE
        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
        #endregion

        #region SAVE
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion

    }
}