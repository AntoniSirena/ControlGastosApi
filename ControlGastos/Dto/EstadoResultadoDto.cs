using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlGastos.Dto
{
    public class EstadoResultadoDto
    {
        public decimal Ingresos { get; set; }
        public decimal Gastos { get; set; }
        public decimal Diferencia { get; set; }
    }
}