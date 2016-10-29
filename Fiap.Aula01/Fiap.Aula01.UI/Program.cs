using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiap.Aula01.UI.Model;
using Fiap.Aula01.UI.Exceptions;

namespace Fiap.Aula01.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instanciar uma Pessoa Juridica
            PessoaJuridica p = new PessoaJuridica("Fiap");
            p.Cnpj = "12.232.323/0001-01";
            //p.Nome = "Fiap";

            p.Porte = Porte.SA;

            //Comparação utilizando enum
            if (p.Porte == Porte.SA)
            {
                Console.WriteLine("Fiap é SA");
            }

            //Comparação utilizando string
            if (p.Nome == "Fiap")
            {
                Console.WriteLine("Entra ou não?");
            }

            Console.WriteLine(p.Nome + " " + p.Cnpj);

            //Instanciar uma Pessoa Fisica
            var pf = new PessoaFisica("Danilo")
            {
                //Nome = "Danilo",
                Cpf = "123.123.123-55"
            };

            //Coleção: criar uma lista de pessoa 3
            var lista = new List<PessoaFisica>();
            lista.Add(new PessoaFisica("Thiago") { Renda = 0 });
            lista.Add(new PessoaFisica("Danilo") { Renda = 100 });
            lista.Add(new PessoaFisica("Allan") { Renda = 1000 });

            //Exibir o imposto da pessoa
            foreach (var pessoa in lista)
            {
                try
                {
                    Console.WriteLine(pessoa.CalcularImposto());
                }
                catch (RendaInvalidaException e)
                {
                    //imprime a mensagem da exception
                    Console.WriteLine(e.Message);
                }
                
            }


            Console.ReadLine();
        }
    }
}
