using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fiap.Exemplo02.MVC.Web.Controllers;
using Fiap.Exemplo02.MVC.Web.ViewModels;
using System.Web.Mvc;

namespace Fiap.Exemplo02.Web.Test
{
    [TestClass]
    public class ProfessorControllerTest
    {
        [TestMethod]
        public void Cadastrar_Get()
        {
            ProfessorController controller = new ProfessorController();
            var result = (ViewResult)controller.Cadastrar("teste", "teste");
            Assert.IsNotNull(result);            
        }

        [TestMethod]
        public void Cadastrar_Post()
        {
            ProfessorController pC = new ProfessorController();
            var professor = new ProfessorViewModel()
            {
                Nome = "Teste",
                Salario = 1234
            };

            var result = pC.Cadastrar(professor);
            Assert.IsNotNull(result);

           // var modelResultado = result.Model as ProfessorViewModel;
           // Assert.AreEqual(modelResultado.Mensagem, "Professor cadastrado!");
        }
    }
}
