using PicPay.Simplificado.Domain.Core.Exeception;
using PicPay.Simplificado.Domain.Core.Interfaces.Validadores;
using PicPay.Simplificado.Domain.Enum;

namespace PicPay.Simplificado.Domain.Core.Validadores;
public class TransferenciaValidator : ITransferenciaValidator
{
    public void ValidarLojistaTitular(TipoUsuario tipoUsuario)
    {
        if (tipoUsuario == TipoUsuario.UsuarioLojista)
        {
            throw new LojistaTransferenciaException("Lojistas só recebem transferências, não enviam dinheiro.");
        }
    }
}
