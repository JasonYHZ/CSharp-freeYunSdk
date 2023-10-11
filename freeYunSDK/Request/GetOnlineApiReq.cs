using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace freeYunSDK.Request;

[DataContract]
public class GetOnlineApiReq: BaseApiReq
{
    [JsonIgnore] public string Type => "23";

    public GetOnlineApiReq(string version, long timestamp, string macCode, string secretKey)
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