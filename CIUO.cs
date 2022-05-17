namespace GestionarVE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CIUO")]
    public partial class CIUO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CIUO()
        {
            SolicitudPersonals = new HashSet<SolicitudPersonal>();
        }

        [Key]
        public int CiouID { get; set; }

        public int Code { get; set; }

        public string Description { get; set; }

        public string Denomination { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudPersonal> SolicitudPersonals { get; set; }
    }
}
