using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControlGastos.Models.Banco
{
    public class banc_Cuentas
    {
        [Key]
        public int Id { get; set; }

        public string NumeroCuenta { get; set; }

        public int TipoCuentaId { get; set; }

        public int BancoId { get; set; }

        public int EstadoId { get; set; }


        [ForeignKey("TipoCuentaId")]
        public virtual banc_TipoCuentas TipoCuentas { get; set; }

        [ForeignKey("BancoId")]
        public virtual banc_Bancos Bancos { get; set; }

        [ForeignKey("EstadoId")]
        public virtual Statuses Statuses { get; set; }
    }
}