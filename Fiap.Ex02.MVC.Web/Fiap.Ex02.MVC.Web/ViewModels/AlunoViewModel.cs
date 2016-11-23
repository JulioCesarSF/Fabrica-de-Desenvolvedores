using Fiap.Ex02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Ex02.MVC.Web.ViewModels
{
    public class AlunoViewModel
    {
        #region LISTAS
        public SelectList ListaGrupo { get; set; }
        public ICollection<Aluno> ListaAluno { get; set; }
        #endregion

        public string Mensagem { get; set; }
        public string TipoMensagem { get; set; }

        #region PROPERTIES
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento{ get; set; }
        public Nullable<double> Desconto { get; set; }
        public bool Bolsa { get; set; }
        public int GrupoId { get; set; }
        #endregion

    }
}