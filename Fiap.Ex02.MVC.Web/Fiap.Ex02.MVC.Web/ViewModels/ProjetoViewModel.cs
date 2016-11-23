using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Ex02.MVC.Web.ViewModels
{
    public class ProjetoViewModel
    {
        public SelectList Grupos { get; set; }
        public string Mensagem { get; set; }
        public string TipoMensagem { get; set; }


        #region FIELDS

        public int Id { get; set; }
        [Display(Name = "Nome do Projeto")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Display(Name = "Descrição do Projeto")]
        [Required]
        public string Descricao { get; set; }
        [Display(Name = "Entregue?")]
        [Required]
        public bool Entregue { get; set; }
        [Display(Name = "Data de Início")]
        [Required]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Data de Término")]        
        public Nullable<DateTime> DataTermino { get; set; }
        [Display(Name = "Grupo")]
        [Required]
        public int GrupoId { get; set; }

        #endregion
    }
}