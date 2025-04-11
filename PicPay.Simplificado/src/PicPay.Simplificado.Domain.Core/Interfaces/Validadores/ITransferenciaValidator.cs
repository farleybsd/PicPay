using PicPay.Simplificado.Domain.Enum;

namespace PicPay.Simplificado.Domain.Core.Interfaces.Validadores;
public interface ITransferenciaValidator
{
    void ValidarLojistaTitular(TipoUsuario tipoUsuario);
}
