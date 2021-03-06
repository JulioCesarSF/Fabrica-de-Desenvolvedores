﻿using Fiap.Exemplo01.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo01.MVC.Web.Controllers
{
    public class ClienteController : Controller
    {
        //lista de clientes
        public static IList<Cliente> _lista = new List<Cliente>();
        
        [HttpGet]
        public ActionResult Cadastrar()
        {
            //SelectList            
            // ViewBag.EstadoCivil = new SelectList(new[] { "Solteiro", "Casado", "Outro" });
            var lista = new List<string>();
            lista.Add("Solteiro");
            lista.Add("Casado");
            lista.Add("Separado");

            ViewBag.estados = new SelectList(lista);

            //ViewBag.EstadoCivil = new SelectList(new[] { "Solteiro", "Casado", "Outro" });
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente)
        {            
            _lista.Add(cliente);
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Cadastro realizado com sucesso!";
            
            return RedirectToAction("Cadastrar");
        }
        //luiz.leardine@fiap.com.br
        [HttpGet]
        public ActionResult Listar()
        {                     
            //ViewBag.mLista = _lista;//1 opcao
            return View(_lista); //2 opcao para passar por aqui deve-se usar o @model List<Fiap.Exemplo01.MVC.Web.Models.Cliente>
        }
    }
}