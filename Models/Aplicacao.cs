#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("TBL_APLICACAO")]
    public class Aplicacao
    {
        /// <summary>
        /// Id único do registro da Aplicação
        /// </summary>
        [Column("ID_APL")]
        public int Id { get; set; }

        /// <summary>
        /// Nome da Aplicação
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("NOME_APL")]
        public string? Nome { get; set; }

        /// <summary>
        /// Telas vinculadas na Aplicação
        /// </summary>
        public List<Tela> telas { get; set; }

    }
}