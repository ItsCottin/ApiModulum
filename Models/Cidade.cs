#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("cities")]
    public class Cidade
    {
        /// <summary>
        /// Id único do registro da Cidade
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Nome da Cidade
        /// </summary>
        [Column("name")]
        public string? Nome { get; set; }

        /// <summary>
        /// Slug
        /// </summary>
        [Column("slug")]
        public string? Slug { get; set; }

        /// <summary>
        /// Lista de distritos da Cidade
        /// </summary>
        public ICollection<Distrito> Distritos { get; set; }

        /// <summary>
        /// Lista de Endereços na Cidade
        /// </summary>
        public ICollection<Endereco> Enderecos { get; set; }
    
    }
}