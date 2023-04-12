using System.ComponentModel.DataAnnotations;

namespace UniqueApi.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Email { get; set; }
        public string? Clave { get;set; }
        public double Telefono { get; set; }
    }
}
