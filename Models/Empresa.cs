#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("TBL_EMPRESA")]
    public class Empresa
    {
        /// <summary>
        /// Id único do registro da Empresa
        /// </summary>
        [Column("ID_EMPR")]
        public int Id { get; set; }

        /// <summary>
        /// Nome da Empresa
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("NOME_EMPR")]
        public string? Nome { get; set; }

        /// <summary>
        /// CNPJ da Empresa com formatação '00.000.000/0000-00'.
        /// </summary>
        [StringLength(18)]
        [Column("CNPJ_EMPR")]
        public string? Cpnj { get; set; }

        /// <summary>
        /// Nome fantasia da Empresa
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("NOME_FAN_EMPR")]
        public string? NomeFan { get; set; }

        /// <summary>
        /// Lista de contatos da Empresa
        /// </summary>
        public List<Contato> contatos { get; set; }

        /// <summary>
        /// Locais vinculados na Empresa
        /// </summary>
        public List<Local> locais { get; set; }

    }
}