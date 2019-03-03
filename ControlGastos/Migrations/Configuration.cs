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
            //Tipos de gastos
            context.TiposGastos.AddOrUpdate(
              p => p.Descripcion,
              new TiposGastos { Codigo = "01", Descripcion = "Gastos Fijos" },
              new TiposGastos { Codigo = "02", Descripcion = "Gastos Variables" },
              new TiposGastos { Codigo = "03", Descripcion = "Gastos Marginales" },
              new TiposGastos { Codigo = "04", Descripcion = "Gastos Mixtos" },
              new TiposGastos { Codigo = "05", Descripcion = "Gastos Directos" },
              new TiposGastos { Codigo = "06", Descripcion = "Gastos Indirectos" }
              );

            //Tipos de ingresoso
            context.TiposIngresos.AddOrUpdate(
              p => p.Descripcion,
              new TiposIngresos { Codigo = "01", Descripcion = "Ordinarios" },
              new TiposIngresos { Codigo = "02", Descripcion = "Extraordinarios" }           
              );

            //Semanas
            context.Semanas.AddOrUpdate(
              p => p.Descripcion,
              new Semanas { Codigo = "01", Descripcion = "Semana1" },
              new Semanas { Codigo = "02", Descripcion = "Semana2" },
              new Semanas { Codigo = "03", Descripcion = "Semana3" },
              new Semanas { Codigo = "04", Descripcion = "Semana4" },
              new Semanas { Codigo = "05", Descripcion = "Semana5" },
              new Semanas { Codigo = "06", Descripcion = "Semana6" },
              new Semanas { Codigo = "07", Descripcion = "Semana7" },
              new Semanas { Codigo = "08", Descripcion = "Semana8" },
              new Semanas { Codigo = "09", Descripcion = "Semana9" },
              new Semanas { Codigo = "10", Descripcion = "Semana10" },
              new Semanas { Codigo = "11", Descripcion = "Semana11" },
              new Semanas { Codigo = "12", Descripcion = "Semana12" }
              );

            //Statuses
            context.Statuses.AddOrUpdate(
              p => p.Descripcion,
              new Statuses { Codigo = "01", Descripcion = "Abierto" },
              new Statuses { Codigo = "02", Descripcion = "Pendiente de abrir" },
              new Statuses { Codigo = "03", Descripcion = "Cerrado" }

              );

            //TiposTrasacciones
            context.TiposTrasacciones.AddOrUpdate(
              p => p.Descripcion,
              new TiposTransacciones { Codigo = "GAT", Descripcion = "Gasto" },
              new TiposTransacciones { Codigo = "ING", Descripcion = "Ingreso" }
              );




            context.SaveChanges();

        }
    }
}
