using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApiModulum.Models
{
    [Table("TBL_MODULUM_USUARIO")]
    public class Usuario
    {
        [Column("ID_USU")]
        public int Id { get; set; }

        [Column("NOME_USU")]
        public string Nome { get; set; } = null!;

        [Column("LOGIN_USU")]
        public string Login { get; set; } = null!;

        [Column("SENHA_USU")]
        public string Senha { get; set; } = null!;

        [Column("CPF_USU")]
        public string Cpf { get; set; } = null!;

        [Column("EMAIL_USU")]
        public string Email { get; set; } = null!;

        [Column("ENDERECO_USU")]
        public string Endereco { get; set; } = null!;

        [Column("TELEFONE_USU")]
        public string Telefone { get; set; } = null!;

        [Column("CELULAR_USU")]
        public string Celular { get; set; } = null!;

        [Column("TP_USU")]
        public string TpUsuario { get; set; } = null!;

        [Column("CEP_USU")]
        public string Cep { get; set; } = null!;

        [Column("BAIRRO_USU")]
        public string Bairro { get; set; } = null!;

        [Column("UF_USU")]
        public string Uf { get; set; } = null!;

        [Column("CIDADE_USU")]
        public string Cidade { get; set; } = null!;

        [Column("NUMERO_CASA_USU")]
        public string NumeroCasa { get; set; } = null!;

        [Column("DT_ALTER_USU")]
        public DateTime DataAlter { get; set; }

    }
}