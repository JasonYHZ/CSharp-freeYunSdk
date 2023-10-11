namespace freeYunSDK;

public enum AlgoEnum
{
    Des,
    Aes
}
public class Config
{
    public Config(string encryptKey, string salt, string appid, string version, string secretKey, AlgoEnum algo)
    {
        EncryptKey = encryptKey;
        Salt = salt;
        Appid = appid;
        Version = version;
        SecretKey = secretKey;
        Algo = algo;
    }

    public AlgoEnum Algo { get; set; }

    public string EncryptKey { get; set; }
    public string Salt { get; set; }
    public string Appid { get; set; }
    public string Version { get; set; }
    public string SecretKey { get; set; }
}