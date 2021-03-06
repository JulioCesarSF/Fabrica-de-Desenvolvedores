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

        [HttpGet]
        public ActionResult Listar(GrupoViewModel viewModel)
        {
            var grupoViewModel = new GrupoViewModel()
            {
                Grupos = ListarGrupos()
            };
            return View(grupoViewModel);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var grupo = _unit.GrupoRepository.BuscarPorId(id);
            var viewModel = new GrupoViewModel()
            {
                Nome = grupo.Nome,
                Nota = grupo.Nota
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult BuscarNome(string nome)
        {
            var grupo = _unit.GrupoRepository.BuscarPor(g => g.Nome == nome);
            return Json(new { ok = grupo.Any() }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region POSTS
        [HttpPost]
        public ActionResult Editar(Grupo grupo)
        {
            GrupoViewModel viewModel = null;
            if (ModelState.IsValid)
            {               
                _unit.GrupoRepository.Alterar(grupo);
                _unit.Save();

                viewModel = new GrupoViewModel()
                {                    
                    Mensagem = "Grupo Atualizado!",
                    TipoMensagem = "alert alert-success",
                    Grupos = ListarGrupos()
                };
                return View("Listar", viewModel);
            }else
            {
                viewModel = new GrupoViewModel()
                {
                    Mensagem = "Erro ao atualizar Grupo",
                    TipoMensagem = "alert alert-danger",
                    Nome = grupo.Nome,
                    Nota = grupo.Nota
                };
                return View(viewModel);
            }           
        }

        [HttpPost]
        public ActionResult Cadastrar(GrupoViewModel viewModel)
        {
            if (ModelState.IsValid)
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
            }else
            {
                return View(viewModel);
            }
            
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            GrupoViewModel grupoViewModel = null;            
            var projetos = _unit.ProjetoRepository.BuscarPor(g => g.Id == id);
            var alunos = _unit.AlunoRepository.BuscarPor(g => g.GrupoId == id);
            if (!projetos.Any() && !alunos.Any())
            {
                _unit.GrupoRepository.Remover(id);
                _unit.Save();

                grupoViewModel = new GrupoViewModel()
                {
                    Grupos = ListarGrupos(),
                    Mensagem = "Grupo excluído com sucesso!",
                    TipoMensagem = "alert alert-success"
                };
                return View("Listar", grupoViewModel);
            }else
            {
                grupoViewModel = new GrupoViewModel()
                {
                    Mensagem = "Existem Alunos/Projetos atrelados a este Grupo. Não é possível excluir!",
                    TipoMensagem = "alert alert-danger",
                    Grupos = ListarGrupos()                   
                };
                return View("Listar", grupoViewModel);
            }            
        }
        #endregion

        #region PRIVATE
        private ICollection<Grupo> ListarGrupos()
        {
            return _unit.GrupoRepository.Listar();
        }
        #endregion
    }
}