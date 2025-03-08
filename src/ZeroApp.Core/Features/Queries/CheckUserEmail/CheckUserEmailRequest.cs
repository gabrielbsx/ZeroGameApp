using ZeroApp.Core.Requests;

namespace ZeroApp.Core.Features.Queries.CheckUserEmail;

public sealed record CheckUserEmailRequest(
    string Email
) : ActionRequest<CheckUserEmailResponse>("checkUserEmail");