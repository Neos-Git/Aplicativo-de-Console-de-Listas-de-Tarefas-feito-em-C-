
List<ListaDeTexto> listaDeTextos = new List<ListaDeTexto>(); //Declarando a lista a partir da classe
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.

ConsoleColor[] ColorsOfConsole = new ConsoleColor[] { ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.DarkRed };
bool Working = true;
bool FirtStart = true;

while (Working)
{
    //Criação de lista local usando a classe ListaDeTexto
    ListaDeTexto ls = new();

    //Verifica se o programa foi iniciado pela primeira vez. Caso sim, mostra a mensagem inicial no Console.
    if (FirtStart)
    { 
        Console.WriteLine("type help for the commands list.");
        FirtStart = false;
    }

    //Pega o que o usuário escreveu no Console após teclar Enter e converte para uma string em caracteres minúsculos.
    string input_Do_Usuario = Console.ReadLine().ToLower();

    //Função de adição de texto para a lista. Funciona pegando o comando na primeira linha, o texto na segunda e o número referente a cor na terceira.
    if (input_Do_Usuario.Split(" ")[0] == "addtext")
    {
        
            if (input_Do_Usuario.Split(" ").Length > 2)
            {
                ls.texto = input_Do_Usuario.Split(" ")[1]; //Pega o texto após o primeiro espaçamento no input
                ls.color = int.Parse(input_Do_Usuario.Split(" ")[2]); //pega a variavel de cor após o segundo espaçamento no input
                listaDeTextos.Add(ls); //Após atribuir as váriaveis do input a lista local, adiciona-se na Lista principal do programa.
                Console.WriteLine("Texto Adicionado!");

            }
                    
    }

    //Função de remoção de texto para a lista. Funciona de forma similar a função de adição de texto.
    if (input_Do_Usuario.Split(" ")[0] == "removetext")
    {
        for (int i = 0; i < listaDeTextos.Count; i++) //Inicia um laço para verificar todo os textos da lista.
        {
            if (input_Do_Usuario.Split(" ")[1] == listaDeTextos[i].texto) //Se estiver o texto na lista, ele é removido.
            {
                listaDeTextos.Remove(new ListaDeTexto() { texto = input_Do_Usuario.Split(" ")[1], color = listaDeTextos[i].color });
                Console.WriteLine("Texto Removido!");
                break; //Encerra o laço após encontrar o texto correspondente
            }

        }

    }

    //Função de leitura de texto para a lista.
    if (input_Do_Usuario.Split(" ")[0] == "readlist")
    {
        for (int i = 0; i < listaDeTextos.Count; i++) //Laço para carregar todos os textos da lista
        {
            if (i < 1) //Laço para impedir que as mensagens sejam exibidas a cada ítem presente na lista
            {
                Console.Clear();
                Console.WriteLine("Carregando Lista.");

                Console.WriteLine("Ítens da lista:");

            }

            //Verificar se há cor na variavel da lista correspondente a array com as cores, se sim, muda a cor, caso não, apenas ignora essa função.
            if (listaDeTextos[i].color <= ColorsOfConsole.Length - 1)
            {
                Console.ForegroundColor = ColorsOfConsole[listaDeTextos[i].color];
            }

            Console.WriteLine(listaDeTextos[i].texto);
            Console.ForegroundColor = ConsoleColor.White;

        }

    }

    //Exibe a lista de comandos ao escrever "help" no prompt
    if (input_Do_Usuario.Split(" ")[0] == "help")
    {
        Console.WriteLine("type addtext for add a text to list\n" +
            "type readlist for read the list\n" +
            "type remtext for remove a text from list\n" +
            "type exit to stop the program");

    }

    //Encerra o programa
    if (input_Do_Usuario.Split(" ")[0] == "exit")
    {
        break;

    }

}

//Classe da Lista
public class ListaDeTexto
{
    public string texto = "";
    public int color;


}

