using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Newtonsoft.Json;

namespace WebApiModulum.Entity
{
    public class UsuarioEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Login { get; set; } = null!;

        [Required]
        [StringLength(800)]
        public string Senha { get; set; } = null!;

        [StringLength(14)]
        public string Cpf { get; set; }

        [StringLength(50)]
        public string Email { get; set; } = null!;

        [StringLength(150)]
        public string Endereco { get; set; } = null!;

        [StringLength(18)]
        public string Telefone { get; set; } = null!;

        [StringLength(18)]
        public string Celular { get; set; } = null!;

        [StringLength(10)]
        public string TpUsuario { get; set; } = null!;

        [StringLength(11)]
        public string Cep { get; set; } = null!;

        [StringLength(100)]
        public string Bairro { get; set; } = null!;

        [StringLength(10)]
        public string Uf { get; set; } = null!;

        [StringLength(100)]
        public string Cidade { get; set; } = null!;

        [StringLength(10)]
        public string NumeroCasa { get; set; } = null!;
        public DateTime DataAlter { get; set; }
    }
}
