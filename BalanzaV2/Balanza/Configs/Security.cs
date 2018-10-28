using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Balanza.Configs
{
    class Security
    {

        private const string initVector = "A1b2C3d4E5f6G7h8";
        public const string passPhrase = "AMQ-KEYGEN-SGV-01";
        private const int keysize = 256;
        private String lastError = "";

        public String showLastError()
        {
            return lastError;
        }


        public bool SimpleEncrypt(string plainText, ref string value)
        {
            bool resultado = false;
            try
            {
                byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                value = Convert.ToBase64String(cipherTextBytes);
                resultado = true;
            }
            catch (Exception e)
            {
                lastError = e.Message;
                value = String.Empty;
            }
            return resultado;
        }

        public bool SimpleDecrypt(string cipherText, ref string value)
        {
            bool resultado = false;
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                value = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                resultado = true;
            }
            catch (Exception e)
            {
                lastError = e.Message;
                value = String.Empty;
            }
            return resultado;
        }

        public bool ComplexEncrypt(string toEncrypt, string key, bool useHashing, ref string value)
        {
            bool resultado = false;
            try
            {

                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                //If hashing use get hashcode regards to your key
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes.
                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)

                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                //transform the specified region of bytes array to resultArray
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                //Return the encrypted data into unreadable string format
                value = Convert.ToBase64String(resultArray, 0, resultArray.Length);
                resultado = true;
            }
            catch (Exception e)
            {
                lastError = e.Message;
                value = String.Empty;
            }
            return resultado;
        }

        public bool ComplexDecrypt(string cipherString, string key, bool useHashing, ref string value)
        {
            bool resultado = false;
            try
            {

                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                if (useHashing)
                {
                    //if hashing was used get the hash code with regards to your key
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                {
                    //if hashing was not implemented get the byte code of the key
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);
                }

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes. 
                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor                
                tdes.Clear();
                value = UTF8Encoding.UTF8.GetString(resultArray);
                resultado = true;
            }
            catch (Exception e)
            {
                lastError = e.Message;
                value = String.Empty;
            }
            return resultado;
        }

        public bool sha1Encrypt(string data, ref string value)
        {
            bool resultado = false;
            try
            {

                SHA1 sha1 = SHA1Managed.Create();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha1.ComputeHash(Encoding.UTF8.GetBytes(data));

                for (int i = 0; i < stream.Length; i++)
                {
                    sb.AppendFormat("{0:x2}", stream[i]);
                }
                resultado = true;
                value = sb.ToString();
            }
            catch (Exception e)
            {
                lastError = e.Message;
                value = String.Empty;
            }
            return resultado;
        }

        public bool sha2Encrypt(string data, ref string value)
        {
            bool resultado = false;
            try
            {
                SHA512 sha2 = SHA512Managed.Create();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha2.ComputeHash(Encoding.UTF8.GetBytes(data));

                for (int i = 0; i < stream.Length; i++)
                {
                    sb.AppendFormat("{0:x2}", stream[i]);
                }

                value = sb.ToString();
                resultado = true;
            }
            catch (Exception e)
            {
                lastError = e.Message;
                value = String.Empty;
            }
            return resultado;
        }
    }
}
