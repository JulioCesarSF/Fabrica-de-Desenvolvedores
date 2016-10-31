using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo01.MVC.Web.Models
{
    public class Cliente
    {
        //lista de EstadoCivil com inicialização https://msdn.microsoft.com/en-us/library/bb384062.aspx        
        public IList<string> _estadoCivil = new List<string>()
        {
           "Selecione",
           "Solteiro",
           "Casado",
           "Outro"
        };
        [Display (Name = "Nome")]
        public string Nome { get; set; }
        [Display (Name = "Idade")]
        public int Idade { get; set; }
        [Display (Name = "Crédito")]
        public decimal Credito { get; set; }
        [Display (Name = "Necessidades Especiais")]
        public bool NecessidadesEspeciais { get; set; }
        [Display (Name = "Estado Civil")]
        public string EstadoCivil { get; set; }
        [Display (Name = "Data de Nascimento")]
        [UIHint("Date")]
        public DateTime DataNascimento { get; set; }

        public Cliente()
        {

        }        

        public Cliente(string nome, int idade, decimal credito, bool necessidadesEspeciais, string estadoCivil, DateTime dataNascimento)
        {
            Nome = nome;
            Idade = idade;
            Credito = credito;
            NecessidadesEspeciais = necessidadesEspeciais;
            EstadoCivil = estadoCivil;
            DataNascimento = dataNascimento;
        }
        
    }
}
