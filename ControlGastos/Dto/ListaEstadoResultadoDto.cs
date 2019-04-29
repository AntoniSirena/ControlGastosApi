using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlGastos.Dto
{
    public class ListaEstadoResultadoDto
    {
        public List<EstadoResultadoDto> Resultado { get; set; }
        public List<ResumenTransaccionDto> Ingreso { get; set; }
        public List<ResumenTransaccionDto> Gasto { get; set; }
    }
}