using System;
using System.Collections.Generic;

namespace WebApiModulum.Models
{
    public class Parameter
    {
        public string? name { get; set; }
        public string? @in { get; set; }
        public string? type { get; set; }
        public bool required { get; set; }
    }
}