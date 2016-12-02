using Fiap.Exemplo02.Dominio.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fiap.Exemplo02.Services.Controllers
{
    public class AlunoController : ApiController
    {
        #region FIELDS

        private UnitOfWork _unit = new UnitOfWork();

        #endregion

        //GET api/aluno
        public ICollection<Aluno> Get()
        {
            return _unit.AlunoRepository.Listar();
        }

        //GET api/aluno/{id}
        public Aluno Get(int id)
        {
            return _unit.AlunoRepository.BuscarPorId(id);
        }

        public IHttpActionResult Put(int id, Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                aluno.Id = id;
                _unit.AlunoRepository.Alterar(aluno);
                _unit.Save();
                return Ok(aluno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public IHttpActionResult Post(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _unit.AlunoRepository.Cadastrar(aluno);
                _unit.Save();
                var uri = Url.Link("DefaultApi", new { id = aluno.Id });
                return Created<Aluno>(new Uri(uri), aluno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //GET api/
        public void Delete(int id)
        {
            _unit.AlunoRepository.Remover(id);
            _unit.Save();
        }


    }
}
