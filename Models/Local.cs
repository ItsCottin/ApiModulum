#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("TBL_LOCAL")]
    public class Local
    {
        /// <summary>
        /// Id único do registro do Local
        /// </summary>
        [Column("ID_LOC")]
        public int Id { get; set; }

        /// <summary>
        /// Tipo do Local: 'Residencial' ou 'Comercial'
        /// </summary>
        [Column("TIPO_LOCAL")]
        public string? TipoLocal { get; set; }

        /// <summary>
        /// Número do local
        /// </summary>
        [Column("NUMERO_LOC")]
        public string? Numero { get; set; }

        /// <summary>
        /// Estado do local
        /// </summary>
        [Column("UF_LOC")]
        public string? Uf { get; set; }

        /// <summary>
        /// Cidade do local
        /// </summary>
        [Column("CIDADE_LOC")]
        public string? Cidade { get; set; }

        /// <summary>
        /// CEP do local
        /// </summary>
        [Column("CEP_LOC")]
        public string? Cep { get; set; }
    
        /// <summary>
        /// Endereço do local
        /// </summary>
        [Column("ENDERECO_LOC")]
        public string? Endereco { get; set; }

        /// <summary>
        /// Empresa vinculado no Local
        /// </summary>
        public Empresa Empresa { get; set; }

    }
}