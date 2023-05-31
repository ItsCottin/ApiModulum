namespace WebApiModulum.Entity
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string TpUsuario { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Uf { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string NumeroCasa { get; set; } = null!;
        public DateTime DataAlter { get; set; }
    }
}
