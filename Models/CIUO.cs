using System.ComponentModel.DataAnnotations;

namespace GestionarVE.Models
{
    public class CIUO
    {
        [Key]
        public int CiouID { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Denomination { get; set; }
    }
}