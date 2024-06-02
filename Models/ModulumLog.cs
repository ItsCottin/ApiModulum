#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace ApiModulum.Models
{
    [Table("TBL_LOG")]
    public class ModelLog
    {
        /// <summary>
        /// Id do Log de erro gravado em base.
        /// </summary>
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Detalhes do erro de Exceção.
        /// </summary>
        [Column("Message")]
        public string? Detalhe { get; set; }

        /// <summary>
        /// Resumo do erro de Exceção.
        /// </summary>
        [Column("MessageTemplate")]
        public string? Resumo { get; set; }

        /// <summary>
        /// Tipo do Log, se é Erro ou Informativo.
        /// </summary>
        [Column("Level")]
        public string? TipoLog { get; set; }

        /// <summary>
        /// Data e horário completo do Log.
        /// </summary>
        [Column("TimeStamp")]
        public DateTime Data { get; set; }

        /// <summary>
        /// Exceção do erro completa.
        /// </summary>
        [Column("Exception")]
        public string? Erro { get; set; }

        /// <summary>
        /// Descrição do erro em XML
        /// </summary>
        [Column("Properties")]
        public string? xml { get; set; }
    }
}