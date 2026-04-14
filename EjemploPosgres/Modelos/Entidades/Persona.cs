using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemploPosgres.Modelos.Entidades
{
    [Table("Personas")]
    public class Persona
    {
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio personalizado.")]
        [StringLength(20, MinimumLength = 3,
        ErrorMessage = "El nombre debe tener entre 3 y 20 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El formato debe ser 0000-0000")]
        public string Telefono { get; set; }
    }
}
