using System.ComponentModel.DataAnnotations;

namespace UniqueApi.Models
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }
        public int ServicioId { get; set; }
        public int ClienteId { get; set; }
        public int EstadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Nombre { get; set; } 
        public string? Apellido { get; set; }
    }
}
