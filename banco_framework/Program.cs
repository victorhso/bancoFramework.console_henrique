using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var pessoa = Identificacao();

        while (true)
        {
            Menu();
        }
    }

    static Pessoa Identificacao()
    {
        int id;
        var pessoa = new Pessoa();

        Console.WriteLine("Seu número de identificação:");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID inválido. Digite um número válido:");
        }
        pessoa.Id = id;

        Console.WriteLine("Seu nome:");
        pessoa.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        pessoa.Cpf = Console.ReadLine();
        Console.Clear();

        Console.WriteLine($"Como posso ajudar {pessoa.Nome}?");

        return pessoa;
    }

    static void Menu()
    {
        Console.WriteLine("1 - Depósito");
        Console.WriteLine("2 - Saque");
        Console.WriteLine("3 - Sair");
        Console.WriteLine("--------------");
        Console.WriteLine("Selecione uma opção:");

        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.WriteLine();
        string input = keyInfo.KeyChar.ToString();
        ExibeOpcaoSelecionada(input);
    }

    static void ExibeOpcaoSelecionada(string input)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        switch (input)
        {
            case "1":
                Console.WriteLine("Depósito");
                break;
            case "2":
                Console.WriteLine("Saque");
                break;
            case "3":
                Console.WriteLine("Sair");
                Console.ResetColor();
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Menu();
                break;
        }
        Console.ResetColor();
    }
}
