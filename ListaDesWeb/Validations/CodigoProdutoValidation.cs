using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ListaDesWeb.Validations
{
    public class CodigoProdutoValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("O código do produto não pode ser nulo.");
            }

            string codigo = value.ToString();

            if (codigo.Length != 8)
            {
                return new ValidationResult("O código deve ter exatamente 8 caracteres (AAA-1234).");
            }

            string pattern = @"^[A-Z]{3}-\d{4}$";

            if (!Regex.IsMatch(codigo, pattern))
            {
                return new ValidationResult("O código deve estar no formato 'AAA-1234'.");
            }

            return ValidationResult.Success;
        }
    }
}