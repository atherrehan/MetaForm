using System.Security.Cryptography;
using System.Text;

namespace DynamicFlow.Models.Generic
{
    public class Security
    {
        private static readonly Aes encdec;
        public static readonly byte[] IV;
        public static readonly byte[] Key;
        static Security()
        {
            IV = Encoding.UTF8.GetBytes("@!8&8*5-1#O65x&@");
            Key = Encoding.UTF8.GetBytes("1Z_59W2+)!m7Ro-!&@U@X^%_K6LbqJ@!");
            encdec = Aes.Create();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            encdec.IV = IV;
            encdec.Key = Key;
            encdec.Padding = PaddingMode.PKCS7;
            encdec.Mode = CipherMode.CBC;
        }
        public static string EncryptAES(string plainText)
        {
            try
            {
                if (string.IsNullOrEmpty(plainText))
                    return "";

                byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                using (ICryptoTransform crypto = encdec.CreateEncryptor(encdec.Key, encdec.IV))
                {
                    byte[] enc = crypto.TransformFinalBlock(bytes, 0, bytes.Length);
                    return Convert.ToBase64String(enc);
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string DecryptAES(string encText)
        {
            try
            {
                if (string.IsNullOrEmpty(encText))
                    return "";

                byte[] bytes = Convert.FromBase64String(encText);
                using (ICryptoTransform crypto = encdec.CreateDecryptor(encdec.Key, encdec.IV))
                {
                    byte[] dec = crypto.TransformFinalBlock(bytes, 0, bytes.Length);
                    return Encoding.UTF8.GetString(dec);
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
