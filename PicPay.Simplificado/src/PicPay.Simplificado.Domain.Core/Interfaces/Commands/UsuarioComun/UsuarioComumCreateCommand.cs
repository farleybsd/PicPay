namespace PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarioComun;

public class UsuarioComumCreateCommand
{
    public string NomeCompleto { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    public UsuarioComumCreateCommand(string nomeCompleto, string cpf = null, string email = null, string senha = null)
    {
        NomeCompleto = nomeCompleto;
        Cpf = cpf;
        Email = email;
        Senha = senha;
    }
}