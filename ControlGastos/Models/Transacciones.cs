using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControlGastos.Models
{
    public class Transacciones
    {
        [Key]
        public int Id { get; set; }

        public int? TipoTransacionId { get; set; }

        public int? ConceptoId { get; set; }

        public int? PeriodoId { get; set; }

        public int? SemanaId { get; set; }

        public int? AreaId { get; set; }

        public decimal Monto { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string FechaCreacion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string FechaRegistro { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string FechaAnulacion { get; set; }

        public string Comentario { get; set; }

        public bool EstaAnulada { get; set; }

        public string Referencia { get; set; }



        [ForeignKey("TipoTransacionId")]
        public virtual TiposTransacciones TiposTransacciones { get; set; }

        [ForeignKey("ConceptoId")]
        public virtual TiposConceptos TiposConceptos { get; set; }

        [ForeignKey("PeriodoId")]
        public virtual Periodos Periodos  { get; set; }

        [ForeignKey("SemanaId")]
        public virtual Semanas Semanas { get; set; }

        [ForeignKey("AreaId")]
        public virtual Area Areas { get; set; }
    }
}