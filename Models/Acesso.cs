#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Diagnostics.CodeAnalysis;
using WebApiModulum.Filters;

namespace WebApiModulum.Models
{
    [Table("TBL_ACESSO")]
    public class Acesso
    {
        // TODO: Verificar um jeito de levantar o acesso somente do usuário logado

        /// <summary>
        /// Id único do registro da Aplicação
        /// </summary>
        [Column("ID_APL")]
        public int IdApl { get; set; }

        /// <summary>
        /// Id único do registro da Tela
        /// </summary>
        [Column("ID_TELA")]
        public int IdTela { get; set; }

        /// <summary>
        /// Id único do registro do Usuário
        /// </summary>
        [Column("ID_USU")]
        public int IdUsu { get; set; }
    }
}