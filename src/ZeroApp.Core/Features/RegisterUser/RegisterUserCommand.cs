using ZeroApp.Core.Contracts;

namespace ZeroApp.Core.Features.RegisterUser;

public class RegisterUserCommand : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    public static string Action = "registerUser";
    
    public async Task<RegisterUserResponse> HandleAsync(RegisterUserRequest request)
    {
        return await Task.FromResult(new RegisterUserResponse("Testando"));
    }
}