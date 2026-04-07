using System.ComponentModel.DataAnnotations.Schema;

namespace EjemploPosgres.Modelos.Entidades
{
    [Table("Personas")]
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
