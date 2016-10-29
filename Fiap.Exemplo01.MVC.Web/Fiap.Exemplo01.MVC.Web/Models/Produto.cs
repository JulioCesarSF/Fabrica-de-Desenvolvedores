using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo01.MVC.Web.Models
{
    public class Produto
    {
        [Display (Name ="Nome")]
        public string Nome { get; set; }
        [Display (Name = "Quantidade")]
        public int Quantidade { get; set; }
        [Display (Name = "Idade")]
        public decimal Valor { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, int quantidade, decimal valor)
        {
            Nome = nome;
            Quantidade = quantidade;
            Valor = valor;
        }
    }
}
