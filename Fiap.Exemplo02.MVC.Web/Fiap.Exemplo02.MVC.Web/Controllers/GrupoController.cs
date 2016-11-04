using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Grupo grupo)
        {
            var con = new PortalContext();
            con.Grupo.Add(grupo);
            con.SaveChanges();
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Cadastrado com sucesso!";
            return View();
        }

        public ActionResult Listar()
        {
            var con = new PortalContext();
            var l = con.Grupo.ToList();
            return View(l);
        }
    }
}