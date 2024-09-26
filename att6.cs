using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o tamanho das filas: ");
            int tamanho = int.Parse(Console.ReadLine());
            Fila fila = new Fila(tamanho);


            int opcao = 0;

            while (opcao != 5)
            {
                

                Console.Clear();
                Console.WriteLine("Fila de Atendimento - Banco/Supermercado");
                Console.WriteLine("1 - Adicionar um cliente à fila");
                Console.WriteLine("2 - Atender um cliente (remover o primeiro da fila)");
                Console.WriteLine("3 - Exibir o número de clientes na fila");
                Console.WriteLine("4 - Exibir o próximo cliente a ser atendido");
                Console.WriteLine("5 - Encerrar o programa");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Nome do Cliente: ");
                        string nomeCliente = Console.ReadLine();
                        fila.inserir(nomeCliente);
                        Console.WriteLine($"\nCliente {nomeCliente} adicionado à fila.");
                        break;
                    case 2:
                        Console.Clear();
                        if (fila.Primeiro != fila.Ultimo)
                        {
                            string clienteAtendido = fila.remover();
                            Console.WriteLine($"Cliente {clienteAtendido} foi atendido.");
                        }
                        else
                        {
                            Console.WriteLine("Não há clientes na fila.");
                        }
                        break;
                    case 3:
                        Console.WriteLine($"Número de clientes na fila: {fila.Ultimo}");
                        break;
                    case 4:
                        if (fila.Primeiro != fila.Ultimo)
                        {
                            string proximoCliente = fila.Array[fila.Primeiro];
                            Console.WriteLine($"Próximo cliente a ser atendido: {proximoCliente}");
                        }
                        else
                        {
                            Console.WriteLine("Não há clientes na fila.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }

                if (opcao != 5)
                {
                    Console.WriteLine("\nPressione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }

        class Fila
        {
            private string[] array;
            private int primeiro, ultimo;

            public Fila() { inicializar(5); }
            public Fila(int tamanho)
            {
                inicializar(tamanho);
            }
            public void inicializar(int tamanho)
            {
                array = new string[tamanho + 1];
                primeiro = ultimo = 0;
            }

            public int Primeiro { get { return primeiro; } set { primeiro = value; } }
            public int Ultimo { get { return ultimo; } set { ultimo = value; } }

            public string[] Array { get { return array; } set { array = value; } }

            public void inserir(string x)
            {
                if (((ultimo + 1) % array.Length) == primeiro)
                    throw new Exception("Erro! Fila cheia.");
                array[ultimo] = x;
                ultimo = (ultimo + 1) % array.Length;
            }

            public string remover()
            {
                if (primeiro == ultimo)
                    throw new Exception("Erro! Fila vazia.");
                string resp = array[primeiro];
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

            public bool Buscar(string busca)
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
    }
}






