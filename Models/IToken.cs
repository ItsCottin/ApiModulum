#pragma warning disable CS1591
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace ApiModulum.Models
{
    [Table("TBL_ITOKEN")]
    public partial class IToken
    {
        [Column("LOGIN_USU")]
        public string loginUsu { get; set; } = null!;

        [Column("ID_TOKEN")]
        public string? idToken { get; set; }

        [Column("ITOKEN")]
        public string? iToken { get; set; }

        [Column("IS_ACTIVE")]
        public bool isActive { get; set; }

        [Column("DATA_VALIDADE")]
        public DateTime dateValidade { get; set; }
    }
}