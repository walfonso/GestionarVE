using System.ComponentModel.DataAnnotations;

namespace GestionarVE.Models
{
    public class Estado
    {
        [Key]
        public int EstadoID { get; set; }
        public string Descrption { get; set; }
        public bool Active { get; set; }
    }
}