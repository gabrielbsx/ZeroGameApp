using MediatR;

namespace ZeroApp.Core.Features.Commands.RegisterUser;

public class RegisterUserCommand : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new RegisterUserResponse("Testando"));
    }
}