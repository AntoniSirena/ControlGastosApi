using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControlGastos.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


        [ForeignKey("PersonaId")]
        public virtual Personas Personas { get; set; }

    }
}