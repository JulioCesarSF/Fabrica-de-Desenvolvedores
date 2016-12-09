using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fiap.Exemplo02.MVC.Web.Repositories;
using Fiap.Exemplo02.Dominio.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

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

            //Assert.AreNotEqual(aluno.Id, 0); verificar se um Id foi gerado no banco
        }

        [TestMethod]//DbEntityValidationException
        [ExpectedException(typeof(DbEntityValidationException))]
        public void Cadastro_Professor_Exception()
        {
            //nome é obrigatório
            var prof = new Professor()
            {                
                Salario = 2132
            };
            _repository.Cadastrar(prof);
            int r = _context.SaveChanges();
            //Assert.AreEqual(1, r);

            //Assert.AreNotEqual(aluno.Id, 0); verificar se um Id foi gerado no banco
        }

        [TestMethod]
        public void Cadastro_controller()
        {

        }
    }
}
