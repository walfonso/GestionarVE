using GestionarVE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GestionarVE.DAL
{
    public class VideoEntrevistaContext : DbContext
    {
        public DbSet<VideoEntrevista> VideoEntrevistas { get; set; }
        public DbSet<SolicitudPersonal> SolicitudPersonals { get; set; }
        public DbSet<Preseleccionado> Preseleccionados { get; set; }
        public DbSet<pregunta> Preguntas { get; set; }
        public DbSet<CIUO> CIUOs { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}