using Fiap.Exercicio03.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exercicio03.MVC.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoContext pContext = new ProdutoContext();

        /// <summary>
        /// Action/Método para mostrar a View de cadastro de produto
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            pContext.Produto.Add(produto);
            pContext.SaveChanges();
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Produto cadastrado!";
            return RedirectToAction("Cadastrar");
        }
    }
}