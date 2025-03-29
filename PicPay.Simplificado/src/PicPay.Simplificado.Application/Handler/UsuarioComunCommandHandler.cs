

using PicPay.Simplificado.Application.Response.UsuarioComum.Create;
using PicPay.Simplificado.Domain.ValueObjects;

namespace PicPay.Simplificado.Application.Handler;
public class UsuarioComunCommandHandler : IUsuarioComunCommandHandler
{
    private readonly IUnitOfWork _uow;
    public UsuarioComunCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<CommandResult> Handler(UsuarioComumCreateCommand command)
    {
        await _uow.BeginTransactionAsync();

        try
        {
            var usuarioComum = new UsuarioComun.Builder()
                                         .setUsuarioNome(new Nome(command.NomeCompleto))
                                         .setUsuarioCpf(new DocCPF(command.Cpf))
                                         .setUsuarioEmail(new DocEmail(command.Email))
                                         .setUsuarioSaldo(new Carteira(0))
                                         .Build();

            await _uow.UsuarioComunRepositorio.AddAsync(usuarioComum);

            if (_uow.Commit())
            {
                await _uow.CommitTransactionAsync();

                var response = new UsuarioComumCreateResponse
                {
                    NomeCompleto = usuarioComum.UsuarioNome.ToString(),
                    Cpf = usuarioComum.UsuarioCpf.ToString(),
                    Email = usuarioComum.UsuarioEmail.ToString()
                };

                return new CommandResult(true, "Cliente criado com sucesso", response);
            }

            await _uow.RollbackTransactionAsync();
            return new CommandResult(false, "Dados inválidos");
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new CommandResult(false, $"Erro ao criar cliente: {ex.Message}");
        }
    }



}
