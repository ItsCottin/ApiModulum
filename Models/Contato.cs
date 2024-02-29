#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("TBL_CONTATO")]
    public class Contato
    {
        /// <summary>
        /// Id único do registro de usuário
        /// </summary>
        [Column("ID_CON")]
        public int Id { get; set; }

        /// <summary>
        /// Tipo do contato: 'Residencial' ou 'Comercial'
        /// </summary>
        [Column("TIPO_CON")]
        public string? TipoContato { get; set; }

        /// <summary>
        /// Tipo do número: 'Celular' ou 'Telefone'
        /// </summary>
        [Column("TIPO_NUMERO")]
        public string? TipoNumero { get; set; }

        /// <summary>
        /// Número do contato
        /// </summary>
        [Column("NUMERO_CON")]
        public string? Numero { get; set; }

        /// <summary>
        /// Lista de ramals
        /// </summary>
        public List<Ramal> ramals { get; set; }
    }

}