using System.Security.Cryptography;
using System.Text;

namespace freeYunSDK;

public class CryptoUtil
{
    public static byte[] DesEncrypt(string text, string inputKey)
    {
        var textBytes = Encoding.UTF8.GetBytes(text);
        using var des = DES.Create();
        des.Key = Encoding.UTF8.GetBytes(inputKey);
        des.Mode = CipherMode.ECB;
        des.Padding = PaddingMode.PKCS7;
        using var encryptor = des.CreateEncryptor();
        return encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);
    }


    public static byte[] DesDecrypt(byte[] inputEncryptedBytes, string inputKey)
    {
        using var des = DES.Create();
        des.Key = Encoding.UTF8.GetBytes(inputKey);
        des.Mode = CipherMode.ECB;
        des.Padding = PaddingMode.PKCS7;
        using var decrypted = des.CreateDecryptor();
        return decrypted.TransformFinalBlock(inputEncryptedBytes, 0, inputEncryptedBytes.Length);
    }


    public static byte[] AesEncrypt(string text, string inputKey)
    {
        var textBytes = Encoding.UTF8.GetBytes(text);
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(inputKey);
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;
        using var encryptor = aes.CreateEncryptor();
        return encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);
    }


    public static byte[] AesDecrypt(byte[] inputEncryptedBytes, string inputKey)
    {
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(inputKey);
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;
        using var decrypted = aes.CreateDecryptor();
        return decrypted.TransformFinalBlock(inputEncryptedBytes, 0, inputEncryptedBytes.Length);
    }


    public static string Md5Encrypt32(string source)
    {
        var computeHash = MD5.HashData(Encoding.UTF8.GetBytes(source));
        return computeHash.Aggregate("", (current, b) => current + b.ToString("x"));
    }

    public static byte[] HexStringToByteArray(string hexString)
    {
        int length = hexString.Length;
        byte[] byteArray = new byte[length / 2];
        for (int i = 0; i < length; i += 2)
        {
            byteArray[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
        }

        return byteArray;
    }
}