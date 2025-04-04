using Microsoft.EntityFrameworkCore;
using PicPay.Simplificado.Application.Exceptions;
using PicPay.Simplificado.Application.Response.UsuariosLojistas;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarioLojista;
using PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarrioLojistas;

namespace PicPay.Simplificado.Application.Handler.Command.UsuarioLojistas;

public class UsuarioLojistaCommandHandler : IUsuarioLojistaCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    private const double SALDO_INICIAL = 1000.00;

    public UsuarioLojistaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CommandResult> Handler(UsuarioLojistaCreateCommand command)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var usuarioLojista = new UsuarioLojista.Builder()
                                                    .setUsuarioNome(new Nome(command.NomeCompleto))
                                                    .setUsuarioCnpj(new DocCnpj(command.Cpf))
                                                    .setUsuarioEmail(new DocEmail(command.Email))
                                                    .setUsuarioSaldo(new Carteira(SALDO_INICIAL))
                                                    .setUsuarioPassword(command.Senha)
                                                    .Build();

            await _unitOfWork.UsuarioLojistaRepositorio.AddAsync(usuarioLojista);

            if (_unitOfWork.Commit())
            {
                await _unitOfWork.CommitTransactionAsync();

                var response = new UsuarioLojistaCreateResponse
                {
                    NomeCompleto = usuarioLojista.UsuarioNome.ToString(),
                    Cnpj = usuarioLojista.UsuarioCnpj.ToString(),
                    Email = usuarioLojista.UsuarioEmail.ToString()
                };

                return new CommandResult(true, "Cliente criado com sucesso", response);
            }

            await _unitOfWork.RollbackTransactionAsync();
            return new CommandResult(false, "Dados inválidos");
        }
        catch (DbUpdateException dbEx)
        {
            // Verifica se a exception foi por violação de e-mail único
            if (dbEx.InnerException?.Message.Contains("IX_UsuarioLojista_Email") == true)
                throw new EmailDuplicadoException();

            // Verifica se a exception foi por violação de CPF único
            if (dbEx.InnerException?.Message.Contains("IX_UsuarioLojista_CNPJ") == true)
                throw new CNPJDuplicadoException();

            // Se for outro erro, rethrow
            throw;
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            return new CommandResult(false, $"Erro ao criar cliente: {ex.Message}");
        }
    }
}