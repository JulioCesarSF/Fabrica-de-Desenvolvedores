using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class ProfessorController : Controller
    {
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
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Cadastro efetuado!";

            return View();
        }

        [HttpGet]
        public ActionResult Lista()
        {
            var con = new PortalContext();
            var _lista = con.Professor.ToList();
            return View(_lista);
        }
    }
}