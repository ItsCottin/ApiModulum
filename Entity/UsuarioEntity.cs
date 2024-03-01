#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Entity
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
        /// Tipo do usuário
        /// </summary>
        [StringLength(10)]
        public string TpUsuario { get; set; } = null!;

        /// <summary>
        /// Data de Alteração / Cadastro do Usuário
        /// </summary>
        public DateTime DataAlter { get; set; }
    }
}
