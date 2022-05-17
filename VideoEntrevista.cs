namespace GestionarVE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VideoEntrevista")]
    public partial class VideoEntrevista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VideoEntrevista()
        {
            preguntas = new HashSet<pregunta>();
        }

        [Key]
        public int VEntrevistaID { get; set; }

        public string Name { get; set; }

        public int? estado_EstadoID { get; set; }

        public int? SolicitudPersonal_SolPerID { get; set; }

        public virtual Estado Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pregunta> preguntas { get; set; }

        public virtual SolicitudPersonal SolicitudPersonal { get; set; }
    }
}
