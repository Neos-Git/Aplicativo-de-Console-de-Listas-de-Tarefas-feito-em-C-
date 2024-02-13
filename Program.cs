using System;
using System.Collections.Generic;
using System.IO;

namespace ListaDeTarefasApp
{
    class Program
    {
        static List<listaClasse> listaDeTextos = new List<listaClasse>();
        static string arquivoLista = "listaDeTarefas.txt"; // Nome do arquivo para salvar a lista

        static void Main(string[] args)
        {
            CarregarListaDoArquivo(); // Carrega a lista do arquivo, se existir

            bool FirstStart = false;

            while (true)
            {
                if (!FirstStart)
                {
                    Console.WriteLine("Bem-vindo ao meu programa. Digite 'help' para obter ajuda.");
                    FirstStart = true;
                }

                string inputDoUsuario = Console.ReadLine() ?? "";

                if (string.IsNullOrEmpty(inputDoUsuario))
                {
                    Console.WriteLine("Entrada desconhecida.");
                }
                else
                {
                    ProcessarComando(inputDoUsuario);
                    SalvarListaNoArquivo(); // Salva a lista no arquivo após cada alteração
                }
            }
        }
        
        // Método para carregar a lista do arquivo
        static void CarregarListaDoArquivo()
        {
            if (File.Exists(arquivoLista))
            {
                string[] linhas = File.ReadAllLines(arquivoLista);
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(',');
                    if (partes.Length == 2)
                    {
                        listaClasse novoItem = new listaClasse
                        {
                            texto = partes[0],
                            cor = int.Parse(partes[1])
                        };
                        listaDeTextos.Add(novoItem);
                    }
                }
            }
        }

        // Método para salvar a lista no arquivo
        static void SalvarListaNoArquivo()
        {
            using (StreamWriter sw = new StreamWriter(arquivoLista))
            {
                foreach (var item in listaDeTextos)
                {
                    sw.WriteLine($"{item.texto},{item.cor}");
                }
            }
        }
   

        static void ProcessarComando(string comando)
        {
            string[] partes = comando.Split(' ');

            if (partes.Length == 0)
            {
                Console.WriteLine("Comando inválido.");
                return;
            }

            switch (partes[0])
            {
                case "help":
                    MostrarAjuda();
                    break;

                case "readlist":
                    LerItensDaLista();
                    break;

                case "additem":
                    AdicionarItem(partes);
                    break;

                case "removeitem":
                    RemoverItem(partes);
                    break;

                default:
                    Console.WriteLine("Comando desconhecido.");
                    break;
            }
        }

        static void MostrarAjuda()
        {
            Console.WriteLine("Comandos disponíveis:\n" +
                "readlist - lê os itens da lista.\n" +
                "additem - adiciona um item à lista. Estrutura do comando: additem (item) (número de cor).\n" +
                "removeitem - remove um item da lista. Estrutura do comando: removeitem (nome do item)\n");
        }

        static void LerItensDaLista()
        {
            if (listaDeTextos.Count == 0)
            {
                Console.WriteLine("A lista está vazia.");
                return;
            }

            Console.WriteLine("Itens na lista:");
            foreach (var item in listaDeTextos)
            {
                Console.WriteLine($"- {item.texto} (Cor: {item.cor})");
            }
        }

        static void AdicionarItem(string[] partes)
        {
            if (partes.Length != 3)
            {
                Console.WriteLine("Entrada inválida. Use: additem (item) (número de cor).");
                return;
            }

            listaClasse novoItem = new listaClasse
            {
                texto = partes[1],
                cor = int.Parse(partes[2])
            };

            listaDeTextos.Add(novoItem);
            Console.WriteLine("Item adicionado com sucesso.");
        }

        static void RemoverItem(string[] partes)
        {
            if (partes.Length != 2)
            {
                Console.WriteLine("Entrada inválida. Use: removeitem (nome do item).");
                return;
            }

            string nomeItem = partes[1];
            var itemRemovido = listaDeTextos.RemoveAll(item => item.texto.Equals(nomeItem));

            if (itemRemovido > 0)
            {
                Console.WriteLine($"Item '{nomeItem}' removido com sucesso.");
            }
            else
            {
                Console.WriteLine($"Item '{nomeItem}' não encontrado na lista.");
            }
        }
    }

    class listaClasse
    {
        public string texto { get; set; }
        public int cor { get; set; }
    }
}
