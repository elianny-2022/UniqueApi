using System.ComponentModel.DataAnnotations;

namespace UniqueApi.Models
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        public string? Descripcion { get; set; }
    }
}
