using System.ComponentModel.DataAnnotations;

namespace UniqueApi.Models
{
    public class TipoServicio
    {
        [Key]
        public int TipoId { get; set; }
        public string? Tipo { get; set; }
    }
}
