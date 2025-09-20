namespace Domain.Model
{
    public class Cliente : Pessoa
    {
        public float Saldo { get; private set; }

        public void Depositar(float valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
            }
        }

        public void Sacar(float valor)
        {
            if (valor > 0 && Saldo >= valor)
            {
                Saldo -= valor;
            }
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Seu saldo atual é: R$ {Saldo:F2}");
        }
    }
}
