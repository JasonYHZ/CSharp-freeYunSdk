using System.Text;
using freeYunSDK;
using freeYunSDK.Request;

namespace FreeYunTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestSdkNew()
    {
        var config = new Config(encryptKey: "zLIM3cUB", salt: "bz3cxNPXw7", appid: "24254", version: "1.0",
            secretKey: "AF9E3182D09F566CE454F46763903D73",algo: AlgoEnum.Des);
        var sdk = new FreeYunSdk(config);
        Assert.AreEqual(sdk.Config.SecretKey, config.SecretKey);
    }

    [TestMethod]
    public void TestDesEncrypt()
    {
        const string plantText = "Hello,World!";
        const string key = "12345678";

        var desEncrypt = CryptoUtil.DesEncrypt(plantText, key);
        var desDecrypt = CryptoUtil.DesDecrypt(desEncrypt, key);
        var decryStr = Encoding.UTF8.GetString(desDecrypt);
        Assert.AreEqual(plantText, decryStr);
    }

    [TestMethod]
    public void TestAesEncrypt()
    {
        const string plantText = "Hello,World!";
        const string key = "1234567812345678";

        var desEncrypt = CryptoUtil.AesEncrypt(plantText, key);
        var desDecrypt = CryptoUtil.AesDecrypt(desEncrypt, key);
        var decryStr = Encoding.UTF8.GetString(desDecrypt);
        Assert.AreEqual(plantText, decryStr);
    }
}