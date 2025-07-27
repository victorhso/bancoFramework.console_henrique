using Application;
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
            Menu(pessoa);
        }
    }

    static Cliente Identificacao()
    {
        int id;
        float saldo;
        var cliente = new Cliente();

        Console.WriteLine("Seu número de identificação:");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID inválido. Digite um número válido:");
        }
        cliente.SetId(id);

        Console.WriteLine("Seu nome:");
        cliente.SetNome(Console.ReadLine());

        Console.WriteLine("Seu CPF:");
        cliente.SetCpf(Console.ReadLine());

        Console.Write("Seu saldo: R$");
        while (!float.TryParse(Console.ReadLine(), out saldo) || saldo < 0)
        {
            Console.Write("Saldo inválido. Digite um valor válido: R$");
        }
        cliente.AtualizarSaldo(saldo);
        Console.Clear();

        Console.WriteLine($"Como posso ajudar {cliente.Nome}?");

        return cliente;
    }

    static void Menu(Cliente cliente)
    {
        Console.WriteLine("1 - Depósito");
        Console.WriteLine("2 - Saque");
        Console.WriteLine("3 - Sair");
        Console.WriteLine("--------------");
        Console.WriteLine("Selecione uma opção:");

        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.WriteLine();
        string input = keyInfo.KeyChar.ToString();
        ExibeOpcaoSelecionada(input, cliente);
        RealizaOperacao(input, cliente);
    }

    static void ExibeOpcaoSelecionada(string input, Cliente cliente)
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
                Menu(cliente);
                break;
        }
        Console.ResetColor();
    }

    static void RealizaOperacao(string input, Cliente cliente)
    {
        float valor;
        Console.Clear();
        switch (input)
        {
            case "1":
                Console.Write("Digite o valor: R$");
                while (!float.TryParse(Console.ReadLine(), out valor) || valor < 0)
                {
                    Console.WriteLine("Valor inválido. Digite um valor válido: R$");
                }
                cliente.AtualizarSaldo(Calculo.Soma(cliente.Saldo, valor));
                break;
            case "2":
                Console.Write("Digite o valor: R$");
                while (!float.TryParse(Console.ReadLine(), out valor) || valor < 0)
                {
                    Console.WriteLine("Valor inválido. Digite um valor válido: R$");
                }
                cliente.AtualizarSaldo(Calculo.Subtrair(cliente.Saldo, valor));
                break;
            default:
                Console.Clear();
                Menu(cliente);
                break;
        }
        cliente.ExibirSaldo();
    }
}