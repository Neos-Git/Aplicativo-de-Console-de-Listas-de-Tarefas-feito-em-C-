bool FirstStart = false;
List<listaClasse> listaDeTextos = new List<listaClasse>();

while (true)
{

    if (FirstStart == false)
    {
        Console.WriteLine("Welcome to my program. Type help");
        FirstStart = true;
    }

    string Input_Do_Usuario = Console.ReadLine() ?? "";

    if (String.IsNullOrEmpty(Input_Do_Usuario))
    {
        Console.WriteLine("Unknown Input");

    }
    else
    {

        switch (Input_Do_Usuario)
        {

            case "help":
                Console.WriteLine("Commands:/n" +
                    "readlist - reads the items of the list./n" +
                    "additem - add a item in the list. The structure of the command is: additem (item) (color number)." +
                    "removeitem - removes a item from the list. The structure of the command is: removeitem (name of the item) ");
                break;

        }

    }
}

class listaClasse
{
    public string texto = "";
    public int color = 0;

}