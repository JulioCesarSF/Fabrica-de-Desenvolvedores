using Fiap.Exemplo03.UI.Console.DTOs;
using Fiap.Exemplo03.UI.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int resp = 9;

            do
            {
                System.Console.WriteLine("Digite a opção \n0-Cadatrar\n1-Listar\n2-Sair");
                resp = int.Parse(System.Console.ReadLine());

                switch (resp)
                {
                    case 0:
                        cadastrar();
                        break;

                    case 1:
                        Listar();
                        break;

                    case 2:
                        break;

                    default:
                        resp = 9;
                        break;
                }

            } while (resp != 2);


        }

        private static void Listar()
        {
            IEnumerable<ProfessorDTO> lista = new ProfessorRepository().Listar();
            foreach (var item in lista)
            {
                System.Console.WriteLine("id: {0} Nome do Professor {1}, Salário {2}", item.Id, item.Nome, item.Salario);
            }
        }

        private static void cadastrar()
        {

            System.Console.WriteLine("Digite o nome:");
            string nome = System.Console.ReadLine();
            System.Console.WriteLine("Digite o salário");
            decimal salario = decimal.Parse(System.Console.ReadLine());

            var prof = new ProfessorDTO()
            {
                Nome = nome,
                Salario = salario
            };

            Uri uri = new ProfessorRepository().Cadastrar(prof);
            if (uri != null)
                System.Console.WriteLine("Url {0}", uri.ToString());
            else
                System.Console.WriteLine("Cadastro não realizado!");
        }
    }
}
