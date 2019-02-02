namespace ControlGastos.Migrations
{
    using ControlGastos.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ControlGastos.DBContext.MyDBcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ControlGastos.DBContext.MyDBcontext context)
        {
            context.TiposGastos.AddOrUpdate(
              p => p.Descripcion,
              new TiposGastos { Codigo = "01", Descripcion = "Gastos Fijos" },
              new TiposGastos { Codigo = "02", Descripcion = "Gastos Variables" },
              new TiposGastos { Codigo = "03", Descripcion = "Gastos Marginales" },
              new TiposGastos { Codigo = "04", Descripcion = "Gastos Mixtos" },
              new TiposGastos { Codigo = "05", Descripcion = "Gastos Directos" },
              new TiposGastos { Codigo = "06", Descripcion = "Gastos Indirectos" }
              );





            context.SaveChanges();

        }
    }
}
