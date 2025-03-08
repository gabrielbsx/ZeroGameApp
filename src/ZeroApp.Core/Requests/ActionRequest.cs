using MediatR;

namespace ZeroApp.Core.Requests;

public record ActionRequest<TResponse>(
    string Action
) : IRequest<TResponse>
{
    public string UserId { get; init; } = string.Empty;
    public string UserSessionId { get; init; } = string.Empty;
    public string ClientVersion { get; init; } = string.Empty;
    public int BuildNumber { get; init; }
    public string Auth { get; init; } = string.Empty;
    public int Rct { get; init; }
    public bool KeepAlive { get; init; }
    public string DeviceType { get; init; } = string.Empty;
}