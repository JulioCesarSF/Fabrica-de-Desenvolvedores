using Fiap.Ex02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string NomeBusca { get; set; }
        public int? IdBusca { get; set; }
        public string Mensagem { get; set; }
        public string TipoMensagem { get; set; }

        #region PROPERTIES
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Display(Name = "Data de Nascimento")]
        [Required]
        public DateTime DataNascimento{ get; set; }
        [Display(Name = "Desconto %")]
        public Nullable<double> Desconto { get; set; }
        [Display(Name = "Bolsa")]
        [Required]
        public bool Bolsa { get; set; }
        [Display(Name = "Grupo")]
        [Required]
        public int GrupoId { get; set; }
        #endregion

    }
}