using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace freeYunSDK.Request;

[DataContract]
public class UserRegisterApiReq : BaseApiReq
{
    public UserRegisterApiReq()
    {
    }

    public UserRegisterApiReq(string account, string password, string macCode, long timestamp, string secretKey,
        string qq, string email, string mobile, string invitingCode, string agentCode)
    {
        Account = account;
        Password = password;
        MacCode = macCode;
        Timestamp = timestamp;
        SecretKey = secretKey;
        Qq = qq;
        Email = email;
        Mobile = mobile;
        InvitingCode = invitingCode;
        AgentCode = agentCode;
    }

    [JsonIgnore] public string Type => "2";

    /// <summary>
    /// 用户的账号长度小于等于30，必传
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; }

    /// <summary>
    /// 用户密码长度小于等于20，必传
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; }

    /// <summary>
    /// QQ号码，可空
    /// </summary>
    [JsonPropertyName("qq")]
    public string Qq { get; set; }

    /// <summary>
    /// 邮箱，可空
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// 手机号，可空
    /// </summary>
    [JsonPropertyName("mobile")]
    public string Mobile { get; set; }

    /// <summary>
    /// 邀请码，可空
    /// </summary>
    [JsonPropertyName("invitingCode")]
    public string InvitingCode { get; set; }

    /// <summary>
    /// 代理商编号，可空
    /// </summary>
    [JsonPropertyName("agentCode")]
    public string AgentCode { get; set; }
}