using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControlGastos.Models
{
    public class TiposConceptos
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int? TipoGastoId { get; set; }
        public int? TipoIngresoId { get; set; }

        public string Origen { get; set; }


        [ForeignKey("TipoGastoId")]
        public virtual TiposGastos TiposGastos { get; set; }

        [ForeignKey("TipoIngresoId")]
        public virtual TiposIngresos TipoIngresos { get; set; }
    }
}