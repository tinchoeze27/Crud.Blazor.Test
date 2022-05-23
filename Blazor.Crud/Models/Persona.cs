using System.ComponentModel.DataAnnotations;

namespace Blazor.Crud.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string Ciudad { get; set; }
    }
}
