using System.ComponentModel.DataAnnotations;
using ListaDesWeb.Validations;

namespace ListaDesWeb.Models    
{
    public class Aluno
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O RA é obrigatório")]
        [RaValidation]
        public string RA { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email deve ser válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [CpfValidation]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        public bool Ativo { get; set; }
    }
}