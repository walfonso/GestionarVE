using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GestionarVE
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=VEntrevista")
        {
        }

        public virtual DbSet<CIUO> CIUOs { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<pregunta> preguntas { get; set; }
        public virtual DbSet<Preseleccionado> Preseleccionadoes { get; set; }
        public virtual DbSet<SolicitudPersonal> SolicitudPersonals { get; set; }
        public virtual DbSet<VideoEntrevista> VideoEntrevistas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .HasMany(e => e.VideoEntrevistas)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.estado_EstadoID);

            modelBuilder.Entity<SolicitudPersonal>()
                .HasMany(e => e.Preseleccionadoes)
                .WithOptional(e => e.SolicitudPersonal)
                .HasForeignKey(e => e.SolicitudPersonal_SolPerID);

            modelBuilder.Entity<SolicitudPersonal>()
                .HasMany(e => e.VideoEntrevistas)
                .WithOptional(e => e.SolicitudPersonal)
                .HasForeignKey(e => e.SolicitudPersonal_SolPerID);

            modelBuilder.Entity<VideoEntrevista>()
                .HasMany(e => e.preguntas)
                .WithOptional(e => e.VideoEntrevista)
                .HasForeignKey(e => e.VideoEntrevista_VEntrevistaID);
        }
    }
}
