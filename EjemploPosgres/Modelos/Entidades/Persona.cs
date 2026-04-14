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

        [FechaFutura(2, ErrorMessage = "La reserva debe hacerse con al menos 2 días de anticipación.")]
        public DateTime FechaReserva { get; set; }


        //Validacion personalizada si es mayor de edad >=18
        [MayorDeEdad(18, ErrorMessage = "La persona debe ser mayor de edad")]
        public int Edad { get; set; }


    }


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,
    AllowMultiple = false)]
    public class FechaFuturaAttribute : ValidationAttribute
    {
        private readonly int _diasMinimos;

        public FechaFuturaAttribute(int diasMinimos = 0)
        {
            _diasMinimos = diasMinimos;
            ErrorMessage = $"La fecha debe ser al menos {diasMinimos} día(s) en el futuro.";
        }

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value is null) return ValidationResult.Success;

            if (value is not DateTime fecha)
                return new ValidationResult("El valor debe ser una fecha válida.");

            var fechaMinima = DateTime.UtcNow.AddDays(_diasMinimos);

            if (fecha < fechaMinima)
                return new ValidationResult(
                    FormatErrorMessage(validationContext.DisplayName),
                    new[] { validationContext.MemberName! });

            return ValidationResult.Success;
        }
    }


    // validacion personalizada para detectar si es mayor de edad
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,
    AllowMultiple = false)]
    public class MayorDeEdadAttribute : ValidationAttribute
    {
        private readonly int _edadMimina;

        public MayorDeEdadAttribute(int edadMinima = 18)
        {
            _edadMimina = edadMinima;
            ErrorMessage = $"La edad debe ser al menos {edadMinima} años.";
        }

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value is null) return ValidationResult.Success;


            if ((int) value < 18 )
                return new ValidationResult(
                    FormatErrorMessage(validationContext.DisplayName),
                    new[] { validationContext.MemberName! });

            return ValidationResult.Success;
        }
    }


}
