namespace PicPay.Simplificado.Application.Request.UsuarioComum.Create
{
    public class UsuarioLojistaCreateRequest
    {
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome completo deve ter entre 5 e 100 caracteres.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^(\d{14}|\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2})$",
            ErrorMessage = "O CNPJ deve estar no formato 00.000.000/0000-00 ou conter exatamente 14 dígitos.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string Senha { get; set; }
    }
}