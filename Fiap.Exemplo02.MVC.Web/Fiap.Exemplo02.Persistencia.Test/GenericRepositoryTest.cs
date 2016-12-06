using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fiap.Exemplo02.MVC.Web.Repositories;
using Fiap.Exemplo02.Dominio.Models;

namespace Fiap.Exemplo02.Persistencia.Test
{
    [TestClass]
    public class GenericRepositoryTest
    {
        private GenericRepository<Professor> _repository;
        private PortalContext _context;

        [TestInitialize]
        public void Inicializacao()
        {
            //Inicializar objetos
            _context = new PortalContext();
            _repository = new GenericRepository<Professor>(_context);
        }

        /*
        No caso do Aluno, cadastrar um grupo dentro do teste também
        */

        [TestMethod]
        public void Cadastro_Professor_Ok()
        {
            var prof = new Professor()
            {
                Nome = "Professor Test",
                Salario = 2132
            };
            _repository.Cadastrar(prof);
            int r = _context.SaveChanges();
            Assert.AreEqual(1, r);
        }
    }
}
