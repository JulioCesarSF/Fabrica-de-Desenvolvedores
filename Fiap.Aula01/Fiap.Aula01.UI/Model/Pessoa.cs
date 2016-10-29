using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Aula01.UI.Model
{
    public abstract class Pessoa
    {
        //Construtor
        //ctor -> tab tab
        public Pessoa(string nome)
        {
            _nome = nome;
        }

        //Campo - Field
        private string _nome;

        //Get e Set (Propriedade)
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public abstract void Comprar(string item);

        //virtual -> permite a sobrescrita do método
        public virtual void Vender(string item)
        {
            Console.WriteLine(item);
        }

    }
}
