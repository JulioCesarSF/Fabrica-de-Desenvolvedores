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

        /// <summary>
        /// Action/Método para cadastrar o produto no banco de dados
        /// </summary>
        /// <param name="produto">Objeto do tipo Produto</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            try
            {
                pContext.Produto.Add(produto);
                pContext.SaveChanges();
                TempData["tipoMensagem"] = "alert alert-success";
                TempData["mensagem"] = "Produto cadastrado!";
            }
            catch (Exception ex)
            {
                TempData["tipoMensagem"] = "alert alert-danger";
                TempData["mensagem"] = "Erro ao cadastrar: " + ex.GetType().Name;                
            }
            
            return RedirectToAction("Cadastrar");
        }
        /// <summary>
        /// Action/Método para mostrar a View de lista de produto
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Listar()
        {
            return View(pContext.Produto.ToList());
        }
    }
}