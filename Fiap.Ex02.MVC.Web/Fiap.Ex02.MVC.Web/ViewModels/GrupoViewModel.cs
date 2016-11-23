using Fiap.Ex02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap.Ex02.MVC.Web.ViewModels
{
    public class GrupoViewModel
    {  
        public ICollection<Grupo> Grupos { get; set; }   
        public string Mensagem { get; set; }
        public string TipoMensagem { get; set; }
        #region FIELDS
        public int Id { get; set; }
        [Display(Name = "Nome do Grupo")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Display(Name = "Nota do Grupo")]
        [Range(0.0, 10.0, ErrorMessage = "Valor entre 0 e 10")]
        public Nullable<double> Nota { get; set; }
        #endregion
    }
}