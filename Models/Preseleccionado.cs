using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionarVE.Models
{
    public class Preseleccionado
    {
        [Key]
        public int idPre { get; set; }
        public int codeKey { get; set; }  
        public int codeSolPer { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
    }
}