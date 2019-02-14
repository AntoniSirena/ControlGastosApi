using ControlGastos.Models;
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

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Semanas> Semanas { get; set; }

        public DbSet<Periodos> Periodos { get; set; }

        public DbSet<Statuses> Statuses { get; set; }

        public DbSet<TiposTransacciones> TiposTrasacciones { get; set; }

        public DbSet<Transacciones> Transacciones { get; set; }

        public DbSet<RazonesAnulacion> RazonesAnulacion  { get; set; }








    }
}