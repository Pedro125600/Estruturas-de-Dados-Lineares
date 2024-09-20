using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_linear
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("De o tamanho da Lista de filmes:");
            int tamanho = int.Parse(Console.ReadLine());


            Lista Filmes = new Lista(tamanho);


            int opcaoo = 0;

            while (opcaoo != 8)
            {
                Console.Clear();
                Console.WriteLine("1 - Inserir um filme no final da lista");
                Console.WriteLine("2 - Inserir um filme em uma posição específica da lista");
                Console.WriteLine("3 - Remover um filme da lista");
                Console.WriteLine("4 - Remover um filme em uma posição específica da lista");
                Console.WriteLine("5 - Pesquisar se um filme consta na lista");
                Console.WriteLine("6 - Listar todos os filmes da lista");
                Console.WriteLine("7 - Inverter a ordem dos filmes presentes na lista");
                Console.WriteLine("8 - Encerrar o programa");

                Console.Write("Escolha uma opção:");
                opcaoo = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcaoo)
                {
                    case 1:
                        Console.Write("Novo Filme:");
                        string novoFilme = Console.ReadLine();
                        Filmes.inserirFim(novoFilme);
                        Console.WriteLine($"Filme Adicionado: {novoFilme} ");
                        break;
                    case 2:
                        Console.Write("Novo Filme:");
                        novoFilme = Console.ReadLine();
                        Console.Write("Posição do filme:");
                        int posicao = int.Parse(Console.ReadLine());
                        Filmes.Inserir(novoFilme, posicao);
                        Console.WriteLine($"Filme: {novoFilme} Adicionado a posição {posicao} ");
                        break;
                    case 3:
                        Console.Write("Remover Filme:");
                        string remover = Console.ReadLine();
                        Console.WriteLine($"Filme Removido: {Filmes.removerEspecifico(remover)} ");
                        break;
                    case 4:
                        Console.Write("Remover filme na Posição:");
                        posicao = int.Parse(Console.ReadLine());
                        Filmes.remover(posicao);
                        Console.WriteLine($"Filme: {Filmes} removido da posição {posicao} ");
                        break;
                    case 5:
                        Console.Write("Nome do filme:");
                        string buscarFilme = Console.ReadLine();
                        if (Filmes.Busca(buscarFilme))
                            Console.WriteLine("Esta na lista");
                        else
                            Console.WriteLine("Não esta na lista");
                        break;
                    case 6:Filmes.mostrar();
                        break;
                    case 7:
                        Filmes.Reverso();
                        Console.WriteLine("Lista Invertida");
                        Filmes.mostrar();

                        break;
                    case 8:
                        Console.WriteLine("FIM");
                        break;
                }

                Console.ReadLine();
            }
        }

    class Lista
        {
            private string[] array;
            private int n;
            public Lista() { inicializar(0); }

            public Lista(int tamanho)
            {
                inicializar(tamanho);
            }

            private void inicializar(int tamanho)
            {
                this.array = new string[tamanho];
                this.n = 0;
            }

            public void InserirInicio(string palavra)
            {
                if (n > array.Length)
                    throw new Exception("Erro");

                for (int i = n; i > 0; i--)
                {
                    array[i] = array[i - 1];
                }

                array[0] = palavra;
                n++;
            }
            public void mostrar()
            {
               
                for (int i = 0; i < n; i++)
                {
                    Console.Write(array[i] + ",");
                }
               
            }


            public void inserirFim(string palavra)
            {
                if (n >= array.Length)
                    throw new Exception("Erro!");
                array[n] = palavra;
                n++;
            }

            public void Inserir(string palavra,int pos)
            {
                if (n >= array.Length || pos < 0 || pos > n)
                    throw new Exception("Erro!");

                for(int i = n;i > pos; i--)
                {
                    array[n] = palavra;
                }

                array[pos] = palavra;
                n++;
            }

            public string removerInicio()
            {
                if (n == 0)
                    throw new Exception("Erro!");
                string resp = array[0];
                n--;
                for (int i = 0; i < n; i++)
                {
                    array[i] = array[i + 1];
                }
                return resp;
            }

            public void Reverso()
            {
                int inicio = 0;
                int fim = n-1;

                while (inicio < fim)
                {
                    string temp = array[inicio];
                    array[inicio] = array[fim];
                    array[fim] = temp;

                    fim--;
                    inicio++;
                }


            }


            public bool Busca(string palavra)
            {
                bool resp = false;

                for(int i = 0; i <= n; i++)
                {
                    if (array[i] == palavra)
                        resp = true;
                }

                return resp;
            }


            public string removerFim()
            {
                if (n == 0)
                    throw new Exception("Erro!");
                n = n - 1;
                return array[n];
            }

            public string remover(int pos)
            {
                if (n == 0 || pos < 0 || pos >= n)
                    throw new Exception("Erro!");

                string resp = array[pos];
                n--;
                for (int i = pos; i < n; i++)
                {
                    array[i] = array[i + 1];
                }
                return resp;
            }

            public string removerEspecifico(string palavra)
            {
                int pos = 0;
                for (int i = n; i > 0; i--)
                {
                    if (array[i] == palavra)
                        pos = i;
                }

                if (n == 0 || pos < 0 || pos >= n)
                    throw new Exception("Erro!");

                string resp = array[pos];
                n--;
                for (int i = pos; i < n; i++)
                {
                    array[i] = array[i + 1];
                }
                return resp;
            }




    }



} 
} 
