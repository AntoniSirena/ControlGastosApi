using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControlGastos.Models
{
    public class Personas
    {
        [Key]
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string FechaNacimiento { get; set; }

        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public int? TipoPersonaId { get; set; }

        public string NombreCompleto { get { return string.Format("{0} {1} {2} {3}", PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido); } }


        [ForeignKey("TipoPersonaId")]
        public virtual TiposPersonas TiposPersonas { get; set; }

    }
}