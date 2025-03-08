namespace ZeroApp.Core.Requests;

public record ActionResponse()
{
    public bool? Success { get; init; } = null;
    public string? Available { get; init; } = string.Empty;
    public long ServerTime { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}