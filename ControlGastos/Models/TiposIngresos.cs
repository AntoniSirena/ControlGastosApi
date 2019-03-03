using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlGastos.Models
{
    public class TiposIngresos
    {
        [Key]
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }
    }
}