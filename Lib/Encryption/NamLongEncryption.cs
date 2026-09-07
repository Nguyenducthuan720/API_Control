using System.Security.Cryptography;
using System.Text;

namespace APISmartCity
{
    public static class NamLongEncryption
    {
        private const string Encryptionkey = "NamLong2019@@@@@@@@@@";

        public static string EncryptData(this string textData)
        {
            Aes objrij = Aes.Create();
            objrij.Mode = CipherMode.CBC;
            objrij.Padding = PaddingMode.PKCS7;
            objrij.KeySize = 0x80;
            objrij.BlockSize = 0x80;

            byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
            byte[] EncryptionkeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);
            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;
            byte[] textDataByte = Encoding.UTF8.GetBytes(textData);
            return Convert.ToBase64String(objrij.CreateEncryptor().TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }

        public static string DecryptData(this string EncryptedText)
        {
            Aes objrij = Aes.Create();
            objrij.Mode = CipherMode.CBC;
            objrij.Padding = PaddingMode.PKCS7;
            objrij.KeySize = 0x80;
            objrij.BlockSize = 0x80;

            byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
            byte[] EncryptionkeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);
            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;
            byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);
            byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
            return Encoding.UTF8.GetString(TextByte);
        }

        public static string MD5Hash(this string input)
        {
            StringBuilder hash = new();
            MD5 md5provider = MD5.Create();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}