#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("districts")]
    public class Distrito
    {
        /// <summary>
        /// Id único do registro do Distrito
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Distrito
        /// </summary>
        [Column("name")]
        public string? Nome { get; set; }

        /// <summary>
        /// Slug
        /// </summary>
        [Column("slug")]
        public string? Slug { get; set; }

        /// <summary>
        /// Lista de Endereços no Distrito
        /// </summary>
        public ICollection<Endereco> Enderecos { get; set; }

        /// <summary>
        /// Cidade vinculado no Distrito
        /// </summary>
        public Cidade Cidade { get; set; }
    
    }
}