using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace WebApiModulum.Models
{
    [Table("TBL_LOG")]
    public class ModulumLog
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Message")]
        public string Detalhe { get; set; }

        [Column("MessageTemplate")]
        public string Resumo { get; set; }

        [Column("Level")]
        public string TipoLog { get; set; }

        [Column("TimeStamp")]
        public DateTime Data { get; set; }

        [Column("Exception")]
        public string Erro { get; set; }

        [Column("Properties")]
        public string xml { get; set; }
    }
}