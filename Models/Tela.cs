#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("TBL_TELA")]
    public class Tela
    {
        /// <summary>
        /// Id único do registro da Tela
        /// </summary>
        [Column("ID_TELA")]
        public int Id { get; set; }

        /// <summary>
        /// Nome da tela para o Menu
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("NOME_MENU_TELA")]
        public string? NomeMenu { get; set; }

        /// <summary>
        /// Nome da tela na em banco de dados 
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("NOME_TABELA_TELA")]
        public string? NomeTabela { get; set; }

        /// <summary>
        /// Json base para CRUD da tabela dinânamica
        /// </summary>
        [Required]
        [Column("JSON_BASE")]
        public string? json { get; set; }

        /// <summary>
        /// HTML base para renderização no front-end
        /// </summary>
        [Required]
        [Column("HTML_BASE")]
        public string? html { get; set; }

        /// <summary>
        /// Nome do campo primary key da tabela dinânamica
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("NOME_CAMPO_PK")]
        public string? NomeCampoPK { get; set; }

        /// <summary>
        /// Nome do campo primary key da tabela dinânamica
        /// </summary>
        public List<Relacao> relacoes { get; set; }  
    }
}