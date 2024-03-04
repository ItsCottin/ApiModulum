#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("TBL_RELACAO")]
    public class Relacao
    {
        /// <summary>
        /// Id único do registro da Tela
        /// </summary>
        [Column("ID_RELA")]
        public int Id { get; set; }

        /// <summary>
        /// Id único do registro da Tela
        /// </summary>
        [Column("ID_RELA_FK")]
        public int IdFk { get; set; }

        /// <summary>
        /// Id único do registro da Tela
        /// </summary>
        [Column("TIPO_RELA")]
        public string? TipoRelacao { get; set; }

        /// <summary>
        /// Tela vinculada na Relação
        /// </summary>
        public Tela Tela { get; set; }
    }
}