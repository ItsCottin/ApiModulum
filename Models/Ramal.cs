#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("TBL_RAMAL")]
    public class Ramal
    {
        /// <summary>
        /// Id único do registro do ramal
        /// </summary>
        [Column("ID_RAMAL")]
        public int Id { get; set; }

        /// <summary>
        /// Número do ramal
        /// </summary>
        [Column("NUMERO_RAMAL")]
        public int Numero { get; set; }

        /// <summary>
        /// Contato vinculado no Ramal
        /// </summary>
        public Contato Contato { get; set; }
    }
}