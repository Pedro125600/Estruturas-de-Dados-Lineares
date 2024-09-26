using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pilha pilha = new Pilha(100);

            Console.Write("De o valor de N:");
            int N = int.Parse(Console.ReadLine());

            while (N < 3)
            {
                Console.Write("N deve ser maior ou igual a 3");
                N = int.Parse(Console.ReadLine());

            }

          



            int a = 0, b = 1;

            pilha.InserirFim(a);
            pilha.InserirFim(b);
            for (int i = 2; i < N; i++)
            {
                int c = a + b;
                pilha.InserirFim(c);
                a = b;
                b = c;
            }

            Console.WriteLine("Sequência de Fibonacci na ordem inversa:");

            for (int i = pilha.pow; i > 0 ; i--)
            {
                Console.Write(pilha.removerFim() + " ");
            }
            


            Console.ReadLine();

        }
    }

    class Pilha
    {
        private int[] array;
        public int pow;

        public Pilha(int tamanho)
        {
            pow = 0;
            array = new int[tamanho];
        }


        public void InserirFim(int numero)
        {
            if (pow >= array.Length)
                throw new Exception("Pilha cheia!");
            array[pow] = numero;
            pow++;
        }
        public int removerFim()
        {
            if (pow == 0)
                throw new Exception("Erro!");
            pow = pow - 1;
            return array[pow];
        }
    }
}