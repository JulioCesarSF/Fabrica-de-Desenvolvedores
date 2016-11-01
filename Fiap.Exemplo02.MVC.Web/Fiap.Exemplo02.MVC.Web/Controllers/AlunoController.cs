using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Cadastrado com sucesso";
            var context = new PortalContext();
            context.Aluno.Add(aluno);
            context.SaveChanges();
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            IList<Aluno> _lista = new PortalContext().Aluno.ToList();
            return View(_lista);
        }

        [HttpPost]
        public ActionResult Excluir()
        {
            var context = new PortalContext();
            Aluno a = context.Aluno.Find("Id");
            context.Aluno.Remove(a);
            context.SaveChanges();
           // IList<Aluno> _lista = new PortalContext().Aluno.ToList();
            return RedirectToAction("Listar");
        }
               
    }
}