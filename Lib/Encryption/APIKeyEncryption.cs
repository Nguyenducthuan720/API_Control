using System.Security.Cryptography;
using System.Text;

namespace APISmartCity
{
    public static class APIKeyEncryption
    {
        private const string Encryptionkey = "NLT2024DEV@)@$)#";

        public static string APIKEYEncryptData(this string textData)
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

        public static string APIKEYDecryptData(this string EncryptedText)
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

        private const string EncryptionkeyKey = "NLT2024PASS@)@$#";

        public static string APIKEYEncryptDataKey(this string textData)
        {
            Aes objrij = Aes.Create();
            objrij.Mode = CipherMode.CBC;
            objrij.Padding = PaddingMode.PKCS7;
            objrij.KeySize = 0x80;
            objrij.BlockSize = 0x80;

            byte[] passBytes = Encoding.UTF8.GetBytes(EncryptionkeyKey);
            byte[] EncryptionkeyKeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionkeyKeyBytes.Length)
            {
                len = EncryptionkeyKeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyKeyBytes, len);
            objrij.Key = EncryptionkeyKeyBytes;
            objrij.IV = EncryptionkeyKeyBytes;
            byte[] textDataByte = Encoding.UTF8.GetBytes(textData);
            return Convert.ToBase64String(objrij.CreateEncryptor().TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }  

        public static string APIKEYDecryptDataKey(this string EncryptedText)
        {
            Aes objrij = Aes.Create();
            objrij.Mode = CipherMode.CBC;
            objrij.Padding = PaddingMode.PKCS7;
            objrij.KeySize = 0x80;
            objrij.BlockSize = 0x80;

            byte[] passBytes = Encoding.UTF8.GetBytes(EncryptionkeyKey);
            byte[] EncryptionkeyKeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionkeyKeyBytes.Length)
            {
                len = EncryptionkeyKeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyKeyBytes, len);
            objrij.Key = EncryptionkeyKeyBytes;
            objrij.IV = EncryptionkeyKeyBytes;
            byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);
            byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
            return Encoding.UTF8.GetString(TextByte);
        }
    }
}