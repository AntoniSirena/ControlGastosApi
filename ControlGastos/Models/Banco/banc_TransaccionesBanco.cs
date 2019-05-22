using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControlGastos.Models.Banco
{
    public class banc_TransaccionesBanco
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

        public int Sequencia { get; set; }


        [ForeignKey("TipoTransaccionId")]
        public virtual banc_TipoTransaccionBanco TipoTransaccionBanco { get; set; }

        [ForeignKey("BancoOrigenId")]
        public virtual banc_Banco BancoOrigen { get; set; }

        [ForeignKey("CuentaOrigenId")]
        public virtual banc_Cuenta CuentaOrigen { get; set; }

        [ForeignKey("BancoDestinoId")]
        public virtual banc_Banco BancoDestino { get; set; }

        [ForeignKey("CuentaDestinoId")]
        public virtual banc_Cuenta CuentaDestino { get; set; }

        [ForeignKey("RazonAjusteId")]
        public virtual banc_RazonAjuste RazonAjuste { get; set; }

        [ForeignKey("EstadoId")]
        public virtual Statuses Estatus { get; set; }

    }
}