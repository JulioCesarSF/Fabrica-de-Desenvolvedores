using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using Fiap.Exemplo02.MVC.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class ProfessorController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar(ProfessorViewModel professorViewModel)
        {
            return View(professorViewModel);
        }

        [HttpPost]
        public ActionResult Cadastrar(Professor professor)
        {
            //var con = new PortalContext();
            //con.Professor.Add(professor);

            _unit.ProfessorRepository.Cadastrar(professor);
            _unit.Save();

            var viewModel = new ProfessorViewModel()
            {
                Mensagem = "Professor cadastrado!",
                TipoMensagem = "alert alert-success"
            };            

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //var con = new PortalContext();
            //var _lista = con.Professor.ToList();
            return View(_unit.ProfessorRepository.Listar());
        }
    }
}