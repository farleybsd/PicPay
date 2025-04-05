namespace PicPay.Simplificado.Service.Interfaces;
public interface IAuthorizeGateway
{
    Task<AuthorizeResponse> AutorizarTransracao();
}
