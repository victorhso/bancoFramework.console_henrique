using Application;
using CpfCnpjLibrary;
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

    public static Cliente Identificacao()
    {
        var cliente = new Cliente();
        var erros = new List<string>();

        while (true)
        {
            Console.Clear();
            erros.Clear();

            Console.WriteLine("Seja bem vindo ao banco Framework");
            Console.WriteLine("Por favor, identifique-se");
            Console.WriteLine("");

            Console.WriteLine("Seu número de identificação:");
            string? idInput = Console.ReadLine();

            Console.WriteLine("Seu nome:");
            string? nomeInput = Console.ReadLine();

            Console.WriteLine("Seu CPF:");
            string? cpfInput = Console.ReadLine();

            Console.Write("Seu saldo inicial: R$");
            string? saldoInput = Console.ReadLine();

            if (!int.TryParse(idInput, out int id) || id < 0)
            {
                erros.Add("ID inválido. Deve ser um número positivo.");
            }

            if (string.IsNullOrWhiteSpace(nomeInput))
            {
                erros.Add("Nome inválido. O nome não pode estar em branco.");
            }

            if (!Cpf.Validar(cpfInput))
            {
                erros.Add("CPF digitado não é válido.");
            }

            if (!float.TryParse(saldoInput, out float saldo) || saldo < 0)
            {
                erros.Add("Saldo inválido. Deve ser um valor numérico positivo.");
            }

            if (erros.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Foram encontrados os seguintes erros:");
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var erro in erros)
                {
                    Console.WriteLine($"- {erro}");
                }
                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para tentar novamente...");
                Console.ReadKey();
                continue;
            }

            cliente.Id = id;
            cliente.Nome = nomeInput;
            cliente.Cpf = cpfInput;
            cliente.Depositar(saldo);
            break;
        }

        Console.Clear();
        Console.WriteLine($"Como posso ajudar {cliente.Nome}?");
        return cliente;
    }

    public static void Menu(Cliente cliente)
    {
        Console.WriteLine("1 - Depósito");
        Console.WriteLine("2 - Saque");
        Console.WriteLine("3 - Sair");
        Console.WriteLine("--------------");
        Console.WriteLine("Selecione uma opção:");

        string? input = Console.ReadKey().KeyChar.ToString();
        Console.WriteLine();
        RealizaOperacao(input, cliente);
    }

    private static void RealizaOperacao(string? input, Cliente cliente)
    {
        Console.Clear();
        switch (input)
        {
            case "1":
                Console.WriteLine("Depósito");
                float valorDeposito = AtualizaSaldo("Digite o valor: R$");
                cliente.Depositar(valorDeposito);
                cliente.ExibirSaldo();
                break;
            case "2":
                Console.WriteLine("Saque");
                float valorSaque = AtualizaSaldo("Digite o valor: R$");
                cliente.Sacar(valorSaque);
                cliente.ExibirSaldo();
                break;
            case "3":
                Console.WriteLine("Saindo...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
        Console.WriteLine();
    }

    private static float AtualizaSaldo(string prompt)
    {
        Console.Write(prompt);
        float valor;
        while (!float.TryParse(Console.ReadLine(), out valor) || valor < 0)
        {
            Console.Write("Valor inválido. Digite um valor positivo: R$");
        }
        return valor;
    }
}