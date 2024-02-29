#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("states")]
    public class Estado
    {
        /// <summary>
        /// Id único do registro do Estado
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Estado
        /// </summary>
        [Column("name")]
        public string? Nome { get; set; }

        /// <summary>
        /// Nome do Estado
        /// </summary>
        [Column("initials")]
        public string? Uf { get; set; }

        /// <summary>
        /// Lista de cidades do Estado
        /// </summary>
        public List<Cidade> cidades { get; set; }
    }
}