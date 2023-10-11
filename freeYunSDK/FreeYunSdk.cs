using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using freeYunSDK.Request;
using freeYunSDK.Response;

namespace freeYunSDK;

public class FreeYunSdk
{
    public Config Config { get; }

    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://bgp.freeyun.net"),
    };

    public FreeYunSdk(Config config)
    {
        Config = config;
    }

    /// <summary>
    /// 软件取初始化信息接口
    /// </summary>
    /// <param name="apiReq"></param>
    /// <returns></returns>
    public async Task<InitApiResp?> InitApp(InitApiReq apiReq)
    {
        var json = JsonSerializer.Serialize(apiReq);
        var postJson = await PostJson(json, apiReq.Type, apiReq.Timestamp);
        return postJson == null ? null : ConvertJson<InitApiResp>(postJson.Data);
    }
    
    /// <summary>
    /// 取在线数
    /// </summary>
    /// <param name="apiReq"></param>
    /// <returns></returns>
    public async Task<OnlineNumberResp?> GetOnlineNumber(GetOnlineApiReq apiReq)
    {
        var json = JsonSerializer.Serialize(apiReq);
        var postJson = await PostJson(json, apiReq.Type, apiReq.Timestamp);
        return postJson == null ? null : ConvertJson<OnlineNumberResp>(postJson.Data);
    }
    

    /// <summary>
    /// 账号注册接口
    /// </summary>
    /// <param name="apiReq"></param>
    /// <returns></returns>
    public async Task<BaseApiResp?> UserRegister(UserRegisterApiReq apiReq)
    {
        var json = JsonSerializer.Serialize(apiReq);
        var postJson = await PostJson(json, apiReq.Type, apiReq.Timestamp);
        return postJson == null ? null : ConvertJson<BaseApiResp>(postJson.Data);
    }


    private T? ConvertJson<T>(string json)
    {
        var desString = DeEncrypt(json, Config.EncryptKey);
        var initApiResp = JsonSerializer.Deserialize<T>(desString);
        return initApiResp;
    }

    private async Task<BaseDto?> PostJson(string requestData, string type, long timestamp)
    {
        var encryptKey = Config.EncryptKey;
        var salt = Config.Salt;
        var appid = Config.Appid;
        var wtype = type;
        var data = Encrypt(requestData, encryptKey);;
        
        var sign = CryptoUtil.Md5Encrypt32(wtype + timestamp + salt + appid + data);
        var formData = new Dictionary<string, string>
        {
            { "version", "1.1.3" },
            { "appid", appid },
            { "wtype", wtype },
            { "timestamp", timestamp.ToString() },
            { "data", data },
            { "sign", sign },
        };
        using var content = new FormUrlEncodedContent(formData);
        content.Headers.Clear();
        content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        content.Headers.Add("Version", "1.1.3");
        using var response = await HttpClient.PostAsync("webgateway.html", content);
        response.EnsureSuccessStatusCode();
        var readAsStringAsync = await response.Content.ReadAsStringAsync();
        Console.WriteLine(readAsStringAsync);
        var baseDto = await response.Content.ReadFromJsonAsync<BaseDto>();
        if (baseDto != null && baseDto.Status != 0)
        {
            throw new ApiErrorException(code: baseDto.Status, message: baseDto.Msg);
        }

        return baseDto;
    }

    private string Encrypt(string requestData, string encryptKey)
    {
        var data = "";
        switch (Config.Algo)
        {
            case AlgoEnum.Des:
                data = BitConverter.ToString(CryptoUtil.DesEncrypt(requestData, encryptKey)).Replace("-", "").ToLower();
                break;
            case AlgoEnum.Aes:
                data = BitConverter.ToString(CryptoUtil.AesEncrypt(requestData, encryptKey)).Replace("-", "").ToLower();
                break;
        }

        return data;
    }
    
    
    private string DeEncrypt(string requestData, string encryptKey)
    {

        byte[] desDecrypt = Array.Empty<byte>();
        
        var bytes = CryptoUtil.HexStringToByteArray(requestData);
        
        
        switch (Config.Algo)
        {
            case AlgoEnum.Des:
                desDecrypt =  CryptoUtil.DesDecrypt(bytes, Config.EncryptKey);;
                break;
            case AlgoEnum.Aes:
                desDecrypt =  CryptoUtil.AesDecrypt(bytes, Config.EncryptKey);;
                break;
        }
        var desString = Encoding.UTF8.GetString(desDecrypt);
        return desString;
    }
    
}