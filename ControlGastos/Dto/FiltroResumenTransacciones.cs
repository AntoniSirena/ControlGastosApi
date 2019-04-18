using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlGastos.Dto
{
    public class FiltroResumenTransacciones
    {
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? ConceptoId { get; set; }
        public int? PeriodoId { get; set; }
        public int? SemanaId { get; set; }
        public int? AreaId { get; set; }
    }
}