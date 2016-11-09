using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Grupo grupo)
        {
            //var con = new PortalContext();
            //con.Grupo.Add(grupo);
            //con.SaveChanges();
            _unit.GrupoRepository.Cadastrar(grupo);
            _unit.Save();
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Cadastrado com sucesso!";
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //var con = new PortalContext();
            //var l = con.Grupo.ToList();
            
            return View(_unit.GrupoRepository.Listar());
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            //var con = new PortalContext();
            //var g = con.Grupo.Find(id);
            return View(_unit.GrupoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public ActionResult Alterar(Grupo grupo)
        {
            //var con = new PortalContext();
            //var projeto = con.Projeto.Find(grupo.Id);
            //var g = con.Grupo.Find(grupo.Id);
            //projeto.Nome = grupo.Projeto.Nome;
            //projeto.Descricao = grupo.Projeto.Descricao;
            //projeto.DataInicio = grupo.Projeto.DataInicio;
            //projeto.DataTermino = grupo.Projeto.DataTermino;
            //projeto.Entregue = grupo.Projeto.Entregue;
            //g.Nome = grupo.Nome;
            //g.Nota = grupo.Nota;   
            //con.SaveChanges();
            _unit.

            _unit.GrupoRepository.Atualizar(grupo);
            _unit.Save();
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Grupo/Projeto atualizado!";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            //var con = new PortalContext();
            //var projeto = con.Projeto.Find(id);
            //con.Projeto.Remove(projeto);
            //var gg = con.Grupo.Find(id);
            //con.Grupo.Remove(gg);
            //con.SaveChanges();
            _unit.GrupoRepository.Remover(id);
            _unit.Save();
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Grupo/Projeto removido com sucesso!";
            return RedirectToAction("Listar");
        }
    }
}