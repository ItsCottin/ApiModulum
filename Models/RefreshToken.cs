using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace WebApiModulum.Models
{
    [Table("TBL_MODULUM_REFRESH_TOKEN")]
    public partial class RefreshToken
    {
        [Column("LOGIN_USU")]
        public string loginUsu { get; set; } = null!;

        [Column("ID_TOKEN")]
        public string? idToken { get; set; }

        [Column("REFRESH_TOKEN")]
        public string? refreshToken { get; set; }

        [Column("IS_ACTIVE")]
        public bool isActive { get; set; }

        [Column("DATA_VALIDADE")]
        public DateTime dateValidade { get; set; }
    }
}