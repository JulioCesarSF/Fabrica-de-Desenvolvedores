using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        // GET: Aluno
        [HttpGet]
        public ActionResult Cadastrar()
        {            
            //buscar todos
            //var context = new PortalContext();
            //var lista = context.Grupo.ToList();
            ViewBag.grupos = new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Cadastrado com sucesso";
            //var context = new PortalContext();
            //context.Aluno.Add(aluno);
            //context.SaveChanges();
            _unit.AlunoRepository.Cadastrar(aluno);
            //_unit.Save();
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //include -> busca o relacionamento (preenche o grupo que o aluno possui), faz o join
            // IList<Aluno> _lista = new PortalContext().Aluno.Include("Grupo").ToList();

           // IList<Aluno> _lista = _unit.AlunoRepository.Listar();
            return View(_unit.AlunoRepository.Listar());
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            //var context = new PortalContext();
            //Aluno a = context.Aluno.Find(int.Parse(id));
            //context.Aluno.Remove(a);
            _unit.AlunoRepository.Remover(id);
            _unit.Save();
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Aluno formatado";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        //(int id) para receber o id do view
        public ActionResult Editar(int id)
        {
            //buscar o objeto (aluno) no banco
           // var context = new PortalContext();
           // var aluno = context.Aluno.Find(id);
            //manda o aluno para a view
            return View(_unit.AlunoRepository.BuscarPorId(id));
        }
        
        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            /*
            context.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            */

            _unit.AlunoRepository.Atualizar(aluno);

            //var context = new PortalContext();
            //var a = context.Aluno.Find(aluno.Id);
            //a.Nome = aluno.Nome;
            //a.DataNascimento = aluno.DataNascimento;
            //a.Bolsa = aluno.Bolsa;
            //a.Desconto = aluno.Desconto;
            _unit.Save();

            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Aluno atualizado";
            return RedirectToAction("Listar");
        } 
        
        [HttpGet]
        public ActionResult Buscar(String nomeBusca)
        {
            //var context = new PortalContext();
            //var a = context.Aluno.Where(aa => aa.Nome.Contains(nomeBusca)).ToList();
            return View("Listar", 
                _unit.AlunoRepository.BuscarPor(aa => aa.Nome.Contains(nomeBusca)));
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}