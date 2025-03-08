using ZeroApp.Core.Requests;

namespace ZeroApp.Core.Features.Commands.CreateCharacter;

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
    string Name
) : ActionRequest<CreateCharacterResponse>("createCharacter");