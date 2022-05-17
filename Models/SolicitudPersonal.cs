using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionarVE.Models
{
    public class SolicitudPersonal
    {
        [Key]
        public int SolPerID { get; set; }
        public int EmpresaID { get; set; }
        public int CIOUID { get; set; }
        public string Puesto { get; set; }
        public int CantPuesto { get; set; }

        public virtual CIUO CIOU { get; set; }
        public virtual ICollection<Preseleccionado> Preseleccionados { get; set; }
        public virtual ICollection<VideoEntrevista> VideosEntrevistas { get; set; }


    }
}