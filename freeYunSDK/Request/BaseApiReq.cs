using System.Text.Json.Serialization;

namespace freeYunSDK.Request;

public class BaseApiReq
{
    /// <summary>
    /// 机器码
    /// </summary>
    [JsonPropertyName("macCode")]
    public string MacCode { get; set; }

    /// <summary>
    /// 时间戳
    /// </summary>
    [JsonPropertyName("timeStamp")]
    public long Timestamp { get; set; }
    
    /// <summary>
    /// 软件密钥
    /// </summary>
    [JsonPropertyName("secretKey")]
    public string SecretKey { get; set; }
}