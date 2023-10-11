using System.Text.Json.Serialization;

namespace freeYunSDK;

public class BaseDto
{
    [JsonPropertyName("msg")] public string Msg { get; set; }

    [JsonPropertyName("data")] public string Data { get; set; }

    [JsonPropertyName("status")] public int Status { get; set; }
}