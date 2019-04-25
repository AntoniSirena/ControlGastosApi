using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlGastos.Dto
{
    public class ResumenTransaccionDto
    {
        public string Conceptos { get; set; }
        public decimal? Monto { get; set; }
    }
}