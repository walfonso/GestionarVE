namespace GestionarVE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pregunta")]
    public partial class pregunta
    {
        public int preguntaID { get; set; }

        public int VideoentrevistaID { get; set; }

        public int orderPregID { get; set; }

        public string description { get; set; }

        public int? VideoEntrevista_VEntrevistaID { get; set; }

        public virtual VideoEntrevista VideoEntrevista { get; set; }
    }
}
