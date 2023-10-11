using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using freeYunSDK.Response;

namespace freeYunSDK.Request;

[DataContract]
public class InitApiReq : BaseApiReq
{
    [JsonIgnore] public string Type => "1";

    public InitApiReq(string version, long timestamp, string macCode, string secretKey)
    {
        Version = version;
        Timestamp = timestamp;
        MacCode = macCode;
        SecretKey = secretKey;
    }

    /// <summary>
    /// 软件版本号
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; }
}