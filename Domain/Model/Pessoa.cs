namespace Domain.Model
{
    public class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetCpf(string cpf)
        {
            Cpf = cpf;
        }
    }
}
