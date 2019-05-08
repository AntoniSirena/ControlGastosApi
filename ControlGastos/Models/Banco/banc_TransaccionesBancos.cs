using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControlGastos.Models.Banco
{
    public class banc_TransaccionesBancos
    {
        [Key]
        public int Id { get; set; }
        public string Origen { get; set; }
        public string NumeroTrans { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public decimal Monto { get; set; }
        public int TipoTransaccionId { get; set; }

        public int? BancoOrigenId { get; set; }
        public int? CuentaOrigenId { get; set; }
        public int? BancoDestinoId { get; set; }
        public int? CuentaDestinoId { get; set; }

        public int? RazonAjusteId { get; set; }

        public int? EstadoId { get; set; }
        public bool EstaActiva { get; set; }

        public string Nota { get; set; }


        [ForeignKey("TipoTransaccionId")]
        public virtual banc_TipoTransaccionBancos TipoTransaccionBancos { get; set; }

        [ForeignKey("BancoOrigenId")]
        public virtual banc_Bancos BancoOrigen { get; set; }

        [ForeignKey("CuentaOrigenId")]
        public virtual banc_Cuentas CuentaOrigen { get; set; }

        [ForeignKey("BancoDestinoId")]
        public virtual banc_Bancos BancoDestino { get; set; }

        [ForeignKey("CuentaDestinoId")]
        public virtual banc_Cuentas CuentaDestino { get; set; }

        [ForeignKey("RazonAjusteId")]
        public virtual banc_RazonAjustes RazonAjustes { get; set; }

        [ForeignKey("EstadoId")]
        public virtual Statuses Estado { get; set; }

    }
}