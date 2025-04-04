namespace PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarioLojista;
public class UsuarioLojistaCreateCommand
{
    public string NomeCompleto { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public UsuarioLojistaCreateCommand(string nomeCompleto, string cpf, string email, string senha)
    {
        NomeCompleto = nomeCompleto;
        Cpf = cpf;
        Email = email;
        Senha = senha;
    }
}
