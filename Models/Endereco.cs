#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("address_searchs")]
    public class Endereco
    {
        /// <summary>
        /// Id único do registro do Endereço
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Nome do endereço
        /// </summary>
        [Column("address")]
        public string? endereço { get; set; }

        /// <summary>
        /// CEP do endereço
        /// </summary>
        [Column("postal_code")]
        public string? Cep { get; set; }

        /// <summary>
        /// Latitude do endereço
        /// </summary>
        [Column("latitude")]
        public string? Latitude { get; set; }

        /// <summary>
        /// Longitude do endereço
        /// </summary>
        [Column("longitude")]
        public string? Longitude { get; set; }

        /// <summary>
        /// Prefixo de contato no endereço
        /// </summary>
        [Column("ddd")]
        public string? Ddd { get; set; }
    }
}