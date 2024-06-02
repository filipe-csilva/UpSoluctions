using System.Security.Cryptography;

namespace UpSoluctions.Services
{
    public class AesEncryptService
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public AesEncryptService(byte[] key)
        {
            _key = key;

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                _iv = new byte[16];
                rng.GetBytes(_iv);
            }
        }

        public string Encrypt(string senha)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(_iv, 0, _iv.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(senha);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Decrypt(string senha)
        {
            byte[] fullCipher = Convert.FromBase64String(senha);

            using (Aes aesAlg = Aes.Create())
            {
                using (MemoryStream msDecrypt = new MemoryStream(fullCipher))
                {
                    byte[] iv = new byte[16];
                    msDecrypt.Read(iv, 0, iv.Length);

                    aesAlg.Key = _key;
                    aesAlg.IV = iv;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
