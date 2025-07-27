namespace Domain.Model
{
    public class Cliente : Pessoa
    {
        public float Saldo { get; private set; }

        public void AtualizarSaldo(float valor)
        {
            Saldo = valor;
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual é: R$ {Saldo:F2}");
        }
    }
}
