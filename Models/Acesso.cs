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
    }
}