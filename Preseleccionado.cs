namespace GestionarVE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Preseleccionado")]
    public partial class Preseleccionado
    {
        [Key]
        public int idPre { get; set; }

        public int codeKey { get; set; }

        public int codeSolPer { get; set; }

        public string fullname { get; set; }

        public string email { get; set; }

        public int? SolicitudPersonal_SolPerID { get; set; }

        public virtual SolicitudPersonal SolicitudPersonal { get; set; }
    }
}
