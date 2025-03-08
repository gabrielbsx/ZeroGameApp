using MediatR;

namespace ZeroApp.Core.Features.Queries.CheckUserEmail;

public class CheckUserEmailQuery : IRequestHandler<CheckUserEmailRequest, CheckUserEmailResponse>
{
    public async Task<CheckUserEmailResponse> Handle(CheckUserEmailRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new CheckUserEmailResponse());
    }
}