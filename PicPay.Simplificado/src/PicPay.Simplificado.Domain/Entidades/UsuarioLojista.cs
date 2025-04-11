namespace PicPay.Simplificado.Domain.Entidades;

public class UsuarioLojista : UsuarioBase
{
    public Nome UsuarioNome { get; private set; }
    public DocCnpj UsuarioCnpj { get; set; }
    public DocEmail UsuarioEmail { get; private set; }
    public Carteira UsuarioSaldo { get; private set; }
    public TipoUsuario UsuarioCategoria { get; init; } = TipoUsuario.UsuarioLojista;
    public Password UsuarioPassword { get; private set; }
    public bool TemSaldo => UsuarioSaldo.Saldo > 0;
    public void Debitar(double valor) => UsuarioSaldo.Debitar(valor);

    public void Creditar(double valor) => UsuarioSaldo.Creditar(valor);
    public UsuarioLojista()
    { }

    public class Builder
    {
        private readonly UsuarioLojista _usuarioLojista;

        public Builder()
        {
            _usuarioLojista = new UsuarioLojista();
        }

        public Builder setUsuarioNome(Nome nome)
        {
            _usuarioLojista.UsuarioNome = nome;
            return this;
        }

        public Builder setUsuarioCnpj(DocCnpj cnpj)
        {
            _usuarioLojista.UsuarioCnpj = cnpj;
            return this;
        }

        public Builder setUsuarioEmail(DocEmail email)
        {
            _usuarioLojista.UsuarioEmail = email;
            return this;
        }

        public Builder setUsuarioSaldo(Carteira carteira)
        {
            _usuarioLojista.UsuarioSaldo = carteira;
            return this;
        }

        public Builder setUsuarioPassword(string Password)
        {
            _usuarioLojista.UsuarioPassword = new Password(Password);
            return this;
        }

        public UsuarioLojista Build()
        {
            return _usuarioLojista;
        }
    }
}