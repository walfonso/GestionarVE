using System.ComponentModel.DataAnnotations;

namespace GestionarVE.Models
{
    public class pregunta
    {
        [Key]
        public int preguntaID { get; set; }
        public int VideoentrevistaID { get; set; }
        public int orderPregID { get; set; }
        public string description { get; set; }
    }
}