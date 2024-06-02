#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using ApiModulum.Filters;

namespace ApiModulum.Entity
{
    public class UsuarioEntity
    {

        /// <summary>
        /// Id único do registro de usuário
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome Completo do Usuário
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        /// <summary>
        /// Nome de Login do Usuário
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Login { get; set; } = null!;

        /// <summary>
        /// Senha do Usuário 
        /// </summary>
        [Required]
        [StringLength(800)]
        public string Senha { get; set; } = null!;

        /// <summary>
        /// CPF do Usuário, pode ser com ou sem formatação.
        /// Contém validação se o CPF informado é correto.
        /// </summary>
        [StringLength(14)]
        public string Cpf { get; set; }

        /// <summary>
        /// E-mail do usuário.
        /// Contém validação se o E-mail informado é correto.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Endereço do Usuário: Av. ou Rua
        /// </summary>
        [StringLength(150)]
        public string Endereco { get; set; } = null!;

        /// <summary>
        /// Telefone do Usuário.
        /// Contém validação de dígido, ddd e número.
        /// </summary>
        [StringLength(18)]
        public string Telefone { get; set; } = null!;

        /// <summary>
        /// Celular do Usuário.
        /// Contém validação de dígido, ddd e número.
        /// </summary>
        [StringLength(18)]
        public string Celular { get; set; } = null!;

        /// <summary>
        /// Tipo do usuário
        /// </summary>
        [StringLength(10)]
        public string TpUsuario { get; set; } = null!;

        /// <summary>
        /// CEP do Usuário.
        /// Contem validação se o CEP informado é valido e se as informações dos campos 'endereco', 'bairro', 'uf' e 'cidade' são correspondentes.
        /// </summary>
        [StringLength(11)]
        public string Cep { get; set; } = null!;

        /// <summary>
        /// Bairro do Usuário
        /// </summary>
        [StringLength(100)]
        public string Bairro { get; set; } = null!;

        /// <summary>
        /// Estado do Usuário
        /// </summary>
        [StringLength(10)]
        public string Uf { get; set; } = null!;

        /// <summary>
        /// Cidade do Usuário
        /// </summary>
        [StringLength(100)]
        public string Cidade { get; set; } = null!;

        /// <summary>
        /// Número do Local do Usuário
        /// </summary>
        [StringLength(10)]
        public string NumeroCasa { get; set; } = null!;

        /// <summary>
        /// Data de Alteração / Cadastro do Usuário
        /// </summary>
        public DateTime DataAlter { get; set; }
    }
}
