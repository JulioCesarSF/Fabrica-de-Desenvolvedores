using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.ViewModels
{
    public class AlunoViewModel
    {
        //opções do select
        public SelectList ListaGrupo { get; set; }

        public string Mensagem { get; set; }
        public string TipoMensagem { get; set; }

        #region Aluno Properties
        public int Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string Nome { get; set; }
        [Display(Name="Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public Nullable<double> Desconto { get; set; }
        public bool Bolsa { get; set; }
        [Display(Name = "Grupo")]
        public int GrupoId { get; set; }

        #region Lista properties

        public ICollection<Aluno> Alunos { get; set; }
        public int? idBusca { get; set; }
        public string NomeBusca { get; set; }
        #endregion
        #endregion
    }
}
