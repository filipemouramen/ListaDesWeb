using System.ComponentModel.DataAnnotations;

namespace ListaDesWeb.Validations
{
    public class RaValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("O RA não pode ser nulo.");
            }

            string ra = value.ToString();

            if (ra.Length != 8)
            {
                return new ValidationResult("O RA deve conter 8 caracteres: 'RA' + 6 dígitos.");
            }

            if (ra[0] != 'R' || ra[1] != 'A')
            {
                return new ValidationResult("O RA deve começar com 'RA'.");
            }

            for (int i = 2; i < ra.Length; i++)
            {
                if (!char.IsDigit(ra[i]))
                {
                    return new ValidationResult("Os últimos 6 caracteres do RA devem ser dígitos numéricos.");
                }
            }

            return ValidationResult.Success;
        }
    }
}