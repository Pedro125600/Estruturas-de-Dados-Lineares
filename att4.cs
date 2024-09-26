using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aatt4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma frase ou palavra que sera invertida");
            string texto = Console.ReadLine();

            Pilha pilha = new Pilha(texto.Length);

            for (int i = 0; i < texto.Length; i++)
            {
                pilha.InserirFim(texto[i].ToString());
            }

            Console.WriteLine("A string ao contrario e:");

            for (int i = 0; i < texto.Length; i++)
            {
                Console.Write(pilha.removerFim());
            }

            Console.ReadLine();
        }
    }

    class Pilha
    {
        private string[] array;
        public int pow;

        public Pilha(int tamanho)
        {
            pow = 0;
            array = new string[tamanho];
        }


        public void InserirFim(string t)
        {
            if (pow >= array.Length)
                throw new Exception("Pilha cheia!");
            array[pow] = t;
            pow++;
        }
        public string removerFim()
        {
            if (pow == 0)
                throw new Exception("Erro!");
            pow = pow - 1;
            return array[pow];
        }
    }
}
