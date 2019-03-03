using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlGastos.Global
{
    public static class Constante
    {
        public static class Statuses
        {
            public const string Abierto = "01";
            public const string PendienteAbrir = "02";
            public const string Cerrado = "03";
        }
            

        public static class TiposTransaccion
        {
            public const string Gasto = "GAT";
            public const string Ingeso = "ING";
        }

        public static class OrigenTipoConcepto
        {
            public const string Gasto = "Gasto";
            public const string Ingreso = "Ingreso";
        }

    }
}