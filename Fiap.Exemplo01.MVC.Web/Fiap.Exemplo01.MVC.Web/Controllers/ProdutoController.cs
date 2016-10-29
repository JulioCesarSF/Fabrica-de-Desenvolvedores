using Fiap.Exemplo01.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo01.MVC.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private static IList<Produto> _lista = new List<Produto>();
        //assinatura padrao public ActionResult
        [HttpGet]
        public ActionResult Listar()
        {
            return View(_lista); //devolve uma tela
        }

        //abrir/carrega a tela de cadastrar
        [HttpGet]
        public ActionResult Cadastrar()
        {            
            return View();
        }

        [HttpPost]
        //mvcaction4 -> tab tab
        public ActionResult Cadastrar(Produto produto)
        {
            _lista.Add(produto);
            //Passa informações para a view
            ViewBag.prod = produto;
            TempData["mensagem"] = "Produto cadastrado";
            //retorna a view  Sucesso.cshtml
            return View("Sucesso", produto);
            //return Content(produto.Nome + "  " + produto.Quantidade + " " + produto.Valor + " Total: " + (produto.Quantidade * produto.Valor));
        }                
    }
}