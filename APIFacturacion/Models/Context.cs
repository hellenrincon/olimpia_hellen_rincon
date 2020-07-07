using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIFacturacion.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("Connection")
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Factura> Facturas { get; set; }

    }
}