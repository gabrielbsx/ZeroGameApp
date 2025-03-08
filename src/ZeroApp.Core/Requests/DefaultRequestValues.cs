namespace ZeroApp.Core.Requests;

public record DefaultRequestValues(
    string Action,
    string UserId,
    string UserSessionId,
    string ClientVersion,
    int BuildNumber,
    string Auth,
    int Rct,
    bool KeepAlive,
    string DeviceType
);