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
        public ActionResult Cadastrar(string msg, string tipoMsg)
        {
            var viewModel = new ProfessorViewModel()
            {
                Mensagem = msg,
                TipoMensagem = tipoMsg
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Cadastrar(ProfessorViewModel profViewModel)
        {
            //var con = new PortalContext();
            //con.Professor.Add(professor);

            if (ModelState.IsValid)
            {
                var prof = new Professor()
                {
                    Nome = profViewModel.Nome,
                    Salario = profViewModel.Salario
                    
                };
                _unit.ProfessorRepository.Cadastrar(prof);
                _unit.Save();               

                return RedirectToAction("Cadastrar", new { msg = "Professor cadastrado!", tipoMsg = "alert alert-success" });
            }else
            {
                return View();
            }
            
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