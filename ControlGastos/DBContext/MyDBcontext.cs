using ControlGastos.Models;
using ControlGastos.Models.Banco;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ControlGastos.DBContext
{
    public class MyDBcontext: DbContext
    {
        public MyDBcontext() : base("name=ControlGastos")
        {

        }

        //metodo para eliminar la plurarizacion de las entidades
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<TiposConceptos> TiposConceptos { get; set; }

        public DbSet<TiposGastos> TiposGastos { get; set; }

        public DbSet<Personas> Personas { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Semanas> Semanas { get; set; }

        public DbSet<Periodos> Periodos { get; set; }

        public DbSet<Statuses> Statuses { get; set; }

        public DbSet<TiposTransacciones> TiposTrasacciones { get; set; }

        public DbSet<Transacciones> Transacciones { get; set; }

        public DbSet<RazonesAnulacion> RazonesAnulacion  { get; set; }

        public DbSet<TiposIngresos> TiposIngresos { get; set; }

        public DbSet<RazonesAnulacionTransaccion> RazonesAnulacionTransaccion { get; set; }

        public DbSet<TiposPersonas> TiposPersonas { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<banc_TipoTransaccionBanco> banc_TipoTransaccionBancos { get; set; }

        public DbSet<banc_Banco> banc_Bancos { get; set; }

        public DbSet<banc_TipoCuenta> banc_TipoCuentas { get; set; }

        public DbSet<banc_Cuenta> banc_Cuentas { get; set; }

        public DbSet<banc_RazonAjuste> banc_RazonAjustes { get; set; }

        public DbSet<banc_TransaccionesBanco> banc_TransaccionesBancos { get; set; }

        public DbSet<banc_BalanceCuenta> banc_BalanceCuentas { get; set; }



    }
}