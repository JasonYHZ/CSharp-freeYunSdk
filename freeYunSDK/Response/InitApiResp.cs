using System.Text.Json.Serialization;

namespace freeYunSDK.Response;

public  class InitApiResp : BaseApiResp
{
    public InitApiResp(string lastVersion, long code, string nowVersion, long needUpdate, string baseData,
        long timestamp, string md5, string notic)
    {
        LastVersion = lastVersion;
        Code = code;
        NowVersion = nowVersion;
        NeedUpdate = needUpdate;
        BaseData = baseData;
        Timestamp = timestamp;
        Md5 = md5;
        Notic = notic;
    }

    
    /// <summary>
    /// 最新版本号
    /// </summary>
    [JsonPropertyName("lastVersion")] public string LastVersion { get; set; }


    /// <summary>
    /// 当前版本号
    /// </summary>
    [JsonPropertyName("nowVersion")] public string NowVersion { get; set; }

    /// <summary>
    /// 是否需要强制更新：0不需要、1为需要
    /// </summary>
    [JsonPropertyName("needUpdate")] public long NeedUpdate { get; set; }

    /// <summary>
    /// 这个是基础数据
    /// </summary>
    [JsonPropertyName("baseData")] public string BaseData { get; set; }
    
    /// <summary>
    /// 当前版本号的MD5
    /// </summary>
    [JsonPropertyName("md5")] public string Md5 { get; set; }

    /// <summary>
    /// 这个是公告
    /// </summary>
    [JsonPropertyName("notic")] public string Notic { get; set; }
}