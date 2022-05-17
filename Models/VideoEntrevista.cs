using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionarVE.Models
{
    public class VideoEntrevista
    {
        [Key]
        public int VEntrevistaID  { get; set; }
        public string Name { get; set; }
        public Estado estado { get; set; }
        public virtual ICollection<pregunta> Preguntas { get; set; }
    }
}