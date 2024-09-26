using System;

namespace att5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o tamanho das filas: ");
            int tamanho = int.Parse(Console.ReadLine());

            Fila filaIniciacaoCientifica = new Fila(tamanho);
            Fila filaMestrado = new Fila(tamanho);

            int opcao = 0;

            while (opcao != 11)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Inserir um aluno na fila de espera de bolsas de Iniciação Científica");
                Console.WriteLine("2 - Inserir um aluno na fila de espera de bolsas de Mestrado");
                Console.WriteLine("3 - Remover um aluno da fila de bolsas de Iniciação Científica");
                Console.WriteLine("4 - Remover um aluno da fila de bolsas de Mestrado");
                Console.WriteLine("5 - Mostrar fila de espera de bolsas de Iniciação Científica");
                Console.WriteLine("6 - Mostrar fila de espera de bolsas de Mestrado");
                Console.WriteLine("7 - Pesquisar aluno na fila de espera de bolsas de Iniciação Científica");
                Console.WriteLine("8 - Pesquisar aluno na fila de espera de bolsas de Mestrado");
                Console.WriteLine("9 - Mostrar qual o aluno que está no início da fila de espera de bolsas de Iniciação Científica");
                Console.WriteLine("10 - Mostrar qual o aluno que está no início da fila de espera de bolsas de Mestrado");
                Console.WriteLine("11 - Encerrar o programa");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o código do aluno para Iniciação Científica: ");
                        int alunoIC = int.Parse(Console.ReadLine());
                        filaIniciacaoCientifica.inserir(alunoIC);
                        Console.WriteLine($"Aluno {alunoIC} adicionado à fila de Iniciação Científica.");
                        break;

                    case 2:
                        Console.Write("Digite o código do aluno para Mestrado: ");
                        int alunoMestrado = int.Parse(Console.ReadLine());
                        filaMestrado.inserir(alunoMestrado);
                        Console.WriteLine($"Aluno {alunoMestrado} adicionado à fila de Mestrado.");
                        break;

                    case 3:
                        if (filaIniciacaoCientifica.Primeiro != filaIniciacaoCientifica.Ultimo)
                        {
                            int removidoIC = filaIniciacaoCientifica.remover();
                            Console.WriteLine($"Aluno {removidoIC} removido da fila de Iniciação Científica.");
                        }
                        else
                        {
                            Console.WriteLine("A fila de Iniciação Científica está vazia.");
                        }
                        break;

                    case 4:
                        if (filaMestrado.Primeiro != filaMestrado.Ultimo)
                        {
                            int removidoMestrado = filaMestrado.remover();
                            Console.WriteLine($"Aluno {removidoMestrado} removido da fila de Mestrado.");
                        }
                        else
                        {
                            Console.WriteLine("A fila de Mestrado está vazia.");
                        }
                        break;

                    case 5:
                        if (filaIniciacaoCientifica.Primeiro != filaIniciacaoCientifica.Ultimo)
                        {
                            Console.WriteLine("Fila de espera de Iniciação Científica:");
                            filaIniciacaoCientifica.mostrar();
                        }
                        else
                        {
                            Console.WriteLine("A fila de Iniciação Científica está vazia.");
                        }
                        break;

                    case 6:
                        if (filaMestrado.Primeiro != filaMestrado.Ultimo)
                        {
                            Console.WriteLine("Fila de espera de Mestrado:");
                            filaMestrado.mostrar();
                        }
                        else
                        {
                            Console.WriteLine("A fila de Mestrado está vazia.");
                        }
                        break;

                    case 7:
                        Console.Write("Digite o código do aluno para pesquisar na fila de Iniciação Científica: ");
                        int buscarIC = int.Parse(Console.ReadLine());
                        if (filaIniciacaoCientifica.Buscar(buscarIC))
                        {
                            Console.WriteLine($"Aluno {buscarIC} está na fila de Iniciação Científica.");
                        }
                        else
                        {
                            Console.WriteLine($"Aluno {buscarIC} não está na fila de Iniciação Científica.");
                        }
                        break;

                    case 8:
                        Console.Write("Digite o código do aluno para pesquisar na fila de Mestrado: ");
                        int buscarMestrado = int.Parse(Console.ReadLine());
                        if (filaMestrado.Buscar(buscarMestrado))
                        {
                            Console.WriteLine($"Aluno {buscarMestrado} está na fila de Mestrado.");
                        }
                        else
                        {
                            Console.WriteLine($"Aluno {buscarMestrado} não está na fila de Mestrado.");
                        }
                        break;

                    case 9:
                        if (filaIniciacaoCientifica.Primeiro != filaIniciacaoCientifica.Ultimo)
                        {
                            Console.WriteLine($"Aluno {filaIniciacaoCientifica.Array[filaIniciacaoCientifica.Primeiro]} está no início da fila de Iniciação Científica.");
                        }
                        else
                        {
                            Console.WriteLine("A fila de Iniciação Científica está vazia.");
                        }
                        break;

                    case 10:
                        if (filaMestrado.Primeiro != filaMestrado.Ultimo)
                        {
                            Console.WriteLine($"Aluno {filaMestrado.Array[filaMestrado.Primeiro]} está no início da fila de Mestrado.");
                        }
                        else
                        {
                            Console.WriteLine("A fila de Mestrado está vazia.");
                        }
                        break;

                    case 11:
                        Console.WriteLine("Programa encerrado.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.ReadLine();
            }
        }
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
}
