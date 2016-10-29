using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo01.MVC.Web.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
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
