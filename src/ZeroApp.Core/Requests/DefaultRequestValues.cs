namespace ZeroApp.Core.Requests;

public record DefaultRequestValues(
    string UserId,
    string UserSessionId,
    string ClientVersion,
    string Action
);