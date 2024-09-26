using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace att2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o tamanho da lista: ");
            int tamanho = int.Parse(Console.ReadLine());
            Lista lista = new Lista(tamanho);

            int opcao = 0;

            while (opcao != 9)
            {
                Console.Clear();
                Console.WriteLine("1 - Inserir um número na lista");
                Console.WriteLine("2 - Verificar se um número está na lista");
                Console.WriteLine("3 - Exibir a soma de todos os números na lista");
                Console.WriteLine("4 - Exibir o maior número na lista");
                Console.WriteLine("5 - Exibir o menor número na lista");
                Console.WriteLine("6 - Remover todos os números pares da lista");
                Console.WriteLine("7 - Exibir os números na lista");
                Console.WriteLine("8 - Inverter os elementos da lista");
                Console.WriteLine("9 - Encerrar o programa");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite um número para adicionar à lista: ");
                        int numero = int.Parse(Console.ReadLine());
                        lista.InserirFim(numero);
                        Console.WriteLine($"Número {numero} adicionado à lista.");
                        break;
                    case 2:
                        Console.Write("Digite o número para verificar se está na lista: ");
                        int numParaBuscar = int.Parse(Console.ReadLine());
                        if (lista.Busca(numParaBuscar))
                            Console.WriteLine($"O número {numParaBuscar} está na lista.");
                        else
                            Console.WriteLine($"O número {numParaBuscar} não está na lista.");
                        break;
                    case 3:
                        Console.WriteLine($"A soma de todos os números na lista é: {lista.Soma()}");
                        break;
                    case 4:
                        Console.WriteLine($"O maior número na lista é: {lista.Maior()}");
                        break;
                    case 5:
                        Console.WriteLine($"O menor número na lista é: {lista.Menor()}");
                        break;
                    case 6:
                        lista.RemoverPares();
                        Console.WriteLine("Todos os números pares foram removidos da lista.");
                        break;
                    case 7:
                        lista.Mostrar();
                        break;
                    case 8:
                        lista.Inverter();
                        Console.WriteLine("A lista foi invertida.");
                        lista.Mostrar();
                        break;
                    case 9:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }

    class Lista
    {
        private int[] array;
        private int n;

        public Lista(int tamanho)
        {
            array = new int[tamanho];
            n = 0;
        }

        public void InserirFim(int numero)
        {
            if (n >= array.Length)
                throw new Exception("Lista cheia!");
            array[n] = numero;
            n++;
        }

        public bool Busca(int numero)
        {
            for (int i = 0; i < n; i++)
            {
                if (array[i] == numero)
                    return true;
            }
            return false;
        }

        public int Soma()
        {
            int soma = 0;
            for (int i = 0; i < n; i++)
            {
                soma += array[i];
            }
            return soma;
        }

        public int Maior()
        {
            if (n == 0)
                throw new Exception("A lista está vazia!");
            int maior = array[0];
            for (int i = 1; i < n; i++)
            {
                if (array[i] > maior)
                    maior = array[i];
            }
            return maior;
        }

        public int Menor()
        {
            if (n == 0)
                throw new Exception("A lista está vazia!");
            int menor = array[0];
            for (int i = 1; i < n; i++)
            {
                if (array[i] < menor)
                    menor = array[i];
            }
            return menor;
        }

        public void RemoverPares()
        {
            int[] novoArray = new int[array.Length];
            int j = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i] % 2 != 0)
                {
                    novoArray[j] = array[i];
                    j++;
                }
            }

            array = novoArray;
            n = j;
        }

        public void Mostrar()
        {
            Console.WriteLine("Números na lista:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public void Inverter()
        {
            int inicio = 0;
            int fim = n - 1;

            while (inicio < fim)
            {
                int temp = array[inicio];
                array[inicio] = array[fim];
                array[fim] = temp;
                inicio++;
                fim--;
            }
        }
    }
}