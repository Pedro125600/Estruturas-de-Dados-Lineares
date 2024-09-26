using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att7
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o tamanho da Fila: ");
            int tamanho = int.Parse(Console.ReadLine());

            Fila fila = new Fila(tamanho);
            Pilha pilha = new Pilha(fila.Array.Length - 1);

            Random r = new Random();
            for (int i = 0; i < tamanho; i++)
            {

                int numero = r.Next(0, 100);
                fila.inserir(numero);
            }

            Console.WriteLine("Fila antes de inverter:");
            fila.mostrar();

             int n = fila.Primeiro;
            while (n != fila.Ultimo)
            {
                pilha.InserirFim(fila.Array[n]);
                n = (n + 1) % fila.Array.Length;
            }

            int j = fila.Primeiro;
            while (j != fila.Ultimo)
            {
                fila.Array[j] = pilha.removerFim();
                j = (j + 1) % fila.Array.Length;
            }


            
            



            Console.WriteLine("\nFila após inverter:");
            fila.mostrar();

            Console.ReadLine();
        }



        class Fila
        {
            private int[] array;
            private int primeiro, ultimo;

            public Fila() { inicializar(5); }
            public Fila(int tamanho)
            {
                inicializar(tamanho);
            }
            public void inicializar(int tamanho)
            {
                array = new int[tamanho + 1];
                primeiro = ultimo = 0;
            }

            public int Primeiro { get { return primeiro; } set { primeiro = value; } }
            public int Ultimo { get { return ultimo; } set { ultimo = value; } }

            public int[] Array { get { return array; } set { array = value; } }

            public void inserir(int x)
            {
                if (((ultimo + 1) % array.Length) == primeiro)
                    throw new Exception("Erro! Fila cheia.");
                array[ultimo] = x;
                ultimo = (ultimo + 1) % array.Length;
            }

            public int remover()
            {
                if (primeiro == ultimo)
                    throw new Exception("Erro! Fila vazia.");
                int resp = array[primeiro];
                primeiro = (primeiro + 1) % array.Length;
                return resp;
            }

            public void mostrar()
            {
                int i = primeiro;
                Console.Write("[");
                while (i != ultimo)
                {
                    Console.Write(array[i] + " ");
                    i = (i + 1) % array.Length;
                }
                Console.WriteLine("]");
            }

            public bool Buscar(int busca)
            {
                int i = primeiro;
                while (i != ultimo)
                {
                    if (array[i] == busca)
                        return true;
                    i = (i + 1) % array.Length;
                }
                return false;
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
                    throw new Exception("Erro! Pilha vazia.");
                pow = pow - 1;
                return array[pow];
            }
        }
    }
}