namespace PicPay.Simplificado.Domain.Entidades;

public class UsuarioLojista : UsuarioBase
{
    public Nome UsuarioNome { get; private set; }
    public DocCnpj UsuarioCnpj { get; set; }
    public DocEmail UsuarioEmail { get; private set; }
    public Carteira UsuarioSaldo { get; private set; }
    public TipoUsuario UsuarioCategoria { get; init; } = TipoUsuario.UsuarioComun;

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

        public UsuarioLojista Build()
        {
            return _usuarioLojista;
        }
    }
}