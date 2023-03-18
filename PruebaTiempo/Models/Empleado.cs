using System;
using System.Collections.Generic;

namespace PruebaTiempo.Models
{
    public partial class Empleado
    {
        public int EmpId { get; set; }
        public string? Nombre { get; set; }
        public int? SueldoBase { get; set; }
    }
}
