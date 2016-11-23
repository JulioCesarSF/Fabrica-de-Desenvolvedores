﻿using Fiap.Ex02.MVC.Web.Models;
using Fiap.Ex02.MVC.Web.UnitsOfWork;
using Fiap.Ex02.MVC.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Ex02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {
        #region FIELDS
        private UnitOfWork _unit = new UnitOfWork();
        #endregion

        #region GETS
        [HttpGet]
        public ActionResult Cadastrar(string mensagem, string tipoMensagem)
        {
            var viewModel = new GrupoViewModel()
            {
                Mensagem = mensagem,
                TipoMensagem = tipoMensagem            
            };

            return View(viewModel);
        }

        #endregion

        #region POSTS
        [HttpPost]
        public ActionResult Cadastrar(GrupoViewModel viewModel)
        {
            var grupo = new Grupo()
            {
                Nome = viewModel.Nome,
                Nota = viewModel.Nota
            };
            _unit.GrupoRepository.Cadastrar(grupo);
            _unit.Save();
            return RedirectToAction("Cadastrar", 
                new { mensagem = "Cadastro Realizado!", tipoMensagem = "alert alert-success" });
        }
        #endregion
    }
}