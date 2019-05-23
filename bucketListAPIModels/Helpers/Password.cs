using System;
using System.IO;
using System.Security.Cryptography;

namespace bucketListAPIModels.Helpers
{
    public class Password
    {
        public byte[] EncryptAesManaged(string raw)
        {
            byte[] encrypted;
            try
            {
                // Create Aes that generates a new key and initialization vector (IV).    

                encrypted = Encrypt(raw);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return encrypted;
        }

        public string DecryptAesManaged(byte[] raw)
        {
            string decrypted;
            try
            {
                // Create Aes that generates a new key and initialization vector (IV).    
                // Same key must be used in encryption and decryption    

                decrypted = Decrypt(raw);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return decrypted;
        }


        //Encrypt
        public byte[] Encrypt(string plainText)
        {
            byte[] encrypted = null;
            // Create a new AesManaged. 
            byte[] rawPlaintext = System.Text.Encoding.Unicode.GetBytes(plainText);
            using (AesManaged aes = new AesManaged())
            {
                // Create encryptor
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 128;          // in bits
                aes.Key = new byte[128 / 8];  // 16 bytes for 128 bit encryption
                aes.IV = new byte[128 / 8];
                //ICryptoTransform encryptor = aes.CreateEncryptor();
                // Create MemoryStream    
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        //using (StreamWriter sw = new StreamWriter(cs))
                        //    sw.Write(plainText);
                        //cs.FlushFinalBlock();
                        cs.Write(rawPlaintext, 0, rawPlaintext.Length);
                        cs.FlushFinalBlock();

                    }
                    encrypted = ms.ToArray();
                }
            }
            // Return encrypted data    
            return encrypted;
        }

        //Decrypt

        public string Decrypt(byte[] cipherText)
        {
            byte[] plaintext = null;
            string decrypted = string.Empty;
            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 128;          // in bits
                aes.Key = new byte[128 / 8];  // 16 bytes for 128 bit encryption
                aes.IV = new byte[128 / 8];
                // Create a decryptor 
                //aes.Padding = PaddingMode.None;
                //ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                // Create the streams used for decryption.    
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        // Read crypto stream    
                        //using (StreamReader reader = new StreamReader(cs))
                        //    plaintext = reader.ReadToEnd();
                        //cs.FlushFinalBlock();
                        cs.Write(cipherText, 0, cipherText.Length);
                        cs.FlushFinalBlock();
                    }

                    plaintext = ms.ToArray();
                }

                decrypted = System.Text.Encoding.Unicode.GetString(plaintext);
            }
            return decrypted;
        }
    }
}
