using System.Text.Json.Serialization;

namespace freeYunSDK.Response;

public class BaseApiResp
{
    /// <summary>
    /// 业务响应代码
    /// </summary>
    [JsonPropertyName("code")] public long Code { get; set; }
    /// <summary>
    /// 服务器时间戳
    /// </summary>
    [JsonPropertyName("timestamp")] public long Timestamp { get; set; }
}