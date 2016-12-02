using Fiap.Exemplo02.Dominio.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Fiap.Exemplo02.Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProfessorController : ApiController
    {
        #region FIELDS

        private UnitOfWork _unit = new UnitOfWork();

        #endregion
        
        //GET api/professor
        public ICollection<Professor> Get()
        {
            return _unit.ProfessorRepository.Listar();
        }

        //GET api/professor/{id}
        public Professor Get(int id)
        {
            return _unit.ProfessorRepository.BuscarPorId(id);
        }

        //POST api/professor/
        public IHttpActionResult Post(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _unit.ProfessorRepository.Cadastrar(professor);
                _unit.Save();
                var uri = Url.Link("DefaultApi", new { id = professor.Id });
                return Created<Professor>(new Uri(uri), professor);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //PUT api/professor/...
        public IHttpActionResult Put(int id, Professor professor)
        {
            if (ModelState.IsValid)
            {
                professor.Id = id;
                _unit.ProfessorRepository.Alterar(professor);
                _unit.Save();
                return Ok(professor);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        //DELETE api/professor/{id}
        public void Delete(int id)
        {
            _unit.ProfessorRepository.Remover(id);
            _unit.Save();
        }


    }
}
