namespace PicPay.Simplificado.Domain.Entidades;

public class UsuarioComun : UsuarioBase
{
    public Nome UsuarioNome { get; private set; }
    public DocCPF UsuarioCpf { get; set; }
    public DocEmail UsuarioEmail { get; private set; }
    public Carteira UsuarioSaldo { get; private set; }
    public TipoUsuario UsuarioCategoria { get; init; } = TipoUsuario.UsuarioComun;
    public bool TemSaldo => UsuarioSaldo.Saldo > 0;

    public UsuarioComun()
    { }

    public class Builder
    {
        private readonly UsuarioComun _usuarioComun;

        public Builder()
        {
            _usuarioComun = new UsuarioComun();
        }

        public Builder setUsuarioNome(Nome nome)
        {
            _usuarioComun.UsuarioNome = nome;
            return this;
        }

        public Builder setUsuarioCpf(DocCPF cpf)
        {
            _usuarioComun.UsuarioCpf = cpf;
            return this;
        }

        public Builder setUsuarioEmail(DocEmail email)
        {
            _usuarioComun.UsuarioEmail = email;
            return this;
        }

        public Builder setUsuarioSaldo(Carteira carteira)
        {
            _usuarioComun.UsuarioSaldo = carteira;
            return this;
        }

        public UsuarioComun Build()
        {
            return _usuarioComun;
        }
    }
}