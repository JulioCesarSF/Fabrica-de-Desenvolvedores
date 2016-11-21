using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
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
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Professor professor)
        {
            var con = new PortalContext();
            con.Professor.Add(professor);

            _unit.ProfessorRepository.Cadastrar(professor);
            _unit.Save();

            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Cadastro efetuado!";

            return View();
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