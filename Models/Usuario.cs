using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore;

namespace WebApiModulum.Models
{
    [Table("TBL_USUARIO")]
    public class Usuario
    {
        // Id único do registro de usuário
        [Column("ID_USU")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("NOME_USU")]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        [Column("LOGIN_USU")]
        public string Login { get; set; }

        [Required]
        [StringLength(800)]
        [Column("SENHA_USU")]
        public string Senha { get; set; }

        [StringLength(14)]
        [Column("CPF_USU")]
        public string Cpf { get; set; }
        
        [Required]
        [StringLength(50)]
        [Column("EMAIL_USU")]
        public string Email { get; set; }

        [StringLength(150)]
        [Column("ENDERECO_USU")]
        public string Endereco { get; set; }

        [StringLength(18)]
        [Column("TELEFONE_USU")]
        public string Telefone { get; set; }

        [StringLength(18)]
        [Column("CELULAR_USU")]
        public string Celular { get; set; }

        [StringLength(10)]
        [Column("TP_USU")]
        public string TpUsuario { get; set; }

        [StringLength(11)]
        [Column("CEP_USU")]
        public string Cep { get; set; }

        [StringLength(100)]
        [Column("BAIRRO_USU")]
        public string Bairro { get; set; }

        [StringLength(10)]
        [Column("UF_USU")]
        public string Uf { get; set; }

        [StringLength(100)]
        [Column("CIDADE_USU")]
        public string Cidade { get; set; }

        [StringLength(10)]
        [Column("NUMERO_CASA_USU")]
        public string NumeroCasa { get; set; }

        [Column("DT_ALTER_USU")]
        public DateTime DataAlter { get; set; }

    }
}