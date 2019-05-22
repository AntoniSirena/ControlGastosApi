using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControlGastos.Models.Banco
{
    public class banc_BalanceCuenta
    {
        [Key]
        public int Id { get; set; }

        public int CuentaId { get; set; }

        public decimal Balance { get; set; }

        [ForeignKey("CuentaId")]
        public virtual banc_Cuenta banc_Cuenta { get; set; }
    }
}