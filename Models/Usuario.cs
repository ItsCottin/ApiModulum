#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using ApiModulum.Filters;

namespace ApiModulum.Models
{
    [Table("TBL_USUARIO")]
    public class Usuario
    {
        /// <summary>
        /// Id único do registro de usuário
        /// </summary>
        [Column("ID_USU")]
        public int Id { get; set; }

        /// <summary>
        /// Nome Completo do Usuário
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("NOME_USU")]
        public string? Nome { get; set; }

        /// <summary>
        /// Nome de Login do Usuário
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("LOGIN_USU")]
        public string? Login { get; set; }

        /// <summary>
        /// Senha do Usuário 
        /// </summary>
        [Required]
        [StringLength(800)]
        [Column("SENHA_USU")]
        public string? Senha { get; set; }

        /// <summary>
        /// CPF do Usuário com formatação '000.000.000-00'.
        /// </summary>
        [StringLength(14)]
        [Column("CPF_USU")]
        public string? Cpf { get; set; }

        /// <summary>
        /// E-mail do usuário. 
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("EMAIL_USU")]
        public string? Email { get; set; }

        /// <summary>
        /// Endereço do Usuário: Av. ou Rua
        /// </summary>
        [StringLength(150)]
        [Column("ENDERECO_USU")]
        public string? Endereco { get; set; }

        /// <summary>
        /// Telefone do Usuário: '(11) 0000-0000'
        /// </summary>
        [StringLength(18)]
        [Column("TELEFONE_USU")]
        public string? Telefone { get; set; }

        /// <summary>
        /// Celular do Usuário: '(11) 0 0000-0000'
        /// </summary>
        [StringLength(18)]
        [Column("CELULAR_USU")]
        public string? Celular { get; set; }

        /// <summary>
        /// Tipo do usuário
        /// </summary>
        [StringLength(10)]
        [Column("TP_USU")]
        public string? TpUsuario { get; set; }

        /// <summary>
        /// CEP do Usuário: '00000-000'
        /// </summary>
        [StringLength(11)]
        [Column("CEP_USU")]
        public string? Cep { get; set; }

        /// <summary>
        /// Bairro do Usuário
        /// </summary>
        [StringLength(100)]
        [Column("BAIRRO_USU")]
        public string? Bairro { get; set; }

        /// <summary>
        /// Estado do Usuário
        /// </summary>
        [StringLength(10)]
        [Column("UF_USU")]
        public string? Uf { get; set; }

        /// <summary>
        /// Cidade do Usuário
        /// </summary>
        [StringLength(100)]
        [Column("CIDADE_USU")]
        public string? Cidade { get; set; }

        /// <summary>
        /// Número do Local do Usuário
        /// </summary>
        [StringLength(10)]
        [Column("NUMERO_CASA_USU")]
        public string? NumeroCasa { get; set; }

        /// <summary>
        /// Data de Alteração / Cadastro do Usuário
        /// </summary>
        [Column("DT_ALTER_USU")]
        public DateTime DataAlter { get; set; }

    }
}