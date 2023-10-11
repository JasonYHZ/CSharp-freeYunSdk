using System.Text.Json.Serialization;

namespace freeYunSDK.Response;

public  class OnlineNumberResp : BaseApiResp
{
    public OnlineNumberResp(int onlineNum)
    {
        OnlineNum = onlineNum;
    }

    /// <summary>
    /// 在线人数
    /// </summary>
    [JsonPropertyName("onlineNum")] public int OnlineNum { get; set; }
    
}