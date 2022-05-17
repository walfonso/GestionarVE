namespace GestionarVE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SolicitudPersonal")]
    public partial class SolicitudPersonal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SolicitudPersonal()
        {
            Preseleccionadoes = new HashSet<Preseleccionado>();
            VideoEntrevistas = new HashSet<VideoEntrevista>();
        }

        [Key]
        public int SolPerID { get; set; }

        public int EmpresaID { get; set; }

        public int CIOUID { get; set; }

        public string Puesto { get; set; }

        public int CantPuesto { get; set; }

        public virtual CIUO CIUO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Preseleccionado> Preseleccionadoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VideoEntrevista> VideoEntrevistas { get; set; }
    }
}
