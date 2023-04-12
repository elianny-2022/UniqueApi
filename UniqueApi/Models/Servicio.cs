using System.ComponentModel.DataAnnotations;

namespace UniqueApi.Models
{
    public class Servicio
    {
        [Key]
        public int ServicioId { get; set; }
        public int TipoId { get; set; }
        public string? Descripcion { get;set; }
        public double Costo { get; set; }
        
    }
}
