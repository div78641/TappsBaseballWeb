using System.Text.Json;

namespace TappsBaseballWeb.Data;

public sealed class ParticipantService 
{
    public Task<List<Participant>> GetParticipantsAsync()
    {
        return Task.FromResult(DeserializeJsonFromFile<List<Participant>>("TappsBaseballHistory.json"));
    }
    private static T DeserializeJsonFromFile<T>(string fullyQualifiedFileName)
    {
        T tObject = JsonSerializer.Deserialize<T>(LoadTextFromFile(fullyQualifiedFileName));
        return tObject;
    }

    private static void SerializeJsonToFile<T>(T data, string fullyQualifiedFileName)
    {
        string json = JsonSerializer.Serialize(data);
        File.WriteAllText(fullyQualifiedFileName, json);
    }

    private static string LoadTextFromFile(string fullyQualifiedFileName)
    {
        if (File.Exists(fullyQualifiedFileName))
        {
            return File.ReadAllText(fullyQualifiedFileName);
        }
        else
        {
            return string.Empty;
        }
    }
}