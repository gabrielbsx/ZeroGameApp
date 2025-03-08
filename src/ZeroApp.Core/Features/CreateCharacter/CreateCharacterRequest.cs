using ZeroApp.Core.Requests;

namespace ZeroApp.Core.Features.CreateCharacter;

public sealed record CreateCharacterRequest(
    string Gender,
    int SkinColor,
    int HairColor,
    int HairType,
    int HeadType,
    int EyesType,
    int EyebrowsType,
    int NoseType,
    int MouthType,
    int FacialHairType,
    int DecorationType,
    string Name,
    // Default Request Values
    string Action,
    string UserId,
    string UserSessionId,
    string ClientVersion,
    int BuildNumber,
    string Auth,
    int Rct,
    bool KeepAlive,
    string DeviceType
) : DefaultRequestValues(
    Action,
    UserId,
    UserSessionId,
    ClientVersion,
    BuildNumber,
    Auth,
    Rct,
    KeepAlive,
    DeviceType
);