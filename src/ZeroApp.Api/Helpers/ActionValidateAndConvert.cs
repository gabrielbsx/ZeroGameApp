using System.Text.Json;

namespace ZeroApp.Api.Helpers;

public static class ActionValidateAndConvert
{
    public static object ValidateAndConvert(Dictionary<string, string> formData)
    {
        if (!ActionMapping.Actions.TryGetValue(formData.GetValueOrDefault("action") ?? "", out var requestType))
            throw new InvalidOperationException("Invalid or missing action.");

        return JsonSerializer.Deserialize(JsonSerializer.Serialize(formData), requestType)
               ?? throw new InvalidOperationException("Failed to deserialize request.");
    }
}